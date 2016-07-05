using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiDictionary
{
    public class BiDictionary<TKey1, TKey2, TValue>
    {
        private Dictionary<TKey1, HashSet<TValue>> valuesByFirstKey;
        private Dictionary<TKey2, HashSet<TValue>> valuesBySecondKey;
        private Dictionary<Tuple<TKey1, TKey2>, HashSet<TValue>> valuesByBothKeys;

        public BiDictionary()
        {
            valuesByFirstKey = new Dictionary<TKey1, HashSet<TValue>>();
            valuesBySecondKey = new Dictionary<TKey2, HashSet<TValue>>();
            valuesByBothKeys = new Dictionary<Tuple<TKey1, TKey2>, HashSet<TValue>>();
        }

        public void Add(TKey1 key1, TKey2 key2, TValue value)
        {
            valuesByFirstKey.AppendValueToKey(key1, value);
            valuesBySecondKey.AppendValueToKey(key2, value);
            var combinedKeys = this.GetCombinedKeys(key1, key2);
            valuesByBothKeys.AppendValueToKey(combinedKeys, value);
        }

        public IEnumerable<TValue> Find(TKey1 key1, TKey2 key2)
        {
            var combinedKeys = this.GetCombinedKeys(key1, key2);
            var values = valuesByBothKeys.GetValuesForKey(combinedKeys);
            return values;
        }

        public IEnumerable<TValue> FindByKey1(TKey1 key1)
        {
            var values = valuesByFirstKey.GetValuesForKey(key1);
            return values;
        }

        public IEnumerable<TValue> FindByKey2(TKey2 key2)
        {
            var values = valuesBySecondKey.GetValuesForKey(key2);
            return values;
        }

        public bool Remove(TKey1 key1, TKey2 key2)
        {
            var combinedKeys = this.GetCombinedKeys(key1, key2);
            HashSet<TValue> valuesByKeys;
            if(!valuesByBothKeys.TryGetValue(combinedKeys, out valuesByKeys))
            {
                return false;
            }

            var setFromKey1 = valuesByFirstKey[key1];
            var settFromKey2 = valuesBySecondKey[key2];
            foreach (var item in valuesByKeys)
            {
                setFromKey1.Remove(item);
                settFromKey2.Remove(item);
            }
            valuesByBothKeys.Remove(combinedKeys);
            return true;
        }

        private Tuple<TKey1, TKey2> GetCombinedKeys(TKey1 key1, TKey2 key2)
        {
            var combinedKeys = new Tuple<TKey1, TKey2>(key1, key2);
            return combinedKeys;
        }
    }
}

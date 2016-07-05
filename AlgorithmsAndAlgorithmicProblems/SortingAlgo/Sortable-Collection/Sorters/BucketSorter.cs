namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Sortable_Collection.Contracts;

    public class BucketSorter : ISorter<int>
    {
        public int Max { get; set; }
        public void Sort(List<int> collection)
        {
            var buckets = new List<int>[collection.Count];

            foreach (var element in collection)
            {
                int bucketIndex = (int)((float)element / this.Max * collection.Count);

                if (buckets[bucketIndex] == null)
                {
                    buckets[bucketIndex] = new List<int>();
                }

                buckets[bucketIndex].Add(element);
            }

            for (int i = 0; i < buckets.Length; i++)
            {
                var sorter = new Quicksorter<int>();

                if (buckets[i] != null)
                {
                    sorter.Sort(buckets[i]);
                }
            }

            int index = -1;
            foreach (var bucket in buckets)
            {
                if (bucket != null)
                {
                    foreach (var item in bucket)
                    {
                        collection[++index] = item;
                    }
                }
            }
        }
    }
}

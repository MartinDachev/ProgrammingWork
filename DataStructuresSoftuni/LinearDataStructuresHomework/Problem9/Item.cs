using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem9
{
    public class Item<T>
    {
        public T Value { get; private set; }

        public Item<T> RefItem { get; set; }

        public Item(T value, Item<T> refItem)
        {
            this.Value = value;
            this.RefItem = refItem;
        }
    }
}

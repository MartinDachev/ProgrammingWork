namespace Sortable_Collection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Sortable_Collection.Contracts;

    public class SortableCollection<T> where T : IComparable<T>
    {
        public SortableCollection()
        {
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.Items = new List<T>(items);
        }

        public SortableCollection(params T[] items)
            : this(items.AsEnumerable())
        {
        }

        public List<T> Items { get; } = new List<T>();

        public int Count => this.Items.Count;

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.Items);
        }

        public int BinarySearch(T item)
        {
            // TODO
            return 0;
        }

        public int InterpolationSearch(T item)
        {
        //    int low = 0;
        //    int high = this.Items.Count - 1;
        //    int mid;

        //    while (this.Items[high].CompareTo(this.Items[low]) != 0 && item.CompareTo(this.Items[low]) >= 0 && item.CompareTo(this.Items[high]) <= 0)
        //    {
        //        mid = 
        //    }
        return 0;
        }

        public void Shuffle()
        {
            throw new NotImplementedException();
        }

        public T[] ToArray()
        {
            return this.Items.ToArray();
        }

        public override string ToString()
        {
            return $"[{string.Join(", ", this.Items)}]";
        }        
    }
}
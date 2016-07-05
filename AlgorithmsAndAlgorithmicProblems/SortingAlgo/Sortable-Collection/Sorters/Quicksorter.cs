namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Sortable_Collection.Contracts;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        private void Quicksort(List<T> array, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            T pivot = array[start];
            int storeIndex = start + 1;

            for (int i = start + 1; i <= end; ++i)
            {
                if (array[i].CompareTo(pivot) < 0)
                {
                    Swap(array, i, storeIndex);
                    ++storeIndex;
                }
            }

            --storeIndex;
            Swap(array, start, storeIndex);
            Quicksort(array, start, storeIndex - 1);
            Quicksort(array, storeIndex + 1, end);
        }

        public void Sort(List<T> collection)
        {
            this.Quicksort(collection, 0, collection.Count - 1);
        }       

        public void Swap(List<T> array, int i, int j)
        {
            T temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}

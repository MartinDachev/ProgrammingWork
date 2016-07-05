namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Sortable_Collection.Contracts;

    public class InsertionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            T temp;
            int targetIndex;
            int extractedIndex;
            for (int i = 1; i < collection.Count; ++i)
            {
                targetIndex = i - 1;
                extractedIndex = i;
                while (targetIndex >= 0 && collection[targetIndex].CompareTo(collection[extractedIndex]) > 0)
                {
                    temp = collection[targetIndex];
                    collection[targetIndex] = collection[extractedIndex];
                    collection[extractedIndex] = temp;
                    --targetIndex;
                    --extractedIndex;
                }
            }
        }
    }
}

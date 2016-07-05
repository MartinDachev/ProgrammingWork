namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Sortable_Collection.Contracts;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            T[] tArray = new T[collection.Count];
            MergeSort(collection, tArray, 0, collection.Count - 1);
        }

        private void MergeSort(List<T> array, T[] temporaryArray, int start, int end)
        {
            if (start < end)
            {
                int middle = (start + end) / 2;
                MergeSort(array, temporaryArray, start, middle);
                MergeSort(array, temporaryArray, middle + 1, end);
                MergeHalves(array, temporaryArray, start, middle, end);
                CopyArray(array, temporaryArray, start, end);
            }
        }

        private void MergeHalves(List<T> array, T[] temporaryArray, int start, int middle, int end)
        {
            int leftHalfMinIndex = start;
            int rightHalfIndex = middle + 1;
            int count = end - start;
            int i = start;

            for (; leftHalfMinIndex <= middle && rightHalfIndex <= end; ++i)
            {
                if (array[leftHalfMinIndex].CompareTo(array[rightHalfIndex]) < 0)
                {
                    temporaryArray[i] = array[leftHalfMinIndex];
                    ++leftHalfMinIndex;
                }
                else
                {
                    temporaryArray[i] = array[rightHalfIndex];
                    ++rightHalfIndex;
                }
            }

            while (leftHalfMinIndex <= middle)
            {
                temporaryArray[i] = array[leftHalfMinIndex];
                ++leftHalfMinIndex;
                ++i;
            }

            while (rightHalfIndex <= end)
            {
                temporaryArray[i] = array[rightHalfIndex];
                ++rightHalfIndex;
                ++i;
            }
        }

        private void CopyArray(List<T> array, T[] temporaryArray, int start, int end)
        {
            for (int i = start; i <= end; ++i)
            {
                array[i] = temporaryArray[i];
            }
        }
    }
}

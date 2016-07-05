using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem3
{
    public class ArrayBasedStack<T>
    {
        T[] initialArr;
        private const int InitialCapacity = 16;

        public int Count { get; private set; }

        public int Capacity { get { return this.initialArr.Length; } }

        public ArrayBasedStack(int capacity = InitialCapacity)
        {
            this.initialArr = new T[capacity];
        }

        private void CopyAllElementsTo(T[] arr)
        {
            for (int i = 0; i < this.Count; i++)
            {
                arr[i] = this.initialArr[i];
            }
        }

        private void Grow()
        {
            T[] newInitialArr = new T[2 * this.initialArr.Length];
            this.CopyAllElementsTo(newInitialArr);
            this.initialArr = newInitialArr;
        }

        public void Push(T value)
        {
            if (this.Count == this.initialArr.Length)
            {
                this.Grow();
            }

            this.initialArr[this.Count] = value;
            ++this.Count;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }

            --this.Count;
            return this.initialArr[this.Count];
        }

        public T[] ToArray()
        {
            T[] resultArr = new T[this.Count];

            for (int i = 0; i < this.Count; ++i)
            {
                resultArr[this.Count - 1 - i] = this.initialArr[i];
            }

            return resultArr;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace Problem6
{
    public class ReversedList<T> : IEnumerable<T>
    {
        T[] initialArr;
        
        public int Count { get;  private set; }
        
        public int Capacity { get { return initialArr.Length; } }

        public ReversedList()
        {
            initialArr = new T[4];
            this.Count = 0;
        }

        public T this[int index]
        {
            get 
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException("Index is out of range");
                }

                return initialArr[this.Capacity - this.Count + index];
            }
            set 
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException("Index is out of range");
                }

                initialArr[this.Capacity - this.Count + index] = value;
            }
        }

        public void Add(T value)
        {
            if (this.Count == this.initialArr.Length)
            {
                T[] newArr = new T[this.initialArr.Length * 2];
                for (int i = 0; i < this.initialArr.Length; ++i)
                {
                    newArr[newArr.Length - this.initialArr.Length + i] = this.initialArr[i];
                }
                this.initialArr = newArr;
            }
            this.initialArr[this.initialArr.Length - this.Count - 1] = value;
            ++this.Count;
        }

        public void Remove(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException("Index is out of range");
            }

            for (int i = this.initialArr.Length - this.Count + index; i > this.initialArr.Length - this.Count; --i)
            {
                this.initialArr[i] = this.initialArr[i - 1];
            }

            this.Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.initialArr.Length - this.Count; i < this.initialArr.Length; i++)
            {
                yield return this.initialArr[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}

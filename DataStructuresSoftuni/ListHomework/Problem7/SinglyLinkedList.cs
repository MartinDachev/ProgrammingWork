using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace Problem7
{
    class SinglyLinkedList<T> : IEnumerable<T>
    {
        class ListNode<T>
        {
            public T Value { get; set; }

            public ListNode<T> NextNode { get; set; }

            public ListNode(T value)
            {
                this.Value = value;
            }
        }

        private ListNode<T> head;
        private ListNode<T> tail;

        public int Count { get; private set; }

        public void Add(T value)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new ListNode<T>(value);
            }
            else
            {
                this.tail.NextNode = new ListNode<T>(value);
                this.tail = this.tail.NextNode;
            }
            ++this.Count;
        }

        public void ForEach(Action<T> action)
        {
            var currentNode = this.head;
            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.NextNode;
            }
        }

        public void Remove(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException("Index out of range");
            }

            if (index == 0)
            {
                this.head = this.head.NextNode;
                return;
            }

            ListNode<T> currentNode = this.head;
            ListNode<T> prevNode = this.head;

            for (int i = 0; currentNode != null; ++i)
            {
                if (i == index)
                {
                    prevNode.NextNode = currentNode.NextNode;
                    currentNode = null;
                    
                    if (index == this.Count - 1)
                    {
                        this.tail = prevNode;
                    }

                    break;
                }

                prevNode = currentNode;
                currentNode = currentNode.NextNode;
            }
        }

        public int FirstIndexOf(T value)
        {
            ListNode<T> currentNode = this.head;
            int index = 0;
            while (currentNode != null)
            {
                if (currentNode.Value.Equals(value))
                {
                    return index;
                }
                currentNode = currentNode.NextNode;
                ++index;
            }

            return -1;
        }

        public int LastIndexOf(T value)
        {
            ListNode<T> currentNode = this.head;
            int index = 0, lastIndex = -1;
            while (currentNode != null)
            {
                if (currentNode.Value.Equals(value))
                {
                    lastIndex = index;
                }
                currentNode = currentNode.NextNode;
                ++index;
            }

            return lastIndex;
        }

        public IEnumerator<T> GetEnumerator()
        {
            ListNode<T> currentNode = this.head;

            while (currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.NextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}

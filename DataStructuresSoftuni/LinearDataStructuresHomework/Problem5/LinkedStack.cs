using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem5
{
    public class LinkedStack<T>
    {
        private class Node<T>
        {
            public T Value { get; set; }
            public Node<T> NextNode { get; set; }
            public Node(T value, Node<T> nextNode = null)
            {
                this.Value = value;
                this.NextNode = nextNode;
            }
        }

        private Node<T> firstNode;

        public int Count { get; private set; }

        public LinkedStack()
        {
            this.Count = 0;
        }

        public void Push(T element)
        {
            this.firstNode = new Node<T>(element, this.firstNode);
            ++this.Count;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }

            T result = this.firstNode.Value;
            this.firstNode = this.firstNode.NextNode;
            --this.Count;
            return result;
        }

        public T[] ToArray()
        {
            T[] array = new T[this.Count];
            Node<T> currentNode = firstNode;

            for (int i = 0; currentNode != null && i < this.Count; ++i)
            {
                array[i] = currentNode.Value;
                currentNode = currentNode.NextNode;
            }

            return array;
        }
    }
}

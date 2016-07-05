using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem7
{
    public class LinkedQueue<T>
    {
        private class QueueNode<T>
        {
            public T Value { get; private set; }
            
            public QueueNode<T> NextNode { get; set; }
            
            public QueueNode<T> PrevNode { get; set; }

            public QueueNode(T value)
            {
                this.Value = value;
            }
        }

        private QueueNode<T> head;
        private QueueNode<T> tail;

        public int Count { get; private set; }
        
        public void Enqueue(T element)
        {
            if (this.Count == 0)
            {
                this.tail = this.head = new QueueNode<T>(element);
            }
            else
            {
                this.tail.NextNode = new QueueNode<T>(element);
                this.tail.NextNode.PrevNode = this.tail;
                this.tail = this.tail.NextNode;
            }
            ++this.Count;
        }
        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            T result = this.head.Value;
            this.head = this.head.NextNode;

            if (this.head != null)
            {
                this.head.PrevNode = null;
            }
            else
            {
                this.tail = null;
            }
            --this.Count;
            
            return result;
        }
        public T[] ToArray()
        {
            T[] array = new T[this.Count];
            QueueNode<T> currentNode = this.head;
            int i = 0;

            while(currentNode != null)
            {
                array[i] = currentNode.Value;
                currentNode = currentNode.NextNode;
                ++i;
            }
            return array;
        }

        

    }
}

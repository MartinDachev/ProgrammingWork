using System;

namespace PriorityQueue
{
    public class PriorityQueue<TPriority, TValue> where TPriority : IComparable<TPriority>
    {
        private BinaryHeap<KeyValue<TPriority, TValue>> heap;

        public int Count
        {
            get
            {
                return this.heap.Count;
            }
        }

        public PriorityQueue()
        {
            this.heap = new BinaryHeap<KeyValue<TPriority, TValue>>();
        }

        public void Enqueue(TPriority priority, TValue value)
        {
            this.heap.Insert(new KeyValue<TPriority, TValue>(priority, value));
        }

        public TValue DequeueValue()
        {
            return this.Dequeue().Value;
        }

        public KeyValue<TPriority, TValue> Dequeue()
        {
            return this.heap.ExtractMax();
        }

        public TValue PeekValue()
        {
            return this.Peek().Value;
        }

        public KeyValue<TPriority, TValue> Peek()
        {
            return this.heap.PeekMax();
        }
    }
}

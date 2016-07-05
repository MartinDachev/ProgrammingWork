using System;

namespace PriorityQueue
{
    class PriorityQueueExample
    {
        static void Main(string[] args)
        {
            PriorityQueue<int, string> priorityQueue = new PriorityQueue<int, string>();
            priorityQueue.Enqueue(10, "TEN");
            priorityQueue.Enqueue(4, "FOUR");
            priorityQueue.Enqueue(20, "TWENTY");
            priorityQueue.Enqueue(100, "HUNDRED");
            priorityQueue.Enqueue(35, "THIRTY-FIVE");
            priorityQueue.Enqueue(12, "TWELVE");

            while (priorityQueue.Count > 0)
            {
                Console.WriteLine(priorityQueue.Dequeue());
            }
        }
    }
}

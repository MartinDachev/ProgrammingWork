using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Problem7;

namespace Problem9
{
    class Program
    {
        static void PrintSolution(Item<int> item)
        {
            if (item.RefItem != null)
            {
                PrintSolution(item.RefItem);
                Console.Write(" -> ");
            }

            Console.Write(item.Value);
        }

        static void Main(string[] args)
        {
            Queue<Item<int>> queue = new Queue<Item<int>>();
            Console.Write("Vuvedete n = ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Vuvedete m = ");
            int m = int.Parse(Console.ReadLine());

            queue.Enqueue(new Item<int>(n, null));
            while (queue.Count > 0)
            {
                Item<int> item = queue.Dequeue();

                if (item.Value == m)
                {
                    PrintSolution(item);
                    Console.WriteLine();
                    break;
                }

                if (item.Value < m)
                {
                    queue.Enqueue(new Item<int>(item.Value * 2, item));
                    queue.Enqueue(new Item<int>(item.Value + 2, item));
                    queue.Enqueue(new Item<int>(item.Value + 1, item));
                } 
            }
        }
    }
}

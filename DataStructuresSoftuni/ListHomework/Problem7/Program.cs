using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem7
{
    class Program
    {
        static void Main(string[] args)
        {
            SinglyLinkedList<int> sll = new SinglyLinkedList<int>();
            
            sll.Add(1);
            sll.Add(2);
            sll.Add(3);
            sll.Add(4);
            sll.Add(4);
            sll.Add(4);
            sll.Remove(2);
            

            sll.ForEach(Console.WriteLine);
            
            Console.WriteLine(sll.FirstIndexOf(3));
            Console.WriteLine(sll.LastIndexOf(3));
            Console.WriteLine(sll.FirstIndexOf(4));
            Console.WriteLine(sll.LastIndexOf(4));
            Console.WriteLine((sll.LastIndexOf(1)));
            
            foreach (int number in sll)
            {
                Console.WriteLine(number);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinearDataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>(Array.ConvertAll(Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries), int.Parse));
            while (stack.Count > 0)
            {
                Console.Write("{0} ", stack.Pop());
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem6
{
    class Program
    {
        static void Main(string[] args)
        {
            ReversedList<int> reversedList = new ReversedList<int>();
            reversedList.Add(1);
            Console.WriteLine("reversedList: Count = {0}, Capacity = {1}", reversedList.Count, reversedList.Capacity);
            reversedList.Add(2);
            Console.WriteLine("reversedList: Count = {0}, Capacity = {1}", reversedList.Count, reversedList.Capacity);
            reversedList.Add(3);
            Console.WriteLine("reversedList: Count = {0}, Capacity = {1}", reversedList.Count, reversedList.Capacity);
            reversedList.Add(4);
            Console.WriteLine("reversedList: Count = {0}, Capacity = {1}", reversedList.Count, reversedList.Capacity);
            reversedList.Add(5);
            Console.WriteLine("reversedList: Count = {0}, Capacity = {1}", reversedList.Count, reversedList.Capacity);
            reversedList.Add(6);
            Console.WriteLine("reversedList: Count = {0}, Capacity = {1}", reversedList.Count, reversedList.Capacity);
            
            foreach (int number in reversedList)
            {
                Console.WriteLine(number);
            }

            reversedList.Remove(4);
            
            Console.WriteLine("reversedList: Count = {0}, Capacity = {1}", reversedList.Count, reversedList.Capacity);

            foreach (int number in reversedList)
            {
                Console.WriteLine(number);
            }
        }
    }
}

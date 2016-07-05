using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<int> numbers = new List<int>(Array.ConvertAll((input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)), int.Parse));
            double sum = 0, average = 0;

            foreach (int number in numbers)
            {
                sum += number;
            }

            if(numbers.Count > 0)
            {
                average = sum / numbers.Count;
            }

            Console.WriteLine("Sum={0}; Average={1}", sum, average);
        }
    }
}

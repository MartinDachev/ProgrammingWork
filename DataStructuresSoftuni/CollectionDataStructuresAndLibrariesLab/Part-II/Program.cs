using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace Part_II
{
    class Program
    {
        static void Main(string[] args)
        {
            BigList<char> rope = new BigList<char>();
            int operationsCount = 0;
             
            while (true)
            {
                var input = Console.ReadLine();
                operationsCount++;
                //Console.WriteLine(operationsCount);

                if (input == "PRINT")
                {
                    //var stringBuilder = new StringBuilder(rope.Count);
                    //foreach (var item in rope)
                    //{
                    //    //stringBuilder.Append(item);
                    //}
                    //Console.WriteLine(stringBuilder.ToString());
                }
                else
                {
                    var intervalIndex = input.IndexOf(' ');
                    var command = input.Substring(0, intervalIndex);
                    var arguments = input.Substring(intervalIndex + 1);

                    switch (command)
                    {
                        case "INSERT":
                            {
                                rope.InsertRange(0, arguments);
                                //Console.WriteLine("OK");
                            }
                            break;
                        case "APPEND":
                            {
                                rope.InsertRange(rope.Count, arguments);
                                //Console.WriteLine("OK");
                            }
                            break;
                        case "DELETE":
                            {
                                var indexOfSeparator = arguments.IndexOf(' ');
                                var startIndex = int.Parse(arguments.Substring(0, indexOfSeparator));
                                var count = int.Parse(arguments.Substring(indexOfSeparator + 1));

                                if (startIndex >= 0 && startIndex < rope.Count && count >= 0)
                                {
                                    rope.RemoveRange(startIndex, count);
                                    //Console.WriteLine("OK");
                                }
                                else
                                {
                                    //Console.WriteLine("ERROR");
                                }
                            }
                            break;
                        default:
                            //Console.WriteLine("ERROR");
                            break;
                    }
                }
            }
        }
    }
}

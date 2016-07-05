using System;
using System.Text;
using Wintellect.PowerCollections;

namespace Part_II
{
    class StringEditor
    {
        static void Main(string[] args)
        {
            BigList<char> rope = new BigList<char>();
             
            while (true)
            {
                var input = Console.ReadLine();

                if (input == "PRINT")
                {
                    var stringBuilder = new StringBuilder(rope.Count);
                    foreach (var item in rope)
                    {
                        stringBuilder.Append(item);
                    }
                    Console.WriteLine(stringBuilder.ToString());
                }
                else if (input == "END")
                {
                    break;
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
                                var argumentSeparatorIndex = arguments.IndexOf(' ');
                                var stringToInsert = arguments.Substring(0, argumentSeparatorIndex);
                                var position = int.Parse(arguments.Substring(argumentSeparatorIndex + 1));
                                if (position >= 0 && position <= rope.Count)
                                {
                                    rope.InsertRange(position, stringToInsert);
                                }
                                else
                                {
                                    Console.WriteLine("ERROR");
                                }
                            }
                            break;
                        case "APPEND":
                            {
                                rope.InsertRange(rope.Count, arguments);
                            }
                            break;
                        case "DELETE":
                            {
                                var indexOfSeparator = arguments.LastIndexOf(' ');
                                var startIndex = int.Parse(arguments.Substring(0, indexOfSeparator));
                                var count = int.Parse(arguments.Substring(indexOfSeparator + 1));

                                if (startIndex >= 0 && startIndex < rope.Count && count >= 0 && startIndex + count <= rope.Count)
                                {
                                    rope.RemoveRange(startIndex, count);
                                }
                                else
                                {
                                    Console.WriteLine("ERROR");
                                }
                            }
                            break;
                        case "REPLACE":
                            {
                                var secondSeparator = arguments.LastIndexOf(' ');
                                var firstSeparator = arguments.LastIndexOf(' ', secondSeparator - 1);
                                var startIndex = int.Parse(arguments.Substring(0, firstSeparator));
                                var count = int.Parse(arguments.Substring(firstSeparator + 1, secondSeparator - firstSeparator - 1));
                                var stringForReplacement = arguments.Substring(secondSeparator + 1);

                                if (startIndex >= 0 && startIndex < rope.Count && startIndex + count <= rope.Count)
                                {
                                    rope.RemoveRange(startIndex, count);
                                    rope.InsertRange(startIndex, stringForReplacement);
                                }
                                else
                                {
                                    Console.WriteLine("ERROR");
                                }
                            }
                            break;
                        default:
                            Console.WriteLine("ERROR");
                            break;
                    }
                }
            }
        }
    }
}

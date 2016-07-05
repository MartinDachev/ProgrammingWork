using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HashTable;

namespace Problem3_Phonebook
{
    class Program
    {
        static void Main(string[] args)
        {
            HashTable<string, string> phonebook = new HashTable<string, string>();

            Console.WriteLine("Type every new Person and his Phone Number\nin the format {person}-{phone number}\nType \"search\" to search for people's numbers and type\n\"end\" to stop searching");

            string inputLine = Console.ReadLine();
            string name, phoneNumber;
            char splitter = '-';
            int indexOfSplitter;

            while (inputLine != "search")
            {
                indexOfSplitter = inputLine.IndexOf(splitter);
                name = inputLine.Substring(0, indexOfSplitter);
                phoneNumber = inputLine.Substring(indexOfSplitter + 1);
                phonebook[name] = phoneNumber;
                inputLine = Console.ReadLine();
            }

            inputLine = Console.ReadLine();

            while (inputLine != "end")
            {
                if (phonebook.ContainsKey(inputLine))
                {
                    Console.WriteLine("{0} -> {1}", inputLine, phonebook[inputLine]);
                }
                else
                {
                    Console.WriteLine("Contact {0} does not exist.", inputLine);
                }
                inputLine = Console.ReadLine();
            }
        }
    }
}

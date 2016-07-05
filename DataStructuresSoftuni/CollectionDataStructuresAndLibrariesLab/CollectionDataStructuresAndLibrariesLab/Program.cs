using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace CollectionDataStructuresAndLibrariesLab
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var dictionary = new OrderedMultiDictionary<DateTime, string>(true);
            string[] tokens;
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                tokens = Console.ReadLine().Split('|');
                var eventName = tokens[0].Trim();
                var eventDate = DateTime.Parse(tokens[1].Trim());
                dictionary.Add(eventDate, eventName);
            }

            n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                tokens = Console.ReadLine().Split('|');
                var startEventDate = DateTime.Parse(tokens[0].Trim());
                var endEventDate = DateTime.Parse(tokens[1].Trim());
                var eventsRange = dictionary.Range(startEventDate, true, endEventDate, true);

                Console.WriteLine(eventsRange.KeyValuePairs.Count);

                foreach (var eventsInRange in eventsRange)
                {
                    var currentEventsDate = eventsInRange.Key;
                    foreach (var eventsOnSameDate in eventsInRange.Value)
                    {
                        Console.WriteLine("{0} | {1}", eventsOnSameDate, currentEventsDate);
                    }
                }
            }
        }
    }
}

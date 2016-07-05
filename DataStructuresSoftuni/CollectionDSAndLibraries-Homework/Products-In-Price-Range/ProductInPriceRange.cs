using System;
using Wintellect.PowerCollections;

namespace Products_In_Price_Range
{
    class ProductInPriceRange
    {
        static void Main(string[] args)
        {
            var productsDictionary = new OrderedMultiDictionary<double, string>(true);
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                var indexOfSeparator = input.LastIndexOf(' ');
                var productName = input.Substring(0, indexOfSeparator);
                var productPrice = double.Parse(input.Substring(indexOfSeparator + 1));
                productsDictionary.Add(productPrice, productName);
            }

            int hitCount = 1, endCount = 20;
            var inputOfRange = Console.ReadLine();
            var indexOfRangeSeparator = inputOfRange.LastIndexOf(' ');
            var startPrice = double.Parse(inputOfRange.Substring(0, indexOfRangeSeparator));
            var endPrice = double.Parse(inputOfRange.Substring(indexOfRangeSeparator + 1));
            var productsRange = productsDictionary.Range(startPrice, true, endPrice, true);
            foreach (var products in productsRange)
            {
                if (hitCount > endCount)
                {
                    break;
                }

                foreach (var product in products.Value)
                {
                    if (hitCount > endCount)
                    {
                        break;
                    }

                    Console.WriteLine("{0} {1}", products.Key, product);
                    hitCount++;
                }
            }
        }
    }
}

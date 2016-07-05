using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection_of_Products
{
    class CollectionOfProductsExample
    {
        static void Main(string[] args)
        {
            ProductsCollection products = new ProductsCollection();
            var product7 = new Product("535", "Olio", "Durex", 10.99);
            var product11 = new Product("421", "Puding", "Gosho", 4.20);
            var product1 = new Product("12B", "Zahar", "Pesho", 5.25);
            var product9 = new Product("601", "Olio", "Minka", 4.20);
            var product2 = new Product("11A", "Brashno", "Gosho", 6.15);
            var product3 = new Product("10B", "Olio", "Pesho", 6);
            var product4 = new Product("51A", "Ocet", "Gosho", 3.30);
            var product5 = new Product("001", "Prezervativ", "Durex", 2.50);
            var product6 = new Product("120", "Olio", "Gosho", 4.20);
            var product8 = new Product("02Z", "Olio", "Pesho", 4.20);
            var product10 = new Product("315", "Puding", "Gosho", 3.30);

            products.Add(product7);
            products.Add(product11);
            products.Add(product1);
            products.Add(product9);
            products.Add(product2);
            products.Add(product3);
            products.Add(product4);
            products.Add(product5);
            products.Add(product6);
            products.Add(product8);
            products.Add(product10);

            var productsInPriceRange = products.FindProductsInPriceRange(4, 6.15);
            var productByTitle = products.FindProductsByTitle("Olio");
            var productByTitleAndPrice = products.FindProductsByTitleAndPrice("Olio", 4.20);
            var productsByTitleAndPriceRange = products.FindProductsByTitleAndPriceRange("Olio", 3, 15);
            var productsBySupplierAndPrice = products.FindProductsBySupplierAndPrice("Gosho", 4.20);
            var productsBySupplierAndPriceRange = products.FindProductsBySupplierAndPriceRange("Gosho", 4, 7.30);

            bool b1 = products.Remove(product9.Id);

            var productByTitle2 = products.FindProductsByTitle("Olio");

            bool b2 = products.Remove("Limonada");
            bool b3 = products.Remove(product6.Id);

            var productsBySupplierAndPrice2 = products.FindProductsBySupplierAndPrice("Gosho", 4.20);
            var productByTitleAndPrice2 = products.FindProductsByTitleAndPrice("Olio", 4.20);
            var productsBySupplierAndPriceRange2 = products.FindProductsBySupplierAndPriceRange("Gosho", 4, 7.30);
            var productsInPriceRange2 = products.FindProductsInPriceRange(4, 6.15);
            var productsByTitleAndPriceRange2 = products.FindProductsByTitleAndPriceRange("Olio", 3, 6);
        }
    }
}

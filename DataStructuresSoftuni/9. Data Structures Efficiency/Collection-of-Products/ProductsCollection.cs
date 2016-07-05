using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace Collection_of_Products
{
    public class ProductsCollection
    {
        private Dictionary<string, Product> productsById;
        private OrderedDictionary<double, HashSet<Product>> productsByPrice;
        private Dictionary<string, SortedSet<Product>> productsByTitle;
        private Dictionary<string, OrderedDictionary<double, SortedSet<Product>>> productsByTitleAndPrice;
        private Dictionary<string, OrderedDictionary<double, SortedSet<Product>>> productsBySupplierAndPrice;

        public ProductsCollection()
        {
            productsById = new Dictionary<string, Product>();
            productsByPrice = new OrderedDictionary<double, HashSet<Product>>();
            productsByTitle = new Dictionary<string, SortedSet<Product>>();
            productsByTitleAndPrice = new Dictionary<string, OrderedDictionary<double, SortedSet<Product>>>();
            productsBySupplierAndPrice = new Dictionary<string, OrderedDictionary<double, SortedSet<Product>>>();
        }

        public void Add(Product product)
        {
            productsById.Add(product.Id, product);
            productsByPrice.AppendValueToKey(product.Price, product);
            productsByTitle.AppendValueToKey(product.Title, product);
            productsByTitleAndPrice.EnsureKeyExists(product.Title);
            productsByTitleAndPrice[product.Title].AppendValueToKey(product.Price, product);
            productsBySupplierAndPrice.EnsureKeyExists(product.Supplier);
            productsBySupplierAndPrice[product.Supplier].AppendValueToKey(product.Price, product);
        }

        public Product FindProductById(string id)
        {
            Product product;
            productsById.TryGetValue(id, out product);
            return product;
        }

        public bool Remove(string id)
        {
            var product = this.FindProductById(id);
            if (product == null)
            {
                return false;
            }

            productsById.Remove(id);
            productsByPrice[product.Price].Remove(product);
            productsByTitle[product.Title].Remove(product);
            productsByTitleAndPrice[product.Title][product.Price].Remove(product);
            productsBySupplierAndPrice[product.Supplier][product.Price].Remove(product);

            return true;
        }

        public IEnumerable<Product> FindProductsInPriceRange(double startPrice, double endPrice)
        {
            var productsPriceCollection = productsByPrice.Range(startPrice, true, endPrice, true);
            var productsSortedById = new SortedSet<Product>();

            foreach (var products in productsPriceCollection)
            {
                foreach (var product in products.Value)
                {
                    productsSortedById.Add(product);
                }
            }

            return productsSortedById;
        }

        public IEnumerable<Product> FindProductsByTitle(string title)
        {
            var products = productsByTitle.GetValuesForKey(title);
            return products;
        }

        public IEnumerable<Product> FindProductsByTitleAndPrice(string title, double price)
        {
            OrderedDictionary<double, SortedSet<Product>> productsWithTitle;

            if (!productsByTitleAndPrice.TryGetValue(title, out productsWithTitle))
            {
                return Enumerable.Empty<Product>();
            }

            var productsWithPrice = productsWithTitle.GetValuesForKey(price);
            return productsWithPrice;
        }

        public IEnumerable<Product> FindProductsByTitleAndPriceRange(string title, double startPrice, double endPrice)
        {
            if (!productsByTitleAndPrice.ContainsKey(title))
            {
                return Enumerable.Empty<Product>();
            }

            var productsInPriceRange = productsByTitleAndPrice[title].Range(startPrice, true, endPrice, true);
            SortedSet<Product> products = new SortedSet<Product>();
            foreach (var productsWithPrice in productsInPriceRange)
            {
                foreach (var eachProduct in productsWithPrice.Value)
                {
                    products.Add(eachProduct);
                }
            }

            return products;
        }

        public IEnumerable<Product> FindProductsBySupplierAndPrice(string supplier, double price)
        {
            OrderedDictionary<double, SortedSet<Product>> productsWithSupplier;

            if (!productsBySupplierAndPrice.TryGetValue(supplier, out productsWithSupplier))
            {
                return Enumerable.Empty<Product>();
            }

            var productsWithPrice = productsWithSupplier.GetValuesForKey(price);
            return productsWithPrice;
        }

        public IEnumerable<Product> FindProductsBySupplierAndPriceRange(string supplier, double startPrice, double endPrice)
        {
            if (!productsBySupplierAndPrice.ContainsKey(supplier))
            {
                return Enumerable.Empty<Product>();
            }

            var productsInPriceRange = productsBySupplierAndPrice[supplier].Range(startPrice, true, endPrice, true);
            SortedSet<Product> products = new SortedSet<Product>();
            foreach (var productsWithPrice in productsInPriceRange)
            {
                foreach (var eachProduct in productsWithPrice.Value)
                {
                    products.Add(eachProduct);
                }
            }

            return products;
        }
    }
}

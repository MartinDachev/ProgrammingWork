using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection_of_Products
{
    public class Product : IComparable<Product>
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Supplier { get; set; }

        public double Price { get; set; }

        public Product(string id, string title, string supplier, double price)
        {
            this.Id = id;
            this.Title = title;
            this.Supplier = supplier;
            this.Price = price;
        }

        public int CompareTo(Product other)
        {
            return this.Id.CompareTo(other.Id);
        }
    }
}

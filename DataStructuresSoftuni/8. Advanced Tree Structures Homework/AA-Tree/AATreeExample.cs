using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA_Tree
{
    class AATreeExample
    {
        static void Main(string[] args)
        {
            SortedDictionary<int, int> dictionary = new SortedDictionary<int, int>();
            AATree<int> tree = new AATree<int>();
            tree.Add(4);
            tree.Add(10);
            tree.Add(2);
            tree.Add(6);
            tree.Add(12);
            tree.Add(3);
            tree.Add(1);
            tree.Add(8);
            tree.Add(13);
            tree.Add(11);
            tree.Add(5);
            tree.Add(9);
            tree.Add(7);
            bool b = tree.Remove(1);
            tree.Remove(5);
            tree.Remove(1);
        }
    }
}

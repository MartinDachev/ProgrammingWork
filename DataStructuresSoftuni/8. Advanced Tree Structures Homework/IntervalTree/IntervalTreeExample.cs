using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntervalTree
{
    class IntervalTreeExample
    {
        static void Main(string[] args)
        {
            IntervalTree<int> tree = new IntervalTree<int>();
            tree.Add(1, 3);
            tree.Add(0, 5);
            tree.Add(-1, 3);
            tree.Add(-7, 20);
            tree.Add(-10, 0);
            tree.Add(-6, -4);
            tree.Add(-11, 21);
            tree.Add(-12, 3);
            tree.Add(0, 3);
            tree.Remove(0, 3);
            tree.Remove(22, 23);
            var list = tree.GetOverlappingIntervals(-100, 100);
        }
    }
}

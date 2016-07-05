using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem1_PlayWithTrees
{
    public class Tree<T>
    {
        public T Value { get; set; }

        public Tree<T> Parent { get; set; }

        public IList<Tree<T>> Children { get; private set; }

        public Tree(T value, params Tree<T>[] children)
        {
            this.Value = value;
            this.Children = new List<Tree<T>>(children.Length);

            for (int i = 0; i < children.Length; i++)
            {
                this.Children.Add(children[i]);
                children[i].Parent = this;
            }
        }

        public void PrintSubtreeSum()
        {
            Console.Write(this.Value);

            for (int i = 0; i < this.Children.Count; ++i)
            {
                Console.Write(" + ");
                this.Children[i].PrintSubtreeSum();
            }
        }
    }
}

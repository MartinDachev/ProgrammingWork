using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem4_Ordered_Set
{
    public class TreeNode<T> : IEnumerable
    {
        public T Value { get; set; }

        public TreeNode<T> parent;

        public TreeNode<T> leftChild;

        public TreeNode<T> rightChild;

        public int Height { get; set; }

        public TreeNode(T value)
        {
            this.Value = value;
        }

        public TreeNode(TreeNode<T> parent, T value)
        {
            this.parent = parent;
            this.Value = value;
            this.Height = 1;
        }

        public static int GetHeightOfNode(TreeNode<T> node)
        {
            if (node == null)
            {
                return 0;
            }
            return node.Height;
        }

        public int GetBalance()
        {
            if (this == null)
            {
                return 0;
            }
            return GetHeightOfNode(this.leftChild) - GetHeightOfNode(this.rightChild);
        }

        public void UpdateHeight()
        {
            this.Height = Math.Max(GetHeightOfNode(this.leftChild), GetHeightOfNode(this.rightChild)) + 1;
        }

        public TreeNode<T> LeftRotate()
        {
            TreeNode<T> x = this.rightChild;
            TreeNode<T> BT = x.leftChild;
            
            x.leftChild = this;
            x.parent = this.parent;
            this.parent = x;
            this.rightChild = BT;
            if (BT != null)
            {
                BT.parent = this;
            }

            this.UpdateHeight();
            x.UpdateHeight();

            // Return the new root
            return x;
        }

        public TreeNode<T> RightRotate()
        {
            TreeNode<T> x = this.leftChild;
            TreeNode<T> BT = x.rightChild;

            x.rightChild = this;
            x.parent = this.parent;
            this.parent = x;
            this.leftChild = BT;
            if (BT != null)
            {
                BT.parent = this;
            }

            this.UpdateHeight();
            x.UpdateHeight();

            // Return the new root
            return x;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (leftChild != null)
            {
                foreach (var child in leftChild)
                {
                    yield return child;
                }
            }

            yield return this.Value;

            if (rightChild != null)
            {
                foreach (var child in rightChild)
                {
                    yield return child;
                }
            }
        }
    }
}

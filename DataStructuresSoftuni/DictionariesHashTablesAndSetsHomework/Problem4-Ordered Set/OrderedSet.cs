using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem4_Ordered_Set
{
    public class OrderedSet<T> : IEnumerable where T : IComparable
    {
        public TreeNode<T> Root;

        public int Count { get; private set; }

        public OrderedSet()
        {
            this.Count = 0;
        }

        public void Add(T value)
        {
            if (this.Root == null)
            {
                this.Root = new TreeNode<T>(null, value);
                this.Count++;
                return;
            }
            bool added = false;
            TreeNode<T> nodeToAddValueTo = this.Root;
            TreeNode<T> currentNode = this.Root;
            int comparisonResult = 0;

            while(!added)
            {
                comparisonResult = value.CompareTo(nodeToAddValueTo.Value);

                if (comparisonResult < 0)
                {
                    if (nodeToAddValueTo.leftChild == null)
                    {
                        nodeToAddValueTo.leftChild = new TreeNode<T>(nodeToAddValueTo, value);
                        currentNode = nodeToAddValueTo.leftChild;
                        added = true;
                    }
                    else
                    {
                        nodeToAddValueTo = nodeToAddValueTo.leftChild;
                    }
                }
                else if (comparisonResult > 0)
                {
                    if (nodeToAddValueTo.rightChild == null)
                    {
                        nodeToAddValueTo.rightChild = new TreeNode<T>(nodeToAddValueTo, value);
                        currentNode = nodeToAddValueTo.rightChild;
                        added = true;
                    }
                    else
                    {
                        nodeToAddValueTo = nodeToAddValueTo.rightChild;
                    }
                }
                else
                {
                    return;
                }
            }
            this.Count++;
            
            // There is a small error that I don't have time to fix
            //
            //int balance;
            //while (currentNode.parent != null)
            //{
            //    currentNode.parent.UpdateHeight();
            //    balance = currentNode.parent.GetBalance();

            //    if (balance > 1)
            //    {
            //        // Left Left case
            //        if (value.CompareTo(currentNode.parent.Value) < 0)
            //        {
            //            currentNode.parent = currentNode.parent.RightRotate();
            //        }
            //        // Left Right case
            //        else
            //        {
            //            currentNode.parent.leftChild = currentNode.parent.leftChild.LeftRotate();
            //            currentNode.parent = currentNode.parent.RightRotate();
            //        }
            //    }

            //    if (balance < -1)
            //    {
            //        // Right Right case
            //        if (value.CompareTo(currentNode.parent.Value) > 0)
            //        {
            //            currentNode.parent = currentNode.parent.LeftRotate();
            //        }
            //        // Right Left case
            //        else
            //        {
            //            currentNode.parent.rightChild = currentNode.parent.rightChild.RightRotate();
            //            currentNode.parent = currentNode.parent.LeftRotate();
            //        }
            //    }
            //    currentNode = currentNode.parent;
            //}
        }

        public bool Contains(T value)
        {
            TreeNode<T> nodeToCheck = this.Root;
            int comparisonResult;

            while (nodeToCheck != null)
            {
                comparisonResult = value.CompareTo(nodeToCheck.Value);

                if (comparisonResult < 0)
                {
                    nodeToCheck = nodeToCheck.leftChild;
                }
                else if (comparisonResult > 0)
                {
                    nodeToCheck = nodeToCheck.rightChild;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }

        public bool Remove(T value)
        {
            return HandleNodeRemove(value, ref this.Root);
        }

        public bool HandleNodeRemove(T value, ref TreeNode<T> node)
        {
            if (node == null)
            {
                return false;
            }

            int comparisonResult;
            comparisonResult = value.CompareTo(node.Value);

             if (comparisonResult < 0)
             {
                 return HandleNodeRemove(value, ref node.leftChild);
             }
             else if (comparisonResult > 0)
             {
                 return HandleNodeRemove(value, ref node.rightChild);
             }
             else
             {
                 if (node.leftChild == null)
                 {
                     node.rightChild.parent = node.parent;
                     node = node.rightChild;
                 }
                 else if (node.rightChild == null)
                 {
                     node.leftChild.parent = node.parent;
                     node = node.leftChild;
                 }
                 else
                 {
                     RemoveNodeWithTwoChildren(ref node);
                 }

                 this.Count--;
                 return true;
             }
        }

        private void RemoveNodeWithTwoChildren(ref TreeNode<T> node)
        {
            TreeNode<T> minNode = node.rightChild;
            this.FindMinElementInTree(ref minNode);
            node.Value = minNode.Value;

            if (minNode.rightChild != null)
            {
                if (minNode.Value.CompareTo(minNode.parent.Value) < 0)
                {
                    minNode.parent.leftChild = minNode.rightChild;
                    minNode.rightChild.parent = minNode.parent;
                }
                else
                {
                    minNode.parent.rightChild = minNode.rightChild;
                    minNode.rightChild.parent = minNode.parent;
                }
            }
        }

        private void FindMinElementInTree(ref TreeNode<T> node)
        {
            while (node.leftChild != null)
            {
                node = node.leftChild;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.Root.GetEnumerator();
        }
    }
}

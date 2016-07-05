using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntervalTree
{
    public class IntervalTree<T> where T : IComparable<T>
    {
        public class Interval<T>
            where T : IComparable<T>
        {
            public T LowValue { get; set; }

            public T HighValue { get; set; }

            public Interval(T lowValue, T highValue)
            {
                if (lowValue.CompareTo(highValue) > 0)
                {
                    throw new ArgumentException("The start of the Interval can't be bigger than the end");
                }

                this.LowValue = lowValue;
                this.HighValue = highValue;
            }

            public bool IsEqualTo(Interval<T> other)
            {
                return this.LowValue.Equals(other.LowValue) && this.HighValue.Equals(other.HighValue);
            }

            public bool Intersects(Interval<T> other)
            {
                return this.LowValue.CompareTo(other.HighValue) <= 0 && this.HighValue.CompareTo(other.LowValue) >= 0;
            }

            public int CompareTo(IntervalTree<T>.Interval<T> other)
            {
                throw new NotImplementedException();
            }
        }

        private class TreeNode<T> where T : IComparable<T>
        {
            public Interval<T> IntervalItem { get; set; }

            public T TreeMaxValue { get; set; }

            public T TreeMinValue { get; set; }

            public int Level { get; set; }

            public TreeNode<T> leftChild;
            public TreeNode<T> rightChild;

            public TreeNode(Interval<T> interval, int level)
            {

                this.IntervalItem = interval;
                this.Level = level;
                this.TreeMaxValue = interval.HighValue;
                this.TreeMinValue = interval.LowValue;
            }

            public void UpdateTreeMinAndMax()
            {
                T treeMin = this.IntervalItem.LowValue;
                if (this.leftChild != null && this.leftChild.TreeMinValue.CompareTo(treeMin) < 0)
                {
                    treeMin = this.leftChild.TreeMinValue;
                }

                if (this.rightChild != null && this.rightChild.TreeMinValue.CompareTo(treeMin) < 0)
                {
                    treeMin = this.rightChild.TreeMinValue;
                }

                T treeMax = this.IntervalItem.HighValue;
                if (this.leftChild != null && this.leftChild.TreeMaxValue.CompareTo(treeMax) > 0)
                {
                    treeMax = this.leftChild.TreeMaxValue;
                }

                if (this.rightChild != null && this.rightChild.TreeMaxValue.CompareTo(treeMax) > 0)
                {
                    treeMax = this.rightChild.TreeMaxValue;
                }

                this.TreeMinValue = treeMin;
                this.TreeMaxValue = treeMax;
            }
        }

        private TreeNode<T> root;

        public int Count { get; set; }

        public IntervalTree()
        {
            this.Count = 0;
        }

        public bool Add(T lowValue, T highValue)
        {
            if (this.Insert(ref this.root, new Interval<T>(lowValue, highValue)))
            {
                this.Count++;
                return true;
            }

            return false;
        }

        private bool Insert(ref TreeNode<T> node, Interval<T> interval)
        {
            if (node == null)
            {
                node = new TreeNode<T>(interval, 1);
                return true;
            }

            int comparisonResult = interval.LowValue.CompareTo(node.IntervalItem.LowValue);
            if (comparisonResult < 0)
            {
                if (!Insert(ref node.leftChild, interval))
                {
                    return false;
                }
            }
            else // comparisonResult >= 0
            {
                if (!Insert(ref node.rightChild, interval))
                {
                    return false;
                }
            }

            node.UpdateTreeMinAndMax();

            Skew(ref node);
            Split(ref node);

            return true;
        }

        public bool Remove(T lowValue, T highValue)
        {
            if (this.Delete(ref this.root, new Interval<T>(lowValue, highValue)))
            {
                this.Count--;
                return true;
            }
            return false;
        }

        private bool Delete(ref TreeNode<T> node, Interval<T> interval)
        {
            if (node == null || node.TreeMaxValue.CompareTo(interval.LowValue) < 0 || node.TreeMinValue.CompareTo(interval.HighValue) > 0)
            {
                return false;
            }

            if (node.IntervalItem.IsEqualTo(interval))
            {
                if (node.leftChild == null && node.rightChild == null)
                {
                    node = null;
                }
                else if (node.leftChild == null)
                {
                    node = node.rightChild;
                }
                else if (node.rightChild == null)
                {
                    node = node.leftChild;
                }
                else // Node with two children
                {
                    var inOrderPredecessor = this.FindInOrderPredecessor(node.leftChild);
                    node.IntervalItem = inOrderPredecessor.IntervalItem;
                    Delete(ref node.leftChild, inOrderPredecessor.IntervalItem);
                }
            }
            else
            {

                int comparisonResult = interval.LowValue.CompareTo(node.IntervalItem.LowValue);

                if (comparisonResult < 0)
                {
                    if (!Delete(ref node.leftChild, interval))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!Delete(ref node.rightChild, interval))
                    {
                        return false;
                    }
                }
            }

            if (node != null) // Rebalance
            {
                node.UpdateTreeMinAndMax();
                int leftLevel;
                int rightLevel;
                if (node.leftChild == null)
                {
                    leftLevel = 0;
                }
                else
                {
                    leftLevel = node.leftChild.Level;
                }

                if (node.rightChild == null)
                {
                    rightLevel = 0;
                }
                else
                {
                    rightLevel = node.rightChild.Level;
                }

                if (leftLevel < node.Level - 1 || rightLevel < node.Level - 1)
                {
                    node.Level--;
                    if (node.rightChild != null && node.rightChild.Level > node.Level)
                    {
                        node.rightChild.Level = node.Level;
                    }

                    this.Skew(ref node);
                    if (node.rightChild != null)
                    {
                        this.Skew(ref node.rightChild);
                    }
                    if (node.rightChild.rightChild != null)
                    {
                        this.Skew(ref node.rightChild.rightChild);
                    }
                    this.Split(ref node);
                    if (node.rightChild != null)
                    {
                        this.Split(ref node.rightChild);
                    }
                }
            }
            return true;
        }

        public List<Interval<T>> GetOverlappingIntervals(T lowValue, T highValue)
        {
            List<Interval<T>> intervalsList = new List<Interval<T>>();
            this.FindOverlappingIntervals(new Interval<T>(lowValue, highValue), ref this.root, ref intervalsList);
            return intervalsList;
        }

        private void FindOverlappingIntervals(Interval<T> interval, ref TreeNode<T> node, ref List<Interval<T>> intervalsList)
        {
            if (node == null || node.TreeMaxValue.CompareTo(interval.LowValue) < 0 || node.TreeMinValue.CompareTo(interval.HighValue) > 0)
            {
                return;
            }

            if (node.leftChild != null && node.leftChild.TreeMaxValue.CompareTo(interval.LowValue) >= 0 && node.leftChild.TreeMinValue.CompareTo(interval.HighValue) <= 0)
            {
                FindOverlappingIntervals(interval, ref node.leftChild, ref intervalsList);
            }

            if (node.rightChild != null && node.rightChild.TreeMaxValue.CompareTo(interval.LowValue) >= 0 && node.rightChild.TreeMinValue.CompareTo(interval.HighValue) <= 0)
            {
                FindOverlappingIntervals(interval, ref node.rightChild, ref intervalsList);
            }

            if (node.IntervalItem.Intersects(interval))
            {
                intervalsList.Add(node.IntervalItem);
            }
        }

        private TreeNode<T> FindInOrderPredecessor(TreeNode<T> node)
        {
            var inOrderPredecessor = node;

            while (inOrderPredecessor.rightChild != null)
            {
                inOrderPredecessor = node.rightChild;
            }

            return inOrderPredecessor;
        }

        private void Skew(ref TreeNode<T> node)
        {
            if (node != null && node.leftChild != null && node.Level == node.leftChild.Level)
            {
                var leftNode = node.leftChild;
                node.leftChild = leftNode.rightChild;
                leftNode.rightChild = node;
                node = leftNode;
                node.rightChild.UpdateTreeMinAndMax();
                node.UpdateTreeMinAndMax();
            }
        }

        private void Split(ref TreeNode<T> node)
        {
            if (node != null && node.rightChild != null && node.rightChild.rightChild != null && node.Level == node.rightChild.rightChild.Level)
            {
                var rightNode = node.rightChild;
                node.rightChild = rightNode.leftChild;
                rightNode.leftChild = node;
                rightNode.Level++;
                node = rightNode;
                node.leftChild.UpdateTreeMinAndMax();
                node.UpdateTreeMinAndMax();
            }
        }
    }
}

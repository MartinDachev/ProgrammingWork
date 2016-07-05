using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Problem7.Tests
{
    [TestClass]
    public class UnitTestsLinkedQueue
    {
        [TestMethod]
        public void EnqueueDequeue_ShouldWorkCorrectly()
        {
            // Arrange
            LinkedQueue<int> queue = new LinkedQueue<int>();
            int value = 5;

            // Assert
            Assert.AreEqual(0, queue.Count);

            //Act
            queue.Enqueue(value);

            // Assert
            Assert.AreEqual(value, queue.Dequeue());
            Assert.AreEqual(0, queue.Count);
        }

        [TestMethod]
        public void EnqueueDequeue1000Values_ShouldWorkCorrectly()
        {
            // Arrange
            LinkedQueue<string> queue = new LinkedQueue<string>();

            // Act & Assert in a loop
            Assert.AreEqual(0, queue.Count);
            for (int i = 0; i < 1000; ++i)
            {
                queue.Enqueue(i.ToString());
                Assert.AreEqual(i + 1, queue.Count);
            }

            for (int i = 0; i < 1000; ++i)
            {
                Assert.AreEqual((i).ToString(), queue.Dequeue());
                Assert.AreEqual(999 - i, queue.Count);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DequeueFromEmptyQueue_ShouldThrowAnException()
        {
            // Arrange
            LinkedQueue<int> queue = new LinkedQueue<int>();

            // Act
            queue.Dequeue();

            // Assert: expect an exception
        }

        [TestMethod]
        public void EnqueueDequeue2_ShouldWorkCorrectly()
        {
            // Arrange
            LinkedQueue<int> queue = new LinkedQueue<int>();
            int firstElement = 1204;
            int secondElement = -125;

            // Assert
            Assert.AreEqual(0, queue.Count);

            // Act
            queue.Enqueue(firstElement);

            // Assert
            Assert.AreEqual(1, queue.Count);

            // Act
            queue.Enqueue(secondElement);

            // Assert
            Assert.AreEqual(2, queue.Count);

            // Act & Assert
            Assert.AreEqual(firstElement, queue.Dequeue());
            Assert.AreEqual(1, queue.Count);
            Assert.AreEqual(secondElement, queue.Dequeue());
            Assert.AreEqual(0, queue.Count);
        }

        [TestMethod]
        public void QueueToArray_ShouldWorkCorrectly()
        {
            // Arrange
            LinkedQueue<int> queue = new LinkedQueue<int>();

            // Act
            queue.Enqueue(3);
            queue.Enqueue(5);
            queue.Enqueue(-2);
            queue.Enqueue(7);

            // Assert
            CollectionAssert.AreEqual(new int[] { 3, 5, -2, 7 }, queue.ToArray());
        }

        [TestMethod]
        public void EmptyQueueToArray_ShouldReturnEmptyArray_ShouldWorkCorrectly()
        {
            // Arrange
            LinkedQueue<DateTime> queue = new LinkedQueue<DateTime>();

            // Act & Assert
            CollectionAssert.AreEqual(new DateTime[0], queue.ToArray());
        }
    }
}

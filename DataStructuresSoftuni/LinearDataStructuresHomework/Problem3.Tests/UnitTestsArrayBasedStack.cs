using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Problem3.Tests
{
    [TestClass]
    public class UnitTestsArrayBasedStack
    {
        [TestMethod]
        public void PushPop_ShouldWorkCorrectly()
        {
            // Arrange
            ArrayBasedStack<int> stack = new ArrayBasedStack<int>();
            int value = 5;

            // Assert
            Assert.AreEqual(0, stack.Count);

            //Act
            stack.Push(value);

            // Assert
            Assert.AreEqual(value, stack.Pop());
            Assert.AreEqual(0, stack.Count);
        }

        [TestMethod]
        public void PushPop1000Values_ShouldWorkCorrectly()
        {
            // Arrange
            ArrayBasedStack<string> stack = new ArrayBasedStack<string>();

            // Act & Assert in a loop
            Assert.AreEqual(0, stack.Count);
            for (int i = 0; i < 1000; ++i)
            {
                stack.Push(i.ToString());
                Assert.AreEqual(i + 1, stack.Count);
            }

            for (int i = 999; i>= 0; --i)
            {
                Assert.AreEqual((i).ToString(), stack.Pop());
                Assert.AreEqual(i, stack.Count);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PopFromEmptyStack_ShouldThrowAnException()
        {
            // Arrange
            ArrayBasedStack<int> stack = new ArrayBasedStack<int>();

            // Act
            stack.Pop();

            // Assert: expect an exception
        }

        [TestMethod]
        public void PushPop_StartCapacity1_ShouldWorkCorrectly()
        {
            // Arrange
            ArrayBasedStack<int> stack = new ArrayBasedStack<int>(1);
            int firstElement = 1204;
            int secondElement = -125;

            // Assert
            Assert.AreEqual(0, stack.Count);

            // Act
            stack.Push(firstElement);

            // Assert
            Assert.AreEqual(1, stack.Count);

            // Act
            stack.Push(secondElement);

            // Assert
            Assert.AreEqual(2, stack.Count);

            // Act & Assert
            Assert.AreEqual(secondElement, stack.Pop());
            Assert.AreEqual(1, stack.Count);
            Assert.AreEqual(firstElement, stack.Pop());
            Assert.AreEqual(0, stack.Count);
        }
        
        [TestMethod]
        public void StackToArray_ShouldWorkCorrectly()
        {
            // Arrange
            ArrayBasedStack<int> stack = new ArrayBasedStack<int>();

            // Act
            stack.Push(3);
            stack.Push(5);
            stack.Push(-2);
            stack.Push(7);

            // Assert
            CollectionAssert.AreEqual(new int[] { 7, -2, 5, 3 }, stack.ToArray());
        }

        [TestMethod]
        public void EmptyStackToArray_ShouldReturnEmptyArray_ShouldWorkCorrectly()
        {
            // Arrange
            ArrayBasedStack<DateTime> stack = new ArrayBasedStack<DateTime>();

            // Act & Assert
            CollectionAssert.AreEqual(new DateTime[0], stack.ToArray());
        }
    }
}

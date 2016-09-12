using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algo1.Core;

namespace Algo1.UnitTests
{
    [TestClass]
    public class BubbleSorterTests
    {
        [TestMethod]
        public void SortNullArray()
        {
            BubbleSorter sort = new BubbleSorter();

            var result = sort.Sort(null);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void SortEmptyArray()
        {
            BubbleSorter sort = new BubbleSorter();

            var result = sort.Sort(new int[0]);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Length == 0);
        }


        [TestMethod]
        public void SortArrayOneElement()
        {
            BubbleSorter sort = new BubbleSorter();

            var input = new int[1];
            input[0] = 10;
            var result = sort.Sort(input);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Length == 1);
            Assert.IsTrue(input[0] == result[0]);
        }

        [TestMethod]
        public void SortArrayTwoElementsSorted()
        {
            BubbleSorter sort = new BubbleSorter();

            var input = new int[2] { 2, 4 };

            var result = sort.Sort(input);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Length == input.Length);
            Assert.IsTrue(input[0] == result[0]);
            Assert.IsTrue(input[1] == result[1]);
        }

        [TestMethod]
        public void SortArrayTwoElementsInversedSorted()
        {
            BubbleSorter sort = new BubbleSorter();

            var input = new int[2] { 4, 2 };

            var result = sort.Sort(input);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Length == input.Length);
            Assert.IsTrue(result[0] == 2);
            Assert.IsTrue(result[1] == 4);
        }


        [TestMethod]
        public void SortArrayFiveElementsInversedSorted()
        {
            BubbleSorter sort = new BubbleSorter();

            var input = new int[5] { 4, 2 ,3 ,1 ,5};

            var result = sort.Sort(input);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Length == input.Length);
            for (int i = 0; i < 5; i++)
            {
                Assert.IsTrue(result[i] == i+1);
            }
        }
    }
}

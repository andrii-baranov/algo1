using System;
using Algo1.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algo1.UnitTests
{
    [TestClass]
    public class QuickSortTests
    {
        [TestMethod]
        public void SortNullArray()
        {
            ISorter sort = new QuickSort();

            var result = sort.Sort(null);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void SortEmptyArray()
        {
            ISorter sort = new QuickSort();

            var result = sort.Sort(new int[0]);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Length == 0);
        }


        [TestMethod]
        public void SortArrayOneElement()
        {
            ISorter sort = new QuickSort();

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
            ISorter sort = new QuickSort();

            var input = new int[2] { 2, 4 };

            var result = sort.Sort(input);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Length == input.Length);
            Assert.IsTrue(input[0] == result[0]);
            Assert.IsTrue(input[1] == result[1]);
        }

        [TestMethod]
        public void SortArray8ElementsSorted()
        {
            ISorter sort = new QuickSort();

            var input = new int[] { 6, 5, 3, 1, 7, 8, 2, 4 };

            var result = sort.Sort(input);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Length == input.Length);

            for (int i = 0; i < input.Length; i++)
            {
                Assert.IsTrue(result[i] == i + 1);
            }
        }

        [TestMethod]
        public void SortArrayTwoElementsInversedSorted()
        {
            ISorter sort = new QuickSort();

            var input = new int[2] { 4, 2 };

            var result = sort.Sort(input);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Length == input.Length);
            Assert.IsTrue(result[0] == 2);
            Assert.IsTrue(result[1] == 4);
        }
    }
}

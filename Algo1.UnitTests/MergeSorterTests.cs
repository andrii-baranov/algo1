using Algo1.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo1.UnitTests
{
    [TestClass]
    public class MergeSorterTests
    {
        [TestMethod]
        public void SortNullArray()
        {
            ISorter sort = new MergeSorter();

            var result = sort.Sort(null);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void SortEmptyArray()
        {
            ISorter sort = new MergeSorter();

            var result = sort.Sort(new int[0]);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Length == 0);
        }


        [TestMethod]
        public void SortArrayOneElement()
        {
            ISorter sort = new MergeSorter();

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
            ISorter sort = new MergeSorter();

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
            ISorter sort = new MergeSorter();

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
            MergeSorter sort = new MergeSorter();

            var input = new int[5] { 4, 2, 3, 1, 5 };

            var result = sort.Sort(input);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Length == input.Length);
            for (int i = 0; i < 5; i++)
            {
                Assert.IsTrue(result[i] == i + 1);
            }
            Assert.IsTrue(sort.InversionsCount == 5);
        }

        [TestMethod]
        public void SortArray6ElementsInversedSorted()
        {
            MergeSorter sort = new MergeSorter();

            var input = new int[6] { 4, 2, 6, 3, 1, 5 };

            var result = sort.Sort(input);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Length == input.Length);
            for (int i = 0; i < input.Length; i++)
            {
                Assert.IsTrue(result[i] == i + 1);
            }

            Assert.IsTrue(sort.InversionsCount == 8);
        }

        [TestMethod]
        public void SortArrayInversed()
        {
            MergeSorter sort = new MergeSorter();

            var input = new int[4] { 4, 3, 2, 1 };

            var result = sort.Sort(input);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Length == input.Length);
            for (int i = 0; i < input.Length; i++)
            {
                Assert.IsTrue(result[i] == i + 1);
            }

            Assert.IsTrue(sort.InversionsCount == 6);
        }

        [TestMethod]
        public void SortArray8Elements()
        {
            MergeSorter sort = new MergeSorter();

            var input = new int[8] { 7, 8, 4, 3 , 5, 2, 6, 1 };

            var result = sort.Sort(input);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Length == input.Length);
            for (int i = 0; i < input.Length; i++)
            {
                Assert.IsTrue(result[i] == i + 1);
            }

         //   Assert.IsTrue(sort.InversionsCount == 6);
        }

        [TestMethod]
        public void SortArray10Elements()
        {
            MergeSorter sort = new MergeSorter();

            var input = new int[10] { 10, 9, 7, 8, 4, 3, 5, 2, 6, 1 };

            var result = sort.Sort(input);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Length == input.Length);
            for (int i = 0; i < input.Length; i++)
            {
                Assert.IsTrue(result[i] == i + 1);
            }

            //   Assert.IsTrue(sort.InversionsCount == 6);
        }
    }
}

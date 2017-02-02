using Algo1.Core.Sorting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo1.UnitTests
{
    [TestClass]
    public class SortingTests
    {
        [TestMethod]
        public void CheckSelectionSort()
        {
            int[] input = new int[10] { 3, 8, 5, 4, 9, 2, 10, 6, 1, 7 };
            var actualResult = SelectionSort.Sort(input);

            Assert.IsTrue(actualResult.Count() == 10);
            for (int i = 0; i < 10; i++)
            {
                Assert.IsTrue(actualResult[i] == i + 1);
            }
        }
    }
}

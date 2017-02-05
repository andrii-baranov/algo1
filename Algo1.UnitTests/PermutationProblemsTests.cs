using Algo1.Core.LeetCode;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo1.UnitTests
{
    [TestClass]
    public class PermutationProblemsTests
    {
        [TestMethod]
        public void GeneratePermsTest()
        {
            int n = 3;
            int k = 4;

            var result = new PermutationProblems().GetPermutation(n, k);
            Assert.AreEqual(result, "231");
        }

        [TestMethod]
        public void GeneratePermsLargeTest()
        {
            int n = 9;
            int k = 273822;

            var result = new PermutationProblems().GetPermutation(n, k);
            Assert.AreEqual(result, "783291654");
        }

        [TestMethod]
        public void GeneratePermsMaxTest()
        {
            int n = 9;
            int k = 362880;

            var result = new PermutationProblems().GetPermutation(n, k);
            Assert.AreEqual(result, "987654321");
        }

        [TestMethod]
        public void GeneratePermSmallTest()
        {
            int n = 3;
            int k = 6;

            var result = new PermutationProblems().GetPermutation(n, k);
            Assert.AreEqual(result, "321");
        }
    }
}

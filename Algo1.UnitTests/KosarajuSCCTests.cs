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
    public class KosarajuSCCTests
    {
        [TestMethod]
        public void CalculateSccTest()
        {
            var target = new KosurajuSCC();

            var input = new Dictionary<int, List<int>>();
            input.Add(0, new List<int> { 2, 3 });
            input.Add(1, new List<int> { 0 });
            input.Add(2, new List<int> { 1 });
            input.Add(3, new List<int> { 4 });

            var sccSizes = target.CalucalateSCC(input);

            Assert.IsTrue(sccSizes.Count == 3);
        }


        [TestMethod]
        public void CalculateSccTest2()
        {
            var target = new KosurajuSCC();

            var input = new Dictionary<int, List<int>>();
            input.Add(0, new List<int> { 1 });
            input.Add(1, new List<int> { 2, 3, 4 });
            input.Add(2, new List<int> { 0, 3 });
            input.Add(4, new List<int> { 5 });
            input.Add(5, new List<int> { 4 });

            var sccSizes = target.CalucalateSCC(input);

            Assert.IsTrue(sccSizes.Count == 3);
        }


        [TestMethod]
        public void CalculateSccTest3()
        {
            var target = new KosurajuSCC();

            var input = new Dictionary<int, List<int>>();
            input.Add(1, new List<int> { 2, 4 });
            input.Add(2, new List<int> { 3 });
            input.Add(3, new List<int> { 1,7 });
            input.Add(4, new List<int> { 6 });
            input.Add(5, new List<int> { 4 });
            input.Add(6, new List<int> { 7 });
            input.Add(7, new List<int> { 5 });
            input.Add(8, new List<int> { 6, 11 });
            input.Add(9, new List<int> { 8 });
            input.Add(10, new List<int> { 9 });
            input.Add(11, new List<int> { 10,12 });
            input.Add(12, new List<int> { 7, 10 });

            var sccSizes = target.CalucalateSCC(input);

            Assert.IsTrue(sccSizes.Count == 3);
            Assert.IsTrue(sccSizes.Any(sc => sc.Count == 3));
            Assert.IsTrue(sccSizes.Any(sc => sc.Count == 4));
            Assert.IsTrue(sccSizes.Any(sc => sc.Count == 5));
        }
    }
}

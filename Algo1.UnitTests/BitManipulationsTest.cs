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
    public class BitManipulationsTest
    {
        [TestMethod]
        public void CheckBitConversion()
        {
            int a = 29;
            int b = 15;

            int actualResult = BitManipulations.CheckBitConversion(a, b);

            Assert.IsTrue(actualResult == 2);
        }

        [TestMethod]
        public void SwitchOddAndEven()
        {
            int a = 23;

            int actualResult = BitManipulations.SwapOddAndEvenBits(a);

            Assert.IsTrue(actualResult == 43);
        }
    }
}

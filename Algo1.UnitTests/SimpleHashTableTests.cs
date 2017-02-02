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
    public class SimpleHashTableTests
    {
        [TestMethod]
        public void AddAndRetreiveTest()
        {
            SimpleHashTable hashTable = new SimpleHashTable();


            hashTable.Add("hello", "world");

            var retrieved = hashTable.Get("hello");

            Assert.IsTrue(retrieved == "world");
            Assert.IsTrue(hashTable.HasKey("hello"));
        }

        [TestMethod]
        public void MissingKeyTest()
        {
            SimpleHashTable hashTable = new SimpleHashTable();


            hashTable.Add("hello", "world");

            var hasKey = hashTable.HasKey("missing");
            var retrieved = hashTable.Get("missing");

            Assert.IsTrue(retrieved == null);
            Assert.IsFalse(hasKey);
        }
    }
}

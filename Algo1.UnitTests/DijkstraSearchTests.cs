using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algo1.Core;
using System.Linq;

namespace Algo1.UnitTests
{
    /// <summary>
    /// Summary description for DijkstraSearchTests
    /// </summary>
    [TestClass]
    public class DijkstraSearchTests
    {
        [TestMethod]
        public void InitializeGraph()
        {
            // test input
            var line1 = "1 2,1 3,4";
            var line2 = "2 1,1 3,2 4,6";
            var line3 = "3 1,4 2,2 4,3";
            var line4 = "4 2,6 3,3";

            var pathFinder = new DijkstraPathSearch();

            pathFinder.AddNode(AdjacencyItem.ParseNodeInfo(line1));
            pathFinder.AddNode(AdjacencyItem.ParseNodeInfo(line2));
            pathFinder.AddNode(AdjacencyItem.ParseNodeInfo(line3));
            pathFinder.AddNode(AdjacencyItem.ParseNodeInfo(line4));

            Assert.IsTrue(pathFinder.GraphInfo.Count == 4);
        }

        [TestMethod]
        public void FindShortestPathTest()
        {
            // test input
            var line1 = "1 2,1 3,4";
            var line2 = "2 1,1 3,2 4,6";
            var line3 = "3 1,4 2,2 4,3";
            var line4 = "4 2,6 3,3";

            var pathFinder = new DijkstraPathSearch();

            pathFinder.AddNode(AdjacencyItem.ParseNodeInfo(line1));
            pathFinder.AddNode(AdjacencyItem.ParseNodeInfo(line2));
            pathFinder.AddNode(AdjacencyItem.ParseNodeInfo(line3));
            pathFinder.AddNode(AdjacencyItem.ParseNodeInfo(line4));

            pathFinder.CalculateShortestPath(1);
            Assert.IsTrue(pathFinder.GraphInfo[0].CurrentCost == 0);
            Assert.IsTrue(pathFinder.GraphInfo[1].CurrentCost == 1);
            Assert.IsTrue(pathFinder.GraphInfo[2].CurrentCost == 3);
            Assert.IsTrue(pathFinder.GraphInfo[3].CurrentCost == 6);
        }
    }
}

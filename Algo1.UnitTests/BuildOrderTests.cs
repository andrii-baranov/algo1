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
    public class BuildOrderTests
    {
        [TestMethod]
        public void TestGraphOrder()
        {
            var inputGraph = new Graph(6);


            // a - 0, b-1,c-2,d-3,e-4,f-5
            inputGraph.AddEdge(5, 0);
            inputGraph.AddEdge(1, 5);
            inputGraph.AddEdge(3, 2);
            inputGraph.AddEdge(0, 3);


            //inputGraph.Projects.Add(
            //    new Project() { Name = "a", PreReqs = new HashSet<string> { "f" } });

            //inputGraph.Projects.Add(
            //    new Project() { Name = "b", PreReqs = new HashSet<string> { "f" } });

            //inputGraph.Projects.Add(
            //       new Project() { Name = "c", PreReqs = new HashSet<string> { "d" } });

            //inputGraph.Projects.Add(
            //    new Project() { Name = "d", PreReqs = new HashSet<string> { "a" } });

            //inputGraph.Projects.Add(
            //    new Project() { Name = "e", PreReqs = new HashSet<string> {  } });

            //inputGraph.Projects.Add(
            //    new Project() { Name = "f", PreReqs = new HashSet<string> {  } });

            var actualResult = BuildOrder.CalculateOrder(inputGraph);

            Assert.IsTrue(actualResult.Count == inputGraph.Nodes.Count);
        }
    }
}

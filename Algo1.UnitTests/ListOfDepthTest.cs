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
    public class ListOfDepthTest
    {
        [TestMethod]
        public void CheckCalc()
        {

            //lvl 1
            Node node = new Node { Value = 1 };

            // lvl 2
            node.LeftChild = new Node { Value = 2 };
            node.RightChild = new Node { Value = 3 };

            // lvl 3
            node.LeftChild.LeftChild = new Node { Value = 4 };
            node.LeftChild.RightChild = new Node { Value = 5 };

            //lvl 3
            node.RightChild.LeftChild = new Node { Value = 6 };

            // lvl 4
            node.RightChild.LeftChild.LeftChild = new Node { Value = 7 };

            var result = DepthCalculator.CalculateDepth(node);

            Assert.IsTrue(result.Count == 4);
            Assert.IsTrue(result[0].Count == 1);
            Assert.IsTrue(result[1].Count == 2);
            Assert.IsTrue(result[2].Count == 3);
            Assert.IsTrue(result[3].Count == 1);


        }


        [TestMethod]
        public void CheckCalcBFS()
        {

            //lvl 1
            Node node = new Node { Value = 1 };

            // lvl 2
            node.LeftChild = new Node { Value = 2 };
            node.RightChild = new Node { Value = 3 };

            // lvl 3
            node.LeftChild.LeftChild = new Node { Value = 4 };
            node.LeftChild.RightChild = new Node { Value = 5 };

            //lvl 3
            node.RightChild.LeftChild = new Node { Value = 6 };

            // lvl 4
            node.RightChild.LeftChild.LeftChild = new Node { Value = 7 };

            var result = DepthCalculator.CalculateDepthViaBFS(node);

            Assert.IsTrue(result.Count == 4);
            Assert.IsTrue(result[0].Count == 1);
            Assert.IsTrue(result[1].Count == 2);
            Assert.IsTrue(result[2].Count == 3);
            Assert.IsTrue(result[3].Count == 1);


        }

        [TestMethod]
        public void CheckIfBalanced()
        {

            //lvl 1
            Node node = new Node { Value = 1 };

            // lvl 2
            node.LeftChild = new Node { Value = 2 };
            node.RightChild = new Node { Value = 3 };

            // lvl 3
            node.LeftChild.LeftChild = new Node { Value = 4 };
            ///     node.LeftChild.RightChild = new Node { Value = 5 };

            //lvl 3
            node.RightChild.LeftChild = new Node { Value = 6 };
            node.RightChild.RightChild = new Node { Value = 66 };

            // lvl 4
            node.RightChild.LeftChild.LeftChild = new Node { Value = 7 };
            node.RightChild.LeftChild.RightChild = new Node { Value = 8 };

            var result = DepthCalculator.CheckIfBalanced(node);

            Assert.IsTrue(result == true);
        }

        [TestMethod]
        public void ValideBSTTest()
        {

            //lvl 1
            Node node = new Node { Value = 1 };

            // lvl 2
            node.LeftChild = new Node { Value = 2 };
            node.RightChild = new Node { Value = 3 };

            // lvl 3
            node.LeftChild.LeftChild = new Node { Value = 4 };

            //lvl 3
            node.RightChild.LeftChild = new Node { Value = 6 };
            node.RightChild.RightChild = new Node { Value = 66 };

            // lvl 4
            node.RightChild.LeftChild.LeftChild = new Node { Value = 7 };
            node.RightChild.LeftChild.RightChild = new Node { Value = 8 };

            var result = DepthCalculator.RunValideBST(node);

            Assert.IsTrue(result == false);
        }


        [TestMethod]
        public void ValideBSTTest2()
        {

            //lvl 1
            Node node = new Node { Value = 8 };

            // lvl 2
            node.LeftChild = new Node { Value = 3 };
            node.RightChild = new Node { Value = 10 };

            // lvl 3
            node.LeftChild.LeftChild = new Node { Value = 1 };
            node.LeftChild.RightChild = new Node { Value = 6 };

            node.LeftChild.RightChild.LeftChild = new Node { Value = 4 };
            node.LeftChild.RightChild.RightChild = new Node { Value = 7 };


            //lvl 3
            node.RightChild.RightChild = new Node { Value = 14 };

            // lvl 4
            node.RightChild.RightChild.LeftChild = new Node { Value = 13 };

            var result = DepthCalculator.RunValideBST(node);

            Assert.IsTrue(result == true);
        }


        [TestMethod]
        public void FindSuccessTest()
        {

            //lvl 1
            Node node = new Node { Value = 1 };

            // lvl 2
            node.LeftChild = new Node { Value = 2, Parent = node };
            node.RightChild = new Node { Value = 3, Parent = node };

            // lvl 3
            node.LeftChild.LeftChild = new Node { Value = 4, Parent = node.LeftChild };
            node.LeftChild.RightChild = new Node { Value = 5, Parent = node.LeftChild };

            // lvl 4
            node.LeftChild.RightChild.LeftChild = new Node { Value = 6, Parent = node.LeftChild.RightChild };
            node.LeftChild.RightChild.RightChild = new Node { Value = 7, Parent = node.LeftChild.RightChild };


            var r1 = DepthCalculator.FindInOrderSuccessor(node);
            var r2 = DepthCalculator.FindInOrderSuccessor(node.LeftChild);
            var r3 = DepthCalculator.FindInOrderSuccessor(node.LeftChild.RightChild);
            var r4 = DepthCalculator.FindInOrderSuccessor(node.LeftChild.RightChild.RightChild);

            Assert.IsTrue(r1.Value == 3);
            Assert.IsTrue(r2.Value == 6);
            Assert.IsTrue(r3.Value == 7);
            Assert.IsTrue(r4.Value == 1);
        }

        [TestMethod]
        public void FindCommonAncestorTest()
        {
            //lvl 1
            Node node = new Node { Value = 1 };

            // lvl 2
            node.LeftChild = new Node { Value = 2, Parent = node };
            node.RightChild = new Node { Value = 3, Parent = node };

            // lvl 3
            node.LeftChild.LeftChild = new Node { Value = 4, Parent = node.LeftChild };
            node.LeftChild.RightChild = new Node { Value = 5, Parent = node.LeftChild };

            // lvl 4
            node.LeftChild.LeftChild.LeftChild = new Node { Value = 6, Parent = node.LeftChild.LeftChild };
            node.LeftChild.LeftChild.RightChild = new Node { Value = 7, Parent = node.LeftChild.LeftChild };

            node.LeftChild.RightChild.LeftChild = new Node { Value = 8, Parent = node.LeftChild.RightChild };
            node.LeftChild.RightChild.RightChild = new Node { Value = 9, Parent = node.LeftChild.RightChild };


            var common1 = DepthCalculator.FindFirstCommonAncestor(node.LeftChild, node.RightChild);
            var common2 = DepthCalculator.FindFirstCommonAncestor(node.LeftChild, node.LeftChild.RightChild);
            var common3 = DepthCalculator.FindFirstCommonAncestor(
                node.LeftChild.LeftChild, node.RightChild);
            var common4 = DepthCalculator.FindFirstCommonAncestor(
                node.LeftChild.LeftChild, node.LeftChild.RightChild.RightChild);

            var common5 = DepthCalculator.FindFirstCommonAncestor(
               node.LeftChild.RightChild, node.LeftChild.RightChild.RightChild);

            Assert.IsTrue(common1.Value == 1);
            Assert.IsTrue(common2.Value == 1);
            Assert.IsTrue(common3.Value == 1);
            Assert.IsTrue(common4.Value == 2);
            Assert.IsTrue(common5.Value == 2);


        }

        [TestMethod]
        public void FindCommonAncestorTestViaDFS()
        {
            //lvl 1
            Node node = new Node { Value = 1 };

            // lvl 2
            node.LeftChild = new Node { Value = 2, Parent = node };
            node.RightChild = new Node { Value = 3, Parent = node };

            // lvl 3
            node.LeftChild.LeftChild = new Node { Value = 4, Parent = node.LeftChild };
            node.LeftChild.RightChild = new Node { Value = 5, Parent = node.LeftChild };

            // lvl 4
            node.LeftChild.LeftChild.LeftChild = new Node { Value = 6, Parent = node.LeftChild.LeftChild };
            node.LeftChild.LeftChild.RightChild = new Node { Value = 7, Parent = node.LeftChild.LeftChild };

            node.LeftChild.RightChild.LeftChild = new Node { Value = 8, Parent = node.LeftChild.RightChild };
            node.LeftChild.RightChild.RightChild = new Node { Value = 9, Parent = node.LeftChild.RightChild };


            var common1 = DepthCalculator.FindCommonAncestorViaDFS(node, node.LeftChild, node.RightChild);
            var common2 = DepthCalculator.FindCommonAncestorViaDFS(node, node.LeftChild, node.LeftChild.RightChild);
            var common3 = DepthCalculator.FindCommonAncestorViaDFS(
                node, node.LeftChild.LeftChild, node.RightChild);
            var common4 = DepthCalculator.FindCommonAncestorViaDFS(
                node, node.LeftChild.LeftChild, node.LeftChild.RightChild.RightChild);

            var common5 = DepthCalculator.FindCommonAncestorViaDFS(
               node, node.LeftChild.RightChild, node.LeftChild.RightChild.RightChild);

            Assert.IsTrue(common1.Value == 1);
            Assert.IsTrue(common2.Value == 1);
            Assert.IsTrue(common3.Value == 1);
            Assert.IsTrue(common4.Value == 2);
            Assert.IsTrue(common5.Value == 2);
        }

        [TestMethod]
        public void TraverseBST()
        {
            //lvl 1
            Node node = new Node { Value = 1 };

            // lvl 2
            node.LeftChild = new Node { Value = 2, Parent = node };
            node.RightChild = new Node { Value = 3, Parent = node };


            var result = DepthCalculator.BSTTraversal(node);

            Assert.IsTrue(result.Count == 2);
        }

        [TestMethod]
        public void TraverseBST2()
        {
            //lvl 1
            Node node = new Node { Value = 3 };

            // lvl 2
            node.LeftChild = new Node { Value = 2, Parent = node };
            node.RightChild = new Node { Value = 5, Parent = node };

            node.RightChild.LeftChild = new Node { Value = 4, Parent = node };
            node.RightChild.RightChild = new Node { Value = 7, Parent = node };

            var result = DepthCalculator.BSTTraversal(node);

            Assert.IsTrue(result.Count == 4);
        }

        [TestMethod]
        public void TestWaiving()
        {
            List<int> first = new List<int>() { 2, 3 };
            List<int> second = new List<int>() { 6, 5};

            List<List<int>> results = new List<List<int>>();
            List<int> prefix = new List<int> { 4 };

            DepthCalculator.MyWaive(first, second, ref results, prefix);
        }


        [TestMethod]
        public void SubtreeCheck()
        {
            var treeA = CreateSubTree();

            var rootB = new Node { Value = 5 };
            rootB.LeftChild = new Node { Value = 8, Parent = rootB };
            rootB.RightChild = new Node { Value = 9, Parent = rootB };

            var result = DepthCalculator.CheckSubtree(treeA, rootB);

            Assert.IsTrue(result == true);
        }



        [TestMethod]
        public void CountPathsWithSums_Test()
        {
            var rootB = new Node { Value = 1 };
            rootB.LeftChild = new Node { Value = 6, Parent = rootB };
            rootB.RightChild = new Node { Value =4, Parent = rootB };
            rootB.RightChild.LeftChild = new Node { Value = 2, Parent = rootB.RightChild };

            Assert.IsTrue(DepthCalculator.CountPathsWithSums(rootB, 7, new List<int>()) == 2);
            Assert.IsTrue(DepthCalculator.CountPathsWithSums(rootB, 6, new List<int>()) == 2);
            Assert.IsTrue(DepthCalculator.CountPathsWithSums(rootB, 4, new List<int>()) == 1);
        }

        public Node CreateSubTree()
        {
            //lvl 1
            Node node = new Node { Value = 1 };

            // lvl 2
            node.LeftChild = new Node { Value = 2, Parent = node };
            node.RightChild = new Node { Value = 3, Parent = node };

            // lvl 3
            node.LeftChild.LeftChild = new Node { Value = 4, Parent = node.LeftChild };
            node.LeftChild.RightChild = new Node { Value = 5, Parent = node.LeftChild };

            // lvl 4
            node.LeftChild.LeftChild.LeftChild = new Node { Value = 6, Parent = node.LeftChild.LeftChild };
            node.LeftChild.LeftChild.RightChild = new Node { Value = 7, Parent = node.LeftChild.LeftChild };

            node.LeftChild.RightChild.LeftChild = new Node { Value = 8, Parent = node.LeftChild.RightChild };
            node.LeftChild.RightChild.RightChild = new Node { Value = 9, Parent = node.LeftChild.RightChild };

            return node;
        }
    }
}

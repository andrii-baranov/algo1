using System;
using System.Collections.Generic;

namespace Algo1.Core
{
    public class DepthCalculator
    {
        public static List<List<Node>> CalculateDepthViaBFS(Node rootNode)
        {
            List<List<Node>> result = new List<List<Node>>();

            var current = new List<Node>();

            current.Add(rootNode);


            while (current.Count > 0)
            {
                result.Add(current);

                var parents = current;

                current = new List<Node>();

                foreach (var node in parents)
                {
                    if (node.LeftChild != null)
                    {
                        current.Add(node.LeftChild);
                    }

                    if (node.RightChild != null)
                    {
                        current.Add(node.RightChild);
                    }
                }
            }

            return result;
        }

        private static void VisitNodeBFS(Node node, int level, List<List<int>> result)
        {
        }

        public static List<List<int>> CalculateDepth(Node rootNode)
        {
            var result = new List<List<int>>();

            VisitNode(rootNode, 0, result);

            return result;
        }

        private static void VisitNode(Node node, int level, List<List<int>> result)
        {
            if (node == null)
            {
                return;
            }

            if (level >= result.Count)
            {
                result.Add(new List<int>());
            }

            result[level].Add(node.Value);

            VisitNode(node.LeftChild, level + 1, result);
            VisitNode(node.RightChild, level + 1, result);
        }


        public static bool CheckIfBalanced(Node root)
        {
            bool result = true;


            NodeHight(root, ref result);

            return result;
        }

        private static int NodeHight(Node node, ref bool isBalanced)
        {
            if (node == null)
            {
                return 0;
            }


            int leftLevels = NodeHight(node.LeftChild, ref isBalanced);
            int rightLevels = NodeHight(node.RightChild, ref isBalanced);

            if (Math.Abs(leftLevels - rightLevels) > 1)
            {
                isBalanced = false;
            }

            if (leftLevels >= rightLevels)
            {
                return leftLevels + 1;
            }
            else
            {
                return rightLevels + 1;
            }

        }


        public static bool ValideBST(Node root)
        {
            bool result = true;


            CheckIfNodeBST(root, ref result);

            return result;
        }


        public static bool RunValideBST(Node root)
        {
            return RunValidateBST(root, int.MinValue, int.MaxValue);
        }

        private static bool RunValidateBST(Node root, int min, int max)
        {
            if (root == null)
            {
                return true;
            }

            if (root.Value < min || root.Value >= max)
            {
                return false;
            }

            return RunValidateBST(root.LeftChild, min, root.Value)
                && RunValidateBST(root.RightChild, root.Value, max);
        }

        private static int CheckIfNodeBST(Node root, ref bool isBst)
        {
            if (root == null)
            {
                return -1;
            }

            var leftMax = CheckIfNodeBST(root.LeftChild, ref isBst);
            var rightMax = CheckIfNodeBST(root.RightChild, ref isBst);
         

            if (leftMax != -1 && leftMax > root.Value)
            {
                isBst = false;

                return -1;

                if (rightMax != -1 && leftMax > rightMax)
                {
                    isBst = false;

                    return -1;
                }
            }

            if (rightMax != -1 && root.Value >= rightMax)
            {
                isBst = false;

                return -1;
            }

            return rightMax > root.Value ? rightMax : root.Value;
         

            //if (root.LeftChild != null)
            //{
            //    if (root.LeftChild.Value >= root.Value)
            //    {
            //        return false;
            //    }

            //    if (root.RightChild != null && root.LeftChild.Value >= root.RightChild.Value)
            //    {
            //        return false;
            //    }
            //}

            //if (root.RightChild != null)
            //{
            //    if (root.RightChild.Value < root.Value)
            //    {
            //        return false;
            //    }

            //    if (root.RightChild.Value > maxVal)
            //    {
            //        maxVal = root.RightChild.Value;
            //    }
            //}
        }

        public static Node FindInOrderSuccessor(Node currentNode)
        {
            List<Node> visitedNodes = new List<Node>();
            visitedNodes.Add(currentNode);

            if (currentNode.RightChild != null)
            {
                //check right subtree
                var fromRightChild = DrillDown(currentNode.RightChild);

                return fromRightChild;
                     
            }
            else if (currentNode.Parent != null)
            {
                // check parent level
                var fromParent = BubbleUp(currentNode.Parent, currentNode);

                return fromParent;
            }

            return null;
        }

        private static Node DrillDown(Node currentNode)
        {
            if (currentNode == null)
            {
                return null;
            }

            var left = DrillDown(currentNode.LeftChild);

            if (left != null)
            {
                return left;
            }
            else
            {
                return currentNode;
            }
        }

        
        private static Node BubbleUp(Node current, Node target)
        {
            if (current.LeftChild == target)
            {
                //var fromRight = DrillDown(current.RightChild);

                //if (fromRight != null)
                //{
                //    return fromRight;
                //}
                //else
                //{
                    return current;
                //}
            }
            else
            {
                return  BubbleUp(current.Parent, current);
            }
        }


        public static Node FindFirstCommonAncestor(Node first, Node second)
        {
            // variants, nodes in differt subtrees
            // one node is child of another node

            // N^2
            // increase first parent by one and bubble up for second

            bool isFound = false;

            var secondParent = second.Parent;
            var firstParent = first.Parent;

            bool found = false;

            while (!found)
            {
                if (second.Parent == firstParent)
                {
                    return second.Parent;
                }

                while (secondParent != null)
                {
                    if (first == secondParent)
                    {
                        return first.Parent;
                    }

                    if (firstParent == secondParent)
                    {
                        return secondParent;
                    }

                    if (secondParent.Parent != null)
                    {
                        secondParent = secondParent.Parent;
                    }
                    else
                    {
                        break;
                    }
                }

                if (firstParent == secondParent)
                {
                    return firstParent;
                }

                if (firstParent.Parent != null)
                {
                    firstParent = firstParent.Parent;
                }
            }

            return null;
        }

        public static Node FindCommonAncestorViaDFS(Node root, Node first, Node second)
        {
            bool foundFirst = false;
            bool foundSecond = false;
            Node common = null;
            FindAncestorRunner(root, first, second, ref foundFirst,ref foundSecond, ref common);

            return common;
        }

        public static int FindAncestorRunner(Node current, Node first, Node second, ref bool foundLeft, ref bool foundRight,ref Node common)
        {
            if (current == null)
            {
                return 0;
            }

            var numInLeft = FindAncestorRunner(current.LeftChild, first, second, ref foundLeft, ref foundRight, ref common);
            var numInRight = FindAncestorRunner(current.RightChild, first, second, ref foundLeft, ref foundRight, ref common);
            
            if (numInLeft + numInRight == 2)
            {
                common = current;
                // stop search
                return 0;
            }

            if (current == first)
            {
                return 1 + numInRight + numInLeft;
            }

            if (current == second)
            {
                return 1 + numInRight + numInLeft;
            }
            else
            {
                return numInLeft + numInRight;
            }

        }


        public static List<List<int>> BSTTraversal(Node root)
        {
            return RevisitTree(root);
        }

        private static List<List<int>> RevisitTree(Node current)
        {
            if (current == null)
            {
                var list = new List<List<int>>();

                return list;
            }

            var leftVars = RevisitTree(current.LeftChild);
            var rightVars = RevisitTree(current.RightChild);

            var united = new List<List<int>>();

           // composing TOP/Left/right composition
           foreach(var l in leftVars)
            {
                var newComp = new List<int>();
                newComp.Add(current.Value);

                newComp.AddRange(l);
                

                foreach(var r in rightVars)
                {
                    var tLR = new List<int>(newComp);
                    tLR.AddRange(r);

                    united.Add(tLR);
                }
            }

            //composing TOP/Right/left compositions
            foreach (var r in rightVars)
            {
                var newComp = new List<int>();
                newComp.Add(current.Value);

                newComp.AddRange(r);


                foreach (var l in leftVars)
                {
                    var tLR = new List<int>(newComp);
                    tLR.AddRange(l);

                    united.Add(tLR);
                }
            }

            if (united.Count == 0)
            {
                united = new List<List<int>>();
                united.Add(new List<int>());
                united[0].Add(current.Value);
            }

            return united;
        }
        private static List<int> Clone(List<int> list)
        {
            return new List<int>(list);
        }

        public static void WaiveLists(List<int> first, List<int> second,
            ref List<List<int>> results, List<int> prefix)
        {
            if (first.Count == 0 || second.Count == 0)
            {
                List<int> currentRes = new List<int>(prefix);

                currentRes.AddRange(first);
                currentRes.AddRange(second);

                results.Add(currentRes);

                return;
            }

            int headFirst = first[0];
            first.RemoveAt(0);
            prefix.Add(headFirst);
            WaiveLists(first, second,ref results, prefix);
            prefix.RemoveAt(prefix.Count - 1);
            first.Insert(0, headFirst);



            int headSecond = second[0];
            second.RemoveAt(0);
            prefix.Add(headSecond);
            WaiveLists(first, second, ref results, prefix);
            prefix.RemoveAt(prefix.Count - 1);
            second.Insert(0, headSecond);
        }


        public static void MyWaive(List<int> a, List<int> b, ref List<List<int>> result, List<int> prefix)
        {
            if (a.Count == 0 || b.Count == 0)
            {
                var currentResult = new List<int>(prefix);
                currentResult.AddRange(a);
                currentResult.AddRange(b);


                result.Add(currentResult);
                return;
            }


            int aFirst = a[0];
            a.RemoveAt(0);
            prefix.Add(aFirst);
            MyWaive(a, b, ref result, prefix);
            prefix.RemoveAt(prefix.Count - 1);
            a.Insert(0, aFirst);



            int bFirst = b[0];
            b.RemoveAt(0);
            prefix.Add(bFirst);
            MyWaive(a, b, ref result, prefix);
            prefix.RemoveAt(prefix.Count - 1);
            b.Insert(0, bFirst);
        }


        public static bool CheckSubtree(Node rootA, Node rootB)
        {

            // steps:
            // 1) find rootB in tree A
            // 2) iterate thru rootB and check if childs are similar

            return FindNodeAndCompare(rootA, rootB);
        }

        private static bool FindNodeAndCompare(Node root, Node nodeToFind)
        {
            if (root == null)
            {
                return false;
            }

            if (root.Value == nodeToFind.Value && CompareSubTrees(root, nodeToFind))
            {
                return true;
            }

            var fromLeft = FindNodeAndCompare(root.LeftChild, nodeToFind);
            var fromRight = FindNodeAndCompare(root.RightChild, nodeToFind);

            return fromLeft || fromRight;
        }

        private static bool CompareSubTrees(Node a, Node b)
        {
            if (a == null && b == null)
            {
                return true;
            }

            if (a == null && b!= null)
            {
                return false;
            }

            if (a != null && b == null)
            {
                return false;
            }

            if (a.Value == b.Value)
            {
                var leftEqual = CompareSubTrees(a.LeftChild, b.LeftChild);
                var rightEqual = CompareSubTrees(a.RightChild, b.RightChild);

                return leftEqual && rightEqual;
            }
            else
            {
                return false;
            }
        }

        public static int CountPathsWithSums(Node root, int targetSum, List<int> passedItems)
        {
            if (root == null)
            {
                return 0;
            }

            passedItems.Add(root.Value);

            int result = 0;
            int currentSum = 0;
            for (int i = passedItems.Count - 1; i >= 0; i--)
            {
                currentSum += passedItems[i];
                if (currentSum == targetSum)
                {
                    result++;
                    break;
                }
            }


            var leftSum = CountPathsWithSums(root.LeftChild, targetSum, new List<int> (passedItems));

            var rightSum = CountPathsWithSums(root.RightChild, targetSum, new List<int>(passedItems));

            return result + leftSum + rightSum;
        }
    }
        public class Node
        {
            public int Value { get; set; }

            public Node LeftChild { get; set; }

            public Node RightChild { get; set; }

            public Node Parent { get; set; }
        }
}

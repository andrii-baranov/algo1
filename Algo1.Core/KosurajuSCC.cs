using System.Collections.Generic;
using System.Linq;

namespace Algo1.Core
{
    public class KosurajuSCC
    {
        public List<HashSet<int>> CalucalateSCC(Dictionary<int, List<int>> adjacencyList)
        {
            Dictionary<int, int> finishTimes = new Dictionary<int, int>();
            List<HashSet<int>> scc = new List<HashSet<int>>();
            HashSet<int> visited = new HashSet<int>();
            Stack<int> stack = new Stack<int>();
            // # of nodes processed so far
            int t = 0;


            // step 1: reverse graph
            var reverseGraph = TraverseGraph(adjacencyList).OrderByDescending(c => c.Key).ToDictionary(c => c.Key, c => c.Value);

            // step 2: first DFS loop over reversed graph
            foreach (var node in reverseGraph)
            {
                if (!visited.Contains(node.Key))
                {
                    stack.Push(node.Key);

                    while (stack.Count > 0)
                    {
                        var current = stack.Peek();

                        visited.Add(current);

                        if (!IsAllExplored(reverseGraph, current, visited))
                        {
                            if (reverseGraph.ContainsKey(current))
                            {
                                foreach (var item in reverseGraph[current])
                                {
                                    if (!visited.Contains(item))
                                    {
                                        stack.Push(item);
                                    }
                                }
                            }
                        }
                        else
                        {
                            stack.Pop();
                            t++;

                            finishTimes[current] = t;
                        }

                    }

                }
            }

            // step 3: second DFS loop over original graph
            var order = finishTimes.OrderByDescending(c => c.Value).Select(c => c.Key);
            visited.Clear();


            foreach (var item in order)
            {
                if (visited.Contains(item))
                {
                    continue;
                }
                HashSet<int> currentSCC = new HashSet<int>();
                var key = item;

                //   DFSUtil(traversed, key, visited, currentSCC);

                Stack<int> nodesToVisit = new Stack<int>();
                nodesToVisit.Push(key);

                while (nodesToVisit.Count > 0)
                {
                    var currentKey = nodesToVisit.Pop();
                    if (!visited.Contains(currentKey))
                    {
                        visited.Add(currentKey);
                        currentSCC.Add(currentKey);

                        if (adjacencyList.ContainsKey(currentKey))
                        {
                            var connectedVertices = adjacencyList[currentKey];

                            foreach (var vertice in connectedVertices)
                            {
                                if (!visited.Contains(vertice))
                                {
                                    nodesToVisit.Push(vertice);
                                }
                            }
                        }
                    }
                }


                if (currentSCC.Count != 0)
                {
                    scc.Add(currentSCC);
                }
            }

            return scc;
        }

        private bool IsAllExplored(Dictionary<int, List<int>> adjacencyList, int key, HashSet<int> explored)
        {
            if (adjacencyList.ContainsKey(key))
            {
                foreach (var item in adjacencyList[key])
                {
                    if (!explored.Contains(item))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        // Correct but fails on big data sets due to stack limits
        private void DFSUtil(Dictionary<int, List<int>> adjacencyList, int key,
         HashSet<int> visited, HashSet<int> currentSCC)
        {
            if (!visited.Contains(key))
            {
                visited.Add(key);
                currentSCC.Add(key);


                if (adjacencyList.ContainsKey(key))
                {
                    var connectedVertices = adjacencyList[key];

                    foreach (var vertice in connectedVertices)
                    {
                        if (!visited.Contains(vertice))
                        {
                            DFSUtil(adjacencyList, vertice, visited, currentSCC);
                        }
                    }
                }
            }
        }

        // Correct but fails on big data sets due to stack limits
        private void VisitVertex(Dictionary<int, List<int>> adjacencyList, int key, 
            HashSet<int> visited,
            Stack<int> stack)
        {
            if (!visited.Contains(key))
            {
                visited.Add(key);


                if (adjacencyList.ContainsKey(key))
                {
                    var connectedVertices = adjacencyList[key];

                    foreach (var vertice in connectedVertices)
                    {
                        if (!visited.Contains(vertice))
                        {
                            VisitVertex(adjacencyList, vertice, visited, stack);
                        }
                    }
                }

                stack.Push(key);
            }

            //if (!visited.Contains(key))
            //{
            //    visited.Add(key);


            //    if (adjacencyList.ContainsKey(key))
            //    {
            //        var connectedVertices = adjacencyList[key];

            //        foreach (var vertice in connectedVertices)
            //        {
            //            if (!visited.Contains(vertice))
            //            {
            //                VisitVertex(adjacencyList, vertice, visited, stack);
            //            }
            //        }
            //    }

            //    stack.Push(key);
            //}
        }

        public Dictionary<int, List<int>> TraverseGraph(Dictionary<int, List<int>> adjacencyList)
        {
            Dictionary<int, List<int>> result = new Dictionary<int, List<int>>();
            int edgesCount =0;
            foreach(var vertice in adjacencyList)
            {
                var edges = vertice.Value;
                if (edges != null)
                {
                    foreach (var edgeHead in edges)
                    {
                        if (!result.ContainsKey(edgeHead))
                        {
                            result[edgeHead] = new List<int>();
                        }

                        result[edgeHead].Add(vertice.Key);
                        edgesCount++;
                    }
                }
            }

            return result;
        }
    }
}

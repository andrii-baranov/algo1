using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo1.Core
{
    public class KargerMinCut
    {
        private List<List<int>> _graph;

        private int _currentBestMinCut;
        public KargerMinCut(List<List<int>> input)
        {
            //todo validation and edge cases?
            _graph = input;
            _currentBestMinCut = int.MaxValue;
        }

        public int CalculateMinCutRepetative(int attemptsCount = 1)
        {
            
            for (int i =0; i <=attemptsCount; i++)
            {
                var workingCopy = CloneWorkingGraph(_graph);


                var minCut = CalculateMinCut(workingCopy);

                if (_currentBestMinCut > minCut)
                {
                    _currentBestMinCut = minCut;
                }
            }

            return _currentBestMinCut;
        }

        private List<List<int>> CloneWorkingGraph(List<List<int>> graph)
        {
            var clone = new List<List<int>>();
            for (int i=0; i < graph.Count; i++)
            {
                var row = new List<int>();
                for (int j = 0; j < graph[i].Count; j++)
                {
                    row.Add(graph[i][j]);
                }

                clone.Add(row);
            }

            return clone;
        }


        //1 attempt min cut
        public int CalculateMinCut(List<List<int>> graph)
        {
            bool hasNodes = true;
            while (hasNodes)
            {
                var nodesToMerge = GetNextNodesToMerge(graph);

                if (nodesToMerge != null)
                {
                    MergeNodes(graph, nodesToMerge[0], nodesToMerge[1]);
                }
                else
                {
                    var firstNode = graph.FirstOrDefault(n => n.Count > 0);
                    var firstIndex = graph.IndexOf(firstNode);

                    // skiping self ref
                    return firstNode.Count(item => item != firstIndex);
                }
            }

            return _currentBestMinCut;
        }

        // simple non optimized merge
        private void MergeNodes(List<List<int>> graph, int firstNode, int secondNode)
        {
            List<int> secondNodeEdgePoints = graph[secondNode];

            for (int i = 0; i < secondNodeEdgePoints.Count; i++)
            {

                var connectedNode = graph[secondNodeEdgePoints[i]];

                for (int j =0; j<connectedNode.Count; j++)
                {
                    if (connectedNode[j] == secondNode)
                    {
                        connectedNode[j] = firstNode;
                    }
                }
            }

             // merging two nodes to first node
            var secondNodeEdges = graph[secondNode];


            for (int i = 0; i < secondNodeEdges.Count; i++)
            {
                // ignoring self refernces
                if (secondNodeEdges[i] != firstNode)
                {
                    graph[firstNode].Add(secondNodeEdges[i]);
                }
            }

            graph[firstNode] = graph[firstNode].Where(item => item != firstNode).ToList();

            // clearing second node because it was merged to first now
            graph[secondNode].Clear();
        }

        private int[] GetNextNodesToMerge(List<List<int>> graph)
        {
            int firstIndex = 0;
            int secondIndex = 0;

            var candidatesToMerge = new List<int>();

            for (int i = 0; i< graph.Count; i++)
            {
                if (graph[i].Count != 0)
                {
                    candidatesToMerge.Add(i);
                }
            }

            if (candidatesToMerge.Count <= 2)
            {
                // we are done
                return null;
            }
            bool secondFound = false;
            while (!secondFound)
            {

                var random = new Random(DateTime.Now.Millisecond);


                var first = random.Next(0, candidatesToMerge.Count);
                firstIndex = candidatesToMerge[first];


                var secondNode = random.Next(0, graph[firstIndex].Count);

               
               if (secondNode != first)
                {
                    secondFound = true;
                    secondIndex = graph[firstIndex][secondNode];
                }
            }

            return new[] { firstIndex, secondIndex };
        }
    }
}

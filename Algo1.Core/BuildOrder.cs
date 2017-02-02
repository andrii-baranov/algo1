using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo1.Core
{
    public class BuildOrder
    {
        public static List<int> CalculateOrder(Graph graph)
        {
            List<int> result = new List<int>();

            Stack<int> availableNodes = new Stack<int>();
            for (int i = 0; i < graph.Nodes.Count; i++)
            {
                if (graph.Dependencies[i].Count == 0)
                {
                    availableNodes.Push(i);
                }
            }

            while (availableNodes.Count > 0)
            {
                int currentNode = availableNodes.Pop();
                result.Add(currentNode);

                // edges that start at current Node
                var nodesStartFromCurrent = graph.Edges[currentNode].ToArray();

                //for each node m with an edge e from n to m do
                //remove edge e from the graph
                for (int i = 0; i < nodesStartFromCurrent.Length; i++)
                {
                    var conNode = nodesStartFromCurrent[i];
                    // edge current -> i

                    // drop dependency on currently processed node
                    graph.Dependencies[conNode].Remove(currentNode);
                    graph.Edges[currentNode].Remove(conNode);

                    // i does not have any dependencies
                    if (graph.Dependencies[conNode].Count == 0)
                    {
                        availableNodes.Push(conNode);
                    }
                }
            }

            if (result.Count < graph.Nodes.Count)
            {
                return null;
            }

            return result;
        }
    }

    public class Graph
    {
        public List<int> Nodes { get; set; }
        public List<List<int>> Dependencies { get; set; } = new List<List<int>>();

        public List<List<int>> Edges { get; set; } = new List<List<int>>();
        public Graph(int nodes)
        {
            Nodes = new List<int>();
            for (int i = 0; i < nodes; i++)
            {
                Nodes.Add(i);
                Dependencies.Add(new List<int>());
                Edges.Add(new List<int>());
            }
        }

        public void AddEdge(int start, int end)
        {
            Dependencies[end].Add(start);
            Edges[start].Add(end);
        }
    }


    public class Project
    {
        public string Name { get; set; }
    }
}

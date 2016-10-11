using System;
using System.Collections.Generic;
using System.Linq;

namespace Algo1.Core
{
    public class DijkstraPathSearch
    {
        List<AdjacencyItem> _graph;
        public DijkstraPathSearch()
        {
            _graph = new List<AdjacencyItem>();
        }

        public void AddNode(AdjacencyItem item)
        {
            _graph.Add(item);
        }

        public void CalculateShortestPath(int startNodeNo)
        {
            var startNode = _graph.FirstOrDefault(n => n.NodeId == startNodeNo);
            if (startNode == null)
            {
                throw new ArgumentException("startNode is not found in the graph");
            }

            startNode.CurrentCost = 0;

            //  List<AdjacencyItem> nodesToVisit = new List<AdjacencyItem>();
            Heap<AdjacencyItem> nodesToVisit = new Heap<AdjacencyItem>(isMinHeap:true);

            nodesToVisit.Insert(startNode);

            while (nodesToVisit.HasItems())
            {
                //todo ugly fix, change with heap structure to enable ordered storage
                var currentNode = nodesToVisit.ExtractRoot();
           
                if (currentNode.IsVisited)
                {
                    continue;
                }
                // nodes numbering starts from 1, need to adjust
                var linkedNodes = _graph[currentNode.NodeId-1].LinkedNodes;

                foreach(var node in linkedNodes)
                {
                    var discoveredNode = _graph[(node.Key) -1];

                    if (!discoveredNode.IsVisited)
                    {
                        if (currentNode.CurrentCost + node.Value < discoveredNode.CurrentCost)
                        {
                            discoveredNode.CurrentCost = currentNode.CurrentCost + node.Value;
                        }

                        nodesToVisit.Insert(discoveredNode);
                    }
                }

                currentNode.IsVisited = true;
            }
            
       
        }

        public List<AdjacencyItem> GraphInfo
        {
            get
            {
                return _graph;
            }
        }
    }

    public class AdjacencyItem : IComparable<AdjacencyItem>
    {
        public AdjacencyItem()
        {
            LinkedNodes = new Dictionary<int, int>();
            CurrentCost = int.MaxValue;
        }
        public int NodeId { get; set; }

        public bool IsVisited { get; set; }

        public int CurrentCost { get; set; }

        public Dictionary<int, int> LinkedNodes { get; set; }

        public static AdjacencyItem ParseNodeInfo(string nodeString)
        {
            var items = nodeString.Split('\t', ' ');

            AdjacencyItem graphItem = new AdjacencyItem();

            graphItem.NodeId = Int32.Parse(items[0]);

            var connectedNodesInfo = items.Skip(1); // skipping nodeId

            foreach (var nodeIndo in connectedNodesInfo)
            {
                if (!string.IsNullOrWhiteSpace(nodeIndo))
                {
                    var splitInfo = nodeIndo.Split(',');
                    var node = Int32.Parse(splitInfo[0]);
                    var cost = Int32.Parse(splitInfo[1]);

                    graphItem.LinkedNodes.Add(node, cost);
                } else
                {

                }
            }

            return graphItem;
        }

        public int CompareTo(AdjacencyItem item)
        {
            if (item == null || this.CurrentCost > item.CurrentCost)
            {
                return 1;
            } else if (CurrentCost == item.CurrentCost)
            {
                return 0;
            }

            return -1;
        }
    }
}

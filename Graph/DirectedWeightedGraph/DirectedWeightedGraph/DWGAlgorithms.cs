using System;
using System.Collections.Generic;

namespace KojakDatastructures
{
    /// <summary>
    /// Extension of the Graph class which contains search algorithms for traversal
    /// </summary>
    public partial class DirectedWeightedGraph
    {
        /// <summary>
        /// Breadth first search for connection between two nodes
        /// </summary>
        /// <returns> Integer representing number of steps to get to end node, -1 if end node not reachable from start node</returns>
        public int BFS(Vertex startNode, Vertex endNode, HashSet<Vertex> visited)
        {
            if (startNode is null || endNode is null) return -1;

            Queue<Vertex> verticesToVisit = new Queue<Vertex>();

            verticesToVisit.Enqueue(startNode);

            int count = 0;

            while (verticesToVisit.Count > 0)
            {
                Vertex current = verticesToVisit.Dequeue();

                if (current is null || visited.Contains(current)) continue;

                visited.Add(current);

                if (current == endNode)
                {
                    return count;
                }
                List<Vertex> neighbors = GetNeighbors(current);
                foreach (Vertex n in neighbors)
                {
                    if (visited.Contains(n)) continue;
                    verticesToVisit.Enqueue(n);
                }

                count++;
            }
            return -1;
        }

        /// <summary>
        /// Depth first search to retrieve shortest path and least amount of steps to reach end node
        ///</summary>
        public int DFS(Vertex startNode, Vertex endNode, HashSet<Vertex> temp, HashSet<Vertex> pathList)
        {
            DFS(startNode, endNode, temp, pathList, true);
            return pathList.Count - 1;

        }

        private void DFS(Vertex startNode, Vertex endNode, HashSet<Vertex> temp, HashSet<Vertex> pathList, bool doNothing)
        {
            if (startNode is null || endNode is null)
            {
                return;
            }
            temp.Add(startNode);

            if (startNode == endNode)
            {
                foreach (Vertex v in temp)
                {
                    pathList.Add(v);
                }
            }
            foreach (Vertex n in GetNeighbors(startNode))
            {
                if (n is null || temp.Contains(n)) continue;
                DFS(n, endNode, temp, pathList, true);
            }
            temp.Remove(startNode);
        }
    }
}
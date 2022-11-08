using System;
using System.Collections.Generic;
using KojakDatastructures.GraphNode;

namespace KojakDatastructures.Graph
{
    /// <summary>
    /// Extension of the Graph class which contains search algorithms for traversal
    /// </summary>
    /// <returns> Integer representing number of steps to get to end node, -1 if end node not reachable from start node</returns>
    public partial class DirectedWeightedGraph
    {
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

                if (current == endNode)
                {
                    visited.Add(current);
                    return count;
                }
                List<Vertex> neighbors = GetNeighbors(current);
                foreach (Vertex n in neighbors)
                {
                    if (visited.Contains(n)) continue;
                    verticesToVisit.Enqueue(n);
                }

                visited.Add(current);

                count++;
            }
            return -1;
        }

        /// <summary>
        /// Depth first search to retrieve shortest path and least amount of steps to reach end node
        ///</summary>
        public int DFS(Vertex startNode, Vertex endNode, HashSet<Vertex> visited)
        {
            int count = DFS(startNode, endNode, visited, true);

            if (visited.Contains(endNode))
            {
                return count;
            }

            return -1;
        }

        private int DFS(Vertex startNode, Vertex endNode, HashSet<Vertex> visited, bool doNothing)
        {

            if (startNode is null || endNode is null)
            {
                return 0;
            }

            visited.Add(startNode);

            if (startNode == endNode) return 1;
            foreach (Vertex n in GetNeighbors(startNode))
            {
                if (n is null || visited.Contains(n)) continue;
                if (n == endNode)
                {
                    visited.Add(n);
                    return 1;
                }
                else return DFS(n, endNode, visited, true) + 1;
            }
            return -1;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace KojakDatastructures
{
    public partial class DirectedWeightedGraph
    {
        // List containing all vertices belonging to the graph
        public List<Vertex> Vertices;
        // Dictionary containing all edge information for vertex = key
        // Edges[key] will return another dictionary containing connected vertices (keys), and weights (values)
        public Dictionary<Vertex, Dictionary<Vertex, int>> Edges;
        public DirectedWeightedGraph()
        {
            Vertices = new List<Vertex>();
            Edges = new Dictionary<Vertex, Dictionary<Vertex, int>>();
        }
        public bool AddVertex(Vertex node)
        {
            // check if there is already a vertex with identical data 
            // do not add new vertex, return false
            if (IsVertex(node)) return false;

            Vertices.Add(node);
            node.Graph = this;
            return true;
        }

        public bool AddEdge(Vertex startNode, Vertex endNode, int weight)
        {
            // validate both nodes belong to the current graph
            if (!IsVertex(startNode) || !IsVertex(endNode)) return false;
            if (IsEdge(startNode, endNode)) return false;

            // check if startnode has any existing edges
            // if not, create new key and add edge
            if (!Edges.ContainsKey(startNode))
            {
                Edges.Add(startNode, new Dictionary<Vertex, int>{
                    { endNode, weight }
                });
            }
            // check if edge does not exist and add edge
            else if (!Edges[startNode].ContainsKey(endNode))
            {
                Edges[startNode].Add(endNode, weight);
            }
            else
            {
                // edge exists
                return false;
            }
            return true;
        }
        /// <returns> List of adjacent vertices or empty list if vertex has no neighbors</returns>
        public List<Vertex> GetNeighbors(Vertex node)
        {
            // Verify node belongs to current graph
            // If node does not belong to current graph or has no edges, return null
            if (!IsVertex(node) || !Edges.Keys.Contains(node)) return new List<Vertex>();
            return Edges[node].Keys.ToList<Vertex>();
        }

        public bool RemoveVertex(Vertex node)
        {
            if (node.Graph != this)
            {
                // node does not belong to current graph
                return false;
            }

            // Remove from vertices list
            Vertices.Remove(node);

            // remove all Edges connected to node
            if (Edges.ContainsKey(node)) Edges.Remove(node);
            foreach (Vertex v in Edges.Keys)
            {
                if (Edges[v].ContainsKey(node)) Edges[v].Remove(node);
            }
            return true;
        }

        public bool RemoveEdge(Vertex startNode, Vertex endNode)
        {
            if (!IsEdge(startNode, endNode)) return false; // edge does not exist

            // edge exists
            // remove edge from dictionary
            Edges[startNode].Remove(endNode);
            return true;
        }

        private bool IsEdge(Vertex startNode, Vertex endNode)
        {
            return Edges.ContainsKey(startNode) && Edges[startNode].ContainsKey(endNode);
        }

        private bool IsVertex(Vertex node)
        {
            IEnumerable<bool> existingNodes = Vertices.Select(v => v.Data == node.Data);
            // Next statement evaluates to the follwing:
            // If the data contained within the node already exists in a node owned by this graph, return true
            // or
            // If the Graph public member of node == current graph, return true
            if (existingNodes.Count() > 0) return existingNodes.Aggregate<bool>((a, b) => a || b) || node.Graph == this;
            // no vertices exist
            return false;
        }
    }
}
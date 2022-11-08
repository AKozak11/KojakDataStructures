using System;
using KojakDatastructures.Graph;

namespace KojakDatastructures.GraphNode
{
    public class Vertex
    {
        public string Data { get; set; }
        public DirectedWeightedGraph Graph { get; set; }
        public Vertex(string data)
        {
            Data = data;
        }
    }
}
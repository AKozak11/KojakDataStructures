using System;

namespace KojakDatastructures
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
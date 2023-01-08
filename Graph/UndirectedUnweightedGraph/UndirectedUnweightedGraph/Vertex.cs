using System;

namespace KojakDatastructures
{
    public class UndirectedVertex
    {
        public int Index { get; set; }
        public UndirectedUnweightedGraph Graph { get; set; }
        public string Data { get; set; }
        public UndirectedVertex(int index, UndirectedUnweightedGraph graph)
        {
            Index = index;
            Graph = graph;
        }
        public UndirectedVertex(string data, int index, UndirectedUnweightedGraph graph)
        {
            Data = data;
            Index = index;
            Graph = graph;
        }
    }

}
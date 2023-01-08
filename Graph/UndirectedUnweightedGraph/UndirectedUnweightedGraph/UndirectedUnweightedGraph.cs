using System.Linq;

namespace KojakDatastructures
{
    public partial class UndirectedUnweightedGraph
    {
        private int _capacity;
        private int _count;
        public int[,] AdjacencyMatrix { get; set; }
        public UndirectedVertex[] Vertices { get; set; }

        /// <param name="capacity">The number of maximum vertices for this graph</param>
        public UndirectedUnweightedGraph(int capacity)
        {
            _count = 0;
            _capacity = capacity;
            Vertices = new UndirectedVertex[_capacity];
            AdjacencyMatrix = new int[_capacity, _capacity];
        }

        public UndirectedVertex AddVertex(string data)
        {
            if (_count >= _capacity)
            {
                // Graph is full
                return null;
            }
            UndirectedVertex node = new UndirectedVertex(data, _count, this);
            Vertices[_count] = node;
            _count++;
            return node;
        }

        public bool AddEdge(int firstIndex, int secondIndex)
        {
            if (EdgeExists(firstIndex, secondIndex))
            {
                // do not modify adjacency list as edge already exists
                return false;
            }

            // Undirected - Add to both rows
            AdjacencyMatrix[firstIndex, secondIndex] = 1;
            AdjacencyMatrix[secondIndex, firstIndex] = 1;
            return true;
        }

        public bool AddEdge(UndirectedVertex firstNode, UndirectedVertex secondNode)
        {
            if (EdgeExists(firstNode.Index, secondNode.Index))
            {
                // do not modify adjacency list as edge already exists
                return false;
            }

            // Undirected - Add to both rows
            AdjacencyMatrix[firstNode.Index, secondNode.Index] = 1;
            AdjacencyMatrix[secondNode.Index, firstNode.Index] = 1;
            return true;
        }

        public UndirectedVertex[] GetNeighbors(int index)
        {
            int length = 0;
            for (int i = 0; i < _count; i++)
            {
                length += AdjacencyMatrix[index, i];
            }

            UndirectedVertex[] nodes = new UndirectedVertex[length];
            int nodesIndex = 0;
            for (int i = 0; i < _count; i++)
            {
                if (AdjacencyMatrix[index, i] == 1)
                {
                    nodes[nodesIndex] = Vertices[i];
                    nodesIndex++;
                }
            }
            return nodes;
        }
        private bool EdgeExists(int firstIndex, int secondIndex)
        {
            return AdjacencyMatrix[firstIndex, secondIndex] == 1;
        }
    }
}
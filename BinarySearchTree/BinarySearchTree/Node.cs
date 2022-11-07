using System;

namespace DataStructures.Tree
{
    public class Node
    {
        public int Data { get; set; }
        public Node? Left { get; set; }
        public Node? Right { get; set; }
        public Node() { }
        public Node(int key)
        {
            Data = key;
        }
    }
}
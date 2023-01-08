using System;
using System.Collections.Generic;

namespace KojakDataStructures
{
    public class BinarySearchTree
    {
        public Node? Root { get; set; }
        public BinarySearchTree() { }
        public BinarySearchTree(Node root)
        {
            Root = root;
        }



        public void Insert(int key)
        {
            if (Root is null)
            {
                Root = new Node(key);
            }
            else
            {
                Insert(Root, key);
            }
        }
        private void Insert(Node node, int key)
        {
            if (node is not null)
            {
                if (node.Data > key)
                {
                    if (node.Left is not null)
                    {
                        Insert(node.Left, key);
                    }
                    else node.Left = new Node(key);
                }
                else if (node.Data < key)
                {
                    if (node.Right is not null)
                    {
                        Insert(node.Right, key);
                    }
                    else node.Right = new Node(key);
                }
                else throw new InvalidOperationException("Duplicate key");
            }
        }
        public bool Remove(int key)
        {
            return Remove(Root, Root, key);
        }
        private bool Remove(Node parent, Node node, int key)
        {
            Node? replacementNode;
            // node doesn't exist
            if (parent is null || node is null)
            {
                return false;
            }

            // find node with value = key by recursively calling Remove after comparing values
            if (node.Data > key) return Remove(node, node.Left, key);
            if (node.Data < key) return Remove(node, node.Right, key);

            // case 0: node does not have any children
            // case 1: node has only left or right child
            if (node.Left is null || node.Right is null)
            {
                replacementNode = node.Left ?? node.Right;
            }
            else
            {
                Node predecessorNode = GetMax(node.Left);
                // remove leaf node to replace target node with
                Remove(Root, Root, predecessorNode.Data);
                replacementNode = new Node(predecessorNode.Data)
                {
                    Left = node.Left,
                    Right = node.Right
                };
            }

            // replace node found in previous steps
            if (node == Root)
            {
                Root = replacementNode;
            }
            else if (parent.Left == node)
            {
                parent.Left = replacementNode;
            }
            else
            {
                parent.Right = replacementNode;
            }
            return true;
        }

        private Node GetMin(Node root)
        {
            if (root is null)
            {
                throw new ArgumentNullException("root");
            }

            if (root.Left is null) return root;

            return GetMin(root.Left);
        }

        private Node GetMax(Node root)
        {
            if (root is null)
            {
                throw new ArgumentNullException("root");
            }

            if (root.Right is null) return root;

            return GetMax(root.Right);
        }

        /// <summary>
        /// Remove node from BST with specific key
        /// </summary>
        /// <param name="key>The key to search for and remove</param>

        /// <summary>
        /// Returns a node with a specified key
        /// </summary>
        public Node Search(int key)
        {
            if (Root is null)
            {
                return default;
            }

            return Search(Root, key);
        }
        private Node Search(Node root, int key)
        {
            if (root is null)
            {
                return default;
            }

            if (root.Data > key)
            {
                return Search(root.Left, key);
            }
            else if (root.Data < key)
            {
                return Search(root.Right, key);
            }

            return root;
        }

        public List<Node> GetKeysPreOrder()
        {
            return GetKeysPreOrder(Root);
        }

        /// <summary>
        /// Return a Pre Ordered list
        /// </summary>
        /// <param name="root">The starting node</param>
        /// <returns>
        /// List of keys in pre-order order
        /// </returns>
        private List<Node> GetKeysPreOrder(Node root)
        {
            List<Node> result = new List<Node>();
            if (root is null)
            {
                return result;
            }

            result.Add(root);
            result.AddRange(GetKeysPreOrder(root.Left));
            result.AddRange(GetKeysPreOrder(root.Right));

            return result;
        }
        public List<Node> GetKeysInOrder()
        {
            return GetKeysInOrder(Root);
        }

        /// <summary>
        /// Return an Ordered list
        /// </summary>
        /// <param name="root">The starting node</param>
        /// <returns>
        /// List of keys in order
        /// </returns>
        private List<Node> GetKeysInOrder(Node root)
        {
            List<Node> result = new List<Node>();
            if (root is null)
            {
                return result;
            }

            result.AddRange(GetKeysInOrder(root.Left));
            result.Add(root);
            result.AddRange(GetKeysInOrder(root.Right));
            return result;
        }

        public int GetHeight()
        {
            return GetHeight(Root);
        }
        private int GetHeight(Node root)
        {
            if (root is null) return 0;

            return Math.Max(GetHeight(root.Left), GetHeight(root.Right)) + 1;
        }
    }
}
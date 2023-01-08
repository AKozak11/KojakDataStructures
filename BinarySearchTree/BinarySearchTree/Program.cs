using System;
using System.Collections.Generic;
using KojakDataStructures;

namespace BSTProgram
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                BinarySearchTree bst = new BinarySearchTree();

                // read list of keys to add to BST, separated by space
                // Console.Write("Enter list of integer values separated by a space.");
                // string rawKeysStr = Console.ReadLine();
                // string rawKeysStr = "79 54 32 44 99 101 4586 9458 83 22 19 75 3000 40054 1055555 7 14 69 999 21";
                string rawKeysStr = "79 54 32 14 69 999 21";
                string[] keys = rawKeysStr.Split(' ');

                for (int i = 0; i < keys.Length; i++)
                {
                    bst.Insert(Int32.Parse(keys[i]));
                }

                List<Node> preOrderNodes = bst.GetKeysPreOrder();
                Console.WriteLine("Print pre order: ");
                foreach (Node n in preOrderNodes)
                {
                    Console.Write(n.Data + " | ");
                }

                List<Node> orderedNodes = bst.GetKeysInOrder();
                Console.WriteLine("\nPrint in order:");
                foreach (Node n in orderedNodes)
                {
                    Console.Write(n.Data + " | ");
                }

                Console.WriteLine($"\nHeight = {bst.GetHeight()}");

                Console.WriteLine($"Remove key <54>: {bst.Remove(54)}");
                orderedNodes = bst.GetKeysInOrder();
                Console.WriteLine("After removal of key <54>: ");
                foreach (Node n in orderedNodes)
                {
                    Console.Write(n.Data + " | ");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during processing {ex}");
            }
        }
    }
}
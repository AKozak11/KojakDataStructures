using System;
using System.Collections.Generic;

namespace KojakDataStructures
{
    public class FenwickTree
    {
        private List<int> _arr;
        public int[] bitArr;
        private int _n;
        public FenwickTree(List<int> arr)
        {
            _arr = arr;
            _n = _arr.Count + 1;
            bitArr = new int[_n];
            // populate binary indewxed tree
            PopulateTree();
        }

        private void PopulateTree()
        {
            // iterate and sort unindexed array
            for (int i = 0; i < _arr.Count; i++) UpdateTree(i, _arr[i]);
        }
        private void UpdateTree(int index, int value)
        {
            index = index + 1;

            // update all affected nodes
            while (index <= _n)
            {
                bitArr[index] += value;

                // get next affected node
                index += index & (-index);
            }
        }
        public int GetSum(int startIndex, int endIndex)
        {
            // add 1 to account for bit 1 based indexing
            endIndex += 1;
            int total = 0;

            while (endIndex > 0)
            {
                total += bitArr[endIndex];

                // get parent node
                endIndex -= endIndex & (-endIndex);
            }
            
            while (startIndex > 0)
            {
                total -= bitArr[startIndex];

                startIndex -= startIndex & (-startIndex);
            }

            return total;
        }
        public void UpdateValue(int index, int value)
        {
            _arr[index] += value;
            UpdateTree(index, value);
        }
    }
}
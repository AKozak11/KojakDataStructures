using System.Collections.Generic;

namespace KojakDatastructures
{
    public partial class UndirectedUnweightedGraph
    {
        /// <summary>
        /// Depth first search to find connection between two nodes.
        ///</summary>
        /// <param name="pathList"> List to store the path, if found. Argument needs to be an empty list. This list may contain multiple entries if more than one path is found.</param>
        /// <returns> The number of paths found between <param name="startIndex"></param> and <param name="endIndex"></param> or -1 if none.</returns>
        public int UndirectedDFS(int startIndex, int endIndex, List<List<UndirectedVertex>> pathList)
        {
            bool[] isVisited = new bool[_count];
            List<int> countList = new List<int>();
            List<UndirectedVertex> tempList = new List<UndirectedVertex>();
            UndirectedDFS(startIndex, endIndex, isVisited, tempList, pathList);
            return pathList.Count > 0 ? pathList.Count : -1;
        }
        // templist is used to keep track of the current path
        // if a successful path is found, a new entry is added to pathlist
        // with the contents of templist
        private void UndirectedDFS(int startIndex, int endIndex, bool[] isVisited, List<UndirectedVertex> tempList, List<List<UndirectedVertex>> pathList)
        {

            if (Vertices[startIndex] is null || Vertices[endIndex] is null)
            {
                return;
            }
            isVisited[startIndex] = true;
            tempList.Add(Vertices[startIndex]);

            if (startIndex.Equals(endIndex))
            {
                // new path found,  add new path to list
                pathList.Add(new List<UndirectedVertex>());
                int pathListLength = pathList.Count;
                // add each node to new list
                foreach (UndirectedVertex node in tempList)
                {
                    pathList[pathListLength - 1].Add(node);
                }
                tempList.Remove(Vertices[startIndex]);
                isVisited[startIndex] = false;
                return;
            }
            foreach (UndirectedVertex node in GetNeighbors(startIndex))
            {
                if (node is not null && !isVisited[node.Index])
                {
                    UndirectedDFS(node.Index, endIndex, isVisited, tempList, pathList);
                }
            }

            tempList.Remove(Vertices[startIndex]);
            isVisited[startIndex] = false;

            return;

        }
    }

}
using Xunit;
using KojakDatastructures;
using System.Collections.Generic;
using KojakDatastructures;

namespace KojakDatastructuresTest
{
    public class UndirectedUnweightedGraphTest
    {
        private UndirectedUnweightedGraph testObject;
        public UndirectedUnweightedGraphTest()
        {
            testObject = new UndirectedUnweightedGraph(15);
        }

        [Fact]
        public void UndirectedDFS_ShouldGetPath_AndReturnCount()
        {
            UndirectedVertex nodeA = testObject.AddVertex("A");
            UndirectedVertex nodeB = testObject.AddVertex("B");
            UndirectedVertex nodeC = testObject.AddVertex("C");
            UndirectedVertex nodeD = testObject.AddVertex("D");
            UndirectedVertex nodeE = testObject.AddVertex("E");
            UndirectedVertex nodeF = testObject.AddVertex("F");
            UndirectedVertex nodeG = testObject.AddVertex("G");
            UndirectedVertex nodeH = testObject.AddVertex("H");
            UndirectedVertex nodeI = testObject.AddVertex("I");

            testObject.AddEdge(nodeA, nodeC);
            bool actualResult = testObject.AddEdge(nodeC, nodeA);
            bool expectedResult = false;
            Assert.Equal(expectedResult, actualResult);

            // create path to nodeI from nodeA and test that the least amount of step was taken to get there
            // also verify shortest path taken to get there

            testObject.AddEdge(nodeC, nodeF);
            testObject.AddEdge(nodeC, nodeB);
            testObject.AddEdge(nodeD, nodeA);
            testObject.AddEdge(nodeD, nodeG);
            testObject.AddEdge(nodeE, nodeG);
            testObject.AddEdge(nodeB, nodeE);
            testObject.AddEdge(nodeI, nodeF);

            UndirectedVertex[] aNeighbors = testObject.GetNeighbors(nodeA.Index);
            Assert.Contains(nodeC, aNeighbors);
            Assert.Contains(nodeD, aNeighbors);
            UndirectedVertex[] bNeighbors = testObject.GetNeighbors(nodeB.Index);
            Assert.Contains(nodeC, bNeighbors);
            Assert.Contains(nodeE, bNeighbors);
            UndirectedVertex[] cNeighbors = testObject.GetNeighbors(nodeC.Index);
            Assert.Contains(nodeA, cNeighbors);
            Assert.Contains(nodeB, cNeighbors);
            Assert.Contains(nodeF, cNeighbors);
            UndirectedVertex[] fNeighbors = testObject.GetNeighbors(nodeF.Index);
            Assert.Contains(nodeC, fNeighbors);
            Assert.Contains(nodeI, fNeighbors);

            List<List<UndirectedVertex>> visited = new List<List<UndirectedVertex>>() { };
            int actualCount = testObject.UndirectedDFS(nodeD.Index, nodeI.Index, visited);
            int expectedCount = 2;
            Assert.Equal(expectedCount, actualCount);

            List<UndirectedVertex> l1 = new List<UndirectedVertex>{
                nodeD,
                nodeA,
                nodeC,
                nodeF,
                nodeI
            };
            List<UndirectedVertex> l2 = new List<UndirectedVertex>{
                nodeD,
                nodeG,
                nodeE,
                nodeB,
                nodeC,
                nodeF,
                nodeI
            };
            // contains two lists since there are two paths to the target node
            List<List<UndirectedVertex>> actualList = new List<List<UndirectedVertex>> {
                l1,
                l2
            };
            Assert.Equal(visited, actualList);
        }
    }
}
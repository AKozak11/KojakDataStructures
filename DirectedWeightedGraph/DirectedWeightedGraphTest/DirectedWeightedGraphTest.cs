using Xunit;
using System;
using System.Collections.Generic;
using KojakDatastructures.Graph;
using KojakDatastructures.GraphNode;

namespace DirectedWeightedGraphTest
{

    public class DirectedWeightedGraphTest
    {
        private DirectedWeightedGraph testObject;
        public DirectedWeightedGraphTest()
        {
            testObject = new DirectedWeightedGraph();
        }
        [Fact]
        public void AddVertex_ShouldReturn_True()
        {
            Vertex node1 = new Vertex("1");
            Vertex node2 = new Vertex("2");
            Vertex node3 = new Vertex("3");

            bool actualResult1 = testObject.AddVertex(node1);
            bool actualResult2 = testObject.AddVertex(node2);
            bool actualResultFalse = testObject.AddVertex(node2);

            bool expectedResult = true;
            bool expectedResultFalse = false;

            Assert.Equal(expectedResult, actualResult1);
            Assert.Equal(expectedResult, actualResult2);
            Assert.Equal(expectedResultFalse, actualResultFalse);
            Assert.Contains<Vertex>(node1, testObject.Vertices);
            Assert.Contains<Vertex>(node2, testObject.Vertices);
            Assert.DoesNotContain<Vertex>(node3, testObject.Vertices);
        }

        [Fact]
        public void AddVertex_ShouldReturn_False()
        {
            Vertex node1 = new Vertex("1");
            Vertex node2 = new Vertex("2");
            Vertex node3 = new Vertex("1");

            testObject.AddVertex(node1);
            testObject.AddVertex(node2);
            bool actualResult = testObject.AddVertex(node3);

            bool expectedResult = false;

            Assert.Equal(expectedResult, actualResult);
            Assert.DoesNotContain(node3, testObject.Vertices);
        }

        [Fact]
        public void AddEdge_ShouldReturn_True()
        {
            Vertex node1 = new Vertex("1");
            Vertex node2 = new Vertex("2");
            Vertex node3 = new Vertex("3");
            Vertex node4 = new Vertex("4");

            testObject.AddVertex(node1);
            testObject.AddVertex(node2);
            testObject.AddVertex(node3);
            testObject.AddVertex(node4);

            int weight12 = 15;
            testObject.AddEdge(node1, node2, weight12);
            int expectedEdgeCount1 = 1;

            Assert.Contains(node1, testObject.Edges.Keys);
            Assert.Equal(expectedEdgeCount1, testObject.Edges[node1].Keys.Count);
            Assert.Contains(node2, testObject.Edges[node1].Keys);
            Assert.Equal(weight12, testObject.Edges[node1][node2]);

            int weight13 = 25;
            testObject.AddEdge(node1, node3, weight13);
            expectedEdgeCount1 = 2;

            Assert.Contains(node1, testObject.Edges.Keys);
            Assert.Contains(node2, testObject.Edges[node1].Keys);
            Assert.Equal(weight12, testObject.Edges[node1][node2]);
            Assert.Contains(node3, testObject.Edges[node1].Keys);
            Assert.Equal(weight13, testObject.Edges[node1][node3]);

            Assert.Equal(expectedEdgeCount1, testObject.Edges[node1].Keys.Count);

            int weight14 = 35;
            testObject.AddEdge(node1, node4, weight14);
            expectedEdgeCount1 = 3;

            Assert.Contains(node1, testObject.Edges.Keys);
            Assert.Contains(node2, testObject.Edges[node1].Keys);
            Assert.Equal(weight12, testObject.Edges[node1][node2]);
            Assert.Contains(node3, testObject.Edges[node1].Keys);
            Assert.Equal(weight13, testObject.Edges[node1][node3]);
            Assert.Contains(node4, testObject.Edges[node1].Keys);
            Assert.Equal(weight14, testObject.Edges[node1][node4]);
            Assert.Equal(expectedEdgeCount1, testObject.Edges[node1].Keys.Count);

        }

        [Fact]
        public void RemoveEdge_ShouldReturn_True()
        {
            Vertex node1 = new Vertex("1");
            Vertex node2 = new Vertex("2");
            Vertex node3 = new Vertex("3");
            Vertex node4 = new Vertex("4");

            testObject.AddVertex(node1);
            testObject.AddVertex(node2);
            testObject.AddVertex(node3);
            testObject.AddVertex(node4);

            int weight12 = 15;
            testObject.AddEdge(node1, node2, weight12);

            int weight13 = 25;
            testObject.AddEdge(node1, node3, weight13);
            int expectedEdgeCount1 = 2;

            int weight14 = 35;
            testObject.AddEdge(node1, node4, weight14);
            bool expectedResult = true;
            bool actualResult = testObject.RemoveEdge(node1, node3);


            // verify that node 3 has been removed and did not damage any other edges
            Assert.Contains(node1, testObject.Edges.Keys);
            Assert.Contains(node2, testObject.Edges[node1].Keys);
            Assert.Equal(weight12, testObject.Edges[node1][node2]);
            Assert.Contains(node4, testObject.Edges[node1].Keys);
            Assert.Equal(weight14, testObject.Edges[node1][node4]);
            Assert.Equal(expectedEdgeCount1, testObject.Edges[node1].Keys.Count);
            Assert.Equal(expectedResult, actualResult);

        }

        // Test 
        [Fact]
        public void GetNeighbors_ShouldReturn_List()
        {
            Vertex node1 = new Vertex("1");
            Vertex node2 = new Vertex("2");
            Vertex node3 = new Vertex("3");
            Vertex node4 = new Vertex("4");
            Vertex node5 = new Vertex("5");

            testObject.AddVertex(node1);
            testObject.AddVertex(node2);
            testObject.AddVertex(node3);
            testObject.AddVertex(node4);
            testObject.AddVertex(node5);

            int weight = 7;
            testObject.AddEdge(node1, node2, weight);
            // verify that trying to add existing edge does not break existing edge
            testObject.AddEdge(node1, node2, weight);
            testObject.AddEdge(node1, node3, weight);
            testObject.AddEdge(node1, node4, weight);
            testObject.AddEdge(node1, node5, weight);
            testObject.RemoveEdge(node1, node5);

            List<Vertex> expectedResult = new List<Vertex>{
                node2,node3,node4
            };

            List<Vertex> actualResult = testObject.GetNeighbors(node1);

            Assert.Equal(expectedResult, actualResult);

        }

        [Fact]
        public void BFS_ShouldGetPath_AndReturn_StepCount()
        {
            Vertex node1 = new Vertex("1");
            Vertex node2 = new Vertex("2");
            Vertex node3 = new Vertex("3");
            Vertex node4 = new Vertex("4");
            Vertex node5 = new Vertex("5");
            Vertex node6 = new Vertex("6");
            Vertex node7 = new Vertex("7");

            testObject.AddVertex(node1);
            testObject.AddVertex(node2);
            testObject.AddVertex(node3);
            testObject.AddVertex(node4);
            testObject.AddVertex(node5);
            testObject.AddVertex(node6);
            testObject.AddVertex(node7);

            int weight = 7;
            testObject.AddEdge(node1, node2, weight);
            testObject.AddEdge(node2, node5, weight);
            testObject.AddEdge(node5, node4, weight);
            testObject.AddEdge(node4, node3, weight);
            testObject.AddEdge(node6, node1, weight);
            testObject.AddEdge(node1, node7, weight);

            HashSet<Vertex> visited = new HashSet<Vertex>();

            int expectedStepCount = 5;
            // expected path below has 5 nodes after the starting node, so the expected count is 5
            HashSet<Vertex> expectedPath =new HashSet<Vertex> {
                node1, node2, node7, node5, node4, node3 
            };

            int actualStepCount = testObject.BFS(node1, node3, visited);

            Assert.Equal(expectedStepCount, actualStepCount);
            Assert.Equal(expectedPath, visited);
        }

        [Fact]
        public void BFS_ShouldGetPath_AndReturn_MinusOne()
        {
            Vertex node1 = new Vertex("1");
            Vertex node2 = new Vertex("2");
            Vertex node3 = new Vertex("3");
            Vertex node4 = new Vertex("4");
            Vertex node5 = new Vertex("5");
            Vertex node6 = new Vertex("6");
            Vertex node7 = new Vertex("7");

            testObject.AddVertex(node1);
            testObject.AddVertex(node2);
            testObject.AddVertex(node3);
            testObject.AddVertex(node4);
            testObject.AddVertex(node5);
            testObject.AddVertex(node6);
            testObject.AddVertex(node7);

            int weight = 7;
            testObject.AddEdge(node1, node2, weight);
            testObject.AddEdge(node2, node5, weight);
            testObject.AddEdge(node5, node4, weight);
            testObject.AddEdge(node4, node3, weight);
            testObject.AddEdge(node6, node1, weight);
            testObject.AddEdge(node1, node7, weight);

            HashSet<Vertex> visited = new HashSet<Vertex>();

            int expectedStepCount = -1;
            // expected path below has 5 nodes after the starting node, so the expected count is 5
            HashSet<Vertex> expectedPath =new HashSet<Vertex> {
                node1, node2, node7, node5, node4, node3 
            };

            int actualStepCount = testObject.BFS(node1, node6, visited);

            Assert.Equal(expectedStepCount, actualStepCount);
            Assert.Equal(expectedPath, visited);
        }

        [Fact]
        public void DFS_ShouldGetPath_AndReturn_StepCount()
        {
            Vertex node1 = new Vertex("1");
            Vertex node2 = new Vertex("2");
            Vertex node3 = new Vertex("3");
            Vertex node4 = new Vertex("4");
            Vertex node5 = new Vertex("5");
            Vertex node6 = new Vertex("6");
            Vertex node7 = new Vertex("7");

            testObject.AddVertex(node1);
            testObject.AddVertex(node2);
            testObject.AddVertex(node3);
            testObject.AddVertex(node4);
            testObject.AddVertex(node5);
            testObject.AddVertex(node6);
            testObject.AddVertex(node7);

            int weight = 7;
            testObject.AddEdge(node1, node2, weight);
            testObject.AddEdge(node2, node5, weight);
            testObject.AddEdge(node5, node4, weight);
            testObject.AddEdge(node4, node3, weight);
            testObject.AddEdge(node6, node1, weight);
            testObject.AddEdge(node1, node7, weight);

            HashSet<Vertex> visited = new HashSet<Vertex>();

            int expectedStepCount = 4;
            // expected path below has 5 nodes after the starting node, so the expected count is 5
            HashSet<Vertex> expectedPath =new HashSet<Vertex> {
                node1, node2, node5, node4, node3 
            };

            int actualStepCount = testObject.DFS(node1, node3, visited);

            Assert.Equal(expectedStepCount, actualStepCount);
            Assert.Equal(expectedPath, visited);
        }

        [Fact]
        public void DFS_ShouldGetPath_AndReturn_MinusOne()
        {
            Vertex node1 = new Vertex("1");
            Vertex node2 = new Vertex("2");
            Vertex node3 = new Vertex("3");
            Vertex node4 = new Vertex("4");
            Vertex node5 = new Vertex("5");
            Vertex node6 = new Vertex("6");
            Vertex node7 = new Vertex("7");

            testObject.AddVertex(node1);
            testObject.AddVertex(node2);
            testObject.AddVertex(node3);
            testObject.AddVertex(node4);
            testObject.AddVertex(node5);
            testObject.AddVertex(node6);
            testObject.AddVertex(node7);

            int weight = 7;
            testObject.AddEdge(node1, node2, weight);
            testObject.AddEdge(node2, node5, weight);
            testObject.AddEdge(node5, node4, weight);
            testObject.AddEdge(node4, node3, weight);
            testObject.AddEdge(node6, node1, weight);
            testObject.AddEdge(node1, node7, weight);

            HashSet<Vertex> visited = new HashSet<Vertex>();

            int expectedStepCount = -1;
            // expected path below has 5 nodes after the starting node, so the expected count is 5
            HashSet<Vertex> expectedPath =new HashSet<Vertex> {
                node1, node2, node5, node4, node3 
            };

            int actualStepCount = testObject.DFS(node1, node6, visited);

            Assert.Equal(expectedStepCount, actualStepCount);
        }
    }
}
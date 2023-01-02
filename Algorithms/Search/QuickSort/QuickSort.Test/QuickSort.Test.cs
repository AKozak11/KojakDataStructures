using Xunit;
using System.Collections.Generic;
using KojakAlgorithms;

namespace KojakAlgorithms.Test
{

    public class QuickSortTest
    {
        private List<int> testData;
        public QuickSortTest()
        {
            testData = new List<int> { 6, 15, 4, 69, 12, 145, 7, 99 };
        }
        [Fact]
        public void Partition_ShouldFind_PartitionIndex()
        {
            int expected = 6;
            int actual = QuickSort.Partition(testData, 0, (testData.Count - 1));

            Assert.Equal(expected, actual);

            testData = new List<int> { 6, 15, 4, 69, 12, 145, 7, 21, 22, 23, 99 };
            expected = 9;
            actual = QuickSort.Partition(testData, 0, (testData.Count - 1));

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Sort_ShouldSortList()
        {
            List<int> expected = new List<int> { 4, 6, 7, 12, 15, 69, 99, 145 };
            QuickSort.Sort(testData, 0, (testData.Count - 1));

            Assert.Equal(expected, testData);

            testData = new List<int> { 2, 1 };
            expected = new List<int> { 1, 2 };

            QuickSort.Sort(testData, 0, (testData.Count - 1));

            Assert.Equal(expected, testData);
        }
    }
}
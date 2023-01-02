using Xunit;
using KojakAlgorithms;
namespace KojakAlgorithms.Test
{

    public class MergeSortTest
    {
        private int[] testData;
        public MergeSortTest()
        {
            testData = new int[] { 1, 4, 8, 2, 5, 6, 9 };
        }
        [Fact]
        public void Merge_ShouldMerge_SortedArrays()
        {
            int[] expected = new int[] { 1, 2, 4, 5, 6, 8, 9 };
            MergeSort.Merge(testData, 0, 2, 6);

            Assert.Equal(expected, testData);

            testData = new int[] { 4, 5, 7, 14, 24, 47, 52, 3, 10 };
            expected = new int[] { 3, 4, 5, 7, 10, 14, 24, 47, 52 };
            MergeSort.Merge(testData, 0, 6, 8);

            Assert.Equal(expected, testData);


            testData = new int[] { 1 };
            expected = testData;
            MergeSort.Merge(testData, 0, 0, 0);

            Assert.Equal(expected, testData);
        }

        [Fact]
        public void Sort_ShouldSort_UnsortedList()
        {
            int[] expected = new int[] { 1, 2, 4, 5, 6, 8, 9 };
            MergeSort.Sort(testData, 0, (testData.Length - 1));

            Assert.Equal(expected, testData);

            testData = new int[] { 4, 3, 7, 15, 45, 1, 47, 124, 36, 29, 2000, 444, 6124, 9, 21, 99, 777 };
            expected = new int[] { 1, 3, 4, 7, 9, 15, 21, 29, 36, 45, 47, 99, 124, 444, 777, 2000, 6124 };
            MergeSort.Sort(testData, 0, (testData.Length - 1));
            
            Assert.Equal(expected, testData);
        }
    }
}




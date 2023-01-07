using Xunit;
using System;
using System.Collections.Generic;
using KojakDataStructures.BIT;

namespace KojakDataStructures.BIT.Test
{
    public class FenwickTreeTest
    {
        private List<int> testData;
        private FenwickTree testObject;
        public FenwickTreeTest()
        {
            testData = new List<int> { 4, 5, 14, -2, 1, -4, 16, -10, -5, 7 };
        }
        [Fact]
        public void GetSum_ShouldCalculateSum_WithinRangeStartToEndIndex()
        {
            testObject = new FenwickTree(testData);

            // test sum at each index
            int expectedSum = 4;
            int actualSum = testObject.GetSum(0, 0);

            Assert.Equal(expectedSum, actualSum);

            expectedSum = 9;
            actualSum = testObject.GetSum(0, 1);

            Assert.Equal(expectedSum, actualSum);

            expectedSum = 23;
            actualSum = testObject.GetSum(0, 2);

            Assert.Equal(expectedSum, actualSum);

            expectedSum = 9;
            actualSum = testObject.GetSum(2, 5);

            Assert.Equal(expectedSum, actualSum);

            expectedSum = 8;
            actualSum = testObject.GetSum(6, 9);

            Assert.Equal(expectedSum, actualSum);

            expectedSum = 18;
            actualSum = testObject.GetSum(0, 5);

            Assert.Equal(expectedSum, actualSum);

            expectedSum = 15;
            actualSum = testObject.GetSum(1, 8);

            Assert.Equal(expectedSum, actualSum);
            
            expectedSum = 22;
            actualSum = testObject.GetSum(1, 9);

            Assert.Equal(expectedSum, actualSum);

            expectedSum = 24;
            actualSum = testObject.GetSum(0, 7);

            Assert.Equal(expectedSum, actualSum);

            expectedSum = 19;
            actualSum = testObject.GetSum(0, 8);

            Assert.Equal(expectedSum, actualSum);
        }
    }
}
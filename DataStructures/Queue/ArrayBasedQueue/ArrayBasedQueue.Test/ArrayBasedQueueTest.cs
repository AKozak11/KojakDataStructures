using Xunit;
using System;
using KojakDataStructures;

namespace KojakDataStructures.Queue.Test
{

    public class ArrayBasedQueueTest
    {
        private ArrayBasedQueue<string> testObject;
        public ArrayBasedQueueTest()
        {
            testObject = new ArrayBasedQueue<string>();
        }

        [Fact]
        public void IsFull_ShouldReturn_False()
        {
            bool expected = false;
            bool actual = testObject.IsFull();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IsEmpty_ShouldReturn_True()
        {
            bool expected = true;
            bool actual = testObject.IsEmpty();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Enqueue_ShouldAddItems_ToQueue()
        {
            testObject = new ArrayBasedQueue<string>(10);

            testObject.Enqueue("test1");
            testObject.Enqueue("test2");
            testObject.Enqueue("test3");
            testObject.Enqueue("test4");

            int expected = 4;

            Assert.Equal(expected, testObject.Count);
        }

        [Fact]
        public void Enqueue_ShouldNotAddItems_ToQueue_WhenFull()
        {
            testObject = new ArrayBasedQueue<string>(3);

            testObject.Enqueue("test1");
            testObject.Enqueue("test2");
            testObject.Enqueue("test3");

            bool expected = false;
            bool actual = testObject.Enqueue("test4");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Dequeue_Should_RemoveFirstItem_FromQueue()
        {
            testObject = new ArrayBasedQueue<string>(5);

            // fill queue first
            string expected1 = "foo bar";
            testObject.Enqueue(expected1);
            string expected2 = "foobar";
            testObject.Enqueue(expected2);
            string expected3 = "fooooooo bar";
            testObject.Enqueue(expected3);
            string expected4 = "foobah";
            testObject.Enqueue(expected4);
            string expected5 = "fooooooopy doopy bar";
            testObject.Enqueue(expected5);

            Assert.Equal(false, testObject.IsEmpty());
            Assert.Equal(true, testObject.IsFull());

            // validate first two dequeues
            string actual = testObject.Dequeue();

            Assert.Equal(expected1, actual);
            Assert.Equal(false, testObject.IsFull());

            actual = testObject.Dequeue();

            Assert.Equal(expected2, actual);

            // queue first two again
            testObject.Enqueue(expected1);
            testObject.Enqueue(expected2);

            // queue should be full after adding first two again
            Assert.Equal(true, testObject.IsFull());

            // validate third item
            actual = testObject.Dequeue();

            Assert.Equal(expected3, actual);

            actual = testObject.Dequeue();
            Assert.Equal(expected4, actual);

            actual = testObject.Dequeue();
            Assert.Equal(expected5, actual);

            // after queueing the first two again, dequeue to confirm indexing is working for circular array
            actual = testObject.Dequeue();
            Assert.Equal(expected1, actual);

            actual = testObject.Dequeue();
            Assert.Equal(expected2, actual);

            // validate state is being updated properly
            Assert.Equal(true, testObject.IsEmpty());
            Assert.Equal(0, testObject.Count);
        }

        [Fact]
        public void Dequeue_ShouldThrowxception_WhenQueue_IsEmpty()
        {
            testObject.Enqueue("test1");
            testObject.Enqueue("test2");
            testObject.Enqueue("test3");
            testObject.Enqueue("test4");
            testObject.Enqueue("test5");

            testObject.Dequeue();
            testObject.Dequeue();


            testObject.Enqueue("test6");
            testObject.Enqueue("test7");


            testObject.Dequeue();
            testObject.Dequeue();
            testObject.Dequeue();
            testObject.Dequeue();
            testObject.Dequeue();

            Assert.Throws<InvalidOperationException>(() => testObject.Dequeue());
        }
    }
}
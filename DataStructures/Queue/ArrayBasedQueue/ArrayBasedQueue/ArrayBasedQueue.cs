namespace KojakDataStructures
{
    public class ArrayBasedQueue<T>
    {
        private bool isFull = false;
        private bool isEmpty = true;
        private int start = 0;
        private int end = 0;
        private int _maxSize;
        private T[] queue;
        public int Count { get; set; } = 0;

        /// <param name="maxSize">Maximum size of the queue. Default is 1000.</param>
        public ArrayBasedQueue(int maxSize = 1000)
        {
            _maxSize = maxSize;
            queue = new T[_maxSize];
        }

        public bool Enqueue(T item)
        {
            if (IsFull()) return false;

            isEmpty = false;
            Count++;
            queue[end] = item;
            end++;

            if (end >= _maxSize) end = 0;
            if (end == start) isFull = true;

            return true;
        }

        public T Dequeue()
        {
            if (isEmpty) throw new InvalidOperationException("Cannot dequeue wen queue is empty.");

            T item = queue[start];
            start++;
            isFull = false;

            if (start >= _maxSize) start = 0;

            Count--;
            if (Count == 0) isEmpty = true;

            return item;
        }

        public bool IsEmpty() => isEmpty;
        public bool IsFull() => isFull;
    }
}
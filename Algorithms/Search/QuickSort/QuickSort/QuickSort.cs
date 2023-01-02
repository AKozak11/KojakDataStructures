namespace KojakAlgorithms
{
    public class QuickSort
    {
        private static void Swap(List<int> arr, int n, int m)
        {
            int temp = arr[n];
            arr[n] = arr[m];
            arr[m] = temp;
        }
        /// <summary>
        /// Finds new partition index for the subarray arr[low] to arr[high]
        /// <summary>
        public static int Partition(List<int> arr, int low, int high)
        {
            int pi = high;
            int i = (low - 1);

            for (int j = low; j < pi; j++)
            {
                // move all lesser elements to left side of partition
                if (arr[j] < arr[pi])
                {
                    i++;
                    Swap(arr, j, i);
                }
            }

            Swap(arr, (i + 1), pi);
            pi = (i + 1);
            return pi;
        }

        public static void Sort(List<int> arr, int low, int high)
        {
            if (low < high)
            {
                int pi = Partition(arr, low, high);
                Sort(arr, low, (pi - 1));
                Sort(arr, (pi + 1), high);
            }
        }
    }
}
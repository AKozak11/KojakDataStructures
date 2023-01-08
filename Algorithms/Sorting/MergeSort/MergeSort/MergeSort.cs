namespace KojakAlgorithms
{
    public class MergeSort
    {
        public static void Merge(int[] arr, int l, int m, int r)
        {
            int leftLength = m - l + 1;
            int rightLength = r - m;

            int[] tempLeft = new int[leftLength];
            int[] tempRight = new int[rightLength];

            // populate left and right arrays
            int i = 0, j = 0;
            while (i < leftLength)
            {
                tempLeft[i] = arr[l + i];
                i++;
            }
            while (j < rightLength)
            {
                tempRight[j] = arr[m + 1 + j];
                j++;
            }

            i = 0; j = 0;
            int k = l;

            while (i < leftLength && j < rightLength)
            {
                if (tempLeft[i] <= tempRight[j]) arr[k++] = tempLeft[i++];
                else arr[k++] = tempRight[j++];
            }
            while (i < leftLength) arr[k++] = tempLeft[i++];
            while (j < rightLength) arr[k++] = tempRight[j++];
        }
        public static void Sort(int[] arr, int l, int r)
        {
            if (l < r)
            {
                int mid = l + (r - l) / 2;

                Sort(arr, l, mid);
                Sort(arr, mid + 1, r);

                Merge(arr, l, mid, r);
            }
        }
    }
}
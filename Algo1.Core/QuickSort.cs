namespace Algo1.Core
{
    public class QuickSort : ISorter
    {
        public int[] Sort(int[] input)
        {
            if (input == null || input.Length == 0)
            {
                return input;
            }
            else
            {
                Sort(input, 0, input.Length - 1);

                return input;
            }
        }

        private void Sort(int[] array, int startIndex, int endIndex)
        {
            if (startIndex < endIndex)
            {
                var pivot = Partition(array, startIndex, endIndex);
                Sort(array, startIndex, pivot);
                Sort(array, pivot + 1, endIndex);
            }
        }

        private int Partition(int[] array, int low, int high)
        {
            int pivot = array[low];
            int j = low;

            for (int i = j + 1; i <= high; i++)
            {
                if (array[i] < pivot)
                {
                    j++;
                    Swap(array, i, j);
                }
            }
            Swap(array, low, j);

            return j;
        }

        private void Swap(int[] array, int firstIndex, int secondIndex)
        {
            var temp = array[firstIndex];
            array[firstIndex] = array[secondIndex];
            array[secondIndex] = temp;
        }
    }
}

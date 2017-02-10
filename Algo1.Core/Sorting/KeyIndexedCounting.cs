namespace Algo1.Core.Sorting
{
    public class KeyIndexedCounting
    {
        public int[] Sort(int[] numbers, int keys)
        {
            if (numbers == null || numbers.Length <= 1 || keys <= 1)
            {
                return numbers;
            }

            int[] count = new int[keys + 1];
            int[] aux = new int[numbers.Length];

            // 1. count keys
            for (int i = 0; i < numbers.Length; i++)
            {
                count[i + 1]++;
            }

            //2.  transform keys to indices
            for (int i = 0; i < keys; i++)
            {
                count[i + 1] += count[i];
            }

            //3. fill aux. array
            for (int i = 0; i < numbers.Length; i++)
            {
                aux[count[numbers[i]]++] = numbers[i];
            }

            //4. copy back to original array
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = aux[i];
            }

            return numbers;
        }
    }
}

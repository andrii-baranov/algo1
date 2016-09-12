using System;

namespace Algo1.Core
{
    public class MergeSorter : ISorter
    {
        public long InversionsCount { get; set; }
        public int[] Sort(int[] input)
        {
            if (input == null || input.Length <= 1)
            {
                return input;
            }

            return MergeSort(input, 0, input.Length - 1);
        }

        private int[] SliceArray(int[] input, int startIndex, int endIndex)
        {
            int[] result = new int[endIndex - startIndex + 1];

            int counter = 0;

            for (int i = startIndex; i < endIndex + 1; i++)
            {
                result[counter] = input[i];
                counter++;
            }

            return result;
        }

        private int[] MergeSort(int[] input, int startIndex, int endIndex)
        {
            if (input.Length == 1)
            {
                return input;
            }

            if (endIndex - startIndex == 1)
            {
                if (input[startIndex] > input[endIndex])
                {
                    var tmp = input[startIndex];
                    input[startIndex] = input[endIndex];
                    input[endIndex] = tmp;

                    InversionsCount++;
                }

                return input;
            }
            else
            {
                int splitIndex = (endIndex - startIndex - 1) / 2 + 1;

                var leftPart = SliceArray(input, 0, splitIndex - 1);
                var rigthPart = SliceArray(input, splitIndex, input.Length - 1);

                var left = MergeSort(leftPart, startIndex, splitIndex);
                var right = MergeSort(rigthPart, 0, rigthPart.Length);

                var merged = Merge(left, right);

                return merged;
            }
        }

        private int[] Merge(int[] left, int[] right)
        {
            int leftPointer = 0;
            int rightPointer = 0;
            
            int[] result = new int[left.Length + right.Length];

            for (int i = 0; i < result.Length; i++)
            {
                bool hasLeftValue = leftPointer < left.Length;
                bool hasRightValue = rightPointer < right.Length;

                if (hasLeftValue && !hasRightValue)
                {
                    result[i] = left[leftPointer];
                    leftPointer++;
                }
                else if (hasRightValue && !hasLeftValue)
                {
                    result[i] = right[rightPointer];
                    rightPointer++;
                }
                else if (left[leftPointer] <= right[rightPointer])
                {
                    result[i] = left[leftPointer];
                    leftPointer++;
                }
                else
                {
                    result[i] = right[rightPointer];
                    rightPointer++;
                    InversionsCount += left.Length - leftPointer;
                }
            }

            return result;
        }
    }
}

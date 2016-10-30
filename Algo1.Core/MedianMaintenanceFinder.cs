using C5;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Algo1.Core
{
    public class MedianMaintenanceFinder
    {
        public static long GetSumOfMediansLong(int[] input)
        {
            //brute force O(n^2) solution
            List<int> medians = new List<int>();
            for (int i = 0; i <input.Length; i++)
            {
                List<int> temp = new List<int>();
                for (int j = 0; j < i + 1; j++)
                {
                    temp.Add(input[j]);
                }

                temp.Sort();
                int median;
                if (i % 2 == 0)
                {
                    median = i / 2;
                }
                else
                {
                    median = (i - 1) / 2;
                }

                medians.Add(temp[median]);
            }

            long sum = medians.Sum() % 10000;

            return sum;
        }
        public static long GetSumOfMedians(int[] input)
        {
            long result = 0;
            int[] medians = new int[input.Length];

            IntervalHeap<int> maxLeftHeap = new IntervalHeap<int>();
            IntervalHeap<int> minRightHeap = new IntervalHeap<int>();

            medians[0] = input[0];
            result += input[0];
            if (input[0] > input[1])
            {
                maxLeftHeap.Add(input[1]);
                minRightHeap.Add(input[0]);
                medians[1] = input[1];
                result += input[1];
            }
            else
            {
                medians[1] = input[0];
                maxLeftHeap.Add(input[0]);
                minRightHeap.Add(input[1]);
                result += input[0];
            }

            for (int i = 2; i < input.Count(); i++)
            {
                var maxRoot = maxLeftHeap.FindMax();
                if (input[i] < maxRoot)
                {
                    maxLeftHeap.Add(input[i]);
                }
                else
                {
                    minRightHeap.Add(input[i]);
                }

                if (maxLeftHeap.Count - minRightHeap.Count > 1)
                {
                    var root = maxLeftHeap.DeleteMax();
                    minRightHeap.Add(root);
                } else if (minRightHeap.Count - maxLeftHeap.Count > 1)
                {
                    var root = minRightHeap.DeleteMin();
                    maxLeftHeap.Add(root);
                }

                int median = maxLeftHeap.FindMax();

                medians[i] = median;
                result += median;
            }



            return result % 10000;
        }
    }
}

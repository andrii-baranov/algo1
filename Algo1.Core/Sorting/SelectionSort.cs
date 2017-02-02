using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo1.Core.Sorting
{
    public class SelectionSort
    {
        public static int[] Sort(int[] input)
        {
            // todo validate

            int smallestIndex = 0;


            for (int i = 0; i < input.Length; i++)
            {
                smallestIndex = i;

                for (int j = i + 1; j < input.Length; j++)
                {
                    if (input[j] < input[smallestIndex])
                    {
                        smallestIndex = j;
                    }
                }

                int tmp = input[i];
                input[i] = input[smallestIndex];
                input[smallestIndex] = tmp;
            }


            return input;
        }
    }
}

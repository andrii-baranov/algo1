using Algo1.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo1.Core
{
    public class BubbleSorter : ISorter
    {
        public int[] Sort(int[] input)
        {
            if (input == null)
            {
                return input;

            }
            if (input.Length == 0  || input.Length == 1)
            {
                return input;
            }

       

         //   int[] sorted = new int[input.Length];


            for (int i = 0; i < input.Length-1; i++)
            {
                for(int j = i; j<input.Length; j++)
                {
                    if (input[i] > input[j])
                    {
                        var tmp = input[i];
                        input[i] = input[j];

                        input[j] = tmp;
                    }
                }
            }

            return input;
        }
    }
}

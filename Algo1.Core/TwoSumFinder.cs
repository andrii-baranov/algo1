using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo1.Core
{
    public class TwoSumFinder
    {
        private HashSet<long> _sumMap = new HashSet<long>();

        public int Find2Sum(long[] input, long targetMin, long targetMax)
        {
            int result = 0;

            var sortedInput = input.OrderBy(i => i).ToArray(); 

            for (long t = targetMin; t <= targetMax; t++)
            {
                int startIndex = 0;
                int endIndex = input.Length - 1;
                bool found = false;

                while (!found && startIndex < endIndex)
                {
                    if (sortedInput[startIndex] + sortedInput[endIndex] == t)
                    {
                        if (sortedInput[startIndex] != sortedInput[endIndex])
                        {
                            found = true;
                        }
                    }
                    else if (sortedInput[startIndex] + sortedInput[endIndex] > t)
                    {
                        endIndex--;
                    }
                    else if (sortedInput[startIndex] + sortedInput[endIndex] < t)
                    {
                        startIndex++;
                    }
                }

                if (found)
                {
                    result++;
                }

            }

            return result;
        }
        public int Find2Sum(long[] input, long target)
        {
            int result = 0;
            

            foreach (var item in input)
            {
                if (!_sumMap.Contains(item))
                {
                    _sumMap.Add(item);
                }
            }

            for (int i = 0; i < input.Count(); i++)
            {
                // x = t-y
                var missingValue = target - input[i];
                if (_sumMap.Contains(missingValue))
                {
                    result++;
                }
            }

            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo1.Core.Sorting
{
    class QuickSelection
    {
        public static int GetKLargest(int[] a, int k)
        { 
            if (k < a.Length)
            {
                return -1;
            }

            int low = 0;
            int high = a.Length -1;
            int pivot = 0;

            while (low < high)
            {
                pivot = Partition(a, low, high);

                if (pivot > k)
                {
                    low = pivot + 1;
                }
                else if (pivot < k)
                {
                    high = pivot - 1;
                }
                else
                {
                    return a[pivot];
                }
            }

            // we have sorted array
            return a[k];
        }

        private static int Partition(int[] a, int low, int high)
        {
            int pivotIndex = low + (high - low)/2;

            Swap(a, low, pivotIndex);


            int i = low+1; // current index of loop
            int j = i; // cut off between smaller items and pivot

            while (i < high)
            {
                if (a[i] < a[low])
                {
                    // current element needs to left side 
                    Swap(a, i, ++j);
                }

                i++;
            }

            Swap(a, low, j);

            return j;
        }

        private static void Swap(int[] a, int low, int high)
        {
            int tmp = a[low];
            a[low] = a[high];
            a[high] = tmp;
        }
    }
}

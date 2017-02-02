using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo1.Core.Sorting
{
    public class QuickSortBasic
    {
        public void Sort(int[] a)
        {
            SimpleQuickSort(a, 0, a.Length);
        }
        public void SimpleQuickSort(int[] a, int low, int high)
        {
            if (high - low <= 1)
            {
                return;
            }

            int partitionIndex = Partition(a, low, high);

            // 1 run partition
            SimpleQuickSort(a, low, partitionIndex - 1);
            SimpleQuickSort(a, partitionIndex + 1, high);
        }

        private int Partition(int[] a, int low, int high)
        {
            int partitionIndex = (high - low) / 2;

            Swap(a, low, partitionIndex);

            int i = low;
            int j = high + 1;

            while (true)
            {
                // first big item in left part
                while (i < high && a[++i] < a[low])
                {
                    if (i == high)
                    {
                        break;
                    }
                }

                // find small item in right part
                while (j > low && a[--j] > a[low])
                {
                    if (j == low)
                    {
                        break;
                    }
                }

                if (i >= j)
                {
                    break;
                }

                Swap(a, i, j);
            }


            Swap(a, low, j);

            return j;
        }

        private void Swap(int[] a, int first, int second)
        {
            int tmp = a[first];
            a[first] = a[second];
            a[second] = tmp;
        }
    }
}

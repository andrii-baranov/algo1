using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo1.Core.Sorting
{
    public class HeapSort
    {
        public void Sort(int[] a)
        {
            int n = a.Length;
            //heapify
            for (int i = n/2; i>=0; i--)
            {
                var leftChild = a[i * 2];
                var rightChild = a[i * 2 + 1];

                if (a[i] < leftChild)
                {
                    if (leftChild > rightChild)
                    {
                        Swap(a, i, i * 2);
                    } else
                    {
                        Swap(a, i, i * 2 + 1);
                    }
                }
                else if (a[i] < rightChild)
                {
                    Swap(a, i, i * 2 + 1);
                }
            }

            while (n >= 0)
            {
                Swap(a, 0, n--);
                // Sink
                Sink(a, 0, n);
            }
        }

        private void Sink(int[] a, int pos, int count)
        {
            int lChildIndex = pos * 2;
            int rChildIndex = pos * 2 + 1;

            Func<bool> hasLeftChild = () => { return lChildIndex < count; };
            Func<bool> hasRightChild = () => { return rChildIndex < count; };

            while (hasLeftChild() || hasRightChild())
            {
                if (hasLeftChild() && a[pos] < a[lChildIndex])
                {
                    Swap(a, pos, lChildIndex);
                    pos = lChildIndex;
                    lChildIndex = pos * 2;
                    rChildIndex = pos * 2 + 1;

                } else if (hasRightChild() && a[pos] < a[rChildIndex])
                {
                    Swap(a, pos, rChildIndex);
                }
                else
                {
                    return;
                }
            }
        }

        private void Swap(int[] a, int low, int high)
        {
            int tmp = a[low];
            a[low] = a[high];
            a[high] = tmp;
        }
    }
}

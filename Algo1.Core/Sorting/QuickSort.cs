using System;

namespace Algo1.Core
{
    public class QuickSort : ISorter
    {
        private PivotSelectionType _pivotType;
        private Func<int[], int, int, int> _partitionFunc;

        public QuickSort() : this(PivotSelectionType.Median)
        {
        }
        public QuickSort(PivotSelectionType pivotSelectionType)
        {
            _pivotType = pivotSelectionType;
            _partitionFunc = GetPartitionFunc(_pivotType);
        }
        /// <summary>
        /// Holds number of comparisons done during the sorting
        /// </summary>
        public long ComparisonsCount;
        public int[] Sort(int[] input)
        {
            ComparisonsCount = 0;

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
                var pivot = _partitionFunc(array, startIndex, endIndex);
                ComparisonsCount += (pivot - 1 - startIndex);
                Sort(array, startIndex, pivot-1);
                ComparisonsCount += (endIndex - pivot + 1);
                Sort(array, pivot + 1, endIndex);
            }
        }

        private Func<int[], int, int, int> GetPartitionFunc(PivotSelectionType pivotSelector)
        {
            switch (pivotSelector)
            {
                case PivotSelectionType.First:
                    return this.PartitionViaLowPivot;
                case PivotSelectionType.Last:
                    return this.PartitionViaHighPivot;
                default:
                case PivotSelectionType.Median:
                    return PartitionViaMedianPivot;
            }
        }
        private int PartitionViaLowPivot(int[] array, int low, int high)
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

        // end
        private int PartitionViaHighPivot(int[] array, int low, int high)
        {
            Swap(array, low, high);

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
        // partition via median pivot
        private int PartitionViaMedianPivot(int[] array, int low, int high)
        {
            int pivotIndex = FindMedianPivotIndex(array, low, high);

            Swap(array, low, pivotIndex);

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
        private int FindMedianPivotIndex(int[] array, int low, int high)
        {
            int length = high - low + 1;
            int middlePos = 0;
            if (length % 2 == 0)
            {
                middlePos = low + length / 2 - 1;
            }
            else
            {
                middlePos = low + length / 2;
            }

            int firstPos = low;
            int lastPos = high;

            int first = array[firstPos];
            int middle = array[middlePos];
            int last = array[lastPos];

            if (first <= middle)
            {
                if (middle <= last)
                {
                    return middlePos;
                }
                else if (first <= last)
                {
                    return lastPos;
                }
                return firstPos;
            }

            if (first <= last)
            {
                return firstPos;
            }
            else if (middle <= last)
            {
                return lastPos;
            }

            return middlePos;
        }
        
        private void Swap(int[] array, int firstIndex, int secondIndex)
        {
            var temp = array[firstIndex];
            array[firstIndex] = array[secondIndex];
            array[secondIndex] = temp;
        }
    }
}

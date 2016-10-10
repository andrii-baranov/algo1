using System;
using System.Collections.Generic;
using System.Linq;

namespace Algo1.Core
{
    //todo add generic implementation
    public class Heap
    {
        //todo change to minMax
        private bool _isMinHeap;

        private List<int> _data;

        public Heap(bool isMinHeap)
        {
            _isMinHeap = isMinHeap;
            _data = new List<int>();
        }


        public void Heapify(int[] input)
        {
            _data.Clear();

            for (int i =0; i<input.Length; i++)
            {
                Insert(input[i]);
            }
        }
        public int GetTop()
        {
            if (_data.Any())
            {
                return _data[0];
            }

            return 0;
        }

        public bool HasItems()
        {
            return _data.Any();
        }

        public void Insert(int item)
        {
            //todo move logic from heapify
            var lastIndex = _data.Count - 1;
            var newElement = item;

            if (lastIndex < 0)
            {
                // only for first item
                _data.Add(newElement);
            }
            else
            {
                _data.Add(newElement);


                var newElementIndex = lastIndex + 1;

                bool finishInsert = false;
                while (!finishInsert)
                {
                    var parentIndex = GetParentIndex(newElementIndex);

                    // todo assuming min heap for now
                    if (_data[parentIndex] > newElement)
                    {
                        // swap elements
                        var tmp = _data[parentIndex];
                        _data[parentIndex] = _data[newElementIndex];
                        _data[newElementIndex] = tmp;

                        newElementIndex = parentIndex;
                    }
                    else
                    {
                        finishInsert = true;
                    }
                }
            }
        }

        //  heap-down
        public int ExtractRoot()
        {
            if (HasItems())
            {
                var root = _data[0];

                var lastChildIndex = _data.Count -1;
                var lastChild = _data[lastChildIndex];


                _data[0] = lastChild;

                _data.RemoveAt(lastChildIndex);

                bool isOrdered = false;

                var currentIndex = 0;

                while (!isOrdered)
                {
                    var leftChildIndex = GetLeftChildIndex(currentIndex);
                    bool leftChildExists = leftChildIndex < _data.Count;
                    int leftChild = leftChildExists ? _data[leftChildIndex] : 0; //temp value 

                    var rightChildIndex = GetRightChildIndex(currentIndex);
                    bool rightChildExists = rightChildIndex < _data.Count;
                    int rightChild = rightChildExists ? _data[rightChildIndex] : 0; //temp value  

                    if (leftChildExists && rightChildExists)
                    {
                        if (leftChild < rightChild)
                        {
                            if (_data[currentIndex] > leftChild)
                            {
                                Swap(currentIndex, leftChildIndex);

                                currentIndex = leftChildIndex;
                            }
                            else
                            {
                                isOrdered = true;
                            }
                        }
                        else
                        {
                            if (_data[currentIndex] > rightChild)
                            {
                                Swap(currentIndex, rightChildIndex);

                                currentIndex = rightChildIndex;
                            }
                            else
                            {
                                isOrdered = true;
                            }
                        }
                    }
                    else if (leftChildExists)
                    {
                        if (_data[currentIndex] > leftChild)
                        {
                            Swap(currentIndex, leftChildIndex);

                            currentIndex = leftChildIndex;
                        }
                        else
                        {
                            isOrdered = true;
                        }
                    }
                    else if (rightChildExists)
                    {
                        if (_data[currentIndex] > rightChild)
                        {
                            Swap(currentIndex, rightChildIndex);

                            currentIndex = rightChildIndex;
                        }
                        else
                        {
                            isOrdered = true;
                        }
                    }
                    else
                    {
                        isOrdered = true;
                    }
                }

                return root;
            }
            else
            {
                throw new ApplicationException("empty heap!");
            }
        }

        private void Swap(int leftIndex, int rightIndex)
        {
            var tmp = _data[leftIndex];
            _data[leftIndex] = _data[rightIndex];
            _data[rightIndex] = tmp;
        }
        private int GetRightChildIndex(int index)
        {
            return 2 * index + 2;
        }


        private int GetLeftChildIndex(int index)
        {
            return 2 * index + 1;
        }

        private int GetParentIndex(int index)
        {
            return (index - 1) / 2;
        }

        private int GetRightChild(int index)
        {
            var rightChildIndex = GetRightChildIndex(index);

            if (rightChildIndex <= _data.Count)
            {
                return _data[rightChildIndex];
            }
            else
            {
                return default(int);
            }
        }

        private int GetLeftChild(int index)
        {
            var leftChildIndex = GetLeftChildIndex(index);

            if (leftChildIndex <= _data.Count)
            {
                return _data[leftChildIndex];
            }
            else
            {
                return default(int);
            }
        }

        private int GetParent(int index)
        {
            var parentIndex = GetParentIndex(index);

            if (parentIndex <= _data.Count)
            {
                return _data[parentIndex];
            }
            else
            {
                return default(int);
            }
        }
    }
}

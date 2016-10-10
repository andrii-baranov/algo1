using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algo1.Core;

namespace Algo1.UnitTests
{
    [TestClass]
    public class HeapTests
    {
        [TestMethod]
        public void HeapifyEmptyArray()
        {
            Heap heap = new Heap(isMinHeap:true);

            heap.Heapify(new int[0] { });

            Assert.IsFalse(heap.HasItems());
        }


        [TestMethod]
        public void HeapifySingleElement()
        {
            Heap heap = new Heap(isMinHeap: true);

            heap.Heapify(new int[1] { 10 });

            Assert.IsTrue(heap.HasItems());
            Assert.IsTrue(heap.GetTop() == 10);
        }

        [TestMethod]
        public void HeapifyTwoElements()
        {
            Heap heap = new Heap(isMinHeap: true);

            heap.Heapify(new int[2] { 2, 4 });

            Assert.IsTrue(heap.HasItems());
            Assert.IsTrue(heap.GetTop() == 2);
        }

        [TestMethod]
        public void HeapifyTwoElementsInverseOrder()
        {
            Heap heap = new Heap(isMinHeap: true);

            heap.Heapify(new int[2] { 4, 2 });

            Assert.IsTrue(heap.HasItems());
            Assert.IsTrue(heap.GetTop() == 2);
        }

        [TestMethod]
        public void HeapifyThreeElements()
        {
            Heap heap = new Heap(isMinHeap: true);

            heap.Heapify(new int[3] { 6, 1, 4 });

            Assert.IsTrue(heap.HasItems());
            Assert.IsTrue(heap.GetTop() == 1);
        }


        [TestMethod]
        public void Heapify6Elements()
        {
            Heap heap = new Heap(isMinHeap: true);

            heap.Heapify(new int[6] { 6, 1, 4, 5, 2,3 });

            Assert.IsTrue(heap.HasItems());
            Assert.IsTrue(heap.GetTop() == 1);
        }

        [TestMethod]
        public void Heapify6ElementsWithDuplicates()
        {
            Heap heap = new Heap(isMinHeap: true);

            heap.Heapify(new int[6] { 3, 5, 4, 5, 2, 3 });

            Assert.IsTrue(heap.HasItems());
            Assert.IsTrue(heap.GetTop() == 2);
        }

        [TestMethod]
        public void HeapifyAndExtract()
        {
            Heap heap = new Heap(isMinHeap: true);

            heap.Heapify(new int[6] { 3, 5, 4, 5, 1, 3 });

            var extracted = heap.ExtractRoot();

            Assert.IsTrue(extracted == 1);

            extracted = heap.ExtractRoot();
            Assert.IsTrue(extracted == 3);
        }

        [TestMethod]
        public void HeapifyAndExtract5Elements()
        {
            Heap heap = new Heap(isMinHeap: true);

            heap.Heapify(new int[5] { 3, 5, 4, 2, 1 });

            for (int i = 1; i <= 5; i++)
            {
                var extracted = heap.ExtractRoot();
                Assert.IsTrue(extracted == i);
            }
        }

        [TestMethod]
        public void HeapifyAndExtract8Elements()
        {
            Heap heap = new Heap(isMinHeap: true);

            heap.Heapify(new int[8] { 7,6, 3, 5, 4, 2, 1, 8 });

            for (int i = 1; i <= 8; i++)
            {
                var extracted = heap.ExtractRoot();
                Assert.IsTrue(extracted == i);
            }
        }


        [TestMethod]
        public void InsertExtract4Elements()
        {
            Heap heap = new Heap(isMinHeap: true);

            for (int i = 1; i <= 4; i++)
            {
                heap.Insert(i);
            }


            Assert.IsTrue(heap.GetTop() == 1);

            for (int i = 1; i <= 4; i++)
            {
                var extracted = heap.ExtractRoot();
                Assert.IsTrue(extracted == i);
            }
        }
    }
}

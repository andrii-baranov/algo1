using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo1.Core.LeetCode
{
    public class ListProblems
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        //LeetCode 61. Rotate List
        public ListNode RotateRight(ListNode head, int k)
        {
            if (head == null || head.next == null)
            {
                return head;
            }

            var slowNode = head;
            var fastNode = head;
            int itemsCount = 1;

            while (fastNode.next != null)
            {
                fastNode = fastNode.next;

                itemsCount++;
            }

            k = k % itemsCount;
            int realShift = itemsCount - k;

            if (k == 0)
            {
                return head;
            }

            int cnt = 1;
            while (cnt < realShift)
            {
                slowNode = slowNode.next;
                cnt++;
            }

            var newHead = slowNode.next;
            slowNode.next = null;
            fastNode.next = head;

            return newHead;
        }
    }
}

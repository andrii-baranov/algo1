using Algo1.Core.LeetCode;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Algo1.Core.LeetCode.ListProblems;

namespace Algo1.UnitTests
{
    [TestClass]
    public class ListProblemTests
    {
        [TestMethod]
        public void RotateListBy1Test()
        {
            ListNode head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(3);
            head.next.next.next = new ListNode(4);

            var result = new ListProblems().RotateRight(head, 1);

            Assert.IsTrue(result.val == 4);
        }

        [TestMethod]
        public void RotateListBy2Test()
        {
            ListNode head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(3);
            head.next.next.next = new ListNode(4);

            var result = new ListProblems().RotateRight(head, 2);

            Assert.IsTrue(result.val == 3);
        }

        [TestMethod]
        public void RotateListBy4Test()
        {
            ListNode head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(3);
            head.next.next.next = new ListNode(4);

            var result = new ListProblems().RotateRight(head, 4);

            Assert.IsTrue(result.val == 1);
        }

        [TestMethod]
        public void RotateListBy5Test()
        {
            ListNode head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(3);
            head.next.next.next = new ListNode(4);

            var result = new ListProblems().RotateRight(head, 5);

            Assert.IsTrue(result.val == 4);
        }

        [TestMethod]
        public void RotateListBy3Test()
        {
            ListNode head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(3);
            head.next.next.next = new ListNode(4);

            var result = new ListProblems().RotateRight(head, 3);

            Assert.IsTrue(result.val == 2);
        }
    }
}

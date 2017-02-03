using Algo1.Core.LeetCode;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Algo1.Core.LeetCode.ArrayProblems;

namespace Algo1.UnitTests
{
    [TestClass]
    public class ArrayProblemTests
    {
        [TestMethod]
        public void InsertIntervalTests()
        {
            var arrProblem = new ArrayProblems();
            List<Interval> intervals = new List<Interval>();

            intervals.Add(new Interval(1, 2));
            intervals.Add(new Interval(3, 5));
            intervals.Add(new Interval(6, 7));
            intervals.Add(new Interval(8, 10));
            intervals.Add(new Interval(12, 16));

            var intervalToMerge = new Interval(5, 7);

            var result = arrProblem.Insert(intervals, intervalToMerge);

            Assert.AreEqual(result.Count, 4);
        }

        [TestMethod]
        public void InsertIntervalTestToStart()
        {
            var arrProblem = new ArrayProblems();
            List<Interval> intervals = new List<Interval>();

            intervals.Add(new Interval(2, 2));
            intervals.Add(new Interval(3, 5));
            intervals.Add(new Interval(6, 7));
            intervals.Add(new Interval(8, 10));
            intervals.Add(new Interval(12, 16));

            var intervalToMerge = new Interval(0, 1);

            var result = arrProblem.Insert(intervals, intervalToMerge);

            Assert.AreEqual(result.Count, 6);
        }

        [TestMethod]
        public void InsertIntervalTestToMiddle()
        {
            var arrProblem = new ArrayProblems();
            List<Interval> intervals = new List<Interval>();

            intervals.Add(new Interval(2, 2));
            intervals.Add(new Interval(3, 5));
            intervals.Add(new Interval(6, 7));
            intervals.Add(new Interval(8, 9));
            intervals.Add(new Interval(12, 16));

            var intervalToMerge = new Interval(10, 11);

            var result = arrProblem.Insert(intervals, intervalToMerge);

            Assert.AreEqual(result.Count, 6);
        }

        [TestMethod]
        public void InsertIntervalTestToBack()
        {
            var arrProblem = new ArrayProblems();
            List<Interval> intervals = new List<Interval>();

            intervals.Add(new Interval(2, 2));
            intervals.Add(new Interval(3, 5));

            var intervalToMerge = new Interval(6, 8);

            var result = arrProblem.Insert(intervals, intervalToMerge);

            Assert.AreEqual(result.Count, 3);
        }

        [TestMethod]
        public void InsertIntervalTestToEmpty()
        {
            var arrProblem = new ArrayProblems();
            List<Interval> intervals = new List<Interval>();


            var intervalToMerge = new Interval(6, 8);

            var result = arrProblem.Insert(intervals, intervalToMerge);

            Assert.AreEqual(result.Count, 1);
        }

    }
}

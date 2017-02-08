using System;
using System.Collections.Generic;
using System.Linq;

namespace Algo1.Core.LeetCode
{
    public class ArrayProblems
    {
        // LeetCode 57. Insert Interval
        public IList<Interval> Insert(IList<Interval> intervals, Interval newInterval)
        {
            int curIndex = 0;
            int endIndex = 0;
            int startIndex = -1;
            int newEnd = newInterval.end;
            int newStart = newInterval.start;
            List<Interval> result = new List<Interval>();

            if (intervals.Count == 0 ||intervals[curIndex].start > newInterval.end)
            {
               // edge case, no overlapping, add to start
                result.Add(newInterval);
                result.AddRange(intervals);

                return result;
            }

            if (intervals.Last().end < newInterval.start)
            {
                // edge case, no intersection - add to end
                result.AddRange(intervals);
                result.Add(newInterval);
                
                return result;
            }


            bool startMatching = false;
            bool stopMatching = false;

            while (curIndex + 1 < intervals.Count && !(startMatching && stopMatching))
            {
                if (!startMatching
                    && intervals[curIndex].end < newInterval.start
                    && intervals[curIndex + 1].start > newInterval.end)
                {
                    //Interval is in the middle
                    // put into result set and quit
                    result.AddRange(intervals);
                    result.Insert(curIndex+1, newInterval);
                    return result;
                }

                if (intervals[curIndex].start <= newInterval.start && !startMatching)
                {
                    if (intervals[curIndex].end >= newInterval.start)
                    {
                        // interval starts inside of curInterval
                        startMatching = true;
                        startIndex = curIndex;
                        newStart = Math.Min(intervals[curIndex].start, newInterval.start);

                        if (intervals[curIndex].end >= newInterval.end)
                        {
                            // current interval holds entire new interval
                            stopMatching = true;
                        }
                    }
                }
                else if (startMatching && intervals[curIndex].start > newEnd)
                {
                    // mattching ends between intervals
                    stopMatching = true;
                    endIndex = curIndex;
                }
                else if (startMatching && intervals[curIndex].start <= newEnd)
                {
                    newEnd = Math.Max(intervals[curIndex].end, newEnd);
                    endIndex = curIndex;
                }
                else if (!startMatching && intervals[curIndex].start > newInterval.start)
                {
                    newStart = Math.Min(intervals[curIndex].start, newInterval.start);
                    startIndex = curIndex;
                    startMatching = true;
                }

                curIndex++;
            }

            newInterval.start = newStart;
            newInterval.end = newEnd;


            result.AddRange(intervals.Take(startIndex));
            result.Add(newInterval);
            result.AddRange(intervals.Skip(stopMatching ? endIndex : intervals.Count - 1));

            return result;
        }

        public class Interval
        {
            public int start;
            public int end;
            public Interval() { start = 0; end = 0; }
            public Interval(int s, int e) { start = s; end = e; }
        }
    }
}

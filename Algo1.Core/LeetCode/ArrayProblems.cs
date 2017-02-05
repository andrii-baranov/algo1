using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo1.Core.LeetCode
{
    public class ArrayProblems
    {
        // LeetCode 57. Insert Interval
        public IList<Interval> Insert(IList<Interval> intervals, Interval newInterval)
        {
            int curIndex = 0;
            int endIndex = 0;
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


            return result;

            //// find interscetion start TODO fix
            //while (curIndex  < intervals.Count
            //      && (intervals[curIndex].start > newEnd || intervals[curIndex].end < newStart)
            //    )
            //{
            //    curIndex++;
            //}

            //if (intervals[curIndex].end < newStart)
            //{
            //    // instert after TODO

            //    result.AddRange(intervals.Take(curIndex + 1));
            //    result.Add(newInterval);
            //    result.AddRange(intervals.Skip(curIndex+1));

            //    return result;
            //}


            //// merge start point
            //newStart = Math.Min(intervals[curIndex].start, newStart);
            //newEnd = Math.Max(newEnd, intervals[curIndex].end);
            //endIndex = curIndex;

            //while (endIndex + 1 < intervals.Count && newEnd >= intervals[endIndex+1].start)
            //{
            //    newEnd = Math.Max(newEnd, intervals[endIndex + 1].end);
            //    endIndex++;
            //}

            //// curIndex - start of merged items,
            //// endIndex - end of merged items
            //newInterval.start = newStart;
            //newInterval.end = newEnd;

            //result.AddRange(intervals.Take(curIndex));
            //result.Add(newInterval);
            //result.AddRange(intervals.Skip(endIndex + 1));

            //return result;
        }

        public class Interval
        {
            public int start;
            public int end;
            public Interval() { start = 0; end = 0; }
            public Interval(int s, int e) { start = s; end = e; }
        }


        // LeetCode 62. Unique Paths
        public int UniquePaths(int m, int n)
        {
            int[,] map = new int[m, n];

            map[0, 0] = 1;

            for (int r = 0; r < m; r++)
            {

                for (int col = 0; col < n; col++)
                {
                    if (col > 0)
                    {
                        map[r, col] = map[r,col] + map[r, col - 1];
                    }

                    if (r > 0)
                    {
                        map[r, col] = map[r, col] + map[r - 1, col];
                    }
                }
            }

            return map[m - 1, n - 1];
        }
    }
}

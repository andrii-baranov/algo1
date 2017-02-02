using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo1.Core
{
    public class StackSorter
    {
        public static void SortStack(Stack<int> left)
        {
            Stack<int> right = new Stack<int>();
            int temp;

            while(left.Count > 0 )
            {
                temp = left.Pop();

                while (right.Count > 0 && temp < right.Peek())
                {
                    left.Push(right.Pop());
                }

                right.Push(temp);
            }


            while (right.Count > 0)
            {
                left.Push(right.Pop());
            }


        }

    }
}

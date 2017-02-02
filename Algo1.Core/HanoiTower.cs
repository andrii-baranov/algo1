using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo1.Core
{
    public class HanoiTower
    {
        private int _stackSize;

        private Stack<int> _a;

        private Stack<int> _b;

        private Stack<int> _c;

        public HanoiTower(int stackSize)
        {
            _a = new Stack<int>();
            _b = new Stack<int>();
            _c = new Stack<int>();

            _stackSize = stackSize;
        }


        public void Populate(int blocks)
        {
            for (int i = blocks; i >= 0; i++)
            {
                _a.Push(i);
            }
        }

        public void Move()
        {
            var count = _a.Count;

            Move(count, _a, _c, _b);
        }

        private void Move(int numBlocks, Stack<int> source, Stack<int> dest, Stack<int> buffer)
        {
            if (numBlocks == 1)
            {
                if (dest.Peek() > source.Peek())
                {
                    dest.Push(source.Pop());
                }
            }

            if (numBlocks == 2)
            {
                Move(1, source, buffer, dest);
                Move(1, source, dest, buffer);
                Move(1, buffer, dest, source);

                return;
            }

            if (numBlocks > 2)
            {
                Move(numBlocks - 1, source, buffer, dest);
                Move(1, source, dest, buffer);
                Move(numBlocks - 1, buffer, dest, source);
            }
        }
    }
}

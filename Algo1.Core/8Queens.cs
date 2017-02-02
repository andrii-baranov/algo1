using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo1.Core
{
    public class NQueens
    {
        private int[][] _board;

        private int[] _busyRows;

        private int[] _busyCols;

        private int _queensCount;

        private List<int[]> _placedQueens;
        public NQueens(int boardSize, int queensCount)
        {
            _queensCount = queensCount;
            InitBoard(boardSize);
        }

        private void InitBoard(int boardSize)
        {
            _board = new int[boardSize][];
            _busyRows = new int[boardSize];
            _busyCols = new int[boardSize];
            _placedQueens = new List<int[]>();

            for (int i = 0; i < boardSize; i++)
            {
                _board[i] = new int[boardSize];
                for (int j = 0; j < boardSize; j++)
                {
                    _board[i][j] = 0;
                }
            }
        }

        public void PrintBoard()
        {
            Console.WriteLine();
            for (int i = 0; i < _board.Length; i++)
            {
                for (int j = 0; j < _board.Length; j++)
                {
                    Console.Write(_board[i][j] + " ");
                }
                Console.WriteLine();
            }
        }

        public void FindNSolutions(int n)
        {
            List<int[]> usedFigures = new List<int[]>();
            for (int i =0; i < n; i++)
            {
                PlaceNQueens();
                PrintBoard();
                usedFigures.AddRange(_placedQueens);
                ClearCombination(usedFigures);
            }
        }

        private void ClearCombination(List<int[]> usedQueens)
        {
            InitBoard(_board.Length);

            foreach (var queen in usedQueens)
            {
                _board[queen[0]][queen[1]] = -1;
            }
        }

        public void PlaceNQueens()
        {
            int row = 0;
            int col = 0;

            InitBoard(_board.Length);




            //if (PlaceQueenToRow(0))
            //{
            //    PrintBoard();
            //}
            //while (_placedQueens.Count < _queensCount)
            //{
            //    var queen = PlaceQueen();

            //    if (queen == null)
            //    {
            //        // remove last placed queen
            //        var last = _placedQueens[_placedQueens.Count - 1];
            //        _placedQueens.RemoveAt(_placedQueens.Count - 1);

            //        _board[last[0]][last[1]] = -1;
            //        _busyCols[last[1]] = 0;
            //        _busyRows[last[0]] = 0;
            //    }
            //    else
            //    {
            //        // clear used points
            //    }
            //}
        }

        public bool PlaceQueenToRow(int rowToPlace)
        {
            if (rowToPlace >= _board.Length)
            {
                return true;

            }
            for (int i =0; i < _board.Length; i++)
            {
                if (CanPlaceQueen(rowToPlace, i, _board))
                {
                    _board[rowToPlace][i] = 1;

                    if (PlaceQueenToRow(rowToPlace + 1))
                    {
                        return true;
                    }
                    else
                    {
                        _board[rowToPlace][i] = 0;
                    }
                }
            }

            return false;
        }

        public int[] PlaceQueen()
        {
            for (int i = 0; i < _board.Length; i++)
            {
                if (_busyRows[i] == 1)
                {
                    continue;
                }
                for (int j = 0; j <_board.Length; j++)
                {
                    if (_busyCols[j] == 1)
                    {
                        continue;
                    }

                    if (CanPlaceQueen(i, j, _board))
                    {
                        _board[i][j] = 1;
                        _busyRows[i] = 1;
                        _busyCols[j] = 1;
                        var queen = new int[] { i, j };
                        _placedQueens.Add(queen);
                        return queen;
                    }
                }
            }

            // Could not find place for queen
            return null;
        }

        private bool CanPlaceQueen(int row, int col, int[][] board)
        {
            if (board[row][col] != 0)
            {
                return false;
            }

            for (int i =0; i < board.Length; i++)
            {
                if (board[row][i] > 0)
                {
                    return false;
                }
            }

            for (int i = 0; i < board.Length; i++)
            {
                if (board[i][col] > 0)
                {
                    return false;
                }
            }

            int r = row;
            int c = col;

            while (r >= 0 && c>=0)
            {
                if (board[r--][c--] > 0)
                {
                    return false;
                }

            }

            r = row;
            c = col;

            while (r >= 0 && c < board.Length)
            {
                if (board[r--][c++] > 0)
                {
                    return false;
                }

            }

            r = row;
            c = col;

            while (r < board.Length && c < board.Length)
            {
                if (board[r++][c++] > 0)
                {
                    return false;
                }

            }

            r = row;
            c = col;

            while (r < board.Length && c >= 0)
            {
                if (board[r++][c--] > 0)
                {
                    return false;
                }

            }

            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo1.Core
{
    /// <summary>
    ///  Solution drafts of LeetCode problems
    /// </summary>
    public class Solution
    {
        public static string Convert(string s, int numRows)
        {
            if (s == null || s.Length <= numRows)
            {
                return s;
            }

            StringBuilder[] buffs = new StringBuilder[numRows];

            for (int i = 0; i < numRows; i++)
            {
                buffs[i] = new StringBuilder();
            }

            int zCount = Math.Max(numRows - 2, 1);

            int cycleSize = numRows + zCount;

            for (int i = 0; i < s.Length; i++)
            {
                int pos = i % cycleSize;

                if (pos < numRows)
                {
                    buffs[pos].Append(s[i]);
                }
                else
                {
                    pos = (numRows - 1) - pos + (numRows - 1);
                    buffs[pos].Append(s[i]);
                }
            }

            string result = null;
            foreach (var buf in buffs)
            {
                result += buf.ToString();
            }

            return result;
        }

        public static string[] GroupAnagrams(string[] input)
        {
            Dictionary<string, List<int>> sortedInputs = new Dictionary<string, List<int>>();

            // 1) find all matching anagrams
            for (int i = 0; i < input.Length; i++)
            {
                var sorted = String.Concat(input[i].OrderBy(c => c));
                
                if (sortedInputs.ContainsKey(sorted))
                {
                    sortedInputs[sorted].Add(i);
                }
                else
                {
                    sortedInputs.Add(sorted, new List<int>() { i });
                }
            }


            string[] result = new string[input.Length];

            int rCount = 0;

            foreach(var s in sortedInputs)
            {
                foreach(var idx in s.Value)
                {
                    result[rCount++] = input[idx];
                }
            }

            return result;
        }

        public IList<int> FindSubstring(string s, string[] words)
        {
            // generate word combinations
            // check entries in big string
            if (s == null || words == null || s.Length == 0 || words.Length == 0)
            {
                return new List<int>();
            }

            var wordLen = words[0].Length;

            if (wordLen * words.Length > s.Length)
            {
                return new List<int>();
            }

            List<string> combinations = new List<string>();
            List<string> wordsList = words.ToList();
            List<int> result = new List<int>();
            Dictionary<int, string> indexMap = new Dictionary<int, string>();
            Dictionary<string,int> allWords = new Dictionary<string,int>();

            for (int i = 0; i < words.Length; i++)
            {
                if (allWords.ContainsKey(words[i]))
                {
                    allWords[words[i]]++;
                }
                else
                {
                    allWords.Add(words[i], 1);
                }

                var startIndex = s.IndexOf(words[i]);

                if (startIndex == -1)
                {
                    return result;
                }
                else
                {
                    while (startIndex != -1)
                    {
                        if (!indexMap.ContainsKey(startIndex))
                        {
                            indexMap.Add(startIndex, words[i]);
                        }
                        startIndex = s.IndexOf(words[i], startIndex + 1);
                    }
                }
            }

            for (int i = 0; i < indexMap.Count; i++)
            {
                var startWord = indexMap.ElementAt(i);

                if ((startWord.Key + words.Length * wordLen) > s.Length)
                {
                    continue;
                }
                Dictionary<string, int> usedWords = new Dictionary<string, int>();
                int usedCount = 1;
                usedWords.Add(startWord.Value, 1);

                int nextIndex = startWord.Key + wordLen;
                string next = (nextIndex + wordLen) <= s.Length ? s.Substring(nextIndex, wordLen) : null;

                while (next != null)
                {
                    if (allWords.ContainsKey(next))
                    {
                        if (usedWords.ContainsKey(next) && usedWords[next] >= allWords[next])
                        {
                            break;
                        }
                        else
                        {
                            if (usedWords.ContainsKey(next))
                            {
                                usedCount++;
                                usedWords[next]++;
                            }
                            else
                            {
                                usedCount++;
                                usedWords.Add(next, 1);
                            }
                        }

                        nextIndex = nextIndex + wordLen;
                        next = (nextIndex + wordLen) <= s.Length ? s.Substring(nextIndex, wordLen) : null;
                    }
                    else
                    {
                        break;
                    }
                }

                if (usedCount == words.Length)
                {
                    result.Add(startWord.Key);
                }
            }

            return result;
        }

        public IList<int> FindSubstring2(string s, string[] words)
        {
            // generate word combinations
            // check entries in big string
            if (s == null || words == null || s.Length == 0 || words.Length == 0)
            {
                return new List<int>();
            }

            var wordLen = words[0].Length;

            if (wordLen * words.Length > s.Length)
            {
                return new List<int>();
            }

            List<string> combinations = new List<string>();
            List<string> wordsList = words.ToList();
            List<int> result = new List<int>();

            //GenerateWordStrings(wordsList, combinations, "");

            for (int i = 0; i < combinations.Count(); i++)
            {
                var curInd = s.IndexOf(combinations[i]);

                while (curInd != -1)
                {
                    if (!result.Contains(curInd))
                    {
                        result.Add(curInd);
                    }

                    curInd = s.IndexOf(combinations[i], curInd + 1);
                }
            }

            return result;
        }

        public IList<int> FindSubstring4(string s, string[] words)
        {
            // generate word combinations
            // check entries in big string
            if (s == null || words == null || s.Length == 0 || words.Length == 0)
            {
                return new List<int>();
            }

            HashSet<int> result = new HashSet<int>();

            var wordLen = words[0].Length;

            if (wordLen * words.Length > s.Length)
            {
                return new List<int>();
            }

            Dictionary<string, int> wordMap = new Dictionary<string, int>();

            foreach(var w in words)
            {
                if (wordMap.ContainsKey(w))
                {
                    wordMap[w]++;
                }
                else
                {
                    wordMap.Add(w, 1);
                }
            }

            for (int i = 0; i < s.Length; i++)
            {
                Dictionary<string, int> usedWords = new Dictionary<string, int>();
                int usedCount = 1;
                var curWord = s.Substring(i, wordLen);
                if (!wordMap.ContainsKey(curWord))
                {
                    continue;
                }

                usedWords.Add(curWord, 1);

                for (int j = i + wordLen; j < j + wordLen* (words.Length - 1); j+=wordLen)
                {
                    var nWord = s.Substring(j, wordLen);

                    if (wordMap.ContainsKey(nWord))
                    {
                        if (usedWords.ContainsKey(nWord) && usedWords[nWord] >= wordMap[nWord])
                        {
                            break;
                        }
                        else
                        {
                            if (usedWords.ContainsKey(nWord))
                            {
                                usedWords[nWord]++;
                                usedCount++;
                            }
                            else
                            {
                                usedWords.Add(nWord, 1);
                                usedCount++;
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                if (usedCount == words.Length)
                {
                    if (!result.Contains(i))
                    {
                        result.Add(i);
                    }
                }
            }


            return result.ToList();
        }

        public IList<int> FindSubstring3(string s, string[] words)
        {
            // generate word combinations
            // check entries in big string
            if (s == null || words == null || s.Length == 0 || words.Length == 0)
            {
                return new List<int>();
            }

            var wordLen = words[0].Length;

            if (wordLen * words.Length > s.Length)
            {
                return new List<int>();
            }

            List<string> combinations = new List<string>();
            List<string> wordsList = words.ToList();
            List<int> result = new List<int>();
            HashSet<int> idxs = new HashSet<int>();

            FindCombs(idxs, wordsList, combinations, "", s);


            return idxs.ToList(); 
        }

        private void FindCombs(HashSet<int> indexes, List<string> words, List<string> combinations, string currentComb, string target)
        {
            if (words.Count == 0)
            {
                var idx = target.IndexOf(currentComb);
                if (idx != -1 && !indexes.Contains(idx))
                {
                    indexes.Add(idx);
                }
            }
            else
            {
                for (int i = 0; i < words.Count; i++)
                {
                    if (!target.Contains(currentComb))
                    {
                        return;
                    }
                    var leftWords = words.ToList();
                    var word = leftWords[i];
                    leftWords.RemoveAt(i);
                    FindCombs(indexes, leftWords, combinations, currentComb + word, target);
                }
            }
        }

        public int LongestValidParentheses(string s)
        {
            Stack<int> openItems = new Stack<int>();
            openItems.Push(-1); //base case

            int curCount = 0;
            int maxCount = 0;


            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    openItems.Push(i);
                }
                else
                {
                    openItems.Pop();

                    if (openItems.Count > 0)
                    {
                        curCount = i - openItems.Peek();
                        if (curCount > maxCount)
                        {
                            maxCount = curCount;
                        }
                    }
                    else
                    {
                        openItems.Push(i); //new base case
                    }
                }
            }

            return maxCount;
        }


        public int SearchRotated(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
            {
                return -1;
            }

            return SearchRotated(nums, target, 0, nums.Length - 1);
        }

        public void SolveSudoku(char[,] board)
        {
            int size = 9;
            SubSolve(board, size, 0);
        }

        private bool CanPlace(char[,] board, int size, int row, int col, int value)
        {
            var testBoard = board.Clone() as char[,];
            testBoard[row, col] = value.ToString()[0];

            HashSet<char> rowH = new HashSet<char>();
            HashSet<char> colH = new HashSet<char>();

            for (int i = 0; i < size; i++)
            {

            

                if (testBoard[row,i] != '.' && !rowH.Add(testBoard[row, i]))
                {
                    return false;
                }


                if (testBoard[i, col] != '.' && !colH.Add(testBoard[i, col]))
                {
                    return false;
                }
            }

            // check block
            HashSet<char> boxH = new HashSet<char>();
            int rStart = 3 * (row / 3);
            int cStart = 3 * (col / 3);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j <3; j++)
                {
                    if (testBoard[rStart + i, cStart + j] != '.' 
                        && !boxH.Add(testBoard[rStart +i, cStart + j]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private bool SubSolve(char[,] board, int size, int number)
        {
            int row = number / size;
            int col = number % size;

            if (row >= size || col >= size)
            {
                return true;

                //if (IsValidSudoku(board))
                //{
                //    return true;
                //}

                //return false;
            }

            if (board[row, col] != '.')
            {
                if (SubSolve(board, size, number + 1))
                {
                    return true;
                }
            }
            else
            {
                HashSet<char> invalidItems = new HashSet<char>();

                for (int i = 0; i < size; i++)
                {
                    if (board[row, i] != '.')
                    {
                        invalidItems.Add(board[row, i]);
                    }

                    if (board[i, col] != '.')
                    {
                        invalidItems.Add(board[i, col]);
                    }

                }

                for (int i = 1; i <= size; i++)
                {
                    if (!invalidItems.Contains(i.ToString()[0])
                         && CanPlace(board, size, row, col, i))
                    {
                        board[row, col] = i.ToString()[0];
                        if (SubSolve(board, size, number + 1))
                        {
                            return true;
                        }
                        else
                        {
                            board[row, col] = '.';
                        }
                    }
                }
            }

            return false;
        }

        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            IList<IList<int>> r = new List<IList<int>>();
            var c = new List<int>();
            HashSet<string> comboHash = new HashSet<string>();

            CalcComb(candidates.OrderBy(i => i).ToArray(), 0, target, comboHash, c, r, 0);

            return r;
        }

        private void CalcComb(int[] candidates, int curSum, int target, 
            HashSet<string> cmbHash, 
            IList<int> currentCombo, 
            IList<IList<int>> result,
            int startPos)
        {
            if (curSum == target)
            {
                currentCombo = currentCombo.OrderBy(c => c).ToList();

                StringBuilder pattern = new StringBuilder();
                for (int i = 0; i < currentCombo.Count(); i++)
                {
                    pattern.AppendFormat("{0}|", currentCombo[i]);
                }

                if (cmbHash.Contains(pattern.ToString()))
                {
                    return;
                }
                else
                {
                    result.Add(currentCombo);
                    cmbHash.Add(pattern.ToString());
                }

                return;
            }
            else if (curSum > target)
            {
                return;
            }


            for (int i = startPos; i < candidates.Length; i++)
            {
                if (curSum + candidates[i] <= target)
                {
                    currentCombo.Add(candidates[i]);
                    CalcComb(candidates, curSum + candidates[i], target, cmbHash, currentCombo, result, i);
                    currentCombo.Remove(candidates[i]);
                }
            }
        }


        public int FirstMissingPositive(int[] nums)
        {
            int n = nums.Length;

            for (int i = 0; i < n; ++i)
                while (nums[i] > 0 && nums[i] <= n && nums[nums[i] - 1] != nums[i])
                    Swap(nums,i , nums[i] - 1);

            for (int i = 0; i < n; ++i)
                if (nums[i] != i + 1)
                    return i + 1;

            return n + 1;
        }

        private void Swap(int[] nums, int i, int j)
        {
            int tmp = nums[i];
            nums[i] = nums[j];
            nums[j] = tmp;
        }

        private int SearchRotated(int[] nums, int target, int left, int right)
        {
            if (left > right)
            {
                return -1;
            }

            int curInd = left + (right - left) / 2;

            if (nums[curInd] == target)
            {
                return curInd;
            }
            else if (
                (target < nums[curInd] && nums[left] < nums[right]) // simple case with no rotation
                || (nums[left] > nums[right] && target > nums[right])
                || (nums[left] > nums[right] 
                        && target < nums[curInd]  
                        && target < nums[right])
                )
            {
                return SearchRotated(nums, target, left, curInd - 1);

            }
            else
            {
                return SearchRotated(nums, target, curInd + 1, right);
            }
        }

        public bool IsValidSudoku(char[,] board)
        {
            int size = System.Convert.ToInt32(Math.Sqrt(board.Length));
            int subSize = System.Convert.ToInt32(Math.Sqrt(size));
            List<HashSet<int>> colHashes = new List<HashSet<int>>();

            for (int row = 0; row < size; row++)
            {
                HashSet<int> rowHash = new HashSet<int>();
                for (int col = 0; col < size; col++)
                {
                    if (colHashes.Count() <= col)
                    {
                        colHashes.Add(new HashSet<int>());
                    }

                    int cur = 0;

                    if (int.TryParse(board[row,col].ToString(), out cur))
                    {
                        if (colHashes[col].Contains(cur) ||  rowHash.Contains(cur))
                        {
                                return false;
                        }
                        else
                        {
                            colHashes[col].Add(cur);
                            rowHash.Add(cur);
                        }

                    }

                    if ( (row + 1) % subSize == 1 && (col + 1) % subSize == 1
                        && (row + 1) < size && (col + 1)  < size
                        )
                    {
                        if (!CheckBoard(board, row, col, subSize))
                        {
                            return false;
                        }
                    }


                }

            }
           return true;
        }

        private bool CheckBoard(char[,] board, int rowStart, int colStart, int size)
        {
            HashSet<int> boxHash = new HashSet<int>();
            // check row sum
            for (int i = rowStart; i < rowStart + size; i++)
            {
                for (int j = colStart; j < colStart + size; j++)
                {
                    int cur = 0;
                    if (Int32.TryParse(board[i, j].ToString(), out cur))
                    {
                        if (boxHash.Contains(cur))
                        {
                            return false;
                        }
                        else
                        {
                            boxHash.Add(cur);
                        }
                    }
                }
            }

            return true;
        }

        public static int[] SortedMerge(int[] a, int[] b)
        {
            int bLast = b.Length - 1;
            int aLast = a.Length - 1 - b.Length;

            int mCur = a.Length - 1;
            while (bLast >= 0)
            {
                if (aLast > 0 && b[bLast] < a[aLast])
                {
                    a[mCur] = a[aLast--];
                    
                }
                else
                {
                    a[mCur] = b[bLast--];
                }
                mCur--;
            }

            return a;

            //for (int i = 0; i < b.Length; i++)
            //{
            //    int mergedItem = b[i];
            //    int mIndex = a.Length - b.Length + i;
            //    a[mIndex] = mergedItem;

            //    int j = a.Length - b.Length + i - 1;

            //    while (j >= 0 && a[j] > mergedItem)
            //    {
            //        int tmp = a[j];
            //        a[j] = a[j+1];
            //        a[j+1] = tmp;
            //        j--;
            //    }
            //}

            //return a;
        }

        public static int Reverse(int x)
        {
            if (x >= 0 && x < 10)
            {
                return x;
            }

            long result = 0;
            while (x != 0)
            {
                result = result * 10 + x % 10;

                x = x / 10;

                if (result > Int32.MaxValue || result < Int32.MinValue)
                {
                    return 0;
                }
            }

            return System.Convert.ToInt32(result);
        }
        public int MaxSubArray(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }

            int runVal = 0;
            int maxVal = nums[0];
            int maxInd = 0;
            int curStart = 0;


            for (int i = 0; i < nums.Length; i++)
            {
                var withoutF = runVal - nums[curStart];

                if (withoutF > runVal && i > 0)
                {
                    curStart++;
                    runVal = withoutF;
                }


                if (nums[i] > nums[i] + runVal)
                {
                    runVal = nums[i];
                    curStart = i;
                }
                else
                {
                    runVal = nums[i] + runVal;
                }

                if (runVal > maxVal)
                {
                    maxVal = runVal;
                }

            }

            return maxVal;
        }


        public string LongestPalindrome(string s)
        {
            if (s == null || s.Length <= 1)
            {
                return s;
            }

            string maxPal = s[0].ToString();

            for (int i = 1; i < s.Length; i++)
            {
                maxPal = BuildPalindrome(s, i, i, maxPal);
                maxPal = BuildPalindrome(s, i - 1, i, maxPal);
            }

            return maxPal;
        }

        public double MyPow(double x, int n)
        {
            int c = 0;
            double result = 1;
            long nMax = n;
            Dictionary<long, double> powers = new Dictionary<long, double>();

            if (x == 0)
            {
                return 0;
            }

            if (n == 0)
            {
                return 1;
            }

            if (x == 1)
            {
                return x;
            }

            if (n < 0)
            {
                x = 1 / x;
                nMax = n;
                nMax = nMax * (long)-1;
            }

            powers.Add(0, 1);
            powers.Add(1, x);

            result = CalcPow(x, nMax, powers);

            return result;
        }

        private double CalcPow(double x, long n, Dictionary<long, double> known)
        {
            if (known.ContainsKey(n))
            {
                return known[n];
            }

            long l = n / 2;
            long r = n - l;

            double rL = CalcPow(x, l, known);


            if (rL == 0)
            {
                known.Add(n, 0);
                return 0;
            }

            double rR = CalcPow(x, r, known);

            if (rR == 0)
            {
                known.Add(n, 0);

                return 0;
            }

            double result = rR * rL;

            known.Add(n, result);

            return result;
        }


        private string BuildPalindrome(string s, int l, int r, string curMax)
        {
            while (l >= 0 && r < s.Length && s[l] == s[r])
            {
                l--;
                r++;
            }

            if (curMax.Length < r - l - 1)
            {
                return s.Substring(l + 1, r - l - 1);
            }

            return curMax;
        }

        public bool IsMatch(string s, string p)
        {
            if (s == null || p == null)
            {
                return false;
            }

            bool[][] lookUp = new bool[s.Length][];

            for (int i = 0; i < s.Length; i++)
                lookUp[i] = new bool[p.Length];

            lookUp[0][0] = true;

            for (int i = 1; i < p.Length; i++)
            {
                if (p[i - 1] == '*')
                {
                    lookUp[0][i] = lookUp[0][i - 1];
                }
            }

            for (int i = 1; i < s.Length; i++)
            {
                for (int j = 1; j < p.Length; j++)
                {
                    if (p[j - 1] == '*')
                    {
                        lookUp[i][j] = lookUp[i][j - 1] || lookUp[i - 1][j];
                    }
                    else if (p[j - 1] == '?' || s[i - 1] == p[j - 1])
                    {
                        lookUp[i][j] = lookUp[i - 1][j - 1];
                    }
                    else
                    {
                        lookUp[i][j] = false;
                    }
                }
            }

            return lookUp[s.Length - 1][p.Length - 1];
        }

        public static int MyAtoi(string str)
        {
            long result = 0;
            long maxMinusInt = Int32.MaxValue;
            maxMinusInt++;

            str = str.Trim();

            if (str.Length == 0)
            {
                return 0;
            }

            int mask = 1;

            int startIndex = 0;
            if (str[0] == '-')
            {
                mask = -1;
                startIndex++;
            }
            else if (str[0] == '+')
            {
                startIndex++;
            }


            for (int i = startIndex; i < str.Length; i++)
            {
                if (str[i] < 48 || str[i] > 57)
                {
                    break;
                }

                result = result * 10 + (str[i] - 48);

                if (result > Int32.MaxValue && mask == 1)
                {
                    return Int32.MaxValue;
                }

                if (result > maxMinusInt && mask == -1)
                {
                    return Int32.MinValue;
                }
            }

            result = result * mask;

            return System.Convert.ToInt32(result);
        }


        public static int CountSteps(int stepsN, int maxStepSize)
        {
            int[] stepsCache = new int[stepsN + 1];
            stepsCache[1] = 1;
            stepsCache[2] = 2;
            stepsCache[3] = 4;
            return CountOptions(stepsN, stepsCache);
        }

        public int ClimbStairs(int n)
        {
            int[] countSteps = new int[n + 1];
            countSteps[1] = 1;
            countSteps[2] = 2;
            countSteps[3] = 4;

            return CountSteps(n, countSteps);
        }

        private int CountSteps(int stepN, int[] stepsMem)
        {
            if (stepN <= 0)
            {
                return 0;
            }

            if (stepsMem[stepN] != 0)
            {
                return stepsMem[stepN];
            }


            int countN = CountSteps(stepN - 2, stepsMem)
                + CountSteps(stepN - 1, stepsMem);

            stepsMem[stepN] = countN;


            return countN;
        }

        private static int CountOptions(int stepsToMake, int[] stepsCache)
        {
            if (stepsToMake < 1)
            {
                return 0;

            }

            if (stepsCache[stepsToMake] != 0)
            {
                return stepsCache[stepsToMake];
            }


            var result = CountOptions(stepsToMake - 3, stepsCache)
            + CountOptions(stepsToMake - 2, stepsCache)
            + CountOptions(stepsToMake - 1, stepsCache);

            stepsCache[stepsToMake] = result;

            return result;
        }

        public static List<Point> RoboPath(int rows, int cells, int[][] map)
        {
            List<Point> path = new List<Point>();
            List<Point> failed = new List<Point>();
            if (GetPath(rows, cells, path, failed, map))
            {
                return path;
            }

            return null;

        }

        public class Point
        {
            public Point(int row, int cell)
            {
                Row = row;
                Cell = cell;
            }
            public int Row { get; set; }

            public int Cell { get; set; }
        }

        public static List<List<string>> PowerSet(List<string> set)
        {
            List<List<string>> result = new List<List<string>>();

            ComposePowerSet(set, result);

            return result;
        }

        public static string PrintParens(int count)
        {
            string result = null;


            //foreach (var res in GenerateParens(count))
            List<string> r = new List<string>();
            char[] cur = new char[count * 2];
            GenerateP(count, count, r, cur, 0);

            foreach (var res in r)
            {
                result = result + res + Environment.NewLine;
            }



            return result;
        }

        public static string GeneratePermsWithoutDups(string input)
        {
            if (input == null || input.Length <= 1)
            {
                return input;
            }

            List<string> results = GeneratePermWithoutDups(input);


            string result = null;
            foreach (var res in results)
            {
                result = result + res + Environment.NewLine;
            }

            return result;
        }

        private static List<string> GeneratePermWithoutDups(string input)
        {
            if (input.Length == 1)
            {
                return new List<string> { input };
            }

            var cur = input.Substring(input.Length - 1, 1);
            var prevComb = GeneratePermWithoutDups(input.Substring(0, input.Length - 1));
            var perms = new List<string>();

            for (int i = 0; i < prevComb.Count; i++)
            {
                // mid
                for (int j = 0; j <= prevComb[i].Length; j++)
                {
                    var newComb = prevComb[i].Insert(j, cur);
                    perms.Add(newComb);
                }
            }

            return perms;
        }

        private static void GenerateP(int openCount, int closeCount, List<string> results, char[] cur, int index)
        {
            if (openCount < 0 || closeCount < openCount)
            {
                return;
            }

            if (openCount == 0 && closeCount == 0)
            {
                string res = null;

                foreach (var a in cur)
                {
                    res += a;
                }

                results.Add(res);

                return;
            }

            cur[index] = '(';
            GenerateP(openCount - 1, closeCount, results, cur, index + 1);

            cur[index] = ')';
            GenerateP(openCount, closeCount - 1, results, cur, index + 1);

        }

        private static List<string> GenerateParens(int count)
        {
            if (count == 0)
            {
                return new List<string>();
            }

            if (count == 1)
            {
                var p1 = "()";

                return new List<string>() { p1 };
            }

            if (count == 2)
            {
                var p1 = "()()";
                var p2 = "(())";

                return new List<string>() { p1, p2 };
            }


            var prevComb = GenerateParens(count - 1);

            List<string> newParens = new List<string>();

            for (int i = 0; i < prevComb.Count; i++)
            {
                var existing = prevComb[i];
                var append = existing + "()";
                var prepend = "()" + existing;

                if (!newParens.Contains(append))
                {
                    newParens.Add(append);
                }
                if (!newParens.Contains(prepend))
                {
                    newParens.Add(prepend);
                }

                for (int j = 1; j < existing.Length - 1; j++)
                {
                    var mix = existing.Insert(j, "()");

                    if (!newParens.Contains(mix))
                    {
                        newParens.Add(mix);
                    }
                }
            }

            return newParens;
        }

        private static void ComposePowerSet(List<string> baseSet, List<List<string>> result)
        {
            if (baseSet.Count == 0)
            {
                return;
            }

            if (baseSet.Count == 1)
            {
                result.Add(new List<string>() { baseSet[0] });

                return;
            }

            var first = baseSet.First();
            baseSet.RemoveAt(0);

            ComposePowerSet(baseSet, result);

            var count = result.Count;
            for (int i = 0; i < count; i++)
            {
                var newSet = new List<string>(result[i]);
                newSet.Add(first);
                result.Add(newSet);
            }

            result.Add(new List<string>() { first });
        }

        public static void PaintFill(int[][] map, int rowToFill, int colToFill, int targetCol)
        {
            var curColor = map[rowToFill][colToFill];

            FillSpace(map, rowToFill, colToFill, targetCol, curColor);
        }

        private static void FillSpace(int[][] map, int row, int col, int targColor, int filledColor)
        {
            if (row < 0 || row >= map.Length
                || col < 0 || col >= map.Length)
            {
                return; // out of map
            }

            if (map[row][col] == targColor || map[row][col] != filledColor)
            {
                return; // already filled
            }


            map[row][col] = targColor;

            FillSpace(map, row - 1, col, targColor, filledColor);
            FillSpace(map, row + 1, col, targColor, filledColor);
            FillSpace(map, row, col - 1, targColor, filledColor);
            FillSpace(map, row, col + 1, targColor, filledColor);
        }

        public static int FindMagicIndex(int[] input)
        {
            if (input == null || input.Length == 0)
            {
                return 0;
            }

            return FindMagicIndex(input, 0, input.Length);

        }

        private static int FindMagicIndex(int[] input, int startIndex, int endIndex)
        {
            if (startIndex > endIndex)
            {
                return -1;
            }
            int midIndex = startIndex + (endIndex - startIndex) / 2;
            int midValue = input[midIndex];


            if (midIndex == midValue)
            {
                return midIndex;
            }

            if (midValue < midIndex)
            {
                int newEnd = Math.Min(midValue, midIndex - 1);
                int left = FindMagicIndex(input, startIndex, endIndex);

                if (left >= 0)
                {
                    return left;
                }
            }
            if (midValue > midIndex)
            {
                int newStart = Math.Max(midValue, midIndex + 1);

                int right = FindMagicIndex(input, newStart, endIndex);

                if (right >= 0)
                {
                    return right;
                }
            }

            return -1;
        }

        private static bool GetPath(int row, int cell, List<Point> path
            , List<Point> failedPoints
            , int[][] map)
        {
            if (row < 0 || cell < 0)
            {
                return false;
            }

            if (map[row][cell] == 1)
            {
                return false;
            }

            bool atHome = row == 0 && cell == 0;

            if (failedPoints.Any(p => p.Row == row && p.Cell == cell))
            {
                return false;
            }


            if (GetPath(row - 1, cell, path, failedPoints, map)
                || GetPath(row, cell - 1, path, failedPoints, map)
                || atHome)
            {
                path.Add(new Point(row, cell));
                return true;
            }
            else
            {
                failedPoints.Add(new Point(row, cell));

                return false;
            }

        }

        public static void FindCoins(int sum)
        {
            //CalcSum(sum, 0, 0, 0, 0);
        }

        private static void CalcChange(int sum)
        {
            if (sum > 25)
            {
                int quaters = sum / 25;
            }
        }

        private static bool CalcSum(int targetSum, int quaters
            , int dimes, int nickles, int penies)
        {
            int curSum = quaters * 25 + dimes * 10 + nickles * 5 + penies;

            if (curSum > targetSum)
            {
                return false;
            }

            if (curSum == targetSum)
            {
                Console.WriteLine($"Target sum reached: {quaters} quaters, {dimes} dimes, {nickles} nickles, {penies} penies");
                return true;
            }

            // todo produce duplicates
            CalcSum(targetSum, quaters + 1, dimes, nickles, penies);
            CalcSum(targetSum, quaters, dimes + 1, nickles, penies);
            CalcSum(targetSum, quaters, dimes, nickles + 1, penies);
            CalcSum(targetSum, quaters, dimes, nickles, penies + 1);

            return true;
        }

        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();

            HashSet<int> hash = new HashSet<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (!hash.Contains(nums[i]))
                {
                    hash.Add(nums[i]);
                }
            }


            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    var a = nums[i];
                    var b = nums[j];
                    var abSum = nums[i] + nums[j];
                    var c = -1 * abSum;

                    if (hash.Contains(c))
                    {
                        var item = new List<int> { a, b, c }.OrderBy(v => v).ToList();

                        if (!result.Any(li => li[0] == item[0] && li[1] == item[1] && li[2] == item[2]))
                        {
                            result.Add(item);
                        }
                    }
                }
            }

            return result;
        }

        public static string LongestCommonPrefix(string[] strs)
        {
            if (strs == null || strs.Length == 0)
            {
                return "";
            }

            int cnt = 0;

            while (true)
            {
                char c = default(char);
                char prevC = default(char);
                for (int i = 0; i < strs.Length; i++)
                {
                    if (strs[i].Length > cnt)
                    {
                        c = strs[i][cnt];

                        if (i != 0 && c != prevC)
                        {
                            return strs[0].Substring(0, cnt);
                        }
                        else
                        {
                            prevC = c;
                        }
                    }
                    else
                    {
                        return strs[0].Substring(0, cnt);
                    }
                }

                cnt++;
            }
        }
        public static int RomanToInt(string s)
        {
            int first = 0;
            int result = 0;
            Dictionary<string, int> translates = new Dictionary<string, int>();
            translates.Add("I",1);
            translates.Add("IV",4); // 2
            translates.Add("V",5);
            translates.Add("IX",9); // 2
            translates.Add("X", 10);
            translates.Add("XL", 40); // 2
            translates.Add("L", 50);
            translates.Add("XC", 90); // 2
            translates.Add("C", 100);
            translates.Add("CD", 400); // 2
            translates.Add("D", 500);
            translates.Add("CM", 900); // 2
            translates.Add("M", 1000);


            //for (int i = 0; i < s.Length - 1; i++)
            while (first < s.Length)
            {
                char tmp = s[first];

                if (first < s.Length -1 && translates.ContainsKey(s.Substring(first, 2)))
                {
                    result += translates[s.Substring(first, 2)];
                    first += 2; 
                }
                else
                {
                    result += translates[s[first].ToString()];
                    first++;
                }
            }

            return result;
        }

        //if (tmp == 'I')
        //{
        //    add = s[first + 1];
        //    if (add == 'V')
        //    {
        //        first++;
        //        result += 4;
        //    }
        //    if (add == 'X')
        //    {
        //        first++;
        //        result += 9;
        //    }
        //}

        //if (tmp == 'X')
        //{
        //    add = s[first + 1];
        //    if (add == 'L')
        //    {
        //        first++;
        //        result += 40;
        //    }
        //    if (add == 'C')
        //    {
        //        first++;
        //        result += 90;
        //    }
        //}

        //if (tmp == 'C')
        //{
        //    add = s[first + 1];
        //    if (add == 'D')
        //    {
        //        result += 400;
        //        first++;
        //    }
        //    if (add == 'M')
        //    {
        //        first++;
        //        result += 900;
        //    }
        //}

        public static string IntToRoman(int num)
        {
            Dictionary<int, string> translates = new Dictionary<int, string>();
            translates.Add(1, "I");
            translates.Add(4, "IV"); // 2
            translates.Add(5, "V");
            translates.Add(9, "IX"); // 2
            translates.Add(10, "X");
            translates.Add(40, "XL"); // 2
            translates.Add(50, "L");
            translates.Add(90, "XC"); // 2
            translates.Add(100, "C");
            translates.Add(400, "CD"); // 2
            translates.Add(500, "D");
            translates.Add(900, "CM"); // 2
            translates.Add(1000, "M");
            if (num < 1 || num > 3999)
            {
                return null;
            }

            int tmp = num;
            string buf = null;
            while (tmp != 0)
            {
                int smaller = 0;
                int bigger = 0;

                foreach (var item in translates)
                {
                    if (tmp >= item.Key)
                    {
                        smaller = item.Key;
                    }

                    if (tmp < item.Key)
                    {
                        bigger = item.Key;
                        break;
                    }
                }
                int foundIndex = 0;
                if (smaller != 0)
                {
                    foundIndex = smaller;
                }
                else
                {
                    foundIndex = bigger;    
                }

                buf += translates[foundIndex];

                tmp -= foundIndex;

            }

            return buf;
        }

        private bool PlaceQueens(int curQueen, int maxQueens, List<List<string>> solutions, int[,] board)
        {
            if (curQueen == maxQueens)
            {

                List<string> comb = new List<string>();
                for (int i = 0; i < maxQueens; i++)
                {
                    string curRow = "";
                    for (int j = 0; j < maxQueens; j++)
                    {
                        curRow += board[i, j] == 1 ? "Q" : ".";
                    }

                    comb.Add(curRow);
                }
                // convert curboard to solution
                return true;
            }


            for (int i = curQueen; i < maxQueens; i++)
            {
                for (int j = 0; j < maxQueens; j++)
                {
                    int curM = i;
                    int curN = j;
                    if (CanPut(board, maxQueens, i, j))
                    {
                        board[curM, curN] = 1;
                        if (!PlaceQueens(curQueen + 1, maxQueens, solutions, board))
                        {
                            // backtrack;
                            board[curM, curN] = 0;
                        }
                    }

                }
            }

            return false;
        }

        private bool CanPut(int[,] board, int size, int m, int n)
        {
            for (int i = 0; i < size; i++)
            {
                if (board[m, i] == 1 || board[i, n] == 1)
                {
                    return false;
                }
            }

            return true;
        }
    }
}

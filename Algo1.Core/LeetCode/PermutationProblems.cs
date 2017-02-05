using System.Collections.Generic;


namespace Algo1.Core.LeetCode
{
    public class PermutationProblems
    {
        // LeetCode 60
        public string GetPermutation(int n, int k)
        {
            List<int> numbers = new List<int>();
            List<int> factorials = new List<int>() { 1 };
            string result = "";

            for (int i = 1; i <= n; i++)
            {
                factorials.Add(factorials[i - 1] * i);
                numbers.Add(i);
            }

            if (factorials[n] < k)
            {
                return null;
            }

            k--;

            for (int i = n; i >= 1; i--)
            {
                int cur = k / factorials[i - 1];
                k = k % factorials[i - 1];

                result += numbers[cur].ToString();
                numbers.RemoveAt(cur);
            }

            return result;
        }
    }
}

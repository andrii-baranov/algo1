using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo1.Core.LeetCode
{
    public class ExpressionTreeProblems
    {
        //LeetCode 150. Evaluate Reverse Polish Notation
        public int EvalRPN(string[] tokens)
        {
            if (tokens == null || tokens.Length == 0)
            {
                return 0;
            }

            Stack<int> operands = new Stack<int>();

            for (int i = 0; i < tokens.Length; i++)
            {
                var current = tokens[i];

                int parsed = 0;

                if (Int32.TryParse(current, out parsed))
                {
                    parsed = Int32.Parse(current);

                    operands.Push(parsed);
                }
                else
                {
                    var right = operands.Pop();
                    var left = operands.Pop();

                    int curRes = 0;

                    switch (current)
                    {
                        case "+":
                            curRes = left + right;
                            break;
                        case "-":
                            curRes = left - right;
                            break;
                        case "*":
                            curRes = left*right;
                            break;
                        case "/":
                            curRes = left/right;
                            break;
                    }

                    operands.Push(curRes);
                }
              
            }

            return operands.Pop();
        }


        public int Calculate(string s)
        {
            var tokens = PopulateRPN(s);

            return EvalRPN(tokens.ToArray());
        }

        public List<string> PopulateRPN(string s)
        {
            List<string> tokens = new List<string>();
            Stack<string> operators = new Stack<string>();

            if (string.IsNullOrWhiteSpace(s))
            {
                return tokens;
            }


            int i = 0;

            while (i < s.Length)
            {
                if (s[i] == ' ')
                {
                    i++;
                    continue;
                }
                if (s[i] == '(')
                {
                    operators.Push("(");
                }
                else if (s[i] == ')')
                {
                    while (operators.Peek() != "(")
                    {
                        tokens.Add(operators.Pop());
                    }
                    operators.Pop(); // drop (
                }
                else if (s[i] == '+' || s[i] == '-')
                {
                    while (operators.Any() && operators.Peek() != "(")
                    {
                        tokens.Add(operators.Pop());
                    }

                    operators.Push(s[i].ToString());

                }
                else
                {
                    int j = i;
                    // read number till end
                    while (j < s.Length - 1 && s[j + 1] >= 48 && s[j + 1] <= 57)
                    {
                        j++;
                    }

                    string num = s.Substring(i, j - i + 1);
                    tokens.Add(num);
                    i = j;
                }

                i++;
            }

            while (operators.Any())
            {
                tokens.Add(operators.Pop());
            }


            return tokens;
        }
    }
}

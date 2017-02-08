using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algo1.Core.LeetCode;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algo1.UnitTests
{
    [TestClass]
    public class ExpressionTreeProblemsTests
    {
        [TestMethod]
        public void EvalRPNTest()
        {
            string[] tokens = new string[] {"2", "1", "+", "3", "*"};

            ExpressionTreeProblems solver = new ExpressionTreeProblems();

            var actualResult = solver.EvalRPN(tokens);


            Assert.AreEqual(actualResult, 9);
        }

        [TestMethod]
        public void EvalRPNTestSimple()
        {
            string[] tokens = new string[] { "2"};

            ExpressionTreeProblems solver = new ExpressionTreeProblems();

            var actualResult = solver.EvalRPN(tokens);


            Assert.AreEqual(actualResult, 2);
        }

        [TestMethod]
        public void EvalRPNTestDivisonMinus()
        {
            string[] tokens = new string[] { "4", "13", "5", "/", "-" };

            ExpressionTreeProblems solver = new ExpressionTreeProblems();

            var actualResult = solver.EvalRPN(tokens);


            Assert.AreEqual(actualResult, 2);
        }

        [TestMethod]
        public void EvalRPNTestDivisionRoundDown()
        {
            string[] tokens = new string[] { "4" , "5", "/" };

            ExpressionTreeProblems solver = new ExpressionTreeProblems();

            var actualResult = solver.EvalRPN(tokens);


            Assert.AreEqual(actualResult, 0);
        }


        [TestMethod]
        public void EvalRPNTestNegativeNumber()
        {
            string[] tokens = new string[] { "4", "-1", "+" };

            ExpressionTreeProblems solver = new ExpressionTreeProblems();

            var actualResult = solver.EvalRPN(tokens);


            Assert.AreEqual(actualResult, 3);
        }

        [TestMethod]
        public void CalculateAddTest()
        {
            string expression = "1+2+3";

            ExpressionTreeProblems solver = new ExpressionTreeProblems();

            int result = solver.Calculate(expression);

            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void CalculateMinusWithSpacesTest()
        {
            string expression = "1 - 2 - 3";

            ExpressionTreeProblems solver = new ExpressionTreeProblems();

            int result = solver.Calculate(expression);

            Assert.AreEqual(-4, result);
        }

        [TestMethod]
        public void CalculateMinusWithBracketsTest()
        {
            string expression = "(1 + 2) - 3";

            ExpressionTreeProblems solver = new ExpressionTreeProblems();

            int result = solver.Calculate(expression);

            Assert.AreEqual(0, result);
        }


        [TestMethod]
        public void CalculateMinusWithBracketsComplexTest()
        {
            string expression = "((1 + 2) + (1+1))";

            ExpressionTreeProblems solver = new ExpressionTreeProblems();

            int result = solver.Calculate(expression);

            Assert.AreEqual(5, result);
        }
    }
}

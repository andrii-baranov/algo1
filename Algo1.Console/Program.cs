using Algo1.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo1.Console
{
    class Program
    {
        static void Main(string[] args)
        {

            var inputLines = File.ReadAllLines(@"C:\temp\_32387ba40b36359a38625cbb397eee65_QuickSort.txt");

            int[] input = new int[inputLines.Length];

            for (int i = 0; i < inputLines.Length; i++)
            {
                input[i] = int.Parse(inputLines[i]);
            }

            var quickSort = new QuickSort(PivotSelectionType.Median);

            var result = quickSort.Sort(input);

            var compCount = quickSort.ComparisonsCount;
            for (int i =0; i < result.Length; i++)
            {
                if (result[i] != i + 1)
                {
                    System.Console.WriteLine("not match");
                }
            }

            System.Console.ReadKey();
        }
    }
}

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

            var inputLines = File.ReadAllLines(@"C:\temp\_410e934e6553ac56409b2cb7096a44aa_SCC.txt");

            Dictionary<int,List<int>> input = new Dictionary<int,List<int>>();

            for (int i = 0; i < inputLines.Length; i++)
            {
                var items = inputLines[i].Trim().Split(' ');

                var startVerticle = int.Parse(items[0]);
                var endVerticle = int.Parse(items[1]);


                if (!input.ContainsKey(startVerticle))
                {
                    input[startVerticle] = new List<int>();
                }

                input[startVerticle].Add(endVerticle);
            }

            KosurajuSCC scc = new KosurajuSCC();
            var result  = scc.CalucalateSCC(input);

            var oderedSccs = result.OrderByDescending(i => i.Count);

            System.Console.ReadKey();
        }
    }
}

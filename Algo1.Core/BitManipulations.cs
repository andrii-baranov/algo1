using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo1.Core
{
    public class BitManipulations
    {
        public static int CheckBitConversion(int a, int b)
        {
            int n = 0;

            while (a != b)
            {
                if ((a & 1) != (b & 1))
                {
                    n++;
                }

                a >>= 1;
                b >>= 1;
            }

            return n;
        }

        public static int SwapOddAndEvenBits(int a)
        {
            uint aA = (uint)a;
            uint maskOdd = 0x55555555 ;
            uint maskEven = 0xAAAAAAA;

            uint even_bits = (aA & maskEven) >> 1;
            uint odd_bits = (aA & maskOdd) << 1;

            return (int)(even_bits | odd_bits);
        }

        public static void Drawline(byte[] screen, int width, int x1, int x2, int y)
        {
            int height = screen.Length / width;

            int startPos = y * width + x1;
            int endPos = y * width + x1 + x2;

            for (int i = startPos; i<endPos; i++)
            {
                screen[i] = Byte.MaxValue;
            }
        }

        public bool IsPrimeNumber(int n)
        {
            if (n < 2)
            {
                return false;
            }


            for (int i = 2; i < Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public bool[] CalculatePrimes(int max)
        {
            bool[] primeMatrix = new bool[max +1];

            int count = 0;

            int prime = 2;

            while (prime <= max)
            {
                CrossNonPrimes(primeMatrix, prime);

                prime = GetNextPrime(primeMatrix, prime);
            }

            return primeMatrix;
        }

        private static void CrossNonPrimes(bool[] primeM, int prime)
        {
            for (int i = prime * prime; i < primeM.Length; i = i + prime)
            {
                primeM[i] = true;
            }
        }

        private static int GetNextPrime(bool[] primes,int currentPrime)
        {
            int next = currentPrime + 1;

            while (next < primes.Length && primes[next] == false)
            {
                next++;
            }

            return next;
        }
    }
}

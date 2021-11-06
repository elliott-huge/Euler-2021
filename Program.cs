using System;
using System.Collections.Generic;

namespace CSharpEuler
{
    class Program
    {
        static void Main(string[] args)
        {

            //System.Console.WriteLine(ThreeFive());
            //System.Console.WriteLine(Fibonacci());
            //System.Console.WriteLine(LargestPrimeFactor(600851475143));
            //System.Console.WriteLine(BiggestPalindrome(1000));
            //System.Console.WriteLine(SmallestMultiple());
            //System.Console.WriteLine(SumSquareDiff(100));
            //System.Console.WriteLine(PrimeFinder(10001));

            string seriesEightS = "73167176531330624919225119674426574742355349194934" +
            "96983520312774506326239578318016984801869478851843" +
            "85861560789112949495459501737958331952853208805511" +
            "12540698747158523863050715693290963295227443043557" +
            "66896648950445244523161731856403098711121722383113" +
            "62229893423380308135336276614282806444486645238749" +
            "30358907296290491560440772390713810515859307960866" +
            "70172427121883998797908792274921901699720888093776" +
            "65727333001053367881220235421809751254540594752243" +
            "52584907711670556013604839586446706324415722155397" +
            "53697817977846174064955149290862569321978468622482" +
            "83972241375657056057490261407972968652414535100474" +
            "82166370484403199890008895243450658541227588666881" +
            "16427171479924442928230863465674813919123162824586" +
            "17866458359124566529476545682848912883142607690042" +
            "24219022671055626321111109370544217506941658960408" +
            "07198403850962455444362981230987879927244284909188" +
            "84580156166097919133875499200524063689912560717606" +
            "05886116467109405077541002256983155200055935729725" +
            "71636269561882670428252483600823257530420752963450";

            //System.Console.WriteLine(GreatestProduct(seriesEightS, 13));
        }

        static int ThreeFive()
        {
            // Euler 1: 3 or 5
            int sumThreeFive = 0;

            for (int i = 5; i < 1000; i+=5)
            {
                if (i % 3 == 0)
                    continue;
                sumThreeFive += i;
            }

            for (int i = 3; i < 1000; i+=3)
            {
                sumThreeFive += i;
            }
            return sumThreeFive;
        }

        static int Fibonacci()
        {
            int fibFirst = 1;
            int fibSecond = 2;
            int fibTemp = 0;

            int fibEven = 0;

            while (fibSecond < 4000000)
            {
                if (fibSecond % 2 == 0)
                    fibEven += fibSecond;
                
                fibTemp = fibSecond;
                fibSecond += fibFirst;
                fibFirst = fibTemp;
                System.Console.WriteLine(fibSecond);
            }
            return fibEven;
        }

        static bool CheckIsPrime(long value)
        {
            if (value <= 1)
                return false;
            if (value == 2)
                return true;

            for (long i = 2; i <= value/2; i++)
            {
                if (value % i == 0 & i != value)
                    return false;
            }
            return true;
        }

        static long LargestPrimeFactor(long target)
        {
            long result = 0;
            for (long i = 2; i < target / 2; i++)
            {
                if (target % i != 0)
                    continue;
                
                if (CheckIsPrime(target / i))
                {
                    result = target / i;
                    break;
                }
            }
            return result;
        }

        static List<int> IntToList(int value)
        {
            List<int> values = new List<int>();
            int valLength = value.ToString().Length;
            for(int i = 0; i < valLength; i++)
            {
                int column = value % 10;
                value -= column;
                value /= 10;
                values.Insert(0, column);
            }

            return values;
        }

        static bool CheckIsPalindrome(int value)
        {
            List<int> pal = IntToList(value);

            int length = pal.Count;
            for (int i = 0; i <= length / 2; i++)
            {
                if (pal[i] != pal[length - i - 1])
                    return false;
            }
            return true;
        }

        static int BiggestPalindrome(int multiSize)
        {
            int biggest = 0;
            int startVals = multiSize - 1;
            for (int i = startVals; i > 0; i--)
                for (int j = startVals; j > 0; j--)
                {
                    int value = i * j;
                    if (CheckIsPalindrome(value) & value > biggest)
                        biggest = value;
                }
            return biggest;
        }

        static int SmallestMultiple()
        {
            int smallest = 0;
            for (int i = 20;; i += 20)
            {
                bool isMultiple = true;
                for (int j = 19; j >= 11; j--)
                {
                    if (i % j != 0)
                    {
                        isMultiple = false;
                    }
                }

                if (isMultiple)
                {
                    smallest = i;
                    break;
                }
            }
            return smallest;
        }

        static long SumSquareDiff(long largest)
        {
            long sumSquare = 0;
            long sum = 0;
            for (long i = 1; i <= largest; i++)
            {
                sumSquare += i*i;
                sum += i;
            }
            return (sum*sum) - sumSquare;
        }

        static long PrimeFinder(long nthPrime)
        {
            if (nthPrime == 1)
                return 2;
            
            long currPrime = 1;
            for (long i = 1; i < nthPrime; i++)
            {
                for (long j = currPrime + 2;; j+=2)
                {
                    if (CheckIsPrime(j))
                    {
                        currPrime = j;
                        break;
                    }
                }
            }
            return currPrime;
        }

        
        static long GreatestProduct(string series, int span = 13)
        {
            char[] cSeries = series.ToCharArray();
            long[] intSeries = Array.ConvertAll(cSeries, c => (long)char.GetNumericValue(c));

            int length = intSeries.Length;

            long biggest = 1;
            for (int i = 0; i < length - span; i++)
            {
                long currSize = 1;
                for (int j = 0; j < span; j++)
                {
                    if (intSeries[j + i] == 0)
                    {
                        currSize = 0;
                        break;
                    }
                    currSize *= intSeries[j + i];
                }
                if (currSize > biggest)
                    biggest = currSize;
            }
            return biggest;
        }

        
    }
}

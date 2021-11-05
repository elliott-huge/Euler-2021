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
            System.Console.WriteLine(SmallestMultiple());
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

            for (long i = 2; i <= value/2; i++)
            {
                if (value % i == 0)
                {
                    return false;
                }
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

    }
}

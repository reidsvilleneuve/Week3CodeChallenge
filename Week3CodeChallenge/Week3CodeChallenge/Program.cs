using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Week3CodeChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            //FindNPrimes(10001).
            Stopwatch timeTester = Stopwatch.StartNew();
            Console.WriteLine("FindNPrimes(10001): {0} (Calculated in {1} ms.)\n", 
                FindNPrimes(10001), timeTester.ElapsedMilliseconds);

            //EvenFibonacciSequencer(1000000). Project specifies that the function writes to the console.
            Console.Write("EvenFibonacciSequencer(1000000): ");
            timeTester = Stopwatch.StartNew();
            EvenFibonacciSequencer(1000000);
            Console.WriteLine(" (Calculated in {0} ms.)\n", timeTester.ElapsedMilliseconds);

            //LongestCollatzSequence(Longest Chain).
            timeTester = Stopwatch.StartNew();
            Console.WriteLine("LongestCollatzSequence: {0} (Calculated in {1} ms.)\n",
                LongestCollatzSequence(), timeTester.ElapsedMilliseconds);

            Console.Write("Press any key to end. ");
            Console.ReadKey();
        }

        static int FindNPrimes(int maxPrime)
        {
            if (maxPrime == 1) return 2; // The only even prime number

            //These account for the above return.
            int primeCount = 1; //Keeps track of how many primes we have found 
            int numToTest = 3; //Number to test against. A counter.
            int lastPrime = 2; //Will be returned when the correct number of primes have been found.

            bool isPrime = true; //Will be set to false if a divisible number is found.

            while (primeCount < maxPrime)
            {
                double testTo = Math.Ceiling(Math.Sqrt(numToTest)); // Mathmatically, this is as far as we need to test.

                for (int i = 3; i <= testTo; i++)
                {
                    if (numToTest % i == 0)
                    {
                        isPrime = false; //Non-prime deteted. No need to test any further numbers.
                        break;
                    }
                }

                if (isPrime) // This made it though the above loop with isPrime still true. It's a prime.
                {
                    primeCount++;
                    lastPrime = numToTest; 
                }

                numToTest+=2; //Even numbers are not primes, so we iterate by 2.
                isPrime = true; //Resets isPrime in case last number was found to NOT be prime.
            }

            return lastPrime;
        }

        static void EvenFibonacciSequencer(int maxValue)
        {
            List<int> fibSequence = new List<int>() { 1, 2 }; //Start our table.
            int nextNumber = 3; //Stores the next number to be added in the sequence.

            while(nextNumber < maxValue)
            {
                fibSequence.Add(nextNumber);
                nextNumber += fibSequence[fibSequence.Count - 2]; //This will be the next one that will be added
            }                                                     //IF it's smaller than maxValue.
            

            Console.Write (fibSequence
                .Where(x => x % 2 == 0) //Only even numbers.
                .Sum(y => y));          //Total sum.
        }

        static int LongestCollatzSequence()
        {
            long calcNum = 0; // Number that will be manipulated.

            int steps = 0; // Counts the number of times that a number goes though a calculation.
            int maxSteps = 0; // Keeps track of the biggest amount of steps so far.
            int maxOccurance = 0; // Records when the biggest step occurance happened.

            for (int i = 1; i < 1000001; i++ ) //Finding biggest step count 
            {
                //Reset values
                calcNum = i;
                steps = 0;

                while (calcNum > 1)
                {
                    steps++;
                    if (calcNum % 2 == 0) calcNum = calcNum / 2;    //Number is even.
                    else calcNum = (3 * calcNum) + 1;               //Number is odd.
                }

                if (maxSteps < steps)   //This iteration took more steps than previous ones.
                {
                    maxSteps = steps;   //Record step count and occurance time.
                    maxOccurance = i;
                }
            }
            
            return maxOccurance;
        }
    }
}

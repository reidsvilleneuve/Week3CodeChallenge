using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3CodeChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(FindNPrimes(10));

            Console.ReadKey();
        }

        static int FindNPrimes(int maxPrime)
        {
            if (maxPrime == 1) return 2; // The only even prime number
            if (maxPrime == 2) return 3; // This saves us 10001 x % y calculations as we no longer have to test for 3.

            //These account for the above two returns.
            int primeCount = 2; //Keeps track of how many primes we have found 
            int numToTest = 5; //Number to test against. A counter.
            int lastPrime = 3; //Will be returned when the correct number of primes have been found.

            bool isPrime = true; //Will be set to false if a divisible number is found.

            List<int> primeTable = new List<int>() { 3 }; //Populated when prime numer is found, depeding on the
                                                             //size of maxPrime.

            while (primeCount < maxPrime)
            {
                double testTo = Math.Ceiling(Math.Sqrt(numToTest)); // Mathmatically, this is as far as we need to test.

                if (testTo > 3) // If we can use our prime table...
                {
                    foreach(int i in primeTable)
                    {
                        if(numToTest % i == 0)
                        {
                            isPrime = false;
                            break;
                        }
                    }
                }
                else // if our current numToTest is too small to use our table...
                {
                    for (int i = 3; i <= testTo; i++)
                    {
                        if (numToTest % i == 0)
                        {
                            isPrime = false;
                            break;
                        }

                    }
                }
                if (isPrime)
                {
                    primeCount++;
                    lastPrime = numToTest;

                    if (lastPrime <= Math.Ceiling(Math.Sqrt(maxPrime)))
                        primeTable.Add(lastPrime);
                }

                numToTest+=2; //Even numbers are not primes, so we iterate by 2.
                isPrime = true; //Resets isPrime in case last number was found to NOT be prime.
            }

            return lastPrime;


        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{

    class Program
    {
        public static int FibonacciSequence(int n)
        {
            /* 
              The Fibonacci sequence is a series of numbers where a number is found by 
              adding up the two numbers before it. Starting with 0 and 1, the sequence 
              goes 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, and so forth.
             */

            int a = 0;
            int b = 1;
            // In N steps compute Fibonacci sequence iteratively.
            for (int i = 0; i < n; i++)
            {
                int temp = a;
                a = b;
                b = temp + b;
            }
            return a;
        }

        static void Main(string[] args)
        {

            for (int i = 0; i < 15; i++)
            {
                Console.WriteLine(FibonacciSequence(i));
            }

            Console.WriteLine("Press Any Key To Continue");
            Console.ReadKey();
        }
    }
}

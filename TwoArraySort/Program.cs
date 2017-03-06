using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoArraySort
{
    class Program
    {
        /*
         * Bubble Sort repeatedly steps through the list to be sorted, compares each pair of adjacent items and swaps them if they are in the wrong order. 
         * The pass through the list is repeated until no swaps are needed, which indicates that the list is sorted.
         */
         
        public static void BubbleSortArray(ref int[] Array)
        {
            int Temp = 0;
            bool swapFlag;

            do
            {
                swapFlag = false;
                for (int i = 0; i < (Array.Length - 1); i++)
                {
                    if (Array[i + 1] < Array[i])
                    {
                        //Swap
                        Temp = Array[i];
                        Array[i] = Array[i + 1];
                        Array[i + 1] = Temp;

                        swapFlag = true;
                    }
                }
            }
            while (swapFlag);

        }

        static void WriteArray (int[] Array)
        {
            foreach (int item in Array)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            int[] Array1 = { 9, 8, 5, 7, 6, 5, 4, 3, 2, 1 };
            int[] Array2 = {100,1, 8, 50, 99, 8 };

            Console.WriteLine("Sort Two Arrays");

            Console.WriteLine("Unsorted Contents of 1st Array");
            WriteArray(Array1);

            Console.WriteLine("Unsorted Contents of 2nd Array");
            WriteArray(Array2);

            BubbleSortArray(ref Array1);
            BubbleSortArray(ref Array2);

            Console.WriteLine("Sort Contents of 1st Array");
            WriteArray(Array1);

            Console.WriteLine("Sort Contents of 2nd Array");
            WriteArray(Array2);

            Console.WriteLine("Press Any Key To Continue");
            Console.ReadKey();
        }
    }
}

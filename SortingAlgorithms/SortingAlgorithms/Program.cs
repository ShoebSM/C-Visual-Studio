using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SortingAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] insertionSort = new int[5] { 10, 4, 15, 29, 2 };
            //list to be sorted
            for (int i = 1; i < insertionSort.Length; i++)
            {
                /*Remember to add in a test to see what the loop reads first.
                My guess/hope is 4!*/
                int temp = insertionSort[i];
                int j;
                for (j = i - 1; j >= 0 && temp < insertionSort[j]; j--) ;
                 insertionSort[j + 1] = insertionSort[j];
                 insertionSort[j + 1] = temp;

         

            }

            Console.WriteLine("Output");
            for (int i = 0; i < insertionSort.Length; i++);
            {
                Console.WriteLine(insertionSort[i]);
            }

            Thread.Sleep(4000);


        }
    }
}

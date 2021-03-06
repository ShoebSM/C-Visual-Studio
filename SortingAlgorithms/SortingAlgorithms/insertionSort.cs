﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] insertionSort = new int[5] { 10, 4, 15, 29, 2 };
            //list to be sorted
            for (int i = 0; i< insertionSort.Length; i++)
            {
                Console.WriteLine(insertionSort[i]);
            }
            for (int i = 1; i < insertionSort.Length; i++)
            {
                Console.WriteLine(insertionSort[i - 1]);
                /*Remember to add in a test to see what the loop reads first.
                My guess/hope is 4! EDIT-Proven correct*/
                int temp = insertionSort[i];
                int j;
                j = i - 1;
                while (j >= 0 && insertionSort[j] > temp)
                {
                    insertionSort[j + 1] = insertionSort[j];
                    j--;
                }
                insertionSort[j + 1] = temp;

          }

            Console.WriteLine("Output");
            for (int j = 0; j < insertionSort.Length; j++)
            {
                Console.WriteLine(insertionSort[j]);
            }
        }
    }
}

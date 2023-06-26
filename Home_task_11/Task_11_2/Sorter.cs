using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_11_2
{
    internal class Sorter
    {
        private static string leftFilePath = "../../../task_11_2_temp_left.txt";
        //private static string rightFilePath = "../../../task_11_2_temp_right.txt";

        // Задумка:
        // - Зчитати першу половину масиву з файлу, посортувати її і записати у темп-файл
        // - Зчитати другу половину масиву з файлу, посортувати її і залишити у пам'яті
        // - По черзі брати по одному елементу з пам'яті і з темп-файлу, порівнювати і записувати
        //   менший елемент у основний файл
        public static void SortFromFile(string arrayFilePath, int length)
        {
            int[] array = new int[length / 2];

            StreamReader reader = new StreamReader(arrayFilePath);
            StreamWriter writerLeft = new StreamWriter(leftFilePath);

            for (int i = 0; i < length / 2; i++)
            {
                array[i] = Convert.ToInt32(reader.ReadLine());
            }
            MergeSort(array, 0, array.Length - 1);
            for (int i = 0; i < length / 2; i++)
            {
                writerLeft.WriteLine(array[i]);
            }

            for (int i = 0; i < length / 2; i++)
            {
                array[i] = Convert.ToInt32(reader.ReadLine());
            }
            MergeSort(array, 0, array.Length - 1);

            reader.Close();
            writerLeft.Close();

            MergeFromFiles(arrayFilePath, length / 2, array);
        }

        private static void MergeFromFiles(string mainArrayFilePath, int leftArrayLength, int[] rightArray)
        {
            StreamReader readerLeft = new StreamReader(leftFilePath);
            StreamWriter writerMain = new StreamWriter(mainArrayFilePath);

            // consider each element X[i] of array X and ignore the element
            // if it is already in correct order else swap it with next smaller
            // element which happens to be first element of Y
            for (int i = 0; i < leftArrayLength; i++)
            {
                // compare current element of X[] with first element of Y[]
                if (X[i] > rightArray[0])
                {
                    Swap(ref X[i], ref rightArray[0]);
                    int first = rightArray[0];
                    // move Y[0] to its correct position to maintain sorted
                    // order of Y[]. Note: Y[1..n-1] is already sorted
                    int k;
                    for (k = 1; k < rightArray.Length && rightArray[k] < first; k++)
                    {
                        rightArray[k - 1] = rightArray[k];
                    }
                    rightArray[k - 1] = first;
                }
            }
        }

        private static void MergeSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;
                MergeSort(array, left, middle);
                MergeSort(array, middle + 1, right);
                Merge(array, left, middle, right);
            }
        }

        private static void Merge(int[] array, int left, int middle, int right)
        {
            int leftPtr = left;
            int rightPtr = middle + 1;

            if (array[middle] <= array[rightPtr])
            {
                return;
            }

            while (leftPtr <= middle && rightPtr <= right)
            {
                if (array[leftPtr] <= array[rightPtr])
                {
                    leftPtr++;
                }
                else
                {
                    int value = array[rightPtr];
                    int index = rightPtr;
                    while (index != leftPtr)
                    {
                        array[index] = array[index - 1];
                        index--;
                    }
                    array[leftPtr] = value;

                    leftPtr++;
                    middle++;
                    rightPtr++;
                }
            }
        }

        private void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}

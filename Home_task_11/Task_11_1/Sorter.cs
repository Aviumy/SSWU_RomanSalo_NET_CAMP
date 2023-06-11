using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_11_1
{
    public enum Pivot
    {
        First,
        Random,
        MedianOf3,
    }

    internal class Sorter<T> where T: IComparable<T>
    {
        private static Random random = new Random();

        public static void QuickSort(T[] array, Pivot pivotMode = Pivot.First)
        {
            QuickSort(array, 0, array.Length - 1, pivotMode);
        }

        private static void QuickSort(T[] array, int left, int right, Pivot pivotMode)
        {
            int pivotIndex;
            if (left < right)
            {
                pivotIndex = Partition(array, left, right, pivotMode);
                QuickSort(array, left, pivotIndex - 1, pivotMode);
                QuickSort(array, pivotIndex + 1, right, pivotMode);
            }
        }

        private static int Partition(T[] array, int left, int right, Pivot pivotMode)
        {  
            if (pivotMode == Pivot.Random)
            {
                int randomIndex = random.Next(left, right + 1);
                Swap(ref array[right], ref array[randomIndex]);
            }
            else if (pivotMode == Pivot.MedianOf3)
            {
                MedianOf3(array, left, right);
            }
            T pivot = array[right];

            int j = left - 1;
            for (int i = left; i < right; i++)
            {
                if (array[i].CompareTo(pivot) <= 0)
                {
                    Swap(ref array[++j], ref array[i]);
                }
            }
            Swap(ref array[++j], ref array[right]);
            return j;
        }

        private static T MedianOf3(T[] array, int left, int right)
        {
            int center = (left + right) / 2;

            if (array[left].CompareTo(array[center]) > 0)
                Swap(ref array[left], ref array[center]);

            if (array[left].CompareTo(array[right]) > 0)
                Swap(ref array[left], ref array[right]);

            if (array[center].CompareTo(array[right]) > 0)
                Swap(ref array[center], ref array[right]);

            Swap(ref array[center], ref array[right - 1]);
            return array[right - 1];
        }

        private static void Swap(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
    }
}

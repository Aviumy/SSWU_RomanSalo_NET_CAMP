using System.Diagnostics;
using System.Reflection.PortableExecutable;

namespace Task_11_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task_11_2();
            //Task_11_2_Test();
        }

        static void Task_11_2()
        {
            Random random = new Random();
            int n = 10;
            DataFileGenerator.GenerateInts(0, 10, n, "../../../task_11_2_data.txt");
            Sorter.SortFromFile("../../../task_11_2_data.txt", n);
        }

        static void Task_11_2_Test()
        {
            Random random = new Random();
            int n = 10;
            //DataFileGenerator.GenerateInts(-10, 10, n, "../../../task_11_2_data.txt");

            var intArrays = new List<int[]>() {
                (new int[n]).Select(x => random.Next(-0, 11)).ToArray(),
            };

            for (int i = 0; i < intArrays.Count; i++)
            {
                PrintArray(intArrays[i]);
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                //Sorter.MergeSort(intArrays[i]);
                stopwatch.Stop();
                //Console.WriteLine(stopwatch.ElapsedMilliseconds);
                PrintArray(intArrays[i]);
            }
        }

        static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]} ");
            }
            Console.WriteLine();
        }
    }
}
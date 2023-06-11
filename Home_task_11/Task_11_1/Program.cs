using System.Diagnostics;

namespace Task_11_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task_11_1();
        }

        static void Task_11_1()
        {
            Random random = new Random();
            int n = 200000;

            var intArrays = new List<int[]>() {
                (new int[n]).Select(x => random.Next(-0, 11)).ToArray(),
                (new int[n]).Select(x => random.Next(-0, 11)).ToArray(),
                (new int[n]).Select(x => random.Next(-0, 11)).ToArray(),
            };

            for (int i = 0; i <= 2; i++)
            {
                //PrintArray(intArrays[i]);
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                Sorter<int>.QuickSort(intArrays[i], (Pivot)i);
                stopwatch.Stop();
                Console.WriteLine(stopwatch.ElapsedMilliseconds);
                //PrintArray(intArrays[i]);
            }
        }
    }
}
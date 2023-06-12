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
            int n = 100000;

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
                Console.WriteLine($"Pivot: {(Pivot)i}, elapsed time: {stopwatch.ElapsedMilliseconds} ms");
                //PrintArray(intArrays[i]);
            }

            Person[] people = new Person[]
            {
                new Person { Name = "Roman", Age = 21 },
                new Person { Name = "Vitaliy", Age = 18 },
                new Person { Name = "Alex", Age = 26 },
                new Person { Name = "Oleh", Age = 15 },
                new Person { Name = "Vasylyna", Age = 15 },
                new Person { Name = "Olena", Age = 22 },
            };

            PrintArray(people);
            Sorter<Person>.QuickSort(people, Pivot.MedianOf3);
            PrintArray(people);
        }

        static void PrintArray<T>(T[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]} ");
            }
            Console.WriteLine();
        }
    }
}
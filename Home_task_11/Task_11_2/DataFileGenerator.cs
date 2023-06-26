using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_11_2
{
    internal static class DataFileGenerator
    {
        private static Random random = new Random();

        public static void GenerateInts(int min, int max, int count, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                for (int i = 0; i < count; i++)
                {
                    writer.WriteLine(random.Next(min, max + 1));
                }
            }
        }
    }
}

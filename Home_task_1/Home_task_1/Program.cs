namespace Home_task_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SpiralMatrix[] matrices = new SpiralMatrix[]
            {
                new SpiralMatrix(3, 4),
                new SpiralMatrix(7, 5),
                new SpiralMatrix(2, 4),
                new SpiralMatrix(4, 2),
                new SpiralMatrix(1, 6),
                new SpiralMatrix(4, 1),
                new SpiralMatrix(1, 1),
            };

            foreach (var matrix in matrices)
            {
                matrix.Fill();
                Console.WriteLine(matrix);
                Console.WriteLine();
            }
        }
    }
}
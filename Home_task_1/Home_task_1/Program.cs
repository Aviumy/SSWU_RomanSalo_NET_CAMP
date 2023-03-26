namespace Home_task_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task_1_1();
        }

        static void Task_1_1()
        {
            /*SpiralMatrix[] matrices = new SpiralMatrix[]
            {
                new SpiralMatrix(3, 4),
                new SpiralMatrix(7, 5),
                new SpiralMatrix(2, 4),
                new SpiralMatrix(4, 2),
                new SpiralMatrix(1, 6),
                new SpiralMatrix(4, 1),
                new SpiralMatrix(1, 1),
            };

            Console.WriteLine("Counter clockwise results");
            foreach (var matrix in matrices)
            {
                matrix.Fill();
                Console.WriteLine(matrix);
            }

            Console.WriteLine("Clockwise results");
            foreach (var matrix in matrices)
            {
                matrix.Fill(SpiralMatrix.Direction.Clockwise);
                Console.WriteLine(matrix);
			}*/

            Console.WriteLine("Enter numbers of rows: ");
            int rows = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter numbers of columns: ");
            int cols = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();
            SpiralMatrix matrix = new SpiralMatrix(rows, cols);
            matrix.Fill();
            Console.WriteLine(matrix);
            matrix.Fill(SpiralMatrix.Direction.Clockwise);
            Console.WriteLine(matrix);
        }
    }
}
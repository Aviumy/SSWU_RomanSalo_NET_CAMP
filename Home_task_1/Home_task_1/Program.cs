namespace Home_task_1
{
    internal class Program
    {//Вітаю. Перше завдання по створенню репозиторію Ви виконали.
        static void Main(string[] args)
        {
            Task_1_1();
            // Task_1_2();
        }

        static void Task_1_1()
        {// треба перехоплювати можливі винятки
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
                matrix.Fill(Direction.Clockwise);
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
            matrix.Fill(Direction.Clockwise);
            Console.WriteLine(matrix);
        }

        static void Task_1_2()
        {
            List<int[,]> matrices = new List<int[,]>() {
                new int[,]
                {
                    { 5, 5, 1, 2 },
                    { 8, 8, 8, 2 },
                },
                new int[,]
                {
                    { 5, 5, 5, 2 },
                    { 8, 8, 4, 2 },
                },
                new int[,]
                {
                    { 5, 5, 1, 2 },
                    { 8, 8, 8, 2 },
                    { 0, 0, 0, 0 },
                },
                new int[,]
                {
                    { 5, 5, 5, 5 },
                    { 8, 8, 8, 2 },
                    { 0, 0, 0, 1 },
                },
                new int[,]
                {
                    { 1, 2, 3 },
                    { 8, 1, 4 },
                },

                //new int[,]
                //{
                //    { -1, 2, 3 },
                //    { 8, 1, 4 },
                //},
                //new int[,]
                //{
                //    { 100, 2, 3 },
                //    { 8, 1, 4 },
                //},
                //new int[0, 0],
            };

            var images = matrices.Select(x => new Image(x)).ToArray();

            foreach (var image in images)
            {
                Console.WriteLine(image);
                Console.WriteLine(image.FindLongestHorizontalLine());
                Console.WriteLine();
            }
        }
    }
}

namespace Home_task_1
{
    internal class Program
    {//Вітаю. Перше завдання по створенню репозиторію Ви виконали.
        static void Main(string[] args)
        {
            //Task_1_1();
            // Task_1_2();
            Task_1_4();
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

        static void Task_1_4()
        {
            Tensor[] tensors = new Tensor[]
            {
                new Tensor(1, 3),
                new Tensor(2, 3),
                new Tensor(3, 3),
                new Tensor(4, 3),
            };

            for (int i = 0; i < tensors.Length; i++)
            {
                tensors[i].FillRandom(0, 9);
            }

            Console.WriteLine("1 dimension (number)");
            Console.WriteLine(tensors[0].GetElement());
            Console.WriteLine();

            Console.WriteLine("2 dimensions (array)");
            for (int i = 0; i < tensors[1].size; i++)
            {
                Console.Write($"{tensors[1].GetElement(i)} ");
            }
            Console.WriteLine("\n");

            Console.WriteLine("3 dimensions (matrix)");
            for (int i = 0; i < tensors[2].size; i++)
            {
                for (int j = 0; j < tensors[2].size; j++)
                {
                    Console.Write($"{tensors[2].GetElement(i, j)} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.WriteLine("4 dimensions (matrix array)");
            for (int i = 0; i < tensors[3].size; i++)
            {
                for (int j = 0; j < tensors[3].size; j++)
                {
                    for (int k = 0; k < tensors[3].size; k++)
                    {
                        Console.Write($"{tensors[3].GetElement(new int[] { i, j, k })} ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            //Console.WriteLine(tensors[3].GetElement(99, tensors[3].size, -1));

            tensors[3].SetElement(value: 99, 1, 1, 1);
            Console.WriteLine("Edited 4 dimensions tensor");
            for (int i = 0; i < tensors[3].size; i++)
            {
                for (int j = 0; j < tensors[3].size; j++)
                {
                    for (int k = 0; k < tensors[3].size; k++)
                    {
                        Console.Write($"{tensors[3].GetElement(new int[] { i, j, k })} ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }
    }
}

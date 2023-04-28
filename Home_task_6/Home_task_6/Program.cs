namespace Home_task_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task6_1();
        }

        static void Task6_1()
        {
            SquareMatrix matrix1 = new SquareMatrix(4);
            matrix1.Fill();
            Console.WriteLine(matrix1);
            foreach (int item in matrix1)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\n");

            SquareMatrix matrix2 = new SquareMatrix(5);
            matrix2.Fill();
            Console.WriteLine(matrix2);
            foreach (int item in matrix2)
            {
                Console.Write(item + " ");
            }
        }
    }
}
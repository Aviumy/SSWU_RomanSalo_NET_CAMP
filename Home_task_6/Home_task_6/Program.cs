namespace Home_task_6
{
    internal class Program
    {// Не дотримуєтесь прийнятої структури папок!!!
        static void Main(string[] args)
        {
            Task6_1();
            //Task6_2();
            //Task6_3();
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

        static void Task6_2()
        {
            int[][] arrays1 = 
            {
                new int[] { 1,2,3 },
                new int[] { 9,8,7 },
                new int[] { -1,10,7,12 },
                new int[] { -2 },
            };
            int[][] arrays2 = 
            {
                new int[] { 5 },
                new int[] { 4 },
                new int[] { 2 },
                new int[] { 3 },
            };
            int[][] arrays3 = 
            {
                new int[] { 5,8,3,0,-9 },
            };
            int[][] arrays4 = 
            {
                new int[] { },
                new int[] { },
            };
// Не зрозуміли умову задачі(
            List<int[][]> testcases = new List<int[][]>
            {
                arrays1, arrays2, arrays3, arrays4
            };
            foreach (var test in testcases)
            {
                MultipleArraysProcessor arraysProc = new MultipleArraysProcessor(test);
                foreach (int item in arraysProc.MergeAndSort())
                {
                    Console.Write(item + " ");
                }
            }
        }

        static void Task6_3()
        {// Тут теж. Це всі задачі на використання yield. пройдіть цю тему повторно.
            Text[] testcases = new Text[]
            {
                new Text("one two three one four four two"),
                new Text("No repeating words"),
                new Text("a a a a a a a a"),
                new Text("a a b c d d"),
                new Text("a b c d a"),
                new Text("    Whitespaces     test  "),
                new Text("   "),
                new Text(""),
            };

            foreach (var test in testcases)
            {
                foreach (var word in test.UniqueWords())
                {
                    Console.Write(word + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

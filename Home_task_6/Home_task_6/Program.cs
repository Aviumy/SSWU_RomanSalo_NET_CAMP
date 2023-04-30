namespace Home_task_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task6_2();
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
                Console.WriteLine();
            }
        }
    }
}
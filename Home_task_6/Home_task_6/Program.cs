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
                new int[] { -1,10,7 },
            };
            MultipleArraysProcessor arraysProc1 = new MultipleArraysProcessor(arrays1);
            foreach (int item in arraysProc1.MergeAndSort())
            {
                Console.Write(item + " ");
            }
        }
    }
}
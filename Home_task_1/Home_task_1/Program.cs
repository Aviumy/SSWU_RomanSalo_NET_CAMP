namespace Home_task_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task_1_3();
        }

        static void Task_1_3()
        {
            byte[,,] pieces1 = new byte[,,]
            {
                {
                    { 1,1,0 },
                    { 1,0,1 },
                    { 1,1,1 },
                },
                {
                    { 1,1,0 },
                    { 1,0,1 },
                    { 1,1,1 },
                },
                {
                    { 1,1,0 },
                    { 1,0,1 },
                    { 1,1,1 },
                },
            };
            Cube cube1 = new Cube(pieces1);
            Console.WriteLine(cube1.FindThroughHoles());
        }
    }
}
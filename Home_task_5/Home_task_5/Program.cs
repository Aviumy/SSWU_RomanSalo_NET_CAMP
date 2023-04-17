namespace Home_task_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task_5_1();
        }

        static void Task_5_1()
        {
            List<Tree> trees1 = new List<Tree>()
            {
                new Tree(-1, 3),
                new Tree(-1.25, 2),
                new Tree(2, 1.5),
                new Tree(-3, 1),
                new Tree(-1, 1),
                new Tree(0.5,0.5),
                new Tree(-0.5,-1.5),
                new Tree(2, -2),
                new Tree(3.5, -2.5),
                new Tree(0, -4),
            };
            Garden garden1 = new Garden(trees1);
            List<Tree> trees2 = new List<Tree>()
            {
                new Tree(1.5, 3.5),
                new Tree(1.5, 3),
                new Tree(-1, 2),
                new Tree(4, 2),
                new Tree(1.5, 1.5),
                new Tree(4, 0),
                new Tree(5, -0.5),
                new Tree(1, -1),
            };
            Garden garden2 = new Garden(trees2);

            garden1.BuildFence();
            garden2.BuildFence();

            //Console.WriteLine(garden1 == garden2);
            //Console.WriteLine(garden1 > garden2);
            //Console.WriteLine(garden1 < garden2);
            //Console.WriteLine(garden1 >= garden2);
            //Console.WriteLine(garden1 <= garden2);
        }
    }
}
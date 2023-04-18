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
            // Common examples
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

            Console.WriteLine(garden1);
            Console.WriteLine(garden2);

            Console.WriteLine(garden1 == garden2);
            Console.WriteLine(garden1 > garden2);
            Console.WriteLine(garden1 < garden2);
            Console.WriteLine(garden1 >= garden2);
            Console.WriteLine(garden1 <= garden2);

            // Examples with almost equal fence length, to test overloaded operators
            List<Tree> trees3 = new List<Tree>()
            {
                new Tree(0, 0),
                new Tree(0, 1),
                new Tree(1, 1),
                new Tree(1, 0),
            };
            Garden garden3 = new Garden(trees3);
            List<Tree> trees4 = new List<Tree>()
            {
                new Tree(0, 0),
                new Tree(0, 1),
                new Tree(1.0000001, 1.0000001),
                new Tree(1, 0),
            };
            Garden garden4 = new Garden(trees4);

            garden3.BuildFence();
            garden4.BuildFence();

            Console.WriteLine(garden3);
            Console.WriteLine(garden4);

            Console.WriteLine(garden3 == garden4);
            Console.WriteLine(garden3 > garden4);
            Console.WriteLine(garden3 < garden4);
            Console.WriteLine(garden3 >= garden4);
            Console.WriteLine(garden3 <= garden4);

            // Examples with no trees or fence
            List<Tree> trees5 = new List<Tree>();
            Garden garden5 = new Garden(trees5);
            List<Tree> trees6 = new List<Tree>()
            {
                new Tree(9, 9),
            };
            Garden garden6 = new Garden(trees6);
            Console.WriteLine(garden5);
            Console.WriteLine(garden6);

            garden5.BuildFence();
            garden6.BuildFence();
            Console.WriteLine(garden5);
            Console.WriteLine(garden6);
        }
    }
}
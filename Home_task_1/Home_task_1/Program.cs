namespace Home_task_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task_1_2();
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
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
            List<byte[,,]> pieces = new List<byte[,,]>()
            {
                new byte[,,]  // No holes
                {
                    {
                        { 0,1,0 },
                        { 1,1,1 },
                        { 1,0,1 },
                    },
                    {
                        { 1,1,1 },
                        { 1,1,1 },
                        { 1,0,1 },
                    },
                    {
                        { 1,1,1 },
                        { 1,1,1 },
                        { 1,1,1 },
                    },
                },

                new byte[,,]  // Front, vertical and horizontal holes
                {
                    {
                        { 1,1,1 },
                        { 1,0,1 },
                        { 1,1,1 },
                    },
                    {
                        { 1,0,1 },
                        { 1,0,1 },
                        { 1,0,1 },
                    },
                    {
                        { 1,1,1 },
                        { 1,0,1 },
                        { 0,0,0 },
                    },
                },

                new byte[,,]  // Upper diagonal holes
                {
                    {
                        { 0,1,1 },
                        { 1,1,1 },
                        { 1,1,1 },
                    },
                    {
                        { 1,0,1 },
                        { 1,1,1 },
                        { 1,1,0 },
                    },
                    {
                        { 1,1,0 },
                        { 1,1,1 },
                        { 1,0,1 },
                    },
                },
            };
            Cube[] cubes = pieces.Select(x => new Cube(x)).ToArray();
            foreach (var cube in cubes)
            {
                Console.WriteLine($"{cube.FindThroughHoles()} holes in coordinates:");
                foreach (var hole in cube.holeCoords)
                {
                    Console.WriteLine($"{hole.Start} --- {hole.End}");
                }
                Console.WriteLine();
            }
        }
    }
}
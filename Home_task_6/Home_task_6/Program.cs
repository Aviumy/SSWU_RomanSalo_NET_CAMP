namespace Home_task_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task6_3();
        }

        static void Task6_3()
        {
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
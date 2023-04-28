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
            Text text1 = new Text("one two three one four four two");
            foreach (var word in text1.UniqueWords())
            {
                Console.Write(word + " ");
            }
            Console.WriteLine();
        }
    }
}
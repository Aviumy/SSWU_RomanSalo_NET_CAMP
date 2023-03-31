namespace Home_task_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task3_2b();
        }

        static void Task3_2b()
        {
            string[] texts =
            {
                "What a Wonderful Day for coding",
                "some word another word",
                "SOME WORD ANOTHER WORD",
                "І також Текст Кирилицею",
                "White       Spaces",
                "      ",
                "",
            };

            foreach (var text in texts)
            {
                Console.WriteLine(TextUtils.CapitalizedWordsCount(text));
            }
        }
    }
}
namespace Home_task_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task3_1b();
            //Task3_2b();
        }

        static void Task3_1b()
        {
            (string text, string substr)[] testcases =
            {
                ("one two three one two", "one"),
                ("one two three one two", "three"),
                ("one two three one 4", "4"),
                ("there's no word", "to match"),
                ("xxxxxxxxxxx", "x"),
                ("xxxxxxxxxxx", "xx"),
                ("oo", "oo"),
                ("blank substr", ""),
                ("1", ""),
                ("", "blank text"),
                ("", ""),
            };

            foreach (var test in testcases)
            {
                Console.WriteLine(TextUtils.IndexOfSecondEntry(test.text, test.substr));
            }
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
namespace Home_task_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task3_1b();
            Task3_2b();
            Task3_3b();
        }

        static void Task3_1b()
        {
            TextUtils textUtils = new TextUtils();

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
                textUtils.Text = test.text;
                Console.WriteLine(textUtils.IndexOfSecondEntry(test.substr));
            }
        }

        static void Task3_2b()
        {
            TextUtils textUtils = new TextUtils();

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
                textUtils.Text = text;
                Console.WriteLine(textUtils.CapitalizedWordsCount());
            }
        }

        static void Task3_3b()
        {
            TextUtils textUtils = new TextUtils();

            (string text, string substr)[] testcases =
            {
                ("wwords with doubllings", "sample"),
                ("Wwords with difFerent case doubLLings", "sample"),
                ("No doublings", "sample"),
                ("Two words in replacement strring", "sample text"),
                ("Multiple repeating symbols aaabc deffffff", "sample"),
                ("doublings in replacemment str", "correct"),
                ("Навмання набраний український текст", "Спеціально"),
                ("blank substrr", ""),
                ("blank substr", ""),
                ("", "blank text"),
                ("", ""),
                ("     ", "whitespace test"),
            };

            foreach (var test in testcases)
            {
                textUtils.Text = test.text;
                Console.WriteLine(textUtils.ReplaceDoublingLetterWordsWith(test.substr));
            }
        }
    }
}
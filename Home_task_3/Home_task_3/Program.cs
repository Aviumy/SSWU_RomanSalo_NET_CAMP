namespace Home_task_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task3_2a();
            Task3_2b();
            Task3_2c();
        }

        static void Task3_2a()
        {
            Text text = new Text();

            (string text, string substr)[] testcases =
            {
                ("one two three one two", "one"),
                ("one two three one two", "three"),
                ("one two three one 4", "4"),
                ("there's no word", "to match"),
                ("different REGISTER text", "t"),
                ("different REGISTER TEXT", "t"),
                ("xxxxxxxxxxx", "x"),
                ("xxxxxxxxxxx", "xx"),
                ("oo", "oo"),
                ("blank substr", ""),
                ("1", ""),
                ("", "blank text"),
                ("", ""),
            };

            foreach (var testcase in testcases)
            {
                text.RawText = testcase.text;
                Console.WriteLine(text.IndexOfSecondEntry(testcase.substr));
            }
        }

        static void Task3_2b()
        {
            Text text = new Text();

            string[] testcases =
            {
                "What a Wonderful Day for coding",
                "some word another word",
                "SOME WORD ANOTHER WORD",
                "І також Текст Кирилицею",
                "White       Spaces",
                "      ",
                "",
            };

            foreach (var testcase in testcases)
            {
                text.RawText = testcase;
                Console.WriteLine(text.CapitalizedWordsCount());
            }
        }

        static void Task3_2c()
        {
            Text text = new Text();

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

            foreach (var testcase in testcases)
            {
                text.RawText = testcase.text;
                Console.WriteLine(text.ReplaceDoublingLetterWordsWith(testcase.substr));
            }
        }
    }
}
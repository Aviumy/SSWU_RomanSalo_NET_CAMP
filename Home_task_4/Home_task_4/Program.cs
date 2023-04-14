namespace Home_task_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Task_4_1();
            Task_4_3();
        }

        static void Task_4_1()
        {
            List<string[]> texts = new List<string[]>() 
            {
                new string[]
                {
                    "Lorem ipsum dolor sit amet. Consectetur adipiscing elit,",
                    "sed do (eiusmod) tempor? incididunt ut labore et dolore. magna ",
                    "aliqua. Ut (enim ad minim veniam, quis ",
                    "nostrud exercitation ullamco laboris ",
                    "nisi) ut aliquip! ex ea commodo consequat.",
                },
                new string[]
                {
                    "Дано текст, який потрібно розмістити в колекцію стрічок. (Можна для",
                    "збереження використовувати і масив)! Текст містить речення, які не",
                    "обов’язково розташовані в одній стрічці. Речення можуть закінчуватися",
                    "крапкою, комою, знаком оклику та знаком запитання? Вважати, що цих знаків",
                    "не може бути в середині речень. У реченнях може бути текст в круглих дужках.",
                    "Потрібно знайти та видрукувати всі речення, які містять інформацію в дужках.",
                    "Вкладених круглих дужок немає.",
                    "Розв’язати задачу, не використовуючи злиття (конкатенацію) стрічок.",
                    "Продемонструвати виконання для текстів українською та англійською",
                    "мовами.",
                },
                new string[]
                {
                    "This text has no ",
                    "parenthesis in it.",
                    "This should return",
                    " empty collection.",
                },
            };

            foreach (var text in texts)
            {
                TextAnalyzer analyzer = new TextAnalyzer(text);
                var result = analyzer.SentencesWithParenthesis();
                foreach (var sentence in result)
                {
                    Console.WriteLine(sentence);
                }
            }
        }

        static void Task_4_3()
        {
            ReportCreator creator = new ReportCreator();
            creator.ReadFromTextFile(@"..\..\..\..\EnergyInfo.txt");
            //Console.WriteLine(creator.CreateReportForAllFlats());
            //Console.WriteLine(creator.CreateReportForOneFlat(2));
            Console.WriteLine("Найбільший боржник: " + creator.FindGreatestDebtor());
            //var flats = creator.FindFlatsWithNoEnergyUsed();
            //foreach (int flat in flats)
            //{
            //    Console.WriteLine(flat + " ");
            //}
        }
    }
}
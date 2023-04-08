namespace Home_task_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task_4_1();
        }

        static void Task_4_1()
        {
            string[] englishText = new string[]
            {
                "Lorem ipsum dolor sit amet. Consectetur adipiscing elit,",
                "sed do (eiusmod) tempor? incididunt ut labore et dolore. magna ",
                "aliqua. Ut (enim ad minim veniam, quis ",
                "nostrud exercitation ullamco laboris ",
                "nisi) ut aliquip! ex ea commodo consequat.",
            };

            string[] ukrainianText = new string[]
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
            };

            TextAnalyzer analyzer = new TextAnalyzer(englishText);
            string[] englishResult = analyzer.SentencesWithParenthesis();
            foreach (var sentence in englishResult)
            {
                Console.WriteLine(sentence);
            }

            analyzer = new TextAnalyzer(ukrainianText);
            string[] ukrainianResult = analyzer.SentencesWithParenthesis();
            foreach (var sentence in ukrainianResult)
            {
                Console.WriteLine(sentence);
            }
        }
    }
}
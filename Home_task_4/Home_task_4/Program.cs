namespace Home_task_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Task_4_1();
            Task_4_2();
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

        static void Task_4_2()
        {
            string text = """
Дійсні електронні адреси
simple@example.com
very.common@example.com
disposable.style.email.with+symbol@example.com
other.email-with-hyphen@example.com
fully-qualified-domain@example.com
user.name+tag+sorting@example.com
x@example.com
example-indeed@strange-example.com
admin@mailserver1
example@s.example
" "@example.org
"john..doe"@example.org
mailhost!username@example.org
user%example.com@example.org

Недійсні адреси електронної пошти
Abc.example.com
A@b@c@example.com
a"b(c)d,e:f;g<h>i[j\k]l@example.com
just"not"right@example.com
this is"not\allowed@example.com
this\ still\"not\\allowed@example.com
1234567890123456789012345678901234567890123456789012345678901234+x@example.com
i_like_underscore@but_its_not_allow_in_this_part.example.com
""";

            EmailFinder text1 = new EmailFinder(text);
            var emails = text1.FindEmails();
            Console.WriteLine("VALID EMAILS:");
            foreach (var email in emails)
            {
                Console.WriteLine(email);
            }
        }
    }
}
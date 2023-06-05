namespace Task_10_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task_10_1();
        }

        static void Task_10_1()
        {
            CardValidator cardValidator = new CardValidator();
            using (StreamReader reader = new StreamReader(@"..\..\..\card_data.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                    Console.WriteLine(cardValidator.TryValidateCard(line, out CardType? type));
                    Console.WriteLine($"Type: {(type != null ? type : "-")}");
                    Console.WriteLine();
                }
            }
        }
    }
}
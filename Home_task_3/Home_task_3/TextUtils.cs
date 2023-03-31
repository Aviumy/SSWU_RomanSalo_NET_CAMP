namespace Home_task_3
{
    public class TextUtils
    {
        public static int? IndexOfSecondEntry(string text, string substr)
        {
            if (text == "" && substr == "")
                return null;

            int firstIndex = text.IndexOf(substr);
            int secondIndex = text.IndexOf(substr, firstIndex + 1);
            return secondIndex == -1 ? null : secondIndex;
        }

        public static int CapitalizedWordsCount(string text)
        {
            var words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int count = 0;
            foreach (var word in words)
            {
                if (word[0].ToString() == word[0].ToString().ToUpperInvariant())
                {
                    count++;
                }
            }
            return count;
        }
    }
}

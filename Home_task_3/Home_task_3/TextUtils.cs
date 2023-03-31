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

        public static string ReplaceDoublingLetterWordsWith(string text, string strToReplace)
        {
            var words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < words.Length; i++)
            {
                bool hasDoubling = false;
                for (int j = 0; j < words[i].Length - 1; j++)
                {
                    if (words[i].ToLowerInvariant()[j] == words[i].ToLowerInvariant()[j + 1])
                    {
                        hasDoubling = true;
                        break;
                    }
                }

                if (hasDoubling)
                {
                    words[i] = strToReplace;
                }
            }
            return string.Join(' ', words);
        }
    }
}

namespace Home_task_3
{
    public class TextUtils
    {
        public string Text { get; set; }

        public TextUtils()
        {
            Text = string.Empty;
        }

        public TextUtils(string text)
        {
            Text = text;
        }

        public int? IndexOfSecondEntry(string substr)
        {
            if (Text == "" && substr == "")
                return null;

            int firstIndex = Text.IndexOf(substr);
            int secondIndex = Text.IndexOf(substr, firstIndex + 1);
            return secondIndex == -1 ? null : secondIndex;
        }

        public int CapitalizedWordsCount()
        {
            var words = Text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
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

        public string ReplaceDoublingLetterWordsWith(string strToReplace)
        {
            var words = Text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
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

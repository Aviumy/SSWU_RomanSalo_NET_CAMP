namespace Home_task_3
{
    public class Text
    {
        public string RawText { get; set; }

        public Text()
        {
            RawText = string.Empty;
        }

        public Text(string text)
        {
            RawText = text;
        }

        public int? IndexOfSecondEntry(string substr)
        {
            if (RawText == "" && substr == "")
                return null;

            int firstIndex = RawText.IndexOf(substr);
            // А якщо не знайдено, то лишній раз шукаємо...
            int secondIndex = RawText.IndexOf(substr, firstIndex + 1);
            return secondIndex == -1 ? null : secondIndex;
        }

        public int CapitalizedWordsCount()
        {
            var words = RawText.Split(' ', StringSplitOptions.RemoveEmptyEntries);
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
            var words = RawText.Split(' ', StringSplitOptions.RemoveEmptyEntries);
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
            //Не збережуться всі початкові пробільні символи.
            return string.Join(' ', words);
        }
    }
}

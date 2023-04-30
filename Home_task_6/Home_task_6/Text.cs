using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_6
{
    internal class Text
    {
        private string _text;

        public Text(string text)
        {
            _text = text;
        }

        // Варіант 1: якщо слово має кілька входжень - виводить лише одне із них
        //public IEnumerable<string> UniqueWords()
        //{
        //    HashSet<string> uniqueWords = new HashSet<string>();
        //    string[] words = _text.Split(new char[] { ' ', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        //    foreach (string word in words)
        //    {
        //        if (uniqueWords.Add(word))
        //        {
        //            yield return word;
        //        }
        //    }
        //}

        // Варіант 2: якщо слово має кілька входжень - не виводить його взагалі
        public IEnumerable<string> UniqueWords()
        {
            string[] words = _text.Split(new char[] { ' ', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < words.Length; i++)
            {
                if (Array.IndexOf(words, words[i], i + 1) == -1 &&
                    Array.IndexOf(words, words[i], 0, i) == -1)
                {
                    yield return words[i];
                }
            }
        }

        public override string ToString()
        {
            return _text;
        }
    }
}

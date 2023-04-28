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

        public IEnumerable<string> UniqueWords()
        {
            HashSet<string> uniqueWords = new HashSet<string>();
            string[] words = _text.Split(new char[] { ' ', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in words)
            {
                if (uniqueWords.Add(word))
                {
                    yield return word;
                }
            }
        }

        public override string ToString()
        {
            return _text;
        }
    }
}

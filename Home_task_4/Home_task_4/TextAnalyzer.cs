using System.Text;

namespace Home_task_4
{
    internal class TextAnalyzer
    {
        private static string[] _delimiters = new string[]
        {
            ".", "?", "!"
        };

        private string[] _text;

        public TextAnalyzer(string[] text)
        {
            _text = text;
        }

        public string[] SentencesWithParenthesis()
        {
            List<string> sentencesWithBrackets = new List<string>();
            StringBuilder currSentence = new StringBuilder();
            bool foundLeftBracket = false;
            bool foundRightBracket = false;

            for (int i = 0; i < _text.Length; i++)
            {
                for (int j = 0; j < _text[i].Length; j++)
                {
                    currSentence.Append(_text[i][j]);

                    if (_delimiters.Any(x => x == _text[i][j].ToString()))
                    {
                        if (foundLeftBracket && foundRightBracket)
                        {
                            sentencesWithBrackets.Add(currSentence.ToString());
                        }
                        currSentence = new StringBuilder();
                        foundLeftBracket = false;
                        foundRightBracket = false;
                    }
                    else if (_text[i][j] == '(')
                    {
                        foundLeftBracket = true;
                    }
                    else if (_text[i][j] == ')')
                    {
                        foundRightBracket = true;
                    }
                }
            }

            return sentencesWithBrackets.ToArray();
        }
    }
}

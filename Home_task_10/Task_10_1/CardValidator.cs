using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task_10_1
{
    internal class CardValidator
    {
        private static string _cardNumberPattern = "\"? *" + @"(\d+ *)+" + "\"?";

        public bool TryValidateCard(string data, out CardType? cardType)
        {
            string number = Regex.Match(data, _cardNumberPattern).ToString();
            number = number.Replace("\"", "").Replace(" ", "");

            int firstTwoDigits = Convert.ToInt32(number.Substring(0, 2));
            if ((firstTwoDigits == 34 || firstTwoDigits == 37) && number.Length == 15)
            {
                cardType = CardType.AmericanExpress;
            }
            else if ((firstTwoDigits >= 51 && firstTwoDigits <= 55) && number.Length == 16)
            {
                cardType = CardType.MasterCard;
            }
            else if (number.StartsWith("4") && (number.Length == 13 || number.Length == 16))
            {
                cardType = CardType.Visa;
            }
            else
            {
                cardType = null;
                return false;
            }

            int[] digits = number.Select(x => x - '0').ToArray();
            for (int i = number.Length - 2; i >= 0; i -= 2)
            {
                if ((digits[i] *= 2) >= 10)
                {
                    digits[i] = 1 + (digits[i] % 10);
                }
            }

            if (digits.Sum() % 10 == 0)
            {
                return true;
            }
            else
            {
                cardType = null;
                return false;
            }
        }
    }
}

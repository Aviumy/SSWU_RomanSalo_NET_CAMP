namespace Home_task_4
{
    internal class EmailFinder
    {
        private string _text;

        public EmailFinder(string text)
        {
            _text = text;
        }

        public override string ToString()
        {
            return _text;
        }

        public string[] FindEmails(out List<string> invalidEmails)
        {
            var words = _text.Split(new string[] { " ", "\t", "\r\n", "\n"}, StringSplitOptions.RemoveEmptyEntries);
            List<string> emails = new List<string>();
            invalidEmails = new List<string>();

            foreach (var word in words)
            {
                int atOccurencies = Array.FindAll(word.ToCharArray(), x => x == '@').Length;
                if (atOccurencies == 1)
                {
                    int atIndex = word.IndexOf('@');
                    string localPart = word.Substring(0, atIndex);
                    string domain = word.Substring(atIndex + 1);

                    if (IsLocalPartValid(localPart) && IsDomainValid(domain))
                    {
                        emails.Add(word);
                    }
                    else
                    {
                        invalidEmails.Add(word);
                    }
                }
                else if (atOccurencies > 1)
                {
                    invalidEmails.Add(word);
                }
            }

            return emails.ToArray();
        }

        private bool IsLocalPartValid(string localPart)
        {
            bool hasIncorrectLength =
                    localPart.Length == 0 ||
                    localPart.Length > 64;
            if (hasIncorrectLength)
            {
                return false;
            }

            bool hasIncorrectPoints =
                localPart[0] == '.' ||
                localPart.Last() == '.' ||
                localPart.IndexOf("..") != -1;
            if (hasIncorrectPoints)
            {
                return false;
            }

            for (int i = 0; i < localPart.Length; i++)
            {
                if (!IsAllowedLocalPartSymbol(localPart[i]))
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsDomainValid(string domain)
        {
            bool hasIncorrectLength =
                    domain.Length == 0 ||
                    domain.Length > 255;
            if (hasIncorrectLength)
            {
                return false;
            }

            string[] subdomains = domain.Split('.');
            string lastSubdomain = subdomains.Last();
            bool isLastSubdomainFullyNumeric = true;
            for (int i = 0; i < lastSubdomain.Length; i++)
            {
                if (!char.IsDigit(lastSubdomain[i]))
                {
                    isLastSubdomainFullyNumeric = false;
                    break;
                }
            }
            if (isLastSubdomainFullyNumeric)
            {
                return false;
            }

            foreach (var subdomain in subdomains)
            {
                bool hasSubdomainIncorrectLength = 
                    subdomain.Length == 0 ||
                    subdomain.Length > 63;
                if (hasSubdomainIncorrectLength)
                {
                    return false;
                }

                bool hasIncorrectHyphen =
                    subdomain[0] == '-' ||
                    subdomain.Last() == '-';
                if (hasIncorrectHyphen)
                {
                    return false;
                }

                for (int i = 0; i < subdomain.Length; i++)
                {
                    if (!IsAllowedSubdomainSymbol(subdomain[i]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private bool IsAllowedLocalPartSymbol(char symbol)
        {
            return char.IsLetterOrDigit(symbol) ||
                ".!#$%&'*+-/=?^_`{|}~".Contains(symbol);
        }

        private bool IsAllowedSubdomainSymbol(char symbol)
        {
            return symbol == '-' ||
                char.IsLetterOrDigit(symbol);
        }
    }
}

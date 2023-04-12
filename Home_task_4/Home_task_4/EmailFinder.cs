using System.Text.RegularExpressions;

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

        public string[] FindEmails()
        {
            var words = _text.Split(new string[] { " ", "\t", "\r\n", "\n"}, StringSplitOptions.RemoveEmptyEntries);
            List<string> emails = new List<string>();

            foreach (var word in words)
            {
                // Whether there is one '@'
                if (Array.FindAll(word.ToCharArray(), x => x == '@').Length == 1)
                {
                    int atIndex = word.IndexOf('@');
                    string localPart = word.Substring(0, atIndex);
                    string domain = word.Substring(atIndex + 1);

                    // Check local part
                    bool hasLocalPartIncorrectLength =
                        localPart.Length == 0 ||
                        localPart.Length > 64;

                    bool hasLocalPartIncorrectPoints =
                        localPart[0] == '.' ||
                        localPart.Last() == '.' ||
                        localPart.IndexOf("..") != -1;

                    bool hasLocalPartForbiddenSymbol = false;
                    for (int i = 0; i < localPart.Length; i++)
                    {
                        if (!(char.IsLetterOrDigit(localPart[i]) || IsAllowedLocalPartSymbol(localPart[i])))
                        {
                            hasLocalPartForbiddenSymbol = true;
                            break;
                        }
                    }

                    // Check domain
                    bool hasDomainIncorrectLength =
                        domain.Length == 0 ||
                        domain.Length > 255;

                    string[] subdomains = domain.Split('.');
                    bool hasSubdomainIncorrectLength = false;
                    bool hasSubdomainIncorrectHyphen = false;
                    bool hasSubdomainForbiddenSymbol = false;
                    foreach (var subdomain in subdomains)
                    {
                        if (subdomain.Length == 0 ||
                            subdomain.Length > 63)
                        {
                            hasSubdomainIncorrectLength = true;
                            break;
                        };

                        if (Array.FindAll(subdomain.ToCharArray(), x => x == '-').Length > 1 ||
                            subdomain[0] == '-' ||
                            subdomain.Last() == '-')
                        {
                            hasSubdomainIncorrectHyphen = true;
                            break;
                        }

                        for (int i = 0; i < subdomain.Length; i++)
                        {
                            if (!(char.IsLetterOrDigit(subdomain[i]) || subdomain[i] == '-'))
                            {
                                hasSubdomainForbiddenSymbol = true;
                                break;
                            }
                        }
                    }

                    bool isLastSubdomainFullyNumeric = true;
                    string lastSubdomain = subdomains.Last();
                    for (int i = 0; i < lastSubdomain.Length; i++)
                    {
                        if (!char.IsDigit(lastSubdomain[i]))
                        {
                            isLastSubdomainFullyNumeric = false;
                            break;
                        }
                    }

                    if (!(hasLocalPartIncorrectLength ||
                          hasLocalPartIncorrectPoints ||
                          hasLocalPartForbiddenSymbol ||
                          hasDomainIncorrectLength ||
                          hasSubdomainIncorrectLength ||
                          hasSubdomainIncorrectHyphen ||
                          hasSubdomainForbiddenSymbol ||
                          isLastSubdomainFullyNumeric))
                    {
                        emails.Add(word);
                    }
                }
            }

            return emails.ToArray();

            #region helperFuncs
            bool IsAllowedLocalPartSymbol(char symbol)
            {
                return ".!#$%&'*+-/=?^_`{|}~".Contains(symbol);
            }
            #endregion
        }
    }
}

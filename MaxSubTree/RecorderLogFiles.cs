using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm_Multiple
{
    class RecorderLogFiles
    {
        public static string[] ReorderLogFiles(string[] logs)
        {

            List<string> letterLogs = new List<string>();
            List<string> numberLogs = new List<string>();

            foreach (string log in logs)
            {
                int contentStart = log.IndexOf(" ") + 1;

                if (Char.IsLetter(log[contentStart]))
                    letterLogs.Add(log);
                else
                    numberLogs.Add(log);
            }

            letterLogs.Sort((log1, log2) =>
            {
                // compare logs ignoring identifier
                string log1Content = log1.Substring(log1.IndexOf(" ") + 1);
                string log2Content = log2.Substring(log2.IndexOf(" ") + 1);
                int result = log1Content.CompareTo(log2Content);

                // compare identifier when log contents are the same
                // result = 0, log1 and log2 have the same order
                // result < 0, log1 precedes log2
                // result > 0, log1 follows log2
                if (result == 0)
                {
                    string log1Identifier = log1.Substring(0, log1.IndexOf(" "));
                    string log2Identifier = log2.Substring(0, log2.IndexOf(" "));
                  
                    result = log1Identifier.CompareTo(log2Identifier);
                }

                return result;
            });

            letterLogs.AddRange(numberLogs);
            return letterLogs.ToArray();
        }
        }
}

using System;
using System.Collections.Generic;

namespace DecryptNumber
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var cryptedNumbers = new List<string>
            {
                "())(",
                "*$(#&",
                "!!!!!!!!!!",
                "$*^&@!",
                "!)(^&(#@",
                "!)(#&%(*@#%"
            };

            Console.WriteLine(DecryptNumber(cryptedNumbers));
        }

        public static List<string> DecryptNumber(List<string> cryptedNumbers)
        {
            List<string> numbersList = new();
            for (var i = 0; i < cryptedNumbers.Count; i++)
            {
                var line = string.Empty;
                foreach (var c in cryptedNumbers[i])
                {
                    var s = c.ToString();
                    switch (s)
                    {
                        case "!":
                            line += "1";
                            break;
                        case "@":
                            line += "2";
                            break;
                        case "#":
                            line += "3";
                            break;
                        case "$":
                            line += "4";
                            break;
                        case "%":
                            line += "5";
                            break;
                        case "^":
                            line += "6";
                            break;
                        case "&":
                            line += "7";
                            break;
                        case "*":
                            line += "8";
                            break;
                        case "(":
                            line += "9";
                            break;
                        case ")":
                            line += "0";
                            break;
                    }
                }

                numbersList.Add(line);
            }

            return numbersList;
        }
    }
}
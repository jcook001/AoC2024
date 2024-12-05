using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AoC2024.Days
{
    [SupportedOSPlatform("windows7.0")] //Added to stop copy to clipboard function complaining
    internal class Day05
    {
        [STAThread]
        public static void Solve()
        {
            /////////////////////////////////////////////
            /////////////////* Part 1 *//////////////////
            /////////////////////////////////////////////

            String[] input = Utils.ReadInput();
            if (input == null)
            {
                Console.WriteLine("Press any key to close");
                Console.ReadKey();
                return;
            }

            List<string> rulesRaw = new List<string>();
            List<string> pagesRaw = new List<string>();

            foreach (string s in input)
            {
                if (s.Contains('|'))
                {
                    rulesRaw.Add(s);
                }
                else if(s.Contains(','))
                {
                    pagesRaw.Add(s);
                }
            }

            int bookReadyCount = 0;

            foreach (string s in pagesRaw)
            {
                Console.WriteLine($"{s}");
                bool isBookReady = true;
                List<int> pages = new List<int>();

                String[] tempStringArray = s.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string tempString in tempStringArray)
                {
                    pages.Add(int.Parse(tempString));
                }

                //check the rules
                foreach (string rule in rulesRaw)
                {
                    String[] ruleNumbers = rule.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                    int earlyNumber = int.Parse(ruleNumbers[0]);
                    int lateNumber = int.Parse(ruleNumbers[1]);

                    if (pages.Contains(earlyNumber) && pages.Contains(lateNumber))
                    {
                        int earlyNumberIndex = pages.IndexOf(earlyNumber);
                        int lateNumberIndex = pages.IndexOf(lateNumber);

                        if(earlyNumberIndex > lateNumberIndex)
                        {
                            Console.WriteLine($"Book failed on rule {rule}");
                            isBookReady = false;
                            break;
                        }
                    }
                }

                if (isBookReady)
                {
                    double middlepage = pages.Count / 2;
                    bookReadyCount += pages[(int)Math.Ceiling(middlepage)];
                    Console.WriteLine("book is ready. Middle page is " + pages[(int)Math.Ceiling(middlepage)]);
                }

            }



            int answer = bookReadyCount;
            // Set the Foreground color to yellow - helpful for highlighting answer
            Console.ForegroundColor
                = ConsoleColor.Yellow;
            Console.WriteLine("Part 1 answer is {0}", answer);
            if (answer != 0)
            {
                Clipboard.SetText(answer.ToString());
                Console.WriteLine("Answer copied to clipboard!");
            }

            // Set the Foreground color to white - set back to white for debug text
            Console.ForegroundColor
                = ConsoleColor.White;

            /////////////////////////////////////////////
            /////////////////* Part 2 *//////////////////
            /////////////////////////////////////////////



            int answer2 = 0;

            // Set the Foreground color to yellow  - helpful for highlighting answer
            Console.ForegroundColor
                = ConsoleColor.Yellow;
            if (answer2 != 0)
            {
                Console.WriteLine("Part2 answer is = " + answer2);
                Clipboard.SetText(answer2.ToString());
                Console.WriteLine("Answer copied to clipboard!");
            }

            Console.WriteLine("Press any key to close");
            Console.ReadKey();
        }

    }
}

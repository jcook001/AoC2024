using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Runtime.Versioning;

namespace AoC2024.Days
{
    [SupportedOSPlatform("windows7.0")]
    internal class Day03
    {
        [STAThread]
        public static void Solve()
        {
            /////////////////////////////////////////////
            /////////////////* Part 1 *//////////////////
            /////////////////////////////////////////////

            String[] inputArray = Utils.ReadInput();
            if (inputArray == null)
            {
                Console.WriteLine("Press any key to close");
                Console.ReadKey();
                return;
            }

            int totalMultiplication = 0;

            //Need to find parts of the string that match the format mul(XXX,XXX) where X could be a number 1-3 digits long
            //And extract each number to a group
            string pattern = @"mul\((\d{1,3}),(\d{1,3})\)";

            Regex regex = new Regex(pattern);

            foreach (string s in inputArray)
            {
                MatchCollection matches = regex.Matches(s);

                foreach (Match match in matches)
                {
                    //Console.WriteLine("match found: " + match.Groups[0].Value);
                    int number1 = int.Parse(match.Groups[1].Value);
                    int number2 = int.Parse(match.Groups[2].Value);

                    totalMultiplication += number1 * number2;
                    //Console.WriteLine("number 1: {0} * number2: {1} = {2}", number1, number2, number1 * number2);
                    //Console.WriteLine("total multiplication is now: " + totalMultiplication);
                }
            }

            int answer = totalMultiplication;
            // Set the Foreground color to yellow - helpful for highlighting answer
            Console.ForegroundColor
                = ConsoleColor.Yellow;
            Console.WriteLine("Part 1: multiplication total {0}", answer);
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

            //Need to find parts of the string that match the format mul(XXX,XXX) where X could be a number 1-3 digits long
            //And extract each number to a group
            //                                 @"mul\((\d{1,3}),(\d{1,3})\)"
            //                @"do\(\)|don't\(\)|mul\(\d{1,3},\d{1,3}\)"
            string pattern2 = @"do\(\)|don't\(\)|mul\((\d{1,3}),(\d{1,3})\)";

            regex = new Regex(pattern2);
            int totalMultiplication2 = 0;

            foreach (string s in inputArray)
            { 
                MatchCollection matches = regex.Matches(s);

                bool shouldProcess = true;
                Console.ForegroundColor = ConsoleColor.Green;

                foreach (Match match in matches)
                {
                    string token = match.Value;

                    if(token == "do()")
                    {
                        shouldProcess = true;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("match found: " + match.Groups[0].Value);
                    }
                    else if (token == "don't()")
                    {
                        shouldProcess = false;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("match found: " + match.Groups[0].Value);
                    }
                    else
                    {
                        if(shouldProcess == true)
                        {
                            Console.WriteLine("match found: " + match.Groups[0].Value);
                            int number1 = int.Parse(match.Groups[1].Value);
                            int number2 = int.Parse(match.Groups[2].Value);

                            totalMultiplication2 += number1 * number2;
                            Console.WriteLine("{0} * {1} = {2}", number1, number2, number1 * number2);
                            Console.WriteLine("total multiplication is now: " + totalMultiplication2);
                        }
                        else
                        {
                            Console.WriteLine("match found: " + match.Groups[0].Value);
                        }
                    }
                }
            }

            int answer2 = totalMultiplication2;

            // Set the Foreground color to yellow  - helpful for highlighting answer
            Console.ForegroundColor
                = ConsoleColor.Yellow;
            if (answer2 != 0)
            {
                Console.WriteLine("Part2: Multiplication total with dos and don'ts accounted for = " + answer2);
                Clipboard.SetText(answer2.ToString());
                Console.WriteLine("Answer copied to clipboard!");

                // 105264641 is too high!
            }

            Console.WriteLine("Press any key to close");
            Console.ReadKey();
        }
    }
}

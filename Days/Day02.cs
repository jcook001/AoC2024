using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AoC2024.Days
{
    public class Day02
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

            int safeCount_part1 = 0;

            foreach (string s in input)
            {
                List<int> levels = new List<int>();
                String[] tempStringArray = s.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string t in tempStringArray)
                {
                    levels.Add(int.Parse(t));
                }

                //Console.WriteLine("string is " + s);
                if (isSafe(levels))
                {
                    //Console.WriteLine("String is safe");
                    safeCount_part1++;
                }
                else
                {
                    //Console.WriteLine("String is not safe");
                }

            }



            int answer = safeCount_part1;
            // Set the Foreground color to yellow - helpful for highlighting answer
            Console.ForegroundColor
                = ConsoleColor.Yellow;
            Console.WriteLine("Part 1: The total amount of safe strings is {0}", answer);
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

            int safeCount_part2 = 0;

            foreach (string s in input)
            {
                List<int> levels = new List<int>();
                String[] tempStringArray = s.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string t in tempStringArray)
                {
                    levels.Add(int.Parse(t));
                }

                Console.WriteLine("string is " + s);
                if (isSafe(levels))
                {
                    Console.WriteLine("String is safe without modifications");
                    safeCount_part2++;
                }
                else
                {
                    Console.WriteLine("String is not safe, going to try again with numbers omitted");
                    //try again with each number omitted in turn
                    for (int numberPosToRemove = 0; numberPosToRemove < levels.Count; numberPosToRemove++)
                    {
                        List<int> intsWithNumberRemoved = new List<int>();
                        for (int x = 0; x < levels.Count; x++)
                        {
                            if (x != numberPosToRemove)
                            {
                                intsWithNumberRemoved.Add(levels[x]);
                            }
                        }

                        Console.Write("new string to check is: ");
                        foreach (int i in intsWithNumberRemoved)
                        {
                            Console.Write(i + ", ");
                        }
                        Console.Write("\n");
                        
                        if (isSafe(intsWithNumberRemoved))
                        {
                            Console.WriteLine("string is safe, moving on...");
                            safeCount_part2++;
                            break;
                        }
                    }
                    Console.WriteLine("string is still not safe");
                }

            }


            int answer2 = safeCount_part2;

            // Set the Foreground color to yellow  - helpful for highlighting answer
            Console.ForegroundColor
                = ConsoleColor.Yellow;
            Console.WriteLine("Part2: Safe count adjusted with Problem Dampener = " + answer2);
            if (answer2 != 0)
            {
                Clipboard.SetText(answer2.ToString());
                Console.WriteLine("Answer copied to clipboard!");
            }

            Console.WriteLine("Press any key to close");
            Console.ReadKey();
        }

        private static bool isSafe(List<int> levels)
        {
            //determine if increasing
            bool? isIncreasing = null;
            bool isSafe = true;
            int tempInt = levels[0];
            for (int i = 1; i < levels.Count; i++)
            {
                if (levels[i] - tempInt > 0)
                {
                    //it's increasing
                    if (isIncreasing == null)
                    {
                        isIncreasing = true;
                    }
                    else if (isIncreasing == false)
                    {
                        //not safe
                        isSafe = false;
                        break;
                    }

                    if (levels[i] - tempInt > 3)
                    {
                        //not safe
                        isSafe = false;
                        break;
                    }
                }
                else if (levels[i] - tempInt < 0)
                {
                    //it's decreasing
                    if (isIncreasing == null)
                    {
                        isIncreasing = false;
                    }
                    else if (isIncreasing == true)
                    {
                        //not safe
                        isSafe = false;
                        break;
                    }

                    if (levels[i] - tempInt < -3)
                    {
                        //not safe
                        isSafe = false;
                        break;
                    }
                }
                else
                {
                    //0 difference
                    //not safe
                    isSafe = false;
                    break;
                }

                tempInt = levels[i];
            }

            if (isSafe)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}

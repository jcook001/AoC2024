using System;
using System.Collections.Generic;
using System.Linq;
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

            List<int> levels = new List<int>();
            int safeCount_part1 = 0;

            foreach (string s in input)
            {
                levels.Clear();
                String[] tempStringArray = s.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string t in tempStringArray)
                {
                    levels.Add(int.Parse(t));
                }

                //determine if increasing
                bool? isIncreasing = null;
                bool isSafe = true;
                int tempInt = levels[0];
                for (int i = 1; i < levels.Count;  i++ )
                {
                    if (levels[i] - tempInt > 0)
                    {
                        //it's increasing
                        if(isIncreasing == null)
                        {
                            isIncreasing = true;
                        }
                        else if (isIncreasing == false)
                        {
                            //not safe
                            isSafe = false;
                            break;
                        }

                        if(levels[i] - tempInt > 3)
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

                //Console.WriteLine("string is " + s);
                if (isSafe)
                {
                    //Console.WriteLine("String is safe");
                    safeCount_part1++;
                }
                else
                {
                    //Console.WriteLine("String is not safe");
                }

                //reset values for next string
                isIncreasing = null;
                isSafe = true;

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
                levels.Clear();
                String[] tempStringArray = s.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string t in tempStringArray)
                {
                    levels.Add(int.Parse(t));
                }

                Console.WriteLine("string is " + s);

                //determine if increasing
                bool? isIncreasing = null;
                int levelUnsafeCount = 0;
                int tempInt = levels[0];
                List<int> valuesRemoved = new List<int>();
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
                            levelUnsafeCount++;
                            valuesRemoved.Add(levels[i]);
                            continue;
                        }

                        if (levels[i] - tempInt > 3)
                        {
                            //not safe
                            levelUnsafeCount++;
                            valuesRemoved.Add(levels[i]);
                            continue;
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
                            levelUnsafeCount++;
                            valuesRemoved.Add(levels[i]);
                            continue;
                        }

                        if (levels[i] - tempInt < -3)
                        {
                            //not safe
                            levelUnsafeCount++;
                            valuesRemoved.Add(levels[i]);
                            continue;
                        }
                    }
                    else
                    {
                        //0 difference
                        //not safe
                        levelUnsafeCount++;
                        valuesRemoved.Add(levels[i]);
                        continue;
                    }

                    tempInt = levels[i];
                }

                if (levelUnsafeCount == 0)
                {
                    Console.WriteLine("String is safe, no removals");
                    safeCount_part2++;
                }
                else if (levelUnsafeCount >= 1)
                {
                    string isSafe = "";
                    if(levelUnsafeCount == 1)
                    {
                        isSafe = "safe";
                        safeCount_part2++;
                    }
                    else
                    {
                        isSafe = "not safe";
                    }
                    Console.WriteLine("String is {1}, {0} removal(s)", levelUnsafeCount, isSafe);
                    Console.WriteLine("Values removed: ");
                    foreach(int i in valuesRemoved)
                    {
                        Console.Write(i + ", ");
                    }
                    Console.Write("\n");
                }
                else
                {
                    Console.WriteLine("String is not safe");
                }

                //reset values for next string
                isIncreasing = null;
                levelUnsafeCount = 0;
                valuesRemoved.Clear();

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

        private int safetyCheck()
        {
            
        }
    }
}

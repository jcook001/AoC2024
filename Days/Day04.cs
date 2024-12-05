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
    internal class Day04
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

            int xmasCount = 0;

            for (int x = 0; x < input[0].Length; x++)
            {
                for (int y = 0; y < input.Length; y++)
                {
                    //check if the char is X
                    if (input[y][x] == 'X')
                    {
                        Console.WriteLine("X Found! Coordinates are {0},{1}", x, y);
                        //If it is X then search for XMAS
                        //forward
                        if (x + 3 < input[y].Length)
                        {
                            string test = "" + input[y][x + 1] + input[y][x + 2] + input[y][x + 3];

                            if (test == "MAS")
                            {
                                xmasCount++;
                            }
                        }

                        //backward
                        if (x >= 3)
                        {
                            string test = "" + input[y][x - 1] + input[y][x - 2] + input[y][x - 3];

                            if (test == "MAS")
                            {
                                xmasCount++;
                            }
                        }

                        //up
                        if (y >= 3)
                        {
                            string test = "" + input[y - 1][x] + input[y - 2][x] + input[y - 3][x];

                            if (test == "MAS")
                            {
                                xmasCount++;
                            }
                        }

                        //down
                        if (y + 3 < input.Length)
                        {
                            string test = "" + input[y + 1][x] + input[y + 2][x] + input[y + 3][x];

                            if (test == "MAS")
                            {
                                xmasCount++;
                            }
                        }

                        //diagonal up left
                        if(y >= 3 && x >= 3)
                        {
                            string test = "" + input[y - 1][x - 1] + input[y - 2][x - 2] + input[y - 3][x - 3];
                            if (test == "MAS")
                            {
                                xmasCount++;
                            }
                        }

                        //diagonal up right
                        if (y >= 3 && x + 3 < input[y].Length)
                        {
                            string test = "" + input[y - 1][x + 1] + input[y - 2][x + 2] + input[y - 3][x + 3];
                            if (test == "MAS")
                            {
                                xmasCount++;
                            }
                        }

                        //diagonal down left
                        if (y + 3 < input.Length && x >= 3)
                        {
                            string test = "" + input[y + 1][x - 1] + input[y + 2][x - 2] + input[y + 3][x - 3];

                            if (test == "MAS")
                            {
                                xmasCount++;
                            }
                        }

                        //diagonal down right
                        if (y + 3 < input.Length && x + 3 < input[y].Length)
                        {
                            string test = "" + input[y + 1][x + 1] + input[y + 2][x + 2] + input[y + 3][x + 3];

                            if (test == "MAS")
                            {
                                xmasCount++;
                            }
                        }

                    }
                }
            }



            int answer = xmasCount;
            // Set the Foreground color to yellow - helpful for highlighting answer
            Console.ForegroundColor
                = ConsoleColor.Yellow;
            Console.WriteLine("Part 1 answer is {0}", answer);
            if (answer != 0)
            {
                Clipboard.SetText(answer.ToString());
                Console.WriteLine("Answer copied to clipboard!");

                //2495 is Too low!
            }

            // Set the Foreground color to white - set back to white for debug text
            Console.ForegroundColor
                = ConsoleColor.White;

            /////////////////////////////////////////////
            /////////////////* Part 2 *//////////////////
            /////////////////////////////////////////////

            int xmasCount2 = 0;

            for (int x = 0; x < input[0].Length; x++)
            {
                for (int y = 0; y < input.Length; y++)
                {
                    //check if the char is X
                    if (input[y][x] == 'A')
                    {
                        Console.WriteLine("A Found! Coordinates are {0},{1}", x, y);
                        //If it is an A check the surrounding chars
                        if (y >= 1 && x >= 1 && y + 1 < input.Length && x + 1 < input[y].Length)
                        {
                            char TL = input[y - 1][x - 1];
                            char TR = input[y - 1][x + 1];
                            char BL = input[y + 1][x - 1];
                            char BR = input[y + 1][x + 1];

                            bool slashCorrect = false;
                            bool backSlashCorrect = false;

                            if ((TL == 'M' && BR == 'S') || (TL == 'S' && BR == 'M'))
                            {
                                backSlashCorrect = true;
                            }

                            if ((TR == 'M' && BL == 'S') || (TR == 'S' && BL == 'M'))
                            {
                                slashCorrect = true;
                            }

                            if(slashCorrect && backSlashCorrect)
                            {
                                xmasCount2++;
                            }

                        }

                    }
                }
            }

            int answer2 = xmasCount2;

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

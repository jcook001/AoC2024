using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AoC2024.Days
{
    [SupportedOSPlatform("windows7.0")] //Added to stop copy to clipboard function complaining
    internal class Day06
    {
        [STAThread]
        public static void Solve()
        {
            /////////////////////////////////////////////
            /////////////////* Part 1 *//////////////////
            /////////////////////////////////////////////

            List<char[]> input = Utils.ReadInputAsListCharArray();
            if (input == null)
            {
                Console.WriteLine("Press any key to close");
                Console.ReadKey();
                return;
            }

            

            var guardPos = (X:0, Y:0); //ValueTuple
            char guardDirection = '^';
            bool isGuardOnMap = true;

            for (int x = 0; x < input[0].Length; x++)
            {
                for (int y = 0; y < input.Count; y++)
                {
                    if(input[y][x] == '^')
                    {
                        guardPos.X = x;
                        guardPos.Y = y;
                        break;
                    }
                }
            }

            //Move Guard
            while (isGuardOnMap)
            {
                //Console.WriteLine($"Guard position is (Y,X) {guardPos.Y},{guardPos.X}");
                switch (guardDirection)
                {
                    //Move Up
                    case '^':
                        if(guardPos.Y - 1 < 0)
                        {
                            //guard is off the map!
                            //Console.WriteLine($"Guard has left map, going up from {guardPos.Y},{guardPos.X}");
                            input[guardPos.Y][guardPos.X] = 'X';
                            isGuardOnMap = false; break;
                        }
                        else if (input[guardPos.Y - 1][guardPos.X] == '#')
                        {
                            //Turn right
                            guardDirection = '>';
                        }
                        else
                        {
                            input[guardPos.Y][guardPos.X] = 'X';
                            input[guardPos.Y - 1][guardPos.X] = '^';
                            guardPos = (X:guardPos.X, Y:guardPos.Y - 1);
                        }
                        break;
                    //Move Down
                    case 'v':
                        if (guardPos.Y + 1 >= input.Count)
                        {
                            //guard is off the map!
                            //Console.WriteLine($"Guard has left map, going down from {guardPos.Y} , {guardPos.X}");
                            input[guardPos.Y][guardPos.X] = 'X';
                            isGuardOnMap = false; break;
                        }
                        else if (input[guardPos.Y + 1][guardPos.X] == '#')
                        {
                            //Turn right
                            guardDirection = '<';
                        }
                        else
                        {
                            input[guardPos.Y][guardPos.X] = 'X';
                            input[guardPos.Y + 1][guardPos.X] = 'v';
                            guardPos = (X: guardPos.X, Y: guardPos.Y + 1);
                        }
                        break;
                    //Move Right
                    case '>':
                        if (guardPos.X + 1 >= input[guardPos.Y].Length)
                        {
                            //guard is off the map!
                            //Console.WriteLine($"Guard has left map, going right from {guardPos.Y} , {guardPos.X}");
                            input[guardPos.Y][guardPos.X] = 'X';
                            isGuardOnMap = false; break;
                        }
                        else if (input[guardPos.Y][guardPos.X + 1] == '#')
                        {
                            //Turn right
                            guardDirection = 'v';
                        }
                        else
                        {
                            input[guardPos.Y][guardPos.X] = 'X';
                            input[guardPos.Y][guardPos.X + 1] = '>';
                            guardPos = (X: guardPos.X + 1, Y: guardPos.Y);
                        }
                        break;
                    //Move Left
                    case '<':
                        if (guardPos.X - 1 < 0)
                        {
                            //guard is off the map!
                            //Console.WriteLine($"Guard has left map, going left from {guardPos.Y} , {guardPos.X}");
                            input[guardPos.Y][guardPos.X] = 'X';
                            isGuardOnMap = false; break;
                        }
                        else if (input[guardPos.Y][guardPos.X - 1] == '#')
                        {
                            //Turn right
                            guardDirection = '^';
                        }
                        else
                        {
                            input[guardPos.Y][guardPos.X] = 'X';
                            input[guardPos.Y][guardPos.X - 1] = '<';
                            guardPos = (X: guardPos.X - 1, Y: guardPos.Y);
                        }
                        break;
                }
            }

            //Guard has completed their movement
            int locationsVisited = 0;

            foreach (char[] Y in input)
            {
                foreach(char X in Y)
                {
                    if(X == 'X')
                    {
                        locationsVisited++;
                    }
                }
            }

            int answer = locationsVisited;
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

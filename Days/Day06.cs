using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Configuration;
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
            var guardStartPos = (X: 0, Y: 0); //ValueTuple
            char guardDirection = '^';
            bool isGuardOnMap = true;

            for (int x = 0; x < input[0].Length; x++)
            {
                for (int y = 0; y < input.Count; y++)
                {
                    if(input[y][x] == '^')
                    {
                        guardPos = (X: x, Y: y);
                        guardStartPos = (X: x, Y: y);
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

            List<char[]> input2 = Utils.ReadInputAsListCharArray();
            List<char[]> tempInput = input2;

            //Place an obstacle in each location of the map and test that
            var obstacleLocation = (X: 0, Y: 0);

            //loop detection
            int loopCount = 0;
            var guardPositions = new List<(int X, int Y)>();
            var guardPreviousPos = (X: 0, Y: 0);

            for ( int x = 0; x < input2[guardPos.Y].Length; x++)
            {
                for (int y = 0; y < input2.Count; y++)
                {
                    //reset input
                    tempInput = Utils.ReadInputAsListCharArray();
                    //reset guard position
                    guardPos = guardStartPos;
                    isGuardOnMap = true;
                    guardDirection = '^';
                    //place Obstacle
                    //Console.WriteLine($"Guard starting position is (Y,X): {guardPos.Y},{guardPos.X}");
                    //Don't place the obstacle on the guard - that would be stupid
                    if (tempInput[y][x] == '^')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Skipping obstacle placement for {y}, {x}");
                        Console.ForegroundColor = ConsoleColor.White;
                        continue;
                    }
                    tempInput[y][x] = '#';
                    obstacleLocation = (X: x, Y: y);
                    Console.WriteLine($"Placed obstacle at {obstacleLocation.Y}, {obstacleLocation.X}");
                    //reset loop detection list
                    guardPositions.Clear();
                    guardPositions.Add(guardPos);

                    ////Draw the map
                    //foreach (var line in tempInput)
                    //{
                    //    foreach(char c in line)
                    //    {
                    //        Console.Write(c);
                    //    }
                    //    Console.Write("\n");
                    //}
                    //Console.ForegroundColor = ConsoleColor.DarkRed;
                    //Console.WriteLine("**********");
                    //Console.ForegroundColor = ConsoleColor.White;


                    while (isGuardOnMap)
                    {
                        ////Draw the map
                        //foreach (var line in tempInput)
                        //{
                        //    foreach (char c in line)
                        //    {
                        //        Console.Write(c);
                        //    }
                        //    Console.Write("\n");
                        //}
                        //Console.ForegroundColor = ConsoleColor.DarkRed;
                        //Console.WriteLine("**********");
                        //Console.ForegroundColor = ConsoleColor.White;
                        //Console.WriteLine($"Guard position is (Y,X) {guardPos.Y},{guardPos.X}");
                        switch (guardDirection)
                        {
                            //Move Up
                            case '^':
                                if (guardPos.Y - 1 >= 0)
                                {
                                    if (tempInput[guardPos.Y - 1][guardPos.X] == 'X')
                                    {
                                        //we've been to the next space before!
                                        for (int moveIndex = 1; moveIndex < guardPositions.Count - 2; moveIndex++)
                                        {
                                            var position1 = guardPositions[moveIndex - 1];
                                            var position2 = guardPositions[moveIndex];

                                            if (guardPreviousPos == position1 && guardPos == position2)
                                            {
                                                //we have a loop!
                                                //Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                //Console.WriteLine("Loop detected!");
                                                //Console.ForegroundColor = ConsoleColor.White;
                                                loopCount++;
                                                isGuardOnMap = false;
                                                break;
                                            }
                                        }

                                    }
                                }


                                if (guardPos.Y - 1 < 0)
                                {
                                    //guard is off the map!
                                    //Console.WriteLine($"Guard has left map, going up from {guardPos.Y},{guardPos.X}");
                                    tempInput[guardPos.Y][guardPos.X] = 'X';
                                    //Console.ForegroundColor = ConsoleColor.Green;
                                    //Console.WriteLine("No loop detected!");
                                    //Console.ForegroundColor = ConsoleColor.White;
                                    isGuardOnMap = false; break;
                                }
                                else if (tempInput[guardPos.Y - 1][guardPos.X] == '#')
                                {
                                    //Turn right
                                    guardDirection = '>';
                                }
                                else
                                {
                                    //Mark where we've been
                                    tempInput[guardPos.Y][guardPos.X] = 'X';
                                    //Move Guard on map
                                    tempInput[guardPos.Y - 1][guardPos.X] = '^';
                                    //record and update Guard position
                                    guardPreviousPos = guardPos;
                                    guardPos = (X: guardPos.X, Y: guardPos.Y - 1);
                                    guardPositions.Add(guardPos);
                                }
                                break;
                            //Move Down
                            case 'v':
                                if (guardPos.Y + 1 < tempInput.Count)
                                {
                                    if (tempInput[guardPos.Y + 1][guardPos.X] == 'X')
                                    {
                                        //we've been to the next space before!
                                        for (int moveIndex = 1; moveIndex < guardPositions.Count - 2; moveIndex++)
                                        {
                                            var position1 = guardPositions[moveIndex - 1];
                                            var position2 = guardPositions[moveIndex];

                                            if (guardPreviousPos == position1 && guardPos == position2)
                                            {
                                                //we have a loop!
                                                //Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                //Console.WriteLine("Loop detected!");
                                                //Console.ForegroundColor = ConsoleColor.White;
                                                loopCount++;
                                                isGuardOnMap = false;
                                                break;
                                            }
                                        }

                                    }
                                }

                                if (guardPos.Y + 1 >= tempInput.Count)
                                {
                                    //guard is off the map!
                                    //Console.WriteLine($"Guard has left map, going down from {guardPos.Y} , {guardPos.X}");
                                    tempInput[guardPos.Y][guardPos.X] = 'X';
                                    //Console.ForegroundColor = ConsoleColor.Green;
                                    //Console.WriteLine("No loop detected!");
                                    //Console.ForegroundColor = ConsoleColor.White;
                                    isGuardOnMap = false; break;
                                }
                                else if (tempInput[guardPos.Y + 1][guardPos.X] == '#')
                                {
                                    //Turn right
                                    guardDirection = '<';
                                }
                                else
                                {
                                    //Mark where we've been
                                    tempInput[guardPos.Y][guardPos.X] = 'X';
                                    //Move Guard on map
                                    tempInput[guardPos.Y + 1][guardPos.X] = 'v';
                                    //record and update Guard position
                                    guardPreviousPos = guardPos;
                                    guardPos = (X: guardPos.X, Y: guardPos.Y + 1);
                                    guardPositions.Add(guardPos);
                                }
                                break;
                            //Move Right
                            case '>':
                                if (guardPos.X + 1 < tempInput[guardPos.Y].Length)
                                {
                                    if (tempInput[guardPos.Y][guardPos.X + 1] == 'X')
                                    {
                                        //we've been to the next space before!
                                        for (int moveIndex = 1; moveIndex < guardPositions.Count - 2; moveIndex++)
                                        {
                                            var position1 = guardPositions[moveIndex - 1];
                                            var position2 = guardPositions[moveIndex];

                                            if (guardPreviousPos == position1 && guardPos == position2)
                                            {
                                                //we have a loop!
                                                //Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                //Console.WriteLine("Loop detected!");
                                                //Console.ForegroundColor = ConsoleColor.White;
                                                loopCount++;
                                                isGuardOnMap = false;
                                                break;
                                            }
                                        }

                                    }
                                }

                                if (guardPos.X + 1 >= tempInput[guardPos.Y].Length)
                                {
                                    //guard is off the map!
                                    //Console.WriteLine($"Guard has left map, going right from {guardPos.Y} , {guardPos.X}");
                                    tempInput[guardPos.Y][guardPos.X] = 'X';
                                    //Console.ForegroundColor = ConsoleColor.Green;
                                    //Console.WriteLine("No loop detected!");
                                    //Console.ForegroundColor = ConsoleColor.White;
                                    isGuardOnMap = false; break;
                                }
                                else if (tempInput[guardPos.Y][guardPos.X + 1] == '#')
                                {
                                    //Turn right
                                    guardDirection = 'v';
                                }
                                else
                                {
                                    //Mark where we've been
                                    tempInput[guardPos.Y][guardPos.X] = 'X';
                                    //Move Guard on map
                                    tempInput[guardPos.Y][guardPos.X + 1] = '>';
                                    //record and update Guard position
                                    guardPreviousPos = guardPos;
                                    guardPos = (X: guardPos.X + 1, Y: guardPos.Y);
                                    guardPositions.Add(guardPos);
                                }
                                break;
                            //Move Left
                            case '<':
                                if (guardPos.X - 1 >= 0)
                                {
                                    if (tempInput[guardPos.Y][guardPos.X - 1] == 'X')
                                    {
                                        //we've been to the next space before!
                                        for (int moveIndex = 1; moveIndex < guardPositions.Count - 2; moveIndex++)
                                        {
                                            var position1 = guardPositions[moveIndex - 1];
                                            var position2 = guardPositions[moveIndex];

                                            if (guardPreviousPos == position1 && guardPos == position2)
                                            {
                                                //we have a loop!
                                                //Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                //Console.WriteLine("Loop detected!");
                                                //Console.ForegroundColor = ConsoleColor.White;
                                                loopCount++;
                                                isGuardOnMap = false;
                                                break;
                                            }
                                        }

                                    }
                                }

                                if (guardPos.X - 1 < 0)
                                {
                                    //guard is off the map!
                                    //Console.WriteLine($"Guard has left map, going left from {guardPos.Y} , {guardPos.X}");
                                    tempInput[guardPos.Y][guardPos.X] = 'X';
                                    //Console.ForegroundColor = ConsoleColor.Green;
                                    //Console.WriteLine("No loop detected!");
                                    //Console.ForegroundColor = ConsoleColor.White;
                                    isGuardOnMap = false; break;
                                }
                                else if (tempInput[guardPos.Y][guardPos.X - 1] == '#')
                                {
                                    //Turn right
                                    guardDirection = '^';
                                }
                                else
                                {
                                    //Mark where we've been
                                    tempInput[guardPos.Y][guardPos.X] = 'X';
                                    //Move Guard on map
                                    tempInput[guardPos.Y][guardPos.X - 1] = '<';
                                    //record and update Guard position
                                    guardPreviousPos = guardPos;
                                    guardPos = (X: guardPos.X - 1, Y: guardPos.Y);
                                    guardPositions.Add(guardPos);
                                }
                                break;
                        }
                    }
                }
            }

            int answer2 = loopCount;

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AoC2024.Days
{
    public class Day01
    {
        [STAThread]
        public static void Solve()
        {
            //////////////////
            ////* Part 1 *////
            //////////////////

            String[] input = Utils.ReadInput();
            List<int> input1 = new List<int>();
            List<int> input2 = new List<int>();

            foreach (string s in input)
            {
                String[] tempStringArray = s.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                int tempInt = 0;
                if (int.TryParse(tempStringArray[0], out tempInt))
                {
                    input1.Add(tempInt);
                }
                else
                {
                    Console.WriteLine("failed parsing in step 1: " + s);
                    Console.WriteLine("split 1 is: " + tempStringArray[0]);
                    Console.WriteLine("split 2 is: " + tempStringArray[1]);
                }

                if (int.TryParse(tempStringArray[1], out tempInt))
                {
                    input2.Add(tempInt);
                }
                else
                {
                    Console.WriteLine("failed parsing in step 2: " + s);
                    Console.WriteLine("split 1 is: " + tempStringArray[0]);
                    Console.WriteLine("split 2 is: " + tempStringArray[1]);
                }
            }

            input1.Sort();
            input2.Sort();

            int differenceCount = 0;
            int count = 0;

            foreach(int i in input1)
            {
                if (input1[count] != input2[count])
                {
                    int difference = input1[count] - input2[count];
                    
                    if(difference < 0)
                    {
                        difference *= -1;
                    }

                    differenceCount += difference;
                }
                count++;
            }

            // Set the Foreground color to yellow - helpful for highlighting answer
            Console.ForegroundColor
                    = ConsoleColor.Yellow;
            Console.WriteLine("Part 1: The total difference of all values is {0}", differenceCount);
            Clipboard.SetText(differenceCount.ToString());
            Console.WriteLine("Answer copied to clipboard!");

            // Set the Foreground color to white - set back to white for debug text
            Console.ForegroundColor
                = ConsoleColor.White;

            //////////////////
            ////* Part 2 *////
            //////////////////

            int similarityScore = 0;

            foreach (int i in input1)
            {
                int matchCount = 0;
                foreach (int j in input2)
                {
                    if (i  == j)
                    {
                        matchCount++;
                    }
                }
                similarityScore += i * matchCount;
            }

            // Set the Foreground color to yellow  - helpful for highlighting answer
            Console.ForegroundColor
                = ConsoleColor.Yellow;
            Console.WriteLine("Part2: Similarity Score = " + similarityScore);
            Clipboard.SetText(similarityScore.ToString());
            Console.WriteLine("Answer copied to clipboard!");
            Console.WriteLine("Press any key to close");
            Console.ReadKey();
        }

    }
}

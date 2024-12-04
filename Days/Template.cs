using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AoC2024.Days
{
    internal class Template
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

            foreach (string s in input)
            {
                String[] tempStringArray = s.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }



            int answer = 0;
            // Set the Foreground color to yellow - helpful for highlighting answer
            Console.ForegroundColor
                = ConsoleColor.Yellow;
            Console.WriteLine("Part 1: The total difference of all values is {0}", answer);
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
            Console.WriteLine("Part2: Similarity Score = " + answer2);
            if (answer2 != 0)
            {
                Clipboard.SetText(answer2.ToString());
                Console.WriteLine("Answer copied to clipboard!");
            }

            Console.WriteLine("Press any key to close");
            Console.ReadKey();
        }

    }
}

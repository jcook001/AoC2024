using AoC2024.Days;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AoC2024
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            bool hasVaildNumber = false;

            while (!hasVaildNumber)
            {
                Console.WriteLine("Enter the day to run (e.g., 1, 2, ... 25):");
                if (int.TryParse(Console.ReadLine(), out int day))
                {
                    hasVaildNumber = true;
                    // Format the class name, e.g., "Day01" for day 1
                    string className = $"AoC2024.Days.Day{day:D2}";
                    Console.WriteLine(className);

                    try
                    {
                        // Load the type (class) dynamically
                        Type dayType = Type.GetType(className);
                        if (dayType == null)
                        {
                            Console.WriteLine($"Day {day} is not yet implemented.");
                            return;
                        }

                        // Find the Solve() method
                        MethodInfo solveMethod = dayType.GetMethod("Solve", BindingFlags.Public | BindingFlags.Static);
                        if (solveMethod == null)
                        {
                            Console.WriteLine($"Solve() method not found for Day {day}.");
                            return;
                        }

                        // Invoke the Solve() method
                        Console.WriteLine($"Running Day {day}...");
                        solveMethod.Invoke(null, null);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred while running Day {day}: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid number.");
                }
            }
        }
    }
}

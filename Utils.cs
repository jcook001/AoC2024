using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AoC2024
{
    public static class Utils
    {
        public static string[] ReadInput()
        {
            //Save "DayXX" in Inputs folder
            // Get the name of the calling class
            var stackTrace = new StackTrace();
            var callingClass = stackTrace.GetFrame(1)?.GetMethod()?.DeclaringType?.Name;

            if (callingClass == null || !callingClass.StartsWith("Day"))
            {
                throw new InvalidOperationException("Could not determine the calling class or invalid class name.");
            }

            // Extract the day number from the class name (e.g., "Day01" -> "01")
            var dayNumber = callingClass.Substring(3); // Assumes the format "DayXX"

            // Get the current directory (bin\Debug or bin\Release)
            string basePath = AppDomain.CurrentDomain.BaseDirectory;

            // Move up three levels to the project root
            string projectRoot = Path.Combine(basePath, "..", "..", "..");

            // Construct the full path to the input file
            string filePath = Path.Combine(projectRoot, "Inputs", $"Day{dayNumber}.txt");

            // Read and return all lines from the file
            if (File.Exists(filePath))
            {
                return File.ReadAllLines(filePath);
            }
            else
            {
                Console.WriteLine("No input file found!");
                return null;
            }
            
        }

        public static List<char[]> ReadInputAsListCharArray()
        {
            // Same logic as before to read the input file
            var stackTrace = new StackTrace();
            var callingClass = stackTrace.GetFrame(1)?.GetMethod()?.DeclaringType?.Name;

            if (callingClass == null || !callingClass.StartsWith("Day"))
            {
                throw new InvalidOperationException("Could not determine the calling class or invalid class name.");
            }

            var dayNumber = callingClass.Substring(3);
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string projectRoot = Path.Combine(basePath, "..", "..", "..");
            string filePath = Path.Combine(projectRoot, "Inputs", $"Day{dayNumber}.txt");

            if (File.Exists(filePath))
            {
                return File.ReadAllLines(filePath).Select(line => line.ToCharArray()).ToList();
            }
            else
            {
                Console.WriteLine("No input file found!");
                return null;
            }
        }

    }
}

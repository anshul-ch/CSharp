using System;
using System.IO;

namespace CSharp.M1_Practice
{
    /// <summary>
    /// Demonstrates basic file handling in C# by writing
    /// multiple lines of text to a file at a specified path.
    /// </summary>
    public class FileHandling
    {
        /// <summary>
        /// Application entry point.
        /// Writes text lines to an output file.
        /// </summary>
        /// <param name="args">Command-line arguments</param>
        public static void Main(string[] args)
        {
            // -------------------------------------------------
            // DATA TO WRITE
            // -------------------------------------------------

            string[] lines = { "First line", "Second line", "Third line" };

            // -------------------------------------------------
            // OUTPUT FILE PATH (CHANGE THIS IF NEEDED)
            // -------------------------------------------------

            // Option 1: Use Documents folder (recommended & safe)
            string outputDirectory = Environment.GetFolderPath(
                Environment.SpecialFolder.MyDocuments
            );

            // Option 2: Custom absolute path (Linux example)
            // string outputDirectory = "/home/anshul/Desktop";

            // Option 3: Current application directory
            // string outputDirectory = AppContext.BaseDirectory;

            // Ensure the directory exists
            Directory.CreateDirectory(outputDirectory);

            // Combine directory and file name safely
            string outputFilePath = Path.Combine(outputDirectory, "WriteLines.txt");

            // -------------------------------------------------
            // WRITE DATA TO FILE
            // -------------------------------------------------

            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                foreach (string line in lines)
                {
                    writer.WriteLine(line);
                }
            }

            // -------------------------------------------------
            // CONFIRMATION OUTPUT
            // -------------------------------------------------

            Console.WriteLine("File successfully created!");
            Console.WriteLine("Output file path:");
            Console.WriteLine(outputFilePath);
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            IGradeTracker book = CreateGradeBook();

            try
            {
                using (FileStream stream = File.Open("grades.txt", FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string line = reader.ReadLine();

                        while (line != null)
                        {
                            float grade = float.Parse(line);
                            book.AddGrade(grade);
                            line = reader.ReadLine();
                        }
                    }
                }
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("Could not locate file");
                Console.ReadLine();
                return;
            }
            catch(UnauthorizedAccessException)
            {
                Console.WriteLine("You dont have access to the file");
                Console.ReadLine();
                return;
            }

            foreach(float grade in book)
            {
                Console.WriteLine(grade);
            }

            try
            {
                //Console.WriteLine("Please enter a name");
                //book.Name = Console.ReadLine();
            }
            catch(ArgumentException)
            {
                Console.WriteLine("Invalid name");
            }
                        
            GradeStatistics stats = book.ComputeStatistics();     

            Console.WriteLine(stats.AverageGrade);
            Console.WriteLine(stats.LowestGrade);
            Console.WriteLine(stats.HighestGrade);
            Console.WriteLine("{0} - {1}",stats.LetterGrade, stats.Description);

            Console.ReadLine();

        }

        private static IGradeTracker CreateGradeBook()
        {
            IGradeTracker book = new ThrowAwayGradeBook("Michaels book");
            return book;
        }

        private static void OnNameChanged2(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine("***");
        }

        private static void OnNameChanged(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine("Name changed from {0} to {1}", args.OldValue, args.NewValue);
        }
        
        private static void WriteBytes(float value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            WriteByteArray(bytes);
        }

        private static void WriteBytes(int value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            WriteByteArray(bytes);
        }

        private static void WriteByteArray(byte[] bytes)
        {
            foreach (byte b in bytes)
            {
                Console.Write("0x{0:X} ", b);
            }
            Console.WriteLine();
        }
        
        private static void WriteNames(params string[] names)
        {
            foreach(string name in names)
            {
                Console.WriteLine(name);
            }
        }

    }
}

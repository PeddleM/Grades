﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            GradeBook book = new GradeBook("My book");
            book.AddGrade(91f);
            book.AddGrade(89.1f);
            book.AddGrade(75f);

            GradeStatistics stats = book.ComputeStatistics();

            book.NameChanged += OnNameChanged;
            book.NameChanged += OnNameChanged2;
            book.NameChanged = new NameChangedDelegate(OnNameChanged2);

            book.Name = "new book";
            WriteNames(book.Name);

            

            Console.WriteLine(stats.AverageGrade);
            Console.WriteLine(stats.LowestGrade);
            Console.WriteLine(stats.HighestGrade);

            Console.ReadLine();

        }

        private static void OnNameChanged2(string oldValue, string newValue)
        {
            Console.WriteLine("***");
        }

        private static void OnNameChanged(string oldValue, string newValue)
        {
            Console.WriteLine("Name changed from {0} to {1}", oldValue, newValue);
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

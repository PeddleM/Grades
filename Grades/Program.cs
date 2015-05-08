using System;
using System.Collections.Generic;
using System.Text;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            GradeBook g1 = new GradeBook();
            GradeBook g2 = g1;

            g1 = new GradeBook();

            g1.Name = "Michaels book";
            Console.WriteLine(g2.Name);

            int x1 = 4;
            int x2 = x1;

            x1 = 100;

            Console.WriteLine(x2);

            Console.ReadLine();


            //GradeBook book = new GradeBook();
            //book.AddGrade(91);
            //book.AddGrade(89.5f);
            //book.AddGrade(75f);

            //GradeStatistics stats = book.ComputeStatistics();
            //Console.WriteLine(stats.AverageGrade);
            //Console.WriteLine(stats.LowestGrade);
            //Console.WriteLine(stats.HighestGrade);

            //Console.ReadLine();
        }
    }
}

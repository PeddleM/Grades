using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Grades
{
    public class GradeBook : GradeTracker
    { 

        protected List<float> _grades;
       
        public GradeBook(string name = "There is no name")
        {
            Console.WriteLine("gradebook ctor");
            _grades = new List<float>();
            Name = name;
        }

        public override void AddGrade(float grade)
        {
            if (grade >= 0 && grade <= 100)
            {
                _grades.Add(grade);
            }
        }

        public override void DoSomeThing()
        {
            
        }

        public override GradeStatistics ComputeStatistics()
        {
            Console.WriteLine("regular compute");
            GradeStatistics stats = new GradeStatistics();
            float sum = 0f;

            foreach (float grade in _grades)
            {
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
                sum += grade;
            }

            stats.AverageGrade = sum / _grades.Count;

            return stats;
        }

        

        public override void WriteGrades(TextWriter textWriter)
        {
            textWriter.WriteLine("Grades:");
            int i = 0;
            do
            {
                textWriter.WriteLine(_grades[i]);
                i++;
            } while (i < _grades.Count);
            textWriter.WriteLine("*********");
        }

        public override IEnumerator GetEnumerator()
        {
            return _grades.GetEnumerator();
        }
    }
}

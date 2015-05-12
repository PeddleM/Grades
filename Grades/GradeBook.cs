using System;
using System.Collections.Generic;

namespace Grades
{
    public class GradeBook
    { 

        List<float> grades;
        private string _name;
        public NameChangedDelegate NameChanged;

        public GradeBook(string name = "There is no name")
        {
            grades = new List<float>();
            _name = name;
        }

        public void AddGrade(float grade)
        {
            if (grade >= 0 && grade <= 100)
            {
                grades.Add(grade);
            }
        }

        public GradeStatistics ComputeStatistics()
        {
            GradeStatistics stats = new GradeStatistics();
            float sum = 0f;

            foreach (float grade in grades)
            {
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
                sum += grade;
            }

            stats.AverageGrade = sum / grades.Count;

            return stats;
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (_name != value)
                {
                    var oldValue = _name;
                    _name = value;
                    if (NameChanged != null)
                    {
                        NameChanged(oldValue, value);
                    }
                }
                
            }
        }
    }
}

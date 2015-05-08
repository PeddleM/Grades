using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Grades;

namespace Grades.Tests
{
    [TestClass]
    public class UnitTest1
    {
        GradeBook book;
        GradeStatistics stats;

        public UnitTest1()
        {
            book = new GradeBook();
            SetUpGrades();
            stats = book.ComputeStatistics();
        }

        [TestMethod]
        public void CheckLowestGrade()
        {
            Assert.AreEqual(65f, stats.LowestGrade);
        }

        [TestMethod]
        public void CheckHighestGrade()
        {
            Assert.AreEqual(90f, stats.HighestGrade);
        }

        [TestMethod]
        public void CheckingAverageCalculation()
        {
            float average = CalculateAverage();
            Assert.AreEqual(average, stats.AverageGrade);
        }

        private void SetUpGrades()
        {
            book.AddGrade(90f);
            book.AddGrade(72.5f);
            book.AddGrade(65f);
        }
        
        public static float CalculateAverage()
        {
            return (90f + 72.5f + 65f) / 3;
        }
    }
}

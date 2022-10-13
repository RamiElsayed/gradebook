using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        public Book(string name)
        {
            grades = new List<double>();
            this.name = name;
        }

        public void AddGrade (double grade)
        {
            grades.Add(grade);
        }

        public Statistics GetStatistics()
        {
            var result = new Statistics();
            var result.High = double.MinValue;
            var result.Min = double.MaxValue;

            foreach(var grade in grades)
            {
                result.High = Math.Max(grade, result.High);
                result.Min = Math.Min(grade, result.Min);
                result.Average += grade;
            }
            result.Average /= grades.Count;

            return result;
        }

        private List<double> grades;
        private string name;
    }
}
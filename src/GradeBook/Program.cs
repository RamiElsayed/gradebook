using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Rami's book");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.5);
            book.GetStatistics();

            var stats = book.GetStatistics();

            Console.WriteLine($"The lowest grade is {result.Min}");
            Console.WriteLine($"The average grade is {result.High}");
            Console.WriteLine($"The average grade is {result.Average:N1}");
        }
    }
}

using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatesAverageGrade()
        {
            //arrange
            var book =  new Book("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            //act
            var result = book.GetStatistics();

            //assert
            Assert.Equal(85.6, result.Average, 1);
            Assert.Equal(90.5, result.High, 1);
            Assert.Equal(77.3, result.Low, 1);
            Assert.Equal('B', result.Letter);
        }
        [Fact]
        public void BookOnlyAcceptsHundredOrLess()
        {
            //arrange
            var book = new Book("");
            book.AddGrade(99);
            book.AddGrade(102);

            //act
            var result = book.GetStatistics();

            //assert
            Assert.NotEqual(102, result.High);
            Assert.Equal(99, result.High);
        }
    }
}

using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GradeBook.Tests
{
    public delegate string WriteLogDelegate(string logMessage);
    public class TypeTests
    {
        int count = 0;

        [Fact]
        public void WriteDelegateCanPointToMethod()
        {
            WriteLogDelegate log = ReturnMessage;
            log += ReturnMessage;
            log += IncrementCount;

            var result = log("Rami");

            Assert.Equal(3, count);
        }
        string IncrementCount(string message)
        {
            count++;
            return message.ToLower();
        }
        string ReturnMessage(string message)
        {
            count++;
            return message;
        }
        [Fact]
        public void Test1()
        {
            var x = GetInt();
            SetInt(x);

            Assert.Equal(3, x);
        }

        private void SetInt(int z)
        {
            z = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CSharpIsPassByRef()
        {
            var book1 = GetBook("InMemoryBook 1");
            GetBookSetName(ref book1, "New InMemoryBook");
            Assert.Equal("New InMemoryBook", book1.Name);
        }

        private void GetBookSetName(ref InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }
        [Fact]
        public void CSharpIsPassByValue()
        {
            var book1 = GetBook("InMemoryBook 1");
            GetBookSetName(book1, "New InMemoryBook");
            Assert.Equal("InMemoryBook 1", book1.Name);
        }

        private void GetBookSetName(InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("InMemoryBook 1");
            SetName("New Name", book1);

            Assert.Equal("New Name", book1.Name);
        }

        private void SetName(string name, InMemoryBook book)
        {
             book.Name = name;
        }

        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            string name = "Rami";
            var upper = MakeUpperCase(name);

            Assert.Equal("Rami", name);
            Assert.Equal("RAMI", upper);
        }

        private object MakeUpperCase(string name)
        {
            return name.ToUpper();
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("InMemoryBook 1");
            var book2 = GetBook("InMemoryBook 2");

            Assert.Equal("InMemoryBook 1", book1.Name);
            Assert.Equal("InMemoryBook 2", book2.Name);
        }

        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            var book1 = GetBook("InMemoryBook 1");
            var book2 = book1;

            Assert.Same(book1, book2);
        }
        InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
    }
}

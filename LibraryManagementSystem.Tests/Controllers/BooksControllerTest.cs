using System;
using System.Collections.Generic;
using System.Linq;
using LibraryManagementSystem.Controllers;
using LibraryManagementSystem.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace LibraryManagementSystem.Tests.Controllers
{
    [TestClass]
    public class BooksControllerTest
    {
        BooksController controller;
        List<Book> books;
        Mock<IMockBooks> mock;

        [TestInitialize]
        public void TestInitialize()
        {
            books = new List<Book>
            {
                new Book {Book_id=101,Book_name="Harry Potter"},
                new Book {Book_id=102,Book_name="Gone with the wind"}
            };

            mock = new Mock<IMockBooks>();
            mock.Setup(b => b.Books).Returns(books.AsQueryable());

            controller = new BooksController(mock.Object);
        }

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
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
                new Book {Book_id=101,Book_name="Harry Potter",Category_id=201},
                new Book {Book_id=102,Book_name="Gone with the wind",Category_id=202}
            };

            mock = new Mock<IMockBooks>();
            mock.Setup(b => b.Books).Returns(books.AsQueryable());

            controller = new BooksController(mock.Object);
        }

        [TestMethod]
        public void IndexViewLoad()
        {
            //act
            ViewResult result = controller.Index() as ViewResult;

            //assert
            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void IndexLoadBooks()
        {
            //act
            var result = (List<Book>)((ViewResult)controller.Index()).Model;

            //assert
            CollectionAssert.AreEqual(books.OrderBy(b => b.Category_id).ToList(), result);
        }

        [TestMethod]
        public void DetailsViewLoad()
        {
            //act
            ViewResult result = controller.Details(101) as ViewResult;

            //assert
            Assert.AreEqual("Details", result.ViewName);
        }

        [TestMethod]
        public void DetailsNullId()
        {
            //Act
            HttpStatusCodeResult result = controller.Details(null) as HttpStatusCodeResult;
            //Assert
            Assert.AreEqual(400, result.StatusCode);
        }

        [TestMethod]
        public void DetailsViewNullBook()
        {
            //Act
            HttpNotFoundResult result = controller.Details(0) as HttpNotFoundResult;
            //Assert
            Assert.AreEqual(404, result.StatusCode);
        }

        [TestMethod]
        public void CreateGetViewLoad()
        {
            //act
            ViewResult result = controller.Create() as ViewResult;

            //assert
            Assert.AreEqual("Create", result.ViewName);
        }

        [TestMethod]
        public void CreateModelBook()
        {
            controller.ModelState.AddModelError("Description", "error");

            //act
            ViewResult result = controller.Create(new Book { Book_id = 103 }) as ViewResult;
           
            //assert
            Assert.AreEqual("Create", result.ViewName);
        }

        [TestMethod]
        public void CreateRedirect()
        {
            //act
            RedirectToRouteResult result = controller.Create(new Book { Book_id = 103 }) as RedirectToRouteResult;

            //assert
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        public void DeleteViewLoad()
        {
            //act
            ViewResult result = controller.Delete(101) as ViewResult;

            //assert
            Assert.AreEqual("Delete", result.ViewName);
        }

        [TestMethod]
        public void DeleteNullId()
        {
            //Act
            HttpStatusCodeResult result = controller.Delete(null) as HttpStatusCodeResult;
            //Assert
            Assert.AreEqual(400, result.StatusCode);
        }

        [TestMethod]
        public void DeleteViewNullBook()
        {
            //Act
            HttpNotFoundResult result = controller.Delete(0) as HttpNotFoundResult;
            //Assert
            Assert.AreEqual(404, result.StatusCode);
        }
    }
}

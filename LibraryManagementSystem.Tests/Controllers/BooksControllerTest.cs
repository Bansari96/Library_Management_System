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
        List<Books_Category> categories;
        Mock<IMockBooks> mock;

        [TestInitialize]
        public void TestInitialize()
        {
            books = new List<Book>
            {
                new Book {Book_id=101,Book_name="Harry Potter",Category_id=201},
                new Book {Book_id=102,Book_name="Gone with the wind",Category_id=202}
            };

            categories = new List<Books_Category>
            {
                new Books_Category { Category_id=201, Category_name="Fake Category"},
                new Books_Category { Category_id=202, Category_name="Fake Category"}
            };

            mock = new Mock<IMockBooks>();
           
            mock.Setup(b => b.Books).Returns(books.AsQueryable());
            mock.Setup(c => c.Books_Category).Returns(categories.AsQueryable());
            controller = new BooksController();
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
        public void IndexViewLoadNotNullReturn()
        {
            //act
            ViewResult result = controller.Index() as ViewResult;

            //assert
            Assert.IsNotNull(result);
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
        public void DetailsViewLoadNotNull()
        {
            //act
            ViewResult result = controller.Details(101) as ViewResult;

            //assert
            Assert.IsNotNull(result);
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
        public void EditGetViewLoad()
        {
            //act
            ViewResult result = controller.Edit(101) as ViewResult;

            //assert
            Assert.AreEqual("Edit", result.ViewName);
        }
        [TestMethod]
        public void EditGetViewLoadNotNull()
        {
            //act
            ViewResult result = controller.Edit(101) as ViewResult;

            //assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void EditNullId()
        {
            //Act
            HttpStatusCodeResult result = controller.Edit((int?)null) as HttpStatusCodeResult;
            //Assert
            Assert.AreEqual(400, result.StatusCode);
        }

        [TestMethod]
        public void EditViewNullBook()
        {
            //Act
            HttpNotFoundResult result = controller.Edit(0) as HttpNotFoundResult;
            //Assert
            Assert.AreEqual(404, result.StatusCode);
        }

        //Edit POST
        [TestMethod]
        public void EditModelBook()
        {            
            //act
            RedirectToRouteResult result = controller.Edit(books[0]) as RedirectToRouteResult;

            //assert
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        public void EditPostInvalidModel()
        {
            controller.ModelState.AddModelError("Description", "Error");

            //act
            ViewResult result = controller.Edit(books[0]) as ViewResult;

            //Assert
            Assert.AreEqual("Edit", result.ViewName);
        }

        [TestMethod]
        public void EditViewBag()
        {
            controller.ModelState.AddModelError("Description", "error");

            // act
            SelectList result = (controller.Edit(books[0]) as ViewResult).ViewBag.Category_id;

            // assert
            Assert.AreEqual(201, result.SelectedValue);

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
        public void DeleteViewLoadNotNull()
        {
            //act
            ViewResult result = controller.Delete(101) as ViewResult;

            //assert
            Assert.IsNotNull(result);
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

        //Delete confirmed
        [TestMethod]
        public void DeleteConfirmedViewLoad()
        {
            //act
            RedirectToRouteResult result = controller.DeleteConfirmed(102) as RedirectToRouteResult;

            //assert
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }
        [TestMethod]
        public void DeleteConfirmedViewLoadNotNull()
        {
            //act
            RedirectToRouteResult result = controller.DeleteConfirmed(102) as RedirectToRouteResult;

            //assert
            Assert.IsNotNull(result);
        }
    }
}

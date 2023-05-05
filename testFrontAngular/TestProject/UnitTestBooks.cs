using api.DataBase;
using api.Models;
using NUnit.Framework;
using System.Collections.Generic;

namespace TestProject
{
    public class TestBooks
    {
        Books dataBase;
        [SetUp]
        public void Setup()
        {
            dataBase = new Books();
        }

        [Test]
        [Order(1)]
        public void TestCreateBook()
        {
            Book bookToCreate = new Book() { Isbn = 1, EditorialId = 1, Title = "title book 1", Synopsis = "synopsis test", NPages = "255 pages" };
            bool returnCreate = dataBase.CreateBook(bookToCreate);
            Assert.AreEqual(returnCreate, true);
            Book booksList = dataBase.GetBook(1);
            Assert.AreEqual(booksList.Title, "title book 1");
        }

        [Test]
        [Order(2)]
        public void TestUpdateBook()
        {
            Book bookToUpdate = new Book() { Isbn = 1, Title = "title book 2", EditorialId = 1 };
            bool returnUpdate = dataBase.UpdateBook(bookToUpdate);
            Assert.AreEqual(returnUpdate, true);
            Book booksList = dataBase.GetBook(1);
            Assert.AreEqual(booksList.Title, "title book 2");
        }

        [Test]
        [Order(3)]
        public void TestDeleteBook()
        {
            Book bookToDelete = new Book() { Isbn = 1 };
            bool returnDelete = dataBase.DeleteBook(bookToDelete);
            Assert.AreEqual(returnDelete, true);
            Book booksList = dataBase.GetBook(1);
            Assert.AreEqual(booksList, null);
        }
    }
}
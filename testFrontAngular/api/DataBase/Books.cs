using api.Controllers;
using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace api.DataBase
{
    public interface IBooks
    {
        public Book GetBook(Int64 isbn);
        public List<Book> GetBooks();
        public Author GetBookAuthor(Int64 isbn);
        public bool CreateBook(Book book);
        public bool UpdateBook(Book book);
        public bool DeleteBook(Book book);
    }

    public class Books : IBooks
    {
        private travel_inventory_dbContext context;
        public Books() {
            context = new travel_inventory_dbContext();
        }
        public Book GetBook(Int64 isbn)
        {
            return context.Books.Include(x => x.Editorial).FirstOrDefault(x => x.Isbn == isbn);
        }

        public List<Book> GetBooks(){
            return context.Books.Include(x => x.Editorial).ToList();
        }

        public Author GetBookAuthor(Int64 isbn)
        {
            return context.Authors.FirstOrDefault(x => x.Id == context.AuthorsHaveBooks.FirstOrDefault(y => y.BooksIsbn == isbn).AuthorsId);
        }

        public bool CreateBook(Book book)
        {
            try
            {
                context.Books.Add(book);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateBook(Book book)
        {
            try
            {
                context.Books.Update(book);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool DeleteBook(Book book)
        {
            try
            {
                context.Books.Remove(book);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

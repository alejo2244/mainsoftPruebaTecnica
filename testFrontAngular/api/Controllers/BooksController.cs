using api.DataBase;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooks db;
        public BooksController(IBooks dataBase) => db = dataBase;

        // GET: api/<BooksController>
        [HttpGet]
        public IEnumerable<object> Get()
        {
            List<object> objList = new();
            foreach (Book book in db.GetBooks())
            {
                Author author = db.GetBookAuthor(book.Isbn);
                objList.Add(new {
                    book.Isbn,
                    EditorialName = book.Editorial.Name,
                    AuthorName = author == null ? "N/A" : (author.Name + " " + author.LastNames),
                    book.Title,
                    book.Synopsis,
                    book.NPages,
                });
            }

            return objList;
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public object Get(Int64 id)
        {
            Book bookBd = db.GetBook(id);
            Author author = db.GetBookAuthor(bookBd.Isbn);
            var book = new
            {
                bookBd.Isbn,
                EditorialName = bookBd.Editorial.Name,
                AuthorName = author == null ? "N/A" : (author.Name + " " + author.LastNames),
                bookBd.Title,
                bookBd.Synopsis,
                bookBd.NPages,
            };
            return book;
        }

        // POST api/<BooksController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

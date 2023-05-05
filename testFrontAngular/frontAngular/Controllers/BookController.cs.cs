using frontAngular.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace frontAngular.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<Book>> GetAsync()
        {
            using var httpClient = new HttpClient();

            var response = await httpClient.GetAsync("https://localhost:44360/api/Books");

            List<Book> bookList = new();

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                bookList = JsonConvert.DeserializeObject<List<Book>>(content);
            }
            else
            {
                Console.WriteLine($"Error al realizar la solicitud. Código de estado: {response.StatusCode}");
            }
            return bookList;
        }

        [HttpGet("{id}")]
        public async Task<Book> GetAsync(Int64 id)
        {
            using var httpClient = new HttpClient();

            var response = await httpClient.GetAsync("https://localhost:44360/api/Books/" + id);

            Book book = new();

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                book = JsonConvert.DeserializeObject<Book>(content);
            }
            else
            {
                Console.WriteLine($"Error al realizar la solicitud. Código de estado: {response.StatusCode}");
            }
            return book;
        }
    }
}

using System.Collections.Generic;
using ASPCourse.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPCourse.Controllers
{
    public class HomeController : Controller
    {
        public List<Book> Books { get; set; }


        public HomeController()
        {
            Books = new List<Book>()
            {
                new Book()
                {
                    Id=1,
                    Title="The art of sql",
                    Description="description of sql language in depth"
                },
                new Book()
                {
                    Id=2,
                    Title="ASP.Net core 2.1 pro",
                    Description="aaaaaa"
                }
            };
        }

        public List<Book> GetBooks()
        {
            return Books;
        }


        public IActionResult DisplayBooks()
        {
            ViewData.Add("A", Books);
            return View();
        }

        public IActionResult ViewBook(int bookId)
        {
            Book selectedBook = null;
            foreach (var book in Books)
            {
                if (book.Id == bookId)
                {
                    selectedBook = book;
                    break;
                }
            }
            ViewData.Add("Book", selectedBook);
            return View();
        }

        public IActionResult GetBooksAsJson()
        {
            var rawJson = JsonConvert.SerializeObject(Books);
            return Content(rawJson);
        }

        public string Index()
        {
            return "Hello world from ASP.NET CORE MVC";
        }
        public string GetData()
        {
            return "Get data from method";
        }
        public IActionResult MyHomePage()
        {
            return View();
        }

    }
}

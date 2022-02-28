using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cftc.demo.Models;

namespace cftc.demo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {

        private readonly ILogger<BookController> _logger;

        public BookController(ILogger<BookController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetBooks_SortInMemory_ByPublisherAuthorTitle")]
        public IEnumerable<Book> GetBooks_SortInMemory_ByPublisherAuthorTitle()
        {
            IEnumerable<Book> Books = DAL.SqlHelper.GetBooks("sp_SelectBooks");

            return Books.OrderBy(x => x.Publisher).ThenBy(x => x.AuthorLastName).ThenBy(x => x. AuthorFirstName).ThenBy(x => x.Title);
        }

        [HttpGet("GetBooks_SortInMemory_ByAuthorTitle")]
        public IEnumerable<Book> GetBooks_SortInMemory_ByAuthorTitle()
        {
            IEnumerable<Book> Books = DAL.SqlHelper.GetBooks("sp_SelectBooks");

            return Books.OrderBy(x => x.AuthorLastName).ThenBy(x => x.AuthorFirstName).ThenBy(x => x.Title);
        }


        [HttpGet("GetBooks_SortInDb_ByPublisherAuthorTitle")]
        public IEnumerable<Book> GetBooks_SortInDb_ByPublisherAuthorTitle()
        {
            IEnumerable<Book> Books = DAL.SqlHelper.GetBooks("sp_SelectBooks_SortInDb_ByPublisherAuthorTitle");

            return Books;
        }

        [HttpGet("GetBooks_SortInDb_ByAuthorTitle")]
        public IEnumerable<Book> GetBooks_SortInDb_ByAuthorTitle()
        {
            IEnumerable<Book> Books = DAL.SqlHelper.GetBooks("sp_SelectBooks_SortInDb_ByAuthorTitle");

            return Books;
        }

        [HttpGet("GetBookInventoryValue")]
        public decimal GetBookInventoryValue()
        {
            IEnumerable<Book> Books = DAL.SqlHelper.GetBooks("sp_SelectBooks");

            return Books.Sum(x => x.Price);
        }

        [HttpPost("UploadBooks")]
        public void UploadBooks(IEnumerable<Book> books)
        {

            DAL.SqlHelper.UploadBooks(books);

        }
    }
}

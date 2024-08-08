using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.BusinessLayer;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookBL _bookBL;
        public BookController(BookBL bookBL)
        {
            _bookBL = bookBL;
        }

        // GET: api/Book
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            var books = _bookBL.GetBooks();
            return Ok(books);
        }

        // GET: api/Book/1
        [HttpGet("{id}/book")]
        public ActionResult<Book> GetBook(int id)
        {
            var book = _bookBL.GetBook(id);

            if (book == null)
            {
                return NotFound(new { Message = "Book not found" });
            }

            return Ok(book);
        }

        // GET: api/Book/{author}
        [HttpGet("{author}")]
        public ActionResult<Book> GetBook(string author)
        {
            var book = _bookBL.GetBook(author);

            if (book == null)
            {
                return NotFound(new { Message = "Book not found" });
            }

            return Ok(book);
        }

        // POST: api/Books
        [HttpPost]
        public ActionResult<Book> PostBook(Book book)
        {
            _bookBL.AddBook(book);
            return Ok(book);
        }

        // PUT: api/Books/2
        [HttpPut("{id}")]
        public IActionResult PutBook(int id, Book book)
        {
            var existingBook = _bookBL.GetBook(id);
            if (existingBook == null)
            {
                return NotFound(new { Message = "Book not found" });
            }

            _bookBL.UpdateBook(id, book);
            return Ok(new { Message = "Book updated successfully" });
        }

        // DELETE: api/Books/1
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var existingBook = _bookBL.GetBook(id);
            if (existingBook == null)
            {
                return NotFound(new { Message = "Book not found" });
            }

            _bookBL.DeleteBook(id);
            return Ok(new { Message = "Book deleted successfully" });
        }
    }
}
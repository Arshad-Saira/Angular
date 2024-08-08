using WebApplication2.DataAccessLayer;
using WebApplication2.Models;

namespace WebApplication2.BusinessLayer
{
    public class BookBL
    {
        private readonly BookDAL _bookDAL;
        public BookBL(BookDAL bookDAL)
        {
            _bookDAL = bookDAL;
        }
        public List<Book> GetBooks()
        {
            return _bookDAL.GetBooks();
        }

        public Book GetBook(int id)
        {
            return _bookDAL.GetBook(id);
        }
        public Book GetBook(string author)
        {
            return _bookDAL.GetBook(author);
        }

        public void AddBook(Book book)
        {
            _bookDAL.AddBook(book);
        }

        public void UpdateBook(int id, Book book)
        {
            var existingBook = _bookDAL.GetBook(id);
            if (existingBook != null)
            {
                book.Id = id; // Ensure the ID remains unchanged
                _bookDAL.UpdateBook(book);
            }
        }

        public void DeleteBook(int id)
        {
            _bookDAL.DeleteBook(id);
        }
    }
}
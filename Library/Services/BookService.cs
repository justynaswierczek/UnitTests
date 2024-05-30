using System.Collections.Generic;
using System.Linq;
using Library.Models;

namespace Library.Services
{
    public class BookService
    {
        private readonly List<Book> _books = new List<Book>();

        public void AddBook(Book book)
        {
            if (book != null && !string.IsNullOrWhiteSpace(book.Title))
            {
                _books.Add(book);
            }
        }

        public List<Book> GetAllBooks()
        {
            return _books;
        }

        public Book FindBookById(int id)
        {
            return _books.FirstOrDefault(b => b.Id == id);
        }

        public void UpdateBook(Book updatedBook)
        {
            var book = FindBookById(updatedBook.Id);
            if (book != null && !string.IsNullOrWhiteSpace(updatedBook.Title))
            {
                book.Title = updatedBook.Title;
                book.Author = updatedBook.Author;
                book.IsAvailable = updatedBook.IsAvailable;
            }
        }

        public void RemoveBook(int id)
        {
            var book = FindBookById(id);
            if (book != null)
            {
                _books.Remove(book);
            }
        }

        public Book FindBookByTitle(string title)
        {
            return _books.FirstOrDefault(b => b.Title == title);
        }
    }
}
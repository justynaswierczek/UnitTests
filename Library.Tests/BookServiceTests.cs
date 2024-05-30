using Library.Models;
using Library.Services;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Library.Tests
{
    [TestFixture]
    public class BookServiceTests
    {
        private BookService _bookService;

        [SetUp]
        public void Setup()
        {
            _bookService = new BookService();
        }

        [Test]
        public void AddBook_ShouldAddBookToList()
        {
            // Arrange
            var book = new Book { Title = "Test Book", Author = "Test Author", IsAvailable = true };

            // Act
            _bookService.AddBook(book);

            // Assert
            ClassicAssert.AreEqual(1, _bookService.GetAllBooks().Count);
        }

        [Test]
        public void GetAllBooks_ShouldReturnAllBooks()
        {
            // Arrange
            var book1 = new Book { Title = "Test Book 1", Author = "Test Author 1", IsAvailable = true };
            var book2 = new Book { Title = "Test Book 2", Author = "Test Author 2", IsAvailable = true };
            _bookService.AddBook(book1);
            _bookService.AddBook(book2);

            // Act
            var books = _bookService.GetAllBooks();

            // Assert
            ClassicAssert.AreEqual(2, books.Count);
        }

        [Test]
        public void FindBookById_ShouldReturnCorrectBook()
        {
            // Arrange
            var book = new Book { Title = "Test Book", Author = "Test Author", IsAvailable = true };
            _bookService.AddBook(book);

            // Act
            var result = _bookService.FindBookById(book.Id);

            // Assert
            ClassicAssert.AreEqual(book, result);
        }

        [Test]
        public void UpdateBook_ShouldModifyBookDetails()
        {
            // Arrange
            var book = new Book { Title = "Test Book", Author = "Test Author", IsAvailable = true };
            _bookService.AddBook(book);
            var updatedBook = new Book { Id = book.Id, Title = "Updated Book", Author = "Updated Author", IsAvailable = false };

            // Act
            _bookService.UpdateBook(updatedBook);
            var result = _bookService.FindBookById(book.Id);

            // Assert
            ClassicAssert.AreEqual("Updated Book", result.Title);
            ClassicAssert.AreEqual("Updated Author", result.Author);
            ClassicAssert.AreEqual(false, result.IsAvailable);
        }

        [Test]
        public void RemoveBook_ShouldDeleteBookFromList()
        {
            // Arrange
            var book = new Book { Title = "Test Book", Author = "Test Author", IsAvailable = true };
            _bookService.AddBook(book);

            // Act
            _bookService.RemoveBook(book.Id);

            // Assert
            ClassicAssert.AreEqual(0, _bookService.GetAllBooks().Count);
        }

        [Test]
        public void AddBook_ShouldNotAddNullBook()
        {
            // Arrange
            Book book = null;

            // Act
            _bookService.AddBook(book);

            // Assert
            ClassicAssert.AreEqual(0, _bookService.GetAllBooks().Count);
        }

        [Test]
        public void UpdateBook_ShouldNotUpdateNonExistingBook()
        {
            // Arrange
            var updatedBook = new Book { Id = 999, Title = "Non-Existing Book", Author = "Non-Existing Author", IsAvailable = false };

            // Act
            _bookService.UpdateBook(updatedBook);

            // Assert
            ClassicAssert.AreEqual(0, _bookService.GetAllBooks().Count);
        }

        [Test]
        public void AddBook_ShouldNotAddBookWithEmptyTitle()
        {
            // Arrange
            var book = new Book { Title = "", Author = "Test Author", IsAvailable = true };

            // Act
            _bookService.AddBook(book);

            // Assert
            ClassicAssert.AreEqual(0, _bookService.GetAllBooks().Count);
        }

        [Test]
        public void UpdateBook_ShouldNotUpdateBookWithNullTitle()
        {
            // Arrange
            var book = new Book { Title = "Test Book", Author = "Test Author", IsAvailable = true };
            _bookService.AddBook(book);
            var updatedBook = new Book { Id = book.Id, Title = null, Author = "Updated Author", IsAvailable = false };

            // Act
            _bookService.UpdateBook(updatedBook);
            var result = _bookService.FindBookById(book.Id);

            // Assert
            ClassicAssert.AreEqual("Test Book", result.Title);
            ClassicAssert.AreEqual("Test Author", result.Author);
            ClassicAssert.AreEqual(true, result.IsAvailable);
        }

        [Test]
        public void RemoveBook_ShouldNotRemoveNonExistingBook()
        {
            // Act
            _bookService.RemoveBook(999);

            // Assert
            ClassicAssert.AreEqual(0, _bookService.GetAllBooks().Count);
        }

    }
}
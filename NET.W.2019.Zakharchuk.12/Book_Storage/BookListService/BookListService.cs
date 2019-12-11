using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


namespace Book_Storage
{
    
    /// <summary>
    /// This class describes actions over the instance of class Book.
    /// </summary>
    internal class BookListService : IEnumerable<Book>
    {
        /// <summary>
        /// Interface link to the logger.
        /// </summary>
        public readonly ILogger logger;
        /// <summary>
        /// Storage for books.
        /// </summary>
        private readonly BookListStorage storage;

        /// <summary>
        /// List of Books.
        /// </summary>
        private List<Book> books = new List<Book>();

        /// <summary>
        /// Initializes a new instance of the <see cref="BookListService"/> class. Constructor Book.
        /// </summary>
        /// <param name="logger">Interface link to the logger.</param>        
        public BookListService(ILogger logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BookListService"/> class. Constructor Book.
        /// </summary>
        /// <param name="books">List of books.</param>
        /// <param name="storage">Storage for books.</param>
        public BookListService(List<Book> books, BookListStorage storage, ILogger logger):this(logger)
        {
            if (storage == null || books == null)
            {
                throw new ArgumentNullException(nameof(storage));
            }

            this.storage = storage;            
            foreach (Book book in books)
            {
                this.AddBook(book);                
            }            
        }

        /// <summary>
        /// Adding book in list of books.
        /// </summary>
        /// <param name="book">Book that needed to add in list of books.</param>        
        public void AddBook(Book book)
        {            
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            if (this.IsContains(book))
            {
                throw new ArgumentNullException(nameof(book));
            }

            this.books.Add(book);
            
            logger.Trace($"Book {book.Title} successfully added.");
        }

        /// <summary>
        /// Removing book from list of books.
        /// </summary>
        /// <param name="book">Book that needed to remove in list of books.</param> 
        public void RemoveBook(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            if (this.IsContains(book))
            {
                foreach (Book b in this.books)
                {
                    if (b.Equals(book))
                    {
                        this.books.Remove(b);

                        logger.Trace($"Book {book.Title} successfully removed.");
                    }
                }
            }            
        }

        /// <summary>
        /// This method finds books by tag.
        /// </summary>
        /// <param name="predicate">Criterion that searching for books in the book list.</param> 
        /// <returns>List of books.</returns>
        public List<Book> FindBookByTag(IPredicate<Book> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            List<Book> books2 = new List<Book>();
            foreach (Book b in this.books)
            {
                if (predicate.IsMatch(b))
                {
                    books2.Add(b);
                    logger.Trace($"Book {b.Title} successfully finded.");
                }
            }

            return books2;
        }

        /// <summary>
        /// This method sorts book list.
        /// </summary>
        /// <param name="comparer">Criteria by which books are sorted in the book list.</param>         
        public void SortBookByTag(IComparer<Book> comparer)
        {
            if (comparer == null)
            {
                throw new ArgumentNullException(nameof(comparer));
            }

            this.books.Sort(comparer);
        }

        /// <summary>
        /// This method saves book list in storage.
        /// </summary>        
        public void SaveToStorage()
        {
            if (this.storage == null)
            {
                throw new IOException(nameof(this.storage));
            }

            this.storage.SaveToStorage(this.books);
            logger.Debug($"List of books saved to the storage");
        }

        /// <summary>
        /// This method loads books from storage in list book.
        /// </summary>
        public void LoadFromStorage()
        {
            if (this.storage == null)
            {
                throw new ArgumentNullException(nameof(this.storage));
            }

            this.books = new List<Book>();
            foreach (Book book in this.storage.ReadStorage())
            {
                this.AddBook(book);
            }

            logger.Debug($"List of books loaded from storage");
        }

        /// <summary>
        /// This method shows list books in console.
        /// </summary>
        public void Show()
        {
            foreach (Book b in this.storage.ReadStorage())
            {
                Console.WriteLine(b);
            }
        }

        /// <inheritdoc />
        public IEnumerator<Book> GetEnumerator()
        {
            foreach (Book book in this.books)
            {
                yield return book;
            }
        }

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /// <summary>
        /// This method checks if the book is in the list.
        /// </summary>
        /// <param name="book">Book to check.</param> 
        /// <returns>True if the book is, false if not.</returns>
        private bool IsContains(Book book)
        {
            if (book == null)
            {
                return false;
            }

            foreach (Book i in this.books)
            {
                if (book.Equals(i))
                {
                    return true;
                }
            }

            return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;

namespace Book_Storage
{
    internal class BookListStorage : IBookListStorage
    {
        /// <summary>
        /// Path in storage.
        /// </summary>
        private string _path = @"storage.bin";

        /// <summary>
        /// Base Constructor.
        /// </summary>       
        public BookListStorage()
        {
        }

        /// <summary>
        /// Constructor BookListStorage.
        /// </summary>
        /// <param name="path">Path in storage.</param>       
        public BookListStorage(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            _path = path;
        }

        /// <summary>
        /// This method saves list book in storage.
        /// </summary>
        /// <param name="books">List of books</param>        
        public void SaveToStorage(IEnumerable<Book> books)
        {
            if (books == null)
            {
                throw new ArgumentNullException(nameof(books));
            }

            using (BinaryWriter writer = new BinaryWriter(File.Open(_path, FileMode.Create)))
            {
                foreach (Book b in books)
                {
                    writer.Write(b.Isbn);
                    writer.Write(b.Author);
                    writer.Write(b.Title);
                    writer.Write(b.Publisher);
                    writer.Write(b.NumberOfPages);
                    writer.Write(b.Year);
                    writer.Write(b.Price);
                }
            }
        }

        /// <summary>
        /// This method reads list book in storage.
        /// </summary>
        /// <returns>List of books</returns>
        public IEnumerable<Book> ReadStorage()
        {
            if (!File.Exists(_path))
            {
                throw new InvalidOperationException("Enter a correct filepath");
            }

            List<Book> books = new List<Book>();

            using (BinaryReader reader = new BinaryReader(File.Open(_path, FileMode.Open)))
            {
                while (reader.PeekChar() > -1)
                {
                    string isbn = reader.ReadString();
                    string author = reader.ReadString();
                    string title = reader.ReadString();
                    string publisher = reader.ReadString();
                    int numberOfPages = reader.ReadInt32();
                    int year = reader.ReadInt32();
                    decimal price = reader.ReadDecimal();

                    books.Add(new Book(isbn, author, title, publisher, numberOfPages, year, price));
                }
            }

            return books;
        }
    }
}

namespace Book_Storage
{    
    public class TitlePredicate : IPredicate<Book>
    {
        /// <summary>
        /// Field title.
        /// </summary>
        private string title;

        /// <summary>
        /// Constructor BookListService.
        /// </summary>
        /// <param name="title">Criteria for find</param>        
        public TitlePredicate(string title)
        {
            this.title = title.ToLower();            
        }

        /// <summary>
        /// This method checks book by criteria title.
        /// </summary>
        /// <param name="book">Book check.</param> 
        /// <returns>True if book find by criteria, false if not</returns>
        public bool IsMatch(Book book)
        {
            return book.Title.ToLower() == title;            
        }
    }

    public class AuthorPredicate : IPredicate<Book>
    {
        /// <summary>
        /// Field author.
        /// </summary>
        private string author;

        /// <summary>
        /// Constructor BookListService.
        /// </summary>
        /// <param name="title">Criteria for find</param>
        public AuthorPredicate(string author)
        {
            this.author = author.ToLower();
        }

        /// <summary>
        /// This method checks book by criteria title.
        /// </summary>
        /// <param name="book">Book check.</param> 
        /// <returns>True if book find by criteria, false if not</returns>
        public bool IsMatch(Book book)
        {
            return book.Author.ToLower() == author;
        }
    }

    public class YearPredicate : IPredicate<Book>
    {
        /// <summary>
        /// Field year.
        /// </summary>
        private int year;

        /// <summary>
        /// Constructor BookListService.
        /// </summary>
        /// <param name="title">Criteria for find</param>
        public YearPredicate(int year)
        {
            this.year = year;
        }

        /// <summary>
        /// This method checks book by criteria title.
        /// </summary>
        /// <param name="book">Book check.</param> 
        /// <returns>True if book find by criteria, false if not</returns>
        public bool IsMatch(Book book)
        {
            return book.Year == year;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Storage
{
    /// <summary>
    /// Extention methods for Book class.
    /// </summary>
    public static class Format
    {
        /// <summary>
        /// This method makes all letters uppercase in Author and Title.
        /// </summary>
        /// <param name="book">Instance of Book class.</param>
        /// <returns>Formatted book.</returns>
        public static Book UpperAuthorAndTitle(this Book book)
        {
            book.Author = book.Author.ToUpper();
            book.Title = book.Title.ToUpper();
            return book;
        }

        /// <summary>
        /// This method makes all letters undercase in Author and Title.
        /// </summary>
        /// <param name="book">Instance of Book class.</param>
        /// <returns>Formatted book.</returns>
        public static Book LowerAuthorAndTitle(this Book book)
        {
            book.Author = book.Author.ToLower();
            book.Title = book.Title.ToLower();
            return book;
        }
    }
}

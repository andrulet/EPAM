using System;
using System.Collections.Generic;

namespace Book_Storage
{
    internal class SortAscendingYear : IComparer<Book>
    {
        /// <summary>
        /// This method sorts 2 books by title length.
        /// </summary>
        /// <param name="x">First book.</param>
        /// <param name="y">Second book.</param> 
        /// <returns>1 if x more then y, and -1 otherwise, 0 if fields are equal</returns>
        int IComparer<Book>.Compare(Book x, Book y)
        {
            if (x == null || y == null)
            {
                throw new ArgumentNullException(nameof(x), nameof(y));
            }

            if (x.Year == y.Year)
            {
                return 0;
            }

            return (x.Year > y.Year) ? 1 : -1;
        }
    }

    /// <summary>
    /// This method sorts 2 books by title length.
    /// </summary>
    /// <param name="x">First book.</param>
    /// <param name="y">Second book.</param> 
    /// <returns>1 if x more then y, and -1 otherwise, 0 if fields are equal</returns>
    internal class SortAscendingTitle : IComparer<Book>
    {
        int IComparer<Book>.Compare(Book x, Book y)
        {
            if (x == null || y == null)
            {
                throw new ArgumentNullException(nameof(x), nameof(y));
            }

            if (x.Title.Length == y.Title.Length)
            {
                return 0;
            }

            return (x.Title.Length > y.Title.Length) ? 1 : -1;
        }
    }

    /// <summary>
    /// This method sorts 2 books by author length.
    /// </summary>
    /// <param name="x">First book.</param>
    /// <param name="y">Second book.</param> 
    /// <returns>1 if x more then y, and -1 otherwise, 0 if fields are equal</returns>
    internal class SortAscendingAuthor : IComparer<Book>
    {
        int IComparer<Book>.Compare(Book x, Book y)
        {
            if (x == null || y == null)
            {
                throw new ArgumentNullException(nameof(x), nameof(y));
            }

            if (x.Author.Length == y.Author.Length)
            {
                return 0;
            }

            return (x.Author.Length > y.Author.Length) ? 1 : -1;
        }
    }

    /// <summary>
    /// This method sorts 2 books by number of pages.
    /// </summary>
    /// <param name="x">First book.</param>
    /// <param name="y">Second book.</param> 
    /// <returns>1 if x more then y, and -1 otherwise, 0 if fields are equal</returns>
    internal class SortAscendingNumberOfPages : IComparer<Book>
    {
        int IComparer<Book>.Compare(Book x, Book y)
        {
            if (x == null || y == null)
            {
                throw new ArgumentNullException(nameof(x), nameof(y));
            }

            if (x.NumberOfPages == y.NumberOfPages)
            {
                return 0;
            }

            return (x.NumberOfPages > y.NumberOfPages) ? 1 : -1;
        }
    }

    internal class SortDescendingYear : IComparer<Book>
    {
        /// <summary>
        /// This method sorts 2 books by year.
        /// </summary>
        /// <param name="x">First book.</param>
        /// <param name="y">Second book.</param> 
        /// <returns>1 if y more then x, and -1 otherwise, 0 if fields are equal</returns>
        int IComparer<Book>.Compare(Book x, Book y)
        {
            if (x == null || y == null)
            {
                throw new ArgumentNullException(nameof(x), nameof(y));
            }

            if (x.Year == y.Year)
            {
                return 0;
            }

            return (x.Year < y.Year) ? 1 : -1;
        }
    }

    /// <summary>
    /// This method sorts 2 books by title length.
    /// </summary>
    /// <param name="x">First book.</param>
    /// <param name="y">Second book.</param> 
    /// <returns>1 if y more then x, and -1 otherwise, 0 if fields are equal</returns>
    internal class SortDescendingTitle : IComparer<Book>
    {
        int IComparer<Book>.Compare(Book x, Book y)
        {
            if (x == null || y == null)
            {
                throw new ArgumentNullException(nameof(x), nameof(y));
            }

            if (x.Title.Length == y.Title.Length)
            {
                return 0;
            }

            return (x.Title.Length < y.Title.Length) ? 1 : -1;
        }
    }

    internal class SortDescendingAuthor : IComparer<Book>
    {
        /// <summary>
        /// This method sorts 2 books by author length.
        /// </summary>
        /// <param name="x">First book.</param>
        /// <param name="y">Second book.</param> 
        /// <returns>1 if y more then x, and -1 otherwise, 0 if fields are equal</returns>
        int IComparer<Book>.Compare(Book x, Book y)
        {
            if (x == null || y == null)
            {
                throw new ArgumentNullException(nameof(x), nameof(y));
            }

            if (x.Author.Length == y.Author.Length)
            {
                return 0;
            }

            return (x.Author.Length < y.Author.Length) ? 1 : -1;
        }
    }

    internal class SortDescendingNumberOfPages : IComparer<Book>
    {
        /// <summary>
        /// This method sorts 2 books by number of pages.
        /// </summary>
        /// <param name="x">First book.</param>
        /// <param name="y">Second book.</param> 
        /// <returns>1 if y more then x, and -1 otherwise, 0 if fields are equal</returns>
        int IComparer<Book>.Compare(Book x, Book y)
        {
            if (x == null || y == null)
            {
                throw new ArgumentNullException(nameof(x), nameof(y));
            }

            if (x.NumberOfPages == y.NumberOfPages)
            {
                return 0;
            }

            return (x.NumberOfPages > y.NumberOfPages) ? 1 : -1;
        }
    }
}

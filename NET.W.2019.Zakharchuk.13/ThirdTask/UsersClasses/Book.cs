using System;
using System.Collections;
using System.Collections.Generic;

namespace Third_Task.UsersClasses
{
    /// <summary>
    /// Class describing Book model.
    /// </summary>
    public class Book : IComparable<Book>, IEquatable<Book>
    {
        /// <summary>
        /// Initializes new instance of <see cref="Point<T>"/> with specified <paramref name="name"/> and <paramref name="page"/>.
        /// </summary>
        /// <param name="name">Name of book.</param>
        /// <param name="y">Count of pages.</param>
        public Book(string name, int pages)
        {
            Name = name;
            Pages = pages;
        }

        /// <summary>
        /// Property Name of book.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Property Pages of book.
        /// </summary>
        public int Pages { get; set; }

        /// <summary>
        /// Interface Realization IComparable<Book>.
        /// </summary>
        public int CompareTo(Book other)
        {
            return this.Pages - other.Pages;
        }

        /// <summary>
        /// Interface Realization IEquatable<Book>.
        /// </summary>
        public bool Equals(Book other)
        {
            return this.Name == other.Name && this.Pages == other.Pages ? true : false;
        }        
    }
}

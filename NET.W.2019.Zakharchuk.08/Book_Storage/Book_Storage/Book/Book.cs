using System;
using System.Text.RegularExpressions;

namespace Book_Storage
{
    public class Book : IComparable, IComparable<Book>, IEquatable<Book>
    {
        /// <summary>
        /// International Standard Book Number.
        /// </summary>
        private string _isbn;

        /// <summary>
        /// Author of book.
        /// </summary>
        private string _author;

        /// <summary>
        /// Title of book.
        /// </summary>
        private string _title;

        /// <summary>
        /// Publisher by book.
        /// </summary>
        private string _publisher;

        /// <summary>
        /// Year .
        /// </summary>
        private int _year;

        /// <summary>
        /// NumberOfPages.
        /// </summary>
        private int _numberOfPages;

        /// <summary>
        /// Price.
        /// </summary>
        private decimal _price;

        /// <summary>
        /// Constructor Book.
        /// </summary>
        public Book(string isbn, string author, string title, string publisher, int year, int numberOfPages, decimal price)
        {
            Isbn = isbn;
            Author = author;
            Title = title;
            Publisher = publisher;
            Year = year;
            NumberOfPages = numberOfPages;
            Price = price;
        }

        /// <summary>
        /// Property for International Standard Book Number field.
        /// </summary>
        public string Isbn
        {
            get
            {
                return _isbn;
            }

            internal set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"Invalid {nameof(value)}");
                }

                Regex regex = new Regex("(ISBN[-]*(1[03])*[ ]*(: ){0,1})*(([0-9Xx][- ]*){13}|([0-9Xx][- ]*){10})");

                if (!regex.IsMatch(value))
                {
                    throw new ArgumentException($"Invalid { nameof(value) }");
                }

                _isbn = value;
            } 
        }

        /// <summary>
        /// Property for Author.
        /// </summary>
        public string Author
        {
            get
            {
                return _author;
            }

            internal set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"Invalid { nameof(value) }");
                }

                _author = value;
            }
        }

        /// <summary>
        /// Property for Author.
        /// </summary>
        public string Title
        {
            get
            {
                return _title;
            }

            internal set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"Invalid { nameof(value) }");
                }

                _title = value;
            }
        }

        /// <summary>
        /// Property for Publisher.
        /// </summary>
        public string Publisher
        {
            get
            {
                return _publisher;
            }

            internal set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"Invalid { nameof(value) }");
                }

                _publisher = value;
            }
        }

        /// <summary>
        /// Property for Year.
        /// </summary>
        public int Year
        {
            get
            {
                return _year;
            }

            internal set
            {
                if (value < 0 || value > DateTime.Now.Year)
                {
                    throw new ArgumentException($"Invalid { nameof(value) }");
                }

                _year = value;
            }
        }

        /// <summary>
        /// Property for NumberOfPages.
        /// </summary>
        public int NumberOfPages
        {
            get
            {
                return _numberOfPages;
            }

            internal set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"Invalid { nameof(value) }");
                }

                _numberOfPages = value;
            }
        }

        /// <summary>
        /// Property for Price.
        /// </summary>
        public decimal Price
        {
            get
            {
                return _price;
            }

            internal set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"Invalid { nameof(value) }");
                }

                _price = value;
            }
        }        

        /// <summary>
        /// override ToString() method.
        /// </summary>
        /// <returns>String representation.</returns>
        public override string ToString()
        {
            return $"ISDN = {Isbn}, Author = {Author}, Title = {Title}, Publisher = {Publisher}, " +
                $"Year = {Year}, NumberOfPages = {NumberOfPages}, Price = {Price}.";
        }

        /// <summary>
        /// override Equals() methods.
        /// </summary>
        /// <returns>Hash code with International Standard Book Number, Year, NumberOfPages, Price divided by 4</returns>
        public override int GetHashCode()
        {
            return (Isbn.GetHashCode() + Year.GetHashCode() + NumberOfPages.GetHashCode() + Price.GetHashCode()) / 4;
        }

        /// <summary>
        /// override Equals() methods.
        /// </summary>
        /// <param name="obj">object to compare</param>
        /// <returns>True if objects are equivalent, false otherwise</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (obj.GetType() == GetType())
            {
                Book book = obj as Book;
                return this.Equals(book);
            }

            return false;
        }

        /// <summary>
        /// IComparable CompareTo
        /// </summary>
        /// <param name="obj">object to compare</param>
        /// <returns>1 if object more then this, and -1 otherwise</returns>
        public int CompareTo(object obj)
        {
            if (ReferenceEquals(obj, null))
            {
                return 1;
            }

            return obj.GetType() != GetType() ? 1 : CompareTo((Book)obj);
        }

        /// <summary>
        /// IComparable(Book) CompareTo
        /// </summary>
        /// <param name="other">object to compare</param>
        /// <returns>1 if other more then this, and -1 otherwise</returns>
        public int CompareTo(Book other)
        {
            if (ReferenceEquals(this, other))
            {
                return 0;
            }

            return ReferenceEquals(other, null) ? 1 : string.Compare(this.Author, other.Author, StringComparison.CurrentCulture);
        }

        /// <summary>
        /// Interface realization
        /// </summary>
        /// <param name="other">object to compare</param>
        /// <returns>true if other and this equals.</returns>
        public bool Equals(Book other)
        {
            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (ReferenceEquals(null, other))
            {
                return false;
            }

            return other.Isbn == this.Isbn;
        }
    }
}

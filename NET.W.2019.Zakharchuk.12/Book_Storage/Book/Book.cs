using System;
using System.Text.RegularExpressions;

namespace Book_Storage
{
    /// <summary>
    /// Book model.
    /// </summary>
    public class Book : IComparable, IComparable<Book>, IEquatable<Book>
    {
        /// <summary>
        /// International Standard Book Number.
        /// </summary>
        private string isbn;

        /// <summary>
        /// Author of book.
        /// </summary>
        private string author;

        /// <summary>
        /// Title of book.
        /// </summary>
        private string title;

        /// <summary>
        /// Publisher by book.
        /// </summary>
        private string publisher;

        /// <summary>
        /// Year in that book was published.
        /// </summary>
        private int year;

        /// <summary>
        /// Number of pages.
        /// </summary>
        private int numberOfPages;

        /// <summary>
        /// Book price.
        /// </summary>
        private decimal price;

        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class. Constructor Book.
        /// </summary>
        /// <param name="isbn">ISBN of book.</param>
        /// <param name="author">Author of book.</param>
        /// <param name="title">Title of book.</param>
        /// <param name="publisher">Publisher of book.</param>
        /// <param name="year">Publishing year.</param>
        /// <param name="numberOfPages">Number of pages of book.</param>
        /// <param name="price">Price of book.</param>
        public Book(string isbn, string author, string title, string publisher, int year, int numberOfPages, decimal price)
        {
            this.Isbn = isbn;
            this.Author = author;
            this.Title = title;
            this.Publisher = publisher;
            this.Year = year;
            this.NumberOfPages = numberOfPages;
            this.Price = price;
        }

        /// <summary>
        ///  Gets International Standard Book Number(ISBN) field.
        /// </summary>
        /// <value>ISBN of book.</value>
        public string Isbn
        {
            get
            {
                return this.isbn;
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

                this.isbn = value;
            } 
        }

        /// <summary>
        ///  Gets author field.
        /// </summary>
        /// <value>Author of book.</value>
        public string Author
        {
            get
            {
                return this.author;
            }

            internal set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"Invalid { nameof(value) }");
                }

                this.author = value;
            }
        }

        /// <summary>
        ///  Gets title field.
        /// </summary>
        /// <value>Title of book.</value>
        public string Title
        {
            get
            {
                return this.title;
            }

            internal set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"Invalid { nameof(value) }");
                }

                this.title = value;
            }
        }

        /// <summary>
        ///  Gets publisher field.
        /// </summary>
        /// <value>Publisher of book.</value>
        public string Publisher
        {
            get
            {
                return this.publisher;
            }

            internal set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"Invalid { nameof(value) }");
                }

                this.publisher = value;
            }
        }

        /// <summary>
        ///  Gets year field.
        /// </summary>
        /// <value>Publishing year of book.</value>
        public int Year
        {
            get
            {
                return this.year;
            }

            internal set
            {
                if (value < 0 || value > DateTime.Now.Year)
                {
                    throw new ArgumentException($"Invalid { nameof(value) }");
                }

                this.year = value;
            }
        }

        /// <summary>
        ///  Gets number of pages field.
        /// </summary>
        /// <value>Number of book's pages.</value>
        public int NumberOfPages
        {
            get
            {
                return this.numberOfPages;
            }

            internal set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"Invalid { nameof(value) }");
                }

                this.numberOfPages = value;
            }
        }

        /// <summary>
        ///  Gets price field.
        /// </summary>
        /// <value>Price of book.</value>
        public decimal Price
        {
            get
            {
                return this.price;
            }

            internal set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"Invalid { nameof(value) }");
                }

                this.price = value;
            }
        }        

        /// <summary>
        /// Override ToString() method.
        /// </summary>
        /// <returns>String representation.</returns>
        public override string ToString()
        {
            return $"ISDN - {Isbn}, Author - {Author}, Title - {Title}, Publisher - {Publisher}, " +
                $"Year - {Year}, NumberOfPages - {NumberOfPages}, Price - {Price}.";
        }

        /// <summary>
        /// Override GetHashCode() methods.
        /// </summary>
        /// <returns>Hash code with International Standard Book Number, Year, NumberOfPages, Price divided by 4.</returns>
        public override int GetHashCode()
        {
            return (this.Isbn.GetHashCode() + this.Year.GetHashCode() + this.NumberOfPages.GetHashCode() + this.Price.GetHashCode()) / 4;
        }

        /// <summary>
        /// Override Equals() methods.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns>True if objects are equivalent, false otherwise.</returns>
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
        /// IComparable CompareTo.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns>1 if object more then this, and -1 otherwise.</returns>
        public int CompareTo(object obj)
        {
            if (ReferenceEquals(obj, null))
            {
                return 1;
            }

            return obj.GetType() != this.GetType() ? 1 : this.CompareTo((Book)obj);
        }

        /// <summary>
        /// IComparable(Book) CompareTo.
        /// </summary>
        /// <param name="other">Object to compare.</param>
        /// <returns>1 if other more then this, and -1 otherwise.</returns>
        public int CompareTo(Book other)
        {
            if (ReferenceEquals(this, other))
            {
                return 0;
            }

            return ReferenceEquals(other, null) ? 1 : string.Compare(this.Author, other.Author);
        }

        /// <summary>
        /// Interface realization.
        /// </summary>
        /// <param name="other">Object to compare.</param>
        /// <returns>True if other and this equals.</returns>
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

        /// <summary>
        /// This method implements the possibility of a string representation of various types.
        /// </summary>
        /// <param name="format">Format in which you need to see information about the book.</param>
        /// <returns>String representation.</returns>
        public string ToString(string format)
        {
            if (string.IsNullOrEmpty(format))
            {
                format = "AT";
            }

            switch (format.ToUpper())
            {
                case "AT":
                    return $"Author - {this.Author}, Title - {this.Title}";
                case "ATP":
                    return $"Author - {this.Author}, Title - {this.Title}, Publisher - {this.Publisher}";
                case "ATPY":
                    return $"Author - {this.Author}, Title - {this.Title}, Publisher - {this.Publisher}, Year - {this.Year}";
                case "IATPY":
                    return $"ISDN - {this.Isbn}, Author - {this.Author}, Title - {this.Title}, Publisher - {this.Publisher}, Year - {this.Year}";
                case "IATPYPR":
                    return $"ISDN - {this.Isbn}, Author - {this.Author}, Title - {this.Title}, Publisher - {this.Publisher}, Year - {this.Year}, Price - {this.Price}";
                case "IATPYNPR":
                    return $"ISDN - {this.Isbn}, Author - {this.Author}, Title - {this.Title}, Publisher - {this.Publisher}, Year - {this.Year}, Number of pagws - {this.Price} Price - {this.Price} rub.";
                    default: throw new FormatException(string.Format($"The {format} format string is not supported."));
            }
        }        
    }
}

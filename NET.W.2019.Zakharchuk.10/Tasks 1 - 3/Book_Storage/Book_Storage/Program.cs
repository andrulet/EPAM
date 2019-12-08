using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Storage
{
    class Program
    {
        static void Main(string[] args)
        {

            Book book1 = new Book("978-5-4461-1102-2", "Джеффри Рихтер", "CLR via C#. Программирование на платформе Microsoft .NET Framework 4.5 на языке C#", "ACT", 770, 2019, 57.45M).LowerAuthorAndTitle();
            Book book2 = new Book("978-5-17-088465-0", "Ирина Орлова, Анастасия Петрова","Самый лучший самоучитель", "ACT", 736, 2017, 15.42M);
            Book book3 = new Book("978-5-4461-1102-4", "Джеффри Рихтер", "CLR via C#. Программирование на платформе Microsoft .NET Framework 4.5 на языке C#", "ACT", 656, 2018, 60M);
            Book book4 = new Book("978-5-4461-1102-5", "Джеффри Рихтер", "CLR via C#.", "ACT", 45, 2018, 34M);
            List<Book> books = new List<Book> { book1, book2, book3, book4};
            foreach(Book b in books)
            {
                Console.WriteLine(b);
            }
            Console.WriteLine("------------------------------------------------------------------------------------");
            Book book5 = new Book("978-5-9909446-1-9", "Б. Албахари, Дж. Албахари", "C# 7.0. Карманный справочник", "Вильямс", 224, 2017, 37.04M);
            BookListService service = new BookListService(books, new BookListStorage());
            service.AddBook(book5);
            service.SortBookByTag(new SortDescendingAuthor());
            service.SaveToStorage();
            service.Show();
            service.SortBookByTag(new SortAscendingTitle());
            Console.WriteLine("------------------------------------------------------------------------------------");
            List<Book> books2 = service.FindBookByTag(new TitlePredicate("C# 7.0. Карманный справочник"));
            foreach(Book b in books2)
            {
                Console.WriteLine(b);
            }
            Console.WriteLine("------------------------------------------------------------------------------------");
            service.LoadFromStorage();
            service.Show();
            Console.WriteLine("------------------------------------------------------------------------------------");
            foreach (Book b in service.FindBookByTag(new TitlePredicate("CLR via C#. Программирование на платформе Microsoft .NET Framework 4.5 на языке C#")))
            {
                Console.WriteLine(b.ToString("IATPYNPR"));
                //Console.WriteLine(b.ToString(null));
                //Console.WriteLine(b.ToString("IaTpY"));
            };


            Console.ReadLine();
        }
    }
}

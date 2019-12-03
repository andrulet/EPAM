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

            Book book1 = new Book("978-5-4461-1102-2", "Джеффри Рихтер", "CLR via C#. Программирование на платформе Microsoft .NET Framework 4.5 на языке C#", "ACT", 770, 2019, 57.45M);
            Book book2 = new Book("978-5-4461-1102-3", "Джеффри Рихтер", "CLR via C#. Программирование на платформе Microsoft .NET Framework 4.5 на языке C#", "ACT", 896, 2018, 60M);            
            List<Book> books = new List<Book> { book1, book2 };
            foreach(Book b in books)
            {
                Console.WriteLine(b);
            }
            Console.WriteLine("------------------------------------------------------------------------------------");
            Book book3 = new Book("978-5-9909446-1-9", "Б. Албахари, Дж. Албахари", "C# 7.0. Карманный справочник", "Вильямс", 224, 2017, 37.04M);
            BookListService service = new BookListService(books, new BookListStorage());
            service.AddBook(book3);
            service.SortBookByTag(new SortDescendingAuthor());
            service.SaveToStorage();
            service.Show();
            service.SortBookByTag(new SortAscendingTitle());            
            Console.WriteLine("------------------------------------------------------------------------------------");
            service.LoadFromStorage();
            service.Show();
            Console.WriteLine("------------------------------------------------------------------------------------");
            foreach (Book b in service.FindBookByTag(new TitlePredicate("CLR via C#. Программирование на платформе Microsoft .NET Framework 4.5 на языке C#")))
            {
                Console.WriteLine(b);
            };


            Console.ReadLine();
        }
    }
}

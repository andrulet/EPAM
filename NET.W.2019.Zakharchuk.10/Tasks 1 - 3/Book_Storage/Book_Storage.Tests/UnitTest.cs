using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Book_Storage.Tests
{
    [TestClass]
    public class UnitTest
    {

        Book book = new Book("978-5-4461-1102-2", "Джеффри Рихтер", "CLR via C#. Программирование на платформе Microsoft .NET Framework 4.5 на языке C#", "ACT", 2019, 770, 57.45M);
        Book book2 = new Book("978-5-4461-1102-2", "Джеффри Рихтер", "CLR via C#. Программирование на платформе Microsoft .NET Framework 4.5 на языке C#", "ACT", 2019, 770, 57.45M).UpperAuthorAndTitle();
        Book book3 = new Book("978-5-4461-1102-2", "Джеффри Рихтер", "CLR via C#. Программирование на платформе Microsoft .NET Framework 4.5 на языке C#", "ACT", 2019, 770, 57.45M).LowerAuthorAndTitle();
        public void CheckOnNull()
        {
            Assert.AreEqual(book.ToString(null), "Author - Джеффри Рихтер, Title - CLR via C#. Программирование на платформе Microsoft .NET Framework 4.5 на языке C#");
        }
        [TestMethod]
        public void CheckOnEmpty()
        {
            Assert.AreEqual(book.ToString(string.Empty), "Author - Джеффри Рихтер, Title - CLR via C#. Программирование на платформе Microsoft .NET Framework 4.5 на языке C#");
        }
        [TestMethod]
        public void CheckOnAT()
        {
            Assert.AreEqual(book.ToString("at"), "Author - Джеффри Рихтер, Title - CLR via C#. Программирование на платформе Microsoft .NET Framework 4.5 на языке C#");
        }
        [TestMethod]
        public void CheckOnATP()
        {
            Assert.AreEqual(book.ToString("atP"), "Author - Джеффри Рихтер, Title - CLR via C#. Программирование на платформе Microsoft .NET Framework 4.5 на языке C#, Publisher - ACT");
        }
        [TestMethod]
        public void CheckOnATPY()
        {
            Assert.AreEqual(book.ToString("ATPY"), "Author - Джеффри Рихтер, Title - CLR via C#. Программирование на платформе Microsoft .NET Framework 4.5 на языке C#, Publisher - ACT, Year - 2019");
        }

        [TestMethod]
        public void CheckOnATPY_Plus_UppercaseAuthorAndTitle()
        {
            Assert.AreEqual(book2.ToString("ATPY"), "Author - ДЖЕФФРИ РИХТЕР, Title - CLR VIA C#. ПРОГРАММИРОВАНИЕ НА ПЛАТФОРМЕ MICROSOFT .NET FRAMEWORK 4.5 НА ЯЗЫКЕ C#, Publisher - ACT, Year - 2019");
        }

        [TestMethod]
        public void CheckOnIATPYNPR_Plus_UndercaseAuthorAndTitle()
        {
            Assert.AreEqual(book3.ToString("iAtPyNPr"), "ISDN - 978-5-4461-1102-2, Author - джеффри рихтер, Title - clr via c#. программирование на платформе microsoft .net framework 4.5 на языке c#, Publisher - ACT, Year - 2019, Number of pagws - 57.45 Price - 57.45 rub.");
        }

    }
}

using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Third_Task;
using Third_Task.UsersClasses;

namespace ThirdTask.Tests
{
    [TestClass]
    public class Tests
    {
        public sealed class PointComparer : IComparer<Point>
        {
            public int Compare(Point x, Point y) => x.X + x.Y - y.X + y.Y;
        }

        public sealed class BookComparer : IComparer<Book>
        {
            public int Compare(Book x, Book y) => y.Pages - x.Pages;
        }
        public sealed class IntComparer : IComparer<int>
        {
            public int Compare(int x, int y) => x - y*y;
        }

        public sealed class StringComparer : IComparer<string>
        {
            public int Compare(string x, string y) => x.Length - y.Length;
        }


        [TestMethod]
        public void IntDefaultCompare()
        {
            int[] arr = new int[] { 100, 88, 75, 91, 90, 99, 103, 105 };
            int[] expected = new int[] { 75, 88, 90, 91, 99, 100, 103, 105 };
            BinarySearchTree<int> list = new BinarySearchTree<int>(arr);
            int i = 0;
            foreach(int x in list.Inorder())
            {
                arr[i++] = x;
            }
            Assert.IsTrue(arr.EqualsArr(expected));
        }
        [TestMethod]
        public void IntCastomCompare()
        {
            
            int[] arr = new int[] { 100, 88, 75, 91, 90, 99, 103, 105 };
            int[] expected = new int[] { 105, 103, 99, 90, 91, 75, 88, 100 };
            BinarySearchTree<int> list = new BinarySearchTree<int>(arr, new IntComparer());
            int i = 0;
            foreach (int x in list.Inorder())
            {
                arr[i++] = x;
            }
            Assert.IsTrue(arr.EqualsArr(expected));
        }

        [TestMethod]
        public void StringDefaultCompare()
        {

            string[] s = new string[] { "One", "three", "four", "eleven" };
            string[] sExpected = new string[] { "eleven", "four", "One", "three" };
            BinarySearchTree<string> list = new BinarySearchTree<string>(s);
            int i = 0;
            foreach (string x in list)
            {
                s[i++] = x;
            }
            Assert.IsTrue(s.EqualsArr(sExpected));
        }

        [TestMethod]
        public void StringCastomCompare()
        {

            string[] s = new string[] { "One", "three", "four", "eleven" };
            string[] sExpected = new string[] { "One", "four", "three", "eleven" };
            BinarySearchTree<string> list = new BinarySearchTree<string>(s, new StringComparer());
            int i = 0;
            foreach (string x in list)
            {
                s[i++] = x;
            }
            Assert.IsTrue(s.EqualsArr(sExpected));
        }

        [TestMethod]
        public void BookDefaultCompare()
        {            
            List<Book> books = new List<Book>
            {
                new Book("ABC",100),
                new Book("ABCD",1000),
                new Book("ABCeW",800),
            };
            List<Book> bookExpected = new List<Book> {
                new Book("ABC",100),
                new Book("ABCeW",800),
                new Book("ABCD",1000),
            };
            BinarySearchTree<Book> list = new BinarySearchTree<Book>(books);
            books.Clear();            
            foreach (Book x in list)
            {
                books.Add(x);
            }
            Assert.IsTrue(books.EqualsBookList(bookExpected));
        }

        [TestMethod]
        public void BookCastomtCompare()
        {
            List<Book> books = new List<Book>
            {
                new Book("ABC",100),
                new Book("ABCD",1000),
                new Book("ABCeW",800),
            };
            List<Book> bookExpected = new List<Book> {
                new Book("ABCD",1000),
                new Book("ABCeW",800),
                new Book("ABC",100),
            };
            BinarySearchTree<Book> list = new BinarySearchTree<Book>(books, new BookComparer());
            books.Clear();
            foreach (Book x in list)
            {
                books.Add(x);
            }
            Assert.IsTrue(books.EqualsBookList(bookExpected));
        }

        [TestMethod]
        public void PointCastomtCompare()
        {
            List<Point> points = new List<Point>
            {
                new Point(3, 10),
                new Point(4, 5),
                new Point(85, 8),
                new Point(4, 4),
                new Point(6, 7),                
            };
            List<Point> pointsExpected = new List<Point>{
                new Point(3, 10),
                new Point(4, 5),
                new Point(4, 4),
                new Point(6, 7),              
                new Point(85, 8)
            };
            BinarySearchTree<Point> list = new BinarySearchTree<Point>(points, new PointComparer());
            List<Point> points2 = new List<Point>();
            foreach (Point x in list)
            {
                points2.Add(x);
            }
            Assert.IsTrue(points2.EqualsPointList(pointsExpected));
        }
    }

    public static class Extension
    {
        public static bool EqualsArr(this int[] x, int[] y)
        {
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] != y[i])
                {
                    return false;
                }
            }
            return true;
        }
        public static bool EqualsArr(this string[] x, string[] y)
        {
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] != y[i])
                {
                    return false;
                }
            }
            return true;
        }

        public static bool EqualsBookList(this List<Book> first, List<Book> second)
        {            
            for (int i = 0; i < first.Count; i++)
            {
                if (!first[i].Equals(second[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool EqualsPointList(this List<Point> first, List<Point> second)
        {
            for (int i = 0; i < first.Count; i++)
            {
                if (!first[i].Equals(second[i]))
                {
                    return false;
                }
            }
            return true;
        }
    }    
}

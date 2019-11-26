using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JuggedArray.Test
{
    [TestClass]
    public class JuggedArrayTest
    {
        [TestMethod]
        public void SortUpMax_Null_ReturnedArgumentNullException()
        {            
            Assert.ThrowsException<ArgumentNullException>(() => JaggedArray.SortUpMax(null));
        }        

        [TestMethod]
        public void SortUpMax_NullInRow_ReturnedArgumentNullException()
        {
            int[][] checkArray = new int[4][];

            checkArray[0] = new int[] { 1, 3, 5, 7, 9 };
            checkArray[1] = new int[] { 0, 2, 4, 6 };
            checkArray[2] = null;
            checkArray[3] = new int[] { -4, -3, -2, -1, 0, 1, 2, 3, 4 };
            Assert.ThrowsException<ArgumentNullException>(() => JaggedArray.SortUpSum(checkArray));
        }

        [TestMethod]
        public void SortDownMax()
        {
            int[][] checkArray = new int[4][];
            checkArray[0] = new int[] { 1, 3, 5, 7, 9 };
            checkArray[1] = new int[] { 0, 2, 4, 6 };
            checkArray[2] = new int[] { 8, 3 };
            checkArray[3] = new int[] { -4, -3, -2, -1, 0, 1, 2, 3, 4 };
            int[][] resultArray = JaggedArray.SortDownMax(checkArray);
            int[][] exppectedArray = new int[4][];
            exppectedArray[0] = new int[] { 1, 3, 5, 7, 9 };
            exppectedArray[1] = new int[] { 8, 3 };
            exppectedArray[2] = new int[] { 0, 2, 4, 6 };
            exppectedArray[3] = new int[] { -4, -3, -2, -1, 0, 1, 2, 3, 4 };
            Assert.IsTrue(IsTrue(resultArray, exppectedArray));
        }

        [TestMethod]
        public void SortDownMin()
        {
            int[][] checkArray = new int[4][];
            checkArray[0] = new int[] { 1, 3, 5, 7, 9 };
            checkArray[1] = new int[] { 0, 2, 4, 6 };
            checkArray[2] = new int[] { 11, 22 };
            checkArray[3] = new int[] { -4, -3, -2, -1, 0, 1, 2, 3, 4 };
            int[][] resultArray = JaggedArray.SortDownMin(checkArray);
            int[][] exppectedArray = new int[4][];
            exppectedArray[0] = new int[] { 11, 22 };
            exppectedArray[1] = new int[] { 1, 3, 5, 7, 9 };
            exppectedArray[2] = new int[] { 0, 2, 4, 6 };
            exppectedArray[3] = new int[] { -4, -3, -2, -1, 0, 1, 2, 3, 4 };

            Assert.IsTrue(IsTrue(resultArray, exppectedArray));
        }

        [TestMethod]
        public void SortDownSum()
        {
            int[][] checkArray = new int[4][];
            checkArray[0] = new int[] { 1, 3, 5, 7, 9 };
            checkArray[1] = new int[] { 0, 2, 4, 6 };
            checkArray[2] = new int[] { 11, 6 };
            checkArray[3] = new int[] { -4, -3, -2, -1, 0, 1, 2, 3, 4 };
            int[][] resultArray = JaggedArray.SortDownSum(checkArray);
            int[][] exppectedArray = new int[4][];
            exppectedArray[0] = new int[] { 1, 3, 5, 7, 9 };
            exppectedArray[1] = new int[] { 11, 6 };
            exppectedArray[2] = new int[] { 0, 2, 4, 6 };
            exppectedArray[3] = new int[] { -4, -3, -2, -1, 0, 1, 2, 3, 4 };

            Assert.IsTrue(IsTrue(resultArray, exppectedArray));
        }

        [TestMethod]
        public void SortUpMax()
        {
            int[][] checkArray = new int[4][];
            checkArray[0] = new int[] { 1, 3, 5, 7, 9 };
            checkArray[1] = new int[] { 0, 2, 4, 6 };
            checkArray[2] = new int[] { 11, 6 };
            checkArray[3] = new int[] { -4, -3, -2, -1, 0, 1, 2, 3, 4 };
            int[][] resultArray = JaggedArray.SortUpMax(checkArray);
            int[][] exppectedArray = new int[4][];
            exppectedArray[0] = new int[] { -4, -3, -2, -1, 0, 1, 2, 3, 4 };
            exppectedArray[1] = new int[] { 0, 2, 4, 6 };
            exppectedArray[2] = new int[] { 1, 3, 5, 7, 9 };
            exppectedArray[3] = new int[] { 11, 6 };

            Assert.IsTrue(IsTrue(resultArray, exppectedArray));
        }

        [TestMethod]
        public void SortUpMin()
        {
            int[][] checkArray = new int[4][];
            checkArray[0] = new int[] { 3, 1, 5, 7, 9 };
            checkArray[1] = new int[] { -3, 2, 4, 6 };
            checkArray[2] = new int[] { 11, 6 };
            checkArray[3] = new int[] { -4, -3, -2, -1, 0, 1, 2, 3, 4 };
            int[][] resultArray = JaggedArray.SortUpMin(checkArray);
            int[][] exppectedArray = new int[4][];
            exppectedArray[0] = new int[] { -4, -3, -2, -1, 0, 1, 2, 3, 4 };
            exppectedArray[1] = new int[] { -3, 2, 4, 6 };
            exppectedArray[2] = new int[] { 3, 1, 5, 7, 9 };
            exppectedArray[3] = new int[] { 11, 6 };

            Assert.IsTrue(IsTrue(resultArray, exppectedArray));
        }

        [TestMethod]
        public void SortUpSum()
        {
            int[][] checkArray = new int[5][];
            checkArray[0] = new int[] { 3, 1, 5, 7, 9,434 };
            checkArray[1] = new int[] { -3, 2, 4, 6,-1000 };
            checkArray[2] = new int[] { 11, 6 };
            checkArray[3] = new int[] { -4, -3, -2, -1, 105, 1, 2, 3, 4 };
            checkArray[4] = new int[] { -435, -100, -2, -1, 10599, 1, 2, 5434, 4 };
            int[][] resultArray = JaggedArray.SortUpSum(checkArray);
            int[][] exppectedArray = new int[5][];
            exppectedArray[0] = new int[] { -3, 2, 4, 6, -1000 };
            exppectedArray[1] = new int[] { 11, 6 };
            exppectedArray[2] = new int[] { -4, -3, -2, -1, 105, 1, 2, 3, 4 };
            exppectedArray[3] = new int[] { 3, 1, 5, 7, 9, 434 };
            exppectedArray[4] = new int[] { -435, -100, -2, -1, 10599, 1, 2, 5434, 4 };

            Assert.IsTrue(IsTrue(resultArray, exppectedArray));
        }

        public static bool IsTrue(int[][] arr, int[][] arrExpected)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                for(int j = 0; j < arr[i].Length; j++)
                {
                    if (arr[i][j] != arrExpected[i][j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}

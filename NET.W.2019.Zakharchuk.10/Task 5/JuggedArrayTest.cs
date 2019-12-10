using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JuggedArray.Test
{
    [TestClass]
    public class JuggedArrayTest
    {
        private static int[][] checkArray1 = new int[4][]
            {
            new int[] { 1, 3, 5, 7, 9 },
            new int[] { 0, 2, 4, 6 },
            new int[] { 8, 3 },
            new int[] { -4, -3, -2, -1, 0, 1, 2, 3, 4 }
            };
        private static int[][] checkArray2 = new int[4][]
            {
            new int[] { 3, 1, 5, 7, 9 },
            new int[] { -3, 2, 4, 6 },
            new int[] { 11, 6 },
            new int[] { -4, -3, -2, -1, 0, 1, 2, 3, 4 }
            };
        private static int[][] checkArray5 = new int[5][]
            {
            new int[] { 3, 1, 5, 7, 9,434 },
            new int[] { -3, 2, 4, 6,-1000 },
            new int[] { 11, 6 },
            new int[] { -4, -3, -2, -1, 105, 1, 2, 3, 4 },
            new int[] { -435, -100, -2, -1, 10599, 1, 2, 5434, 4 }
            };
        
        private int[][] checkArray3 = (int[][])checkArray1.Clone();
        private int[][] checkArray4 = (int[][])checkArray2.Clone();
        private int[][] checkArray6 = (int[][])checkArray5.Clone();



        [TestMethod]
        public void SortUpMax_Null_ReturnedArgumentNullException()
        {            
            Assert.ThrowsException<ArgumentNullException>(() => JaggedArray.SortUpMax(null));
            Assert.ThrowsException<ArgumentNullException>(() => ArraySortDelegate.SortDelegate(null, new SortByMax().Compare, true));
            Assert.ThrowsException<ArgumentNullException>(() => ArraySortInterface.SortInterface(null, new SortByMax(), true));
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
            Assert.ThrowsException<ArgumentNullException>(() => ArraySortDelegate.SortDelegate(checkArray, new SortByMax().Compare, true));
            Assert.ThrowsException<ArgumentNullException>(() => ArraySortInterface.SortInterface(checkArray, new SortByMax(), true));
        }

        [TestMethod]
        public void SortDownMax()
        {            
            int[][] resultArray = JaggedArray.SortDownMax(checkArray1);
            int[][] exppectedArray = new int[4][];
            exppectedArray[0] = new int[] { 1, 3, 5, 7, 9 };
            exppectedArray[1] = new int[] { 8, 3 };
            exppectedArray[2] = new int[] { 0, 2, 4, 6 };
            exppectedArray[3] = new int[] { -4, -3, -2, -1, 0, 1, 2, 3, 4 };
            Assert.IsTrue(IsTrue(resultArray, exppectedArray));
            ArraySortDelegate.SortDelegate(checkArray1, new SortByMax().Compare, true);
            ArraySortInterface.SortInterface(checkArray3, new SortByMax(), true);
            Assert.IsTrue(IsTrue(checkArray1, checkArray3));
            Assert.IsTrue(IsTrue(checkArray3, exppectedArray));
        }

        [TestMethod]
        public void SortDownMin()
        {            
            int[][] resultArray = JaggedArray.SortDownMin(checkArray1);
            int[][] exppectedArray = new int[4][];
            exppectedArray[0] = new int[] { 8, 3 };
            exppectedArray[1] = new int[] { 1, 3, 5, 7, 9 };
            exppectedArray[2] = new int[] { 0, 2, 4, 6 };
            exppectedArray[3] = new int[] { -4, -3, -2, -1, 0, 1, 2, 3, 4 };

            Assert.IsTrue(IsTrue(resultArray, exppectedArray));
            ArraySortDelegate.SortDelegate(checkArray1, new SortByMin().Compare, true);
            ArraySortInterface.SortInterface(checkArray3, new SortByMin(), true);
            Assert.IsTrue(IsTrue(checkArray1, checkArray3));
            Assert.IsTrue(IsTrue(checkArray3, exppectedArray));
        }

        [TestMethod]
        public void SortDownSum()
        {            
            int[][] resultArray = JaggedArray.SortDownSum(checkArray1);
            int[][] exppectedArray = new int[4][];
            exppectedArray[0] = new int[] { 1, 3, 5, 7, 9 };
            exppectedArray[1] = new int[] { 0, 2, 4, 6 };
            exppectedArray[2] = new int[] { 8, 3 };
            exppectedArray[3] = new int[] { -4, -3, -2, -1, 0, 1, 2, 3, 4 };

            Assert.IsTrue(IsTrue(resultArray, exppectedArray));
            ArraySortDelegate.SortDelegate(checkArray1, new SortBySum().Compare, true);
            ArraySortInterface.SortInterface(checkArray3, new SortBySum(), true);
            Assert.IsTrue(IsTrue(checkArray1, checkArray3));
            Assert.IsTrue(IsTrue(checkArray3, exppectedArray));
        }

        [TestMethod]
        public void SortUpMax()
        {                        
            int[][] resultArray = JaggedArray.SortUpMax(checkArray1);
            int[][] exppectedArray = new int[4][];
            exppectedArray[0] = new int[] { -4, -3, -2, -1, 0, 1, 2, 3, 4 };
            exppectedArray[1] = new int[] { 0, 2, 4, 6 };
            exppectedArray[2] = new int[] { 8, 3 };
            exppectedArray[3] = new int[] { 1, 3, 5, 7, 9 };

            Assert.IsTrue(IsTrue(resultArray, exppectedArray));
            ArraySortDelegate.SortDelegate(checkArray1, new SortByMax().Compare, false);
            ArraySortInterface.SortInterface(checkArray3, new SortByMax(), false);
            Assert.IsTrue(IsTrue(checkArray1, checkArray3));
            Assert.IsTrue(IsTrue(checkArray3, exppectedArray));
        }

        [TestMethod]
        public void SortUpMin()
        {            
            int[][] resultArray = JaggedArray.SortUpMin(checkArray2);
            int[][] exppectedArray = new int[4][];
            exppectedArray[0] = new int[] { -4, -3, -2, -1, 0, 1, 2, 3, 4 };
            exppectedArray[1] = new int[] { -3, 2, 4, 6 };
            exppectedArray[2] = new int[] { 3, 1, 5, 7, 9 };
            exppectedArray[3] = new int[] { 11, 6 };

            Assert.IsTrue(IsTrue(resultArray, exppectedArray));
            ArraySortDelegate.SortDelegate(checkArray2, new SortByMin().Compare, false);
            ArraySortInterface.SortInterface(checkArray4, new SortByMax(), false);
            Assert.IsTrue(IsTrue(checkArray2, checkArray4));
            Assert.IsTrue(IsTrue(checkArray4, exppectedArray));
        }

        [TestMethod]
        public void SortUpSum()
        {            
            int[][] resultArray = JaggedArray.SortUpSum(checkArray5);
            int[][] exppectedArray = new int[5][];
            exppectedArray[0] = new int[] { -3, 2, 4, 6, -1000 };
            exppectedArray[1] = new int[] { 11, 6 };
            exppectedArray[2] = new int[] { -4, -3, -2, -1, 105, 1, 2, 3, 4 };
            exppectedArray[3] = new int[] { 3, 1, 5, 7, 9, 434 };
            exppectedArray[4] = new int[] { -435, -100, -2, -1, 10599, 1, 2, 5434, 4 };

            Assert.IsTrue(IsTrue(resultArray, exppectedArray));
            ArraySortDelegate.SortDelegate(checkArray5, new SortBySum().Compare, false);
            ArraySortInterface.SortInterface(checkArray6, new SortBySum(), false);
            Assert.IsTrue(IsTrue(checkArray5, checkArray6));
            Assert.IsTrue(IsTrue(checkArray6, exppectedArray));
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

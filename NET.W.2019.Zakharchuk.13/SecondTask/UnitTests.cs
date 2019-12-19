using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SecondTask.Tests
{
    [TestClass]
    public class UnitTests
    {
        Person person = new Person("Andrei");       
                  
        int[][] dm ={
                            new int[] {1,0,0,0}, new int[] {0,1,0,0}, new int[] {0,0,1,0}, new int[] {0,0,0,1}
                        };
        int[][] simm ={
                            new int[] {1,4,8,6}, new int[] {4,2,7,9}, new int[] {8,7,3,5}, new int[] {6,9,5,4}
                        };
        int[][] sqm ={
                            new int[] {1,4,8,6}, new int[] {4,2,7,9}, new int[] {8,7,3,5}, new int[] {6,9,5,4}
                        };
        int[][] test ={
                            new int[] {1,0,0,0}, new int[] {0,0,1,0}, new int[] {0,0,0,1}
                        };
        int[][] test2 ={
                            new int[] {1,4,8,7}, new int[] {4,2,7,9}, new int[] {8,7,3,5}, new int[] {6,9,5,4}
                        };
        DiagonalMatrix<int> dArr;
        SimmetricMatrix<int> simArr;
        SquareMatrix<int> sqArr;
		
        [TestMethod]
        public void CheckOnNull()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new DiagonalMatrix<int>(null));
            Assert.ThrowsException<ArgumentNullException>(() => new DiagonalMatrix<int>(null));
            Assert.ThrowsException<ArgumentNullException>(() => new DiagonalMatrix<int>(null));
        }

        [TestMethod]
        public void CheckOnValidTypeDiagonalMatrix()
        {
            Assert.ThrowsException<Exception>(() => new DiagonalMatrix<int>(simm));            
        }

        [TestMethod]
        public void CheckOnValidTypeSimmetricMatrix()
        {
            Assert.ThrowsException<Exception>(() => new SimmetricMatrix<int>(test2));
        }

        [TestMethod]
        public void CheckOnValidTypeSquareMatrix()
        {
            Assert.ThrowsException<Exception>(() => new SquareMatrix<int>(test));
        }

        [TestMethod]
        public void ChangeElementInDiagonalMatrix()
        {
            dArr = new DiagonalMatrix<int>(dm);
            dArr.ElementChanged += person.Subscribed;
            dArr.ChangeElement(0, 0, 100);
            Assert.AreEqual(dArr.Array[0][0], 100);
            Assert.AreNotEqual(dArr.Array, dm);
            Assert.AreEqual(person.S, "Element of matrix [0,0] was change. Person Andrei has been notified");            
        }

        [TestMethod]
        public void ChangeElementOnMainDiagonalInSimmetricMatrix()
        {
            simArr = new SimmetricMatrix<int>(simm);
            simArr.ElementChanged += person.Subscribed;
            simArr.ChangeElement(1, 1, 88);
            Assert.AreEqual(simArr.Array[1][1], 88);
            Assert.AreNotEqual(simArr.Array, simm);
            Assert.AreEqual(person.S, "Element of matrix [1,1] was change. Person Andrei has been notified");
        }

        [TestMethod]
        public void ChangeElementsInSimmetricMatrix()
        {
            simArr = new SimmetricMatrix<int>(simm);
            simArr.ElementChanged += person.Subscribed;
            simArr.ChangeElement(1, 2, 108);
            Assert.AreEqual(simArr.Array[1][2], 108);
            Assert.AreNotEqual(simArr.Array, simm);
            Assert.AreEqual(person.S, "Element of matrix [2,1] was change. Person Andrei has been notified");
        }

        [TestMethod]
        public void ChangeElementSquareMatrix()
        {
            sqArr = new SquareMatrix<int>(sqm);
            sqArr.ElementChanged += person.Subscribed;
            sqArr.ChangeElement(3, 3, 21);
            Assert.AreEqual(sqArr.Array[3][3], 21);
            Assert.AreNotEqual(sqArr.Array, sqm);
            Assert.AreEqual(person.S, "Element of matrix [3,3] was change. Person Andrei has been notified");
        }

        [TestMethod]
        public void SumTwoSquareMatrix()
        {
            int[][] result ={
                            new int[] {2,4,8,6}, new int[] {4,3,7,9}, new int[] {8,7,4,5}, new int[] {6,9,5,5}
                        };            
            Assert.IsTrue(((new SquareMatrix<int>(simm).SumWith(new SquareMatrix<int>(dm))).Array.IsEqual(result)));
        }

        [TestMethod]
        public void SumTwoDiagonalMatrix()
        {
            int[][] dm2 ={
                            new int[] {5,0,0,0}, new int[] {0,6,0,0}, new int[] {0,0,7,0}, new int[] {0,0,0,8}
                        };
            int[][] result ={
                            new int[] {6,0,0,0}, new int[] {0,7,0,0}, new int[] {0,0,8,0}, new int[] {0,0,0,9}
                        };
            Assert.IsTrue(((new DiagonalMatrix<int>(dm).SumWith(new DiagonalMatrix<int>(dm2))).Array.IsEqual(result)));
        }
		
        [TestMethod]
        public void SumTwoSimmetricMatrix()
        {
            int[][] simm2 ={
                            new int[] {1,4,8,6}, new int[] {4,2,7,9}, new int[] {8,7,3,5}, new int[] {6,9,5,4}
                        };
            int[][] result ={
                            new int[] {2,8,16,12}, new int[] {8,4,14,18}, new int[] {16,14,6,10}, new int[] {12,18,10,8}
                        };
            Assert.IsTrue(((new SimmetricMatrix<int>(simm).SumWith(new SimmetricMatrix<int>(simm2))).Array.IsEqual(result)));
        }
    }
}

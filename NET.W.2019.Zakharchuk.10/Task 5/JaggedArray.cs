using System;

namespace JuggedArray
{
    /// <summary>
    /// This class describes entity of JaggedArray.
    /// </summary>
    public class JaggedArray
    {
        /// <summary>
        /// This method sorts strings by ascending of added of elements in strings in matrix.
        /// </summary>
        /// <param name="arr">Array that must be sorted.</param>             
        /// <returns> Sorting array.</returns>
        public static int[][] SortUpSum(int[][] arr)
        {
            int[] arrCriteria = GetArraySumInStrings(arr);
            return SortUp(arr, arrCriteria);
        }

        /// <summary>
        /// This method sorts strings by ascending maximum elements in strings in matrix.
        /// </summary>
        /// <param name="arr">Array that must be sorted.</param>             
        /// <returns> Sorting array.</returns>
        public static int[][] SortUpMax(int[][] arr)
        {
            int[] arrCriteria = GetArrayMaxIntInStrings(arr);
            return SortUp(arr, arrCriteria);
        }

        /// <summary>
        /// This method sorts strings by ascending minimum elements in strings in matrix.
        /// </summary>
        /// <param name="arr">Array that must be sorted.</param>             
        /// <returns> Sorting array.</returns>
        public static int[][] SortUpMin(int[][] arr)
        {
            int[] arrCriteria = GetArrayMinIntInStrings(arr);
            return SortUp(arr, arrCriteria);
        }

        /// <summary>
        /// This method sorts strings by descending of added of elements in strings in matrix.
        /// </summary>
        /// <param name="arr">Array that must be sorted.</param>             
        /// <returns> Sorting array.</returns>
        public static int[][] SortDownSum(int[][] arr)
        {
            int[] arrCriteria = GetArraySumInStrings(arr);
            return SortDown(arr, arrCriteria);
        }

        /// <summary>
        /// This method sorts strings by descending of maximum of elements in strings in matrix.
        /// </summary>
        /// <param name="arr">Array that must be sorted.</param>             
        /// <returns> Sorting array.</returns>
        public static int[][] SortDownMax(int[][] arr)
        {
            int[] arrCriteria = GetArrayMaxIntInStrings(arr);
            return SortDown(arr, arrCriteria);
        }

        /// <summary>
        /// This method sorts strings by descending of minimum of elements in strings in matrix.
        /// </summary>
        /// <param name="arr">Array that must be sorted.</param>             
        /// <returns> Sorting array.</returns>
        public static int[][] SortDownMin(int[][] arr)
        {
            int[] arrCriteria = GetArrayMinIntInStrings(arr);
            return SortDown(arr, arrCriteria);
        }

        /// <summary>
        /// This method gets array of sum of elements in strings in matrix.
        /// </summary>
        /// <param name="arr">Two-dimensional array in which you need to find sum of elements in strings of array.</param>             
        /// <returns> Array of sum of elements in strings of matrix.</returns>
        private static int[] GetArraySumInStrings(int[][] arr)
        {
            CheckArgumentOnNull(arr);
            int[] sumElements = new int[arr.Length];
            for (int i = 0; i < sumElements.Length; i++)
            {
                CheckArgumentOnNull(arr[i]);
                sumElements[i] = GetSumElements(arr[i]);
            }

            return sumElements;
        }

        /// <summary>
        /// This method gets array of maximum of elements in strings in matrix.
        /// </summary>
        /// <param name="arr">Two-dimensional array in which you need to find max element in strings of array.</param>             
        /// <returns> Array max elements in strings of matrix.</returns>
        private static int[] GetArrayMaxIntInStrings(int[][] arr)
        {
            CheckArgumentOnNull(arr);
            int[] maxElements = new int[arr.Length];
            for (int i = 0; i < maxElements.Length; i++)
            {
                CheckArgumentOnNull(arr[i]);
                maxElements[i] = GetMaxElements(arr[i]);
            }

            return maxElements;
        }

        /// <summary>
        /// This method gets array of min of elements in strings in matrix.
        /// </summary>
        /// <param name="arr">Two-dimensional array in which you need to find min element in strings of array.</param>             
        /// <returns> Array min elements in strings of matrix.</returns>
        private static int[] GetArrayMinIntInStrings(int[][] arr)
        {
            CheckArgumentOnNull(arr);
            int[] minElements = new int[arr.Length];
            for (int i = 0; i < minElements.Length; i++)
            {
                CheckArgumentOnNull(arr[i]);
                minElements[i] = GetMinElements(arr[i]);
            }

            return minElements;
        }

        /// <summary>
        /// This method sorts a two-dimensional array in ascending order according to the specified array.
        /// </summary>
        /// <param name="arr">Two-dimensional array.</param>
        /// <param name="arrCriteria">Specified array.</param> 
        /// <returns> Sorted a two-dimensional array.</returns>
        private static int[][] SortUp(int[][] arr, int[] arrCriteria)
        {
            int length = arrCriteria.Length;
            for (int i = 0; i <= length - 1; i++)
            {
                int temp;
                int[] tempArr;
                for (int j = i + 1; j < length; j++)
                {
                    if (arrCriteria[i] > arrCriteria[j])
                    {
                        temp = arrCriteria[j];
                        tempArr = arr[j];
                        arrCriteria[j] = arrCriteria[i];
                        arr[j] = arr[i];
                        arrCriteria[i] = temp;
                        arr[i] = tempArr;
                    }
                }
            }

            return arr;
        }

        /// <summary>
        /// This method sorts a two-dimensional array in descending order according to the specified array.
        /// </summary>
        /// <param name="arr">Two-dimensional array.</param>
        /// <param name="arrCriteria">Specified array.</param> 
        /// <returns> Sorted a two-dimensional array.</returns>
        private static int[][] SortDown(int[][] arr, int[] arrCriteria)
        {
            int length = arrCriteria.Length;
            for (int i = length - 1; i >= 0; i--)
            {
                int temp;
                int[] tempArr;
                for (int j = i - 1; j >= 0; j--)
                {
                    if (arrCriteria[i] > arrCriteria[j])
                    {
                        temp = arrCriteria[j];
                        tempArr = arr[j];
                        arrCriteria[j] = arrCriteria[i];
                        arr[j] = arr[i];
                        arrCriteria[i] = temp;
                        arr[i] = tempArr;
                    }
                }
            }

            return arr;
        }

        /// <summary>
        /// This method gets min element from array.
        /// </summary>
        /// <param name="arr">Array of integers.</param>        
        /// <returns> Min element of array.</returns>
        private static int GetMinElements(int[] arr)
        {
            int min = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                min = (arr[i] > min) ? min : arr[i];
            }

            return min;
        }

        /// <summary>
        /// This method gets max element from array.
        /// </summary>
        /// <param name="arr">Array of integers.</param>        
        /// <returns> Max element of array.</returns>
        private static int GetMaxElements(int[] arr)
        {
            int max = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                max = arr[i] > max ? arr[i] : max;
            }

            return max;
        }

        /// <summary>
        /// This method gets sum of array elements.
        /// </summary>
        /// <param name="arr">Array of integers.</param>        
        /// <returns> Sum of array elements.</returns>
        private static int GetSumElements(int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {                
                sum += arr[i];
            }

            return sum;
        }

        /// <summary>
        /// This method checks array on Null.
        /// </summary>
        /// <param name="arr">Array of integers.</param>        
        private static void CheckArgumentOnNull(int[] arr)
        {
            if (arr == null)
            {
                throw new ArgumentNullException();
            }
        }

        /// <summary>
        /// This method checks a two-dimensional array on Null.
        /// </summary>
        /// <param name="arr">Array of integers.</param> 
        private static void CheckArgumentOnNull(int[][] arr)
        {            
            if (arr == null)
            {
                throw new ArgumentNullException();
            }
        }
    }
}

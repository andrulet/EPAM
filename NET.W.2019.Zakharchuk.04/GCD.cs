using System;
using System.Diagnostics;

namespace FindGCD
{
    public class GCD
    {
        /// <summary>
        /// This method calculates GCD using the Euclidean algorithm for random count of numbers.
        /// </summary>
        /// <param name="timeSpend">Time for which the method is executed</param>
        /// <param name="array">Array of integers</param>
        /// <exception cref="ArgumentNullException">If array equals null</exception>
        /// <returnsNumber> GCD</returns>
        public static int GetGcdByEuclideanAlgorithmFromIntegers(out Stopwatch timeSpend, params int[] array)
        {
            timeSpend = new Stopwatch();
            timeSpend.Start();
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            int numberGcd = GetGcdByEuclideanAlgorithmFromIntegers(array);
            timeSpend.Stop();            
            return numberGcd;
        }

        /// <summary>
        /// This method calculates GCD using the Euclidean algorithm for random count of numbers.
        /// </summary>        
        /// <param name="array">Array of integers</param>
        /// <exception cref="ArgumentOutOfRangeException">If number of array more int.MaxValue or less int.MinValue</exception>
        /// <returnsNumber> GCD</returns>
        public static int GetGcdByEuclideanAlgorithmFromIntegers(params int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] <= int.MinValue || array[i + 1] <= int.MinValue || array[i] >= int.MaxValue || array[i + 1] >= int.MaxValue)
                {
                    throw new ArgumentOutOfRangeException();
                }

                if (array[i] == 0)
                {
                    array[i] = array[i + 1];
                    continue;
                }

                if (array[i + 1] == 0)
                {
                    array[i + 1] = array[i];
                    continue;
                }

                if (array[i] <= -1)
                {
                    array[i] = Math.Abs(array[i]);
                }

                if (array[i + 1] <= -1)
                {
                    array[i + 1] = Math.Abs(array[i + 1]);
                }

                while (array[i] != array[i + 1])
                {
                    if (array[i] > array[i + 1])
                    {
                        array[i] -= array[i + 1] + 1;
                    }
                    else
                    {
                        array[i + 1] -= array[i];
                    }
                }
            }

            return array[array.Length - 1];
        }

        /// <summary>
        /// This method calculates GCD using the binary Euclidean algorithm for random count of numbers.
        /// </summary>
        /// <param name="timeSpend">Time for which the method is executed</param>
        /// <param name="array">Array of integers</param>
        /// <exception cref="ArgumentNullException">If array equals null</exception>
        /// <returnsNumber GCD</returns>
        public static int GetGcdByBinaryEuclideanAlgorithmFromIntegers(out Stopwatch timeSpend, params int[] array)
        {
            timeSpend = new Stopwatch();
            timeSpend.Start();
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            int numberGcd = GetGcdByBinaryEuclideanAlgorithmFromIntegers(array);
            timeSpend.Stop();
            return numberGcd;
        }

        /// <summary>
        /// This method calculates GCD using the binary Euclidean algorithm for random count of numbers.
        /// </summary>        
        /// <param name="array">Array of integers</param>
        /// <exception cref="ArgumentOutOfRangeException">If number of array more int.MaxValue or less int.MinValue</exception>
        /// <returnsNumber> GCD</returns>
        public static int GetGcdByBinaryEuclideanAlgorithmFromIntegers(params int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] == int.MinValue || array[i + 1] == int.MinValue)
                {
                    throw new ArgumentOutOfRangeException();
                }

                if (array[i] == array[i + 1])
                {
                    return array[i];
                }

                if (array[i] == array[i + 1])
                {
                    array[i + 1] = array[i];
                }

                if (array[i] == 0)
                {
                    array[i] = array[i + 1];
                    continue;
                }

                if (array[i + 1] == 0)
                {
                    array[i + 1] = array[i];
                    continue;
                }

                if (array[i] <= -1)
                {
                    array[i] = ~array[i] + 1;
                }

                if (array[i + 1] <= -1)
                {
                    array[i + 1] = ~array[i + 1] + 1;
                }

                if (array[i] > 0 && array[i + 1] > 0)
                {
                    if ((array[i] & 1) != 1)
                    {
                        if ((array[i + 1] & 1) != 1)
                        {
                            return GetGcdByBinaryEuclideanAlgorithmFromIntegers(array[i] >> 1, array[i + 1] >> 1) << 1;
                        }
                        else
                        {
                            return GetGcdByBinaryEuclideanAlgorithmFromIntegers(array[i] >> 1, array[i + 1]);
                        }
                    }

                    if ((array[i] & 1) == 1)
                    {
                        if ((array[i + 1] & 1) != 1)
                        {
                            return GetGcdByBinaryEuclideanAlgorithmFromIntegers(array[i], array[i + 1] >> 1);
                        }

                        if ((array[i + 1] & 1) == 1 && array[i + 1] > array[i])
                        {
                            return GetGcdByBinaryEuclideanAlgorithmFromIntegers((array[i + 1] - array[i]) >> 1, array[i]);
                        }

                        if ((array[i + 1] & 1) == 1 && array[i + 1] < array[i])
                        {
                            return GetGcdByBinaryEuclideanAlgorithmFromIntegers((array[i] - array[i + 1]) >> 1, array[i + 1]);
                        }
                    }
                }
            }

            return array[array.Length - 1];
        }
    }
}

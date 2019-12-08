using System;
using System.Diagnostics;

namespace FindGCD
{
    /// <summary>
    /// This delegate indicates the calculation method of GCD.
    /// </summary>
    /// <param name="array">Array of integers.</param>
    /// <returns>GCD integers.</returns>
    public delegate int WayCalculate(params int[] array);

    /// <summary>
    /// This delegate will check the conditions for calculating GCD.
    /// </summary>
    /// <param name="value1">First value</param>
    /// <param name="value2">Second value</param>
    internal delegate void Check(ref int value1, ref int value2);    

    /// <summary>
    /// This static class calculates GSD by two ways.
    /// </summary>
    public static class GCD
    {        
        /// <summary>
        /// This method will check the conditions for calculating GCD.
        /// </summary>
        /// <param name="val1">First value</param>
        /// <param name="val2">Second value</param>
        public static void Verification(ref int val1, ref int val2)
        {
            if (val1 <= int.MinValue || val2 <= int.MinValue || val1 > int.MaxValue || val2 > int.MaxValue)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (val1 == 0)
            {
                val1 = val2;
            }

            if (val2 == 0)
            {
                val2 = val1;
            }

            if (val1 <= -1)
            {
                val1 = Math.Abs(val1);
            }

            if (val2 <= -1)
            {
                val2 = Math.Abs(val2);
            }
        }

        /// <summary>
        /// This method calculates GCD using the Euclidean algorithm for random count of numbers.
        /// </summary>
        /// <param name="timeSpend">Time for which the method is executed.</param>
        /// <param name="way">Delegate WayCalculate.</param>
        /// <param name="array">Array of integers.</param>
        /// <exception cref="ArgumentNullException">If array equals null.</exception>
        /// <returns>GCD with time spend.</returns>
        public static int GetGcdTime(out Stopwatch timeSpend, WayCalculate way, params int[] array)
        {
            timeSpend = new Stopwatch();
            timeSpend.Start();
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            int numberGcd = way(array);
            timeSpend.Stop();            
            return numberGcd;
        }

        /// <summary>
        /// This method calculates GCD using the Euclidean algorithm for random count of numbers.
        /// </summary>        
        /// <param name="array">Array of integers.</param>
        /// <exception cref="ArgumentOutOfRangeException">If number of array more MaxValue or less MinValue.</exception>
        /// <returns>GCD integer.</returns>
        public static int GetGcd(params int[] array)
        {
            Check logic = Verification;
            for (int i = 0; i < array.Length - 1; i++)
            {
                logic(ref array[i], ref array[i + 1]);

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
        /// <param name="array">Array of integers.</param>
        /// <exception cref="ArgumentOutOfRangeException">If number of array more MaxValue or less MinValue.</exception>
        /// <returns>GCD integer.</returns>
        public static int GetGcdByBinary(params int[] array)
        {
            Check logic = Verification;
            for (int i = 0; i < array.Length - 1; i++)
            {
                logic(ref array[i], ref array[i + 1]);

                if (array[i] > 0 && array[i + 1] > 0)
                {
                    if ((array[i] & 1) != 1)
                    {
                        if ((array[i + 1] & 1) != 1)
                        {
                            return GetGcdByBinary(array[i] >> 1, array[i + 1] >> 1) << 1;
                        }
                        else
                        {
                            return GetGcdByBinary(array[i] >> 1, array[i + 1]);
                        }
                    }

                    if ((array[i] & 1) == 1)
                    {
                        if ((array[i + 1] & 1) != 1)
                        {
                            return GetGcdByBinary(array[i], array[i + 1] >> 1);
                        }

                        if ((array[i + 1] & 1) == 1 && array[i + 1] > array[i])
                        {
                            return GetGcdByBinary((array[i + 1] - array[i]) >> 1, array[i]);
                        }

                        if ((array[i + 1] & 1) == 1 && array[i + 1] < array[i])
                        {
                            return GetGcdByBinary((array[i] - array[i + 1]) >> 1, array[i + 1]);
                        }
                    }
                }
            }

            return array[array.Length - 1];
        }
    }
}

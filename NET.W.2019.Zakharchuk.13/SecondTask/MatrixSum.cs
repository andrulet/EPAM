using System;

namespace SecondTask
{
    /// <summary>
    /// This class includs extension methods and operation for <see cref="Matrix{T}"/>.
    /// </summary>
    public static class MatrixSum
    {
        /// <summary>
        /// It is extension method copies data into a new array.
        /// </summary>
        /// <param name="array">Array that is copied</param>
        /// <returns>New array that equals <see cref="array"/>/></returns>
        public static T[][] Copy<T>(this T[][] array)
        {
            int n = array.Length;
            T[][] copy = new T[n][];
            for (int i = 0; i < n; i++)
            {
                copy[i] = new T[n];
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    copy[i][j] = array[i][j];
                }
            }

            return copy;
        }

        /// <summary>
        /// Extension method that adds two <see cref="Matrix{T}"/>.
        /// </summary>
        /// <param name="matrix">Сurrent matrix(First term).</param>
        /// <param name="other">Added matrix(First term).</param>
        /// <returns>New <see cref="Matrix{T}"/> - result of add.</returns>
        public static Matrix<T> SumWith<T>(this Matrix<T> matrix, Matrix<T> other) where T : struct, IComparable<T>
        {
            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            if (matrix.GetType() != other.GetType() || matrix.Size() != other.Size())
            {
                throw new InvalidOperationException();
            }

            int n = matrix.Size();
            T[][] MatrixValues = new T[n][];
            for (int i = 0; i < n; i++)
            {
                MatrixValues[i] = new T[n];
            }

            try
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        MatrixValues[i][j] = (dynamic)matrix[i, j] + other[i, j];
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return MatrixFactory.GetMatrix(MatrixValues, matrix.GetType());
        }

        /// <summary>
        /// Extension method сhecks two array generic types on equels elements.
        /// </summary>
        /// <param name="first">Сurrent array.</param>
        /// <param name="second">Second matrix.</param>
        /// <returns>True if current and seconf arrays is equals, false if isn't.</returns>
        public static bool IsEqual<T>(this T[][] first, T[][] second)
        {
            if (second == null)
            {
                throw new ArgumentNullException(nameof(second));
            }

            if (first.GetType() != second.GetType() || first.Length != second.Length)
            {
                throw new InvalidOperationException();
            }
            for (int i = 0; i < first.Length; i++)
            {
                if (first[i].Length != second[i].Length)
                {
                    throw new InvalidOperationException();
                }

                for (int j = 0;j < first[i].Length; j++)
                {
                    if ((dynamic)first[i][j] != (dynamic)second[i][j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}

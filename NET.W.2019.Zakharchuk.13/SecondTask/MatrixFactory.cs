using System;

namespace SecondTask
{
    /// <summary>
    /// A class implementing a factory method for <see cref="Matrix{T}"/>.
    /// </summary>
    public static class MatrixFactory
    {
        /// <summary>
        /// This method creates a new instance of <see cref="Matrix"/> that depends on <paramref name="type"/>
        /// </summary>
        /// <returns><see cref="Matrix{T}"/></returns>
        public static Matrix<T> GetMatrix<T>(T[][] values, Type type) where T : struct, IComparable<T>
        {
            if (type == typeof(DiagonalMatrix<T>))
            {
                return new DiagonalMatrix<T>(values);
            }

            if (type == typeof(SimmetricMatrix<T>))
            {
                return new SimmetricMatrix<T>(values);
            }

            return new SquareMatrix<T>(values);
        }
    }
}

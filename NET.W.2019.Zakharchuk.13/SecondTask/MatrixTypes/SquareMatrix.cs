using System;

namespace SecondTask
{
    /// <summary>
    /// Class describing SquarelMatrix models.
    /// </summary>
    public class SquareMatrix<T> : Matrix<T> where T : struct, IComparable<T>
    {
        /// <summary>
        /// Initializes new instance of <see cref="SquareMatrix<T>"/> with specified <paramref name="arrayInput"/>.
        /// </summary>
        /// <paramref name="arrayInput"/>Array <paramref name="arrayInput"/>
        public SquareMatrix(T[][] arrayInput)
        {
            if (arrayInput == null)
            {
                throw new ArgumentNullException("Entered matrix equels null.");
            }

            if (!IsValuesCurrect(arrayInput))
            {
                throw new Exception("Invalid parameter for this type" + nameof(arrayInput));
            }

            this.Array = arrayInput.Copy();
        }

        /// <inheritdoc/>
        public override void ChangeElement(int i, int j, T val)
        {
            this.Array[i][j] = val;
            OnElementChanged(i, j);
        }

        /// <inheritdoc/>
        public override bool IsValuesCurrect(T[][] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Length != arr.Length)
                {
                    return false;
                }
            }

            return true;
        }
    }
}

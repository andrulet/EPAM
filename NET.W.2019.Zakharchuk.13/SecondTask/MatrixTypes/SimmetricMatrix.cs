using System;

namespace SecondTask
{
    /// <summary>
    /// Class describing SimmetricMatrix models.
    /// </summary>
    public class SimmetricMatrix<T> : Matrix<T> where T : struct, IComparable<T>
    {
        /// <summary>
        /// Initializes new instance of <see cref="SimmetricMatrix<T>"/> with specified <paramref name="arrayInput"/>.
        /// </summary>
        /// <paramref name="arrayInput"/>Array <paramref name="arrayInput"/>
        public SimmetricMatrix(T[][] arrayInput)
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
            if (i == j)
            {
                this.Array[i][j] = val;
                OnElementChanged(i, j);
            }
            else
            {
                this.Array[i][j] = val;
                this.Array[j][i] = val;
                OnElementChanged(i, j);
                OnElementChanged(j, i);
            }
        }

        /// <inheritdoc/>
        public override bool IsValuesCurrect(T[][] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    if (arr[i][j].CompareTo(arr[j][i]) != 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}

using System;

namespace SecondTask
{
    /// <summary>
    /// A class describing matrix models.
    /// </summary>
    public abstract class Matrix<T> where T : struct, IComparable<T>
    {
        /// <summary>
        /// array.
        /// </summary>
        private T[][] array;

        /// <summary>
        /// Delegate ChangeElementEventHandler.
        /// </summary>
        /// <param name="sender">Object sender - a link to a structure that spawned an event.</param>
        /// <param name="e">Object of <see cref="ElementEventArgs"/> - providing event data.</param>
        public delegate string ChangeElementEventHandler(object sender, ElementEventArgs e);

        /// <summary>
        /// Event ElementChanged.
        /// </summary>
        public event ChangeElementEventHandler ElementChanged;

        /// <summary>
        /// Property of the field <see cref="array"/>.
        /// </summary>
        public T[][] Array { get => array; protected set => array = value; }

        /// <summary>
        /// Property that gets (<see cref="i"/>)-s, (<see cref="j"/>)-s element of the field <see cref="array"/>.
        /// </summary>
        /// 
        public T this[int i, int j] => Array[i][j];

        /// <summary>
        /// This method chenges (<see cref="i"/>)-s, (<see cref="j"/>)-s element of <see cref="array"/>.
        /// </summary>
        public abstract void ChangeElement(int i, int j, T val);

        /// <summary>
        /// This property gets count of (<see cref="i"/>)-s elements of <see cref="array"/>.
        /// </summary>
        public int Size() => Array.Length;

        /// <summary>
        /// This method checks correct data that depends on type of matrix.
        /// </summary>
        /// <returns>True if data correct, false if uncorrect.</returns>
        public abstract bool IsValuesCurrect(T[][] arr);
        
        /// <summary>
        /// Event-generating method.
        /// </summary>
        protected void OnElementChanged(int i, int j)
        {
            ElementChanged?.Invoke(this, new ElementEventArgs(i, j));
        }
    }    
}

using System;

namespace Third_Task
{
    /// <summary>
    /// Class of generic type Node model.
    /// </summary>
    public class Node<T>
    {
        /// <summary>
        /// Initializes new instance of <see cref="Node<T>"/> with specified <paramref name="value"/>.
        /// </summary>
        /// <param name="value">Data.</param>        
        public Node(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException($"{nameof(value)} is null");
            }

            Data = value;
            Left = null;
            Right = null;
        }

        /// <summary>
        /// Property Data.
        /// </summary>
        public T Data { get; private set; }

        /// <summary>
        /// Property reference on left Node.
        /// </summary>
        public Node<T> Left { get; internal set; }

        /// <summary>
        /// Property reference on right Node.
        /// </summary>
        public Node<T> Right { get; internal set; }              
    }
}

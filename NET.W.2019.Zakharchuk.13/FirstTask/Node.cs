namespace FirstTask
{
    /// <summary>
    /// This class describes the nature of the data.
    /// </summary>
    public class Node<T>
    {
        /// <summary>
        /// Initializes new instance of <see cref="Node{T}"/> with specified <paramref name="data"/>.
        /// </summary>        
        public Node(T data)
        {
            Data = data;
        }

        /// <summary>
        /// The property Data.
        /// </summary>
        public T Data 
        { 
            get;
            set; 
        }

        /// <summary>
        /// The property Next.
        /// </summary>
        public Node<T> Next
        { 
            get;
            set; 
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return this.Data.ToString();
        }
    }
}

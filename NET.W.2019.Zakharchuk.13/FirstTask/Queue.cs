using System;
using System.Collections;
using System.Collections.Generic;

namespace FirstTask
{
    /// <summary>
    /// This class describes the nature of the object queue.
    /// </summary>  
    public class Queue<T> : IEnumerable<Node<T>>
    {
        /// <summary>
        /// The field of the first element in the queue.
        /// </summary>    
        private Node<T> head;

        /// <summary>
        /// The field of the tail element in the queue.
        /// </summary>
        private Node<T> tail;

        /// <summary>
        /// The field of the count of element in the queue.
        /// </summary>
        private int count;

        /// <summary>
        /// The property that checks queue on empty.
        /// </summary>
        /// <returns>Returns true if count of element in the queue isn't equal 0, false - equal 0</returns>
        public bool IsEmpty
        {
            get => Count == 0;
        }

        /// <summary>
        /// Property showing the first element of the queue.
        /// </summary>
        /// <exception cref="InvalidOperationException">Queue is empty.</exception>
        /// <returns>First element of the queue.</returns>
        public Node<T> First
        {
            get
            {
                if (IsEmpty)
                {
                    throw new InvalidOperationException("Queue is empty");
                }

                return head;
            }
        }

        /// <summary>
        /// Property showing the last element of the queue.
        /// </summary>
        /// <exception cref="InvalidOperationException">Queue is empty.</exception>
        /// <returns>Last element of the queue.</returns>
        public Node<T> Last
        {
            get
            {
                if (IsEmpty)
                {
                    throw new InvalidOperationException("Queue is empty");
                }

                return tail;
            }
        }
        
        /// <summary>
        /// Property showing the count element of the queue.
        /// </summary>
        public int Count
        {
            get => count; 
        }

        /// <summary>
        /// This method adds the object at the end of the queue.
        /// </summary>
        /// <exception cref="ArgumentNullException">Data is null.</exception>
        /// <param name="data">The object of the generalized type, which must be obtained at the end of the queue.</param>
        public void Add(T data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("Data is null");
            }

            Node<T> node = new Node<T>(data);
            Node<T> temp = tail;
            tail = node;
            if (IsEmpty)
            {
                head = tail;
            }
            else
            {
                temp.Next = tail;
            }

            count++;
        }

        /// <summary>
        /// This method delets first element of the queue.
        /// </summary>
        /// <exception cref="InvalidOperationException">Queue is empty.</exception>
        /// <returns>Returns the deleted item.</returns>
        public T Remove()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            T output = head.Data;
            head = head.Next;
            count--;
            return output;
        }

        /// <summary>
        /// This method clears queue.
        /// </summary>
        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        /// <summary>
        /// This method checks for the presence of objects in the queue.
        /// </summary>
        /// <param name="data">The object of the generalized type.</param>
        /// <exception cref="ArgumentNullException">Data is null.</exception>
        /// <returns>Returns true if data exists in the queue, false if it doesn't</returns>
        public bool Contains(T data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("Data is null");
            }

            Node<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        /// <summary>
        /// Returns enumerator to enumerate all elements in the queue.
        /// </summary>
        public IEnumerator<Node<T>> GetEnumerator()
        {
            return new QueueEnumerator(this);
        }

        /// <summary>
        /// Returns enumerator to enumerate all elements in the queue.
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Inner class, which enumerates elements of the queue
        /// </summary>
        private class QueueEnumerator : IEnumerator<Node<T>>
        {            
            private Node<T> currentNode;
            private Node<T> returnNode;

            public QueueEnumerator(Queue<T> x)
            {                
                currentNode = x.head;
                returnNode = x.head;
            }

            public Node<T> Current => returnNode;

            object IEnumerator.Current => Current;

            public void Dispose()
            {                
            }

            public bool MoveNext()
            {
                if (returnNode.Next == null)
                {
                    return false;
                }

                returnNode = currentNode;
                currentNode = currentNode.Next;
                return true;
            }

            public void Reset()
            {                
            }
        }
    }    
}

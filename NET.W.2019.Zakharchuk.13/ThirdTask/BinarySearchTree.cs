using System;
using System.Collections;
using System.Collections.Generic;

namespace Third_Task
{
    /// <summary>
    /// Class describing BinarySearchTree model.
    /// </summary>
    public class BinarySearchTree<T> : IEnumerable<T>
    {
        /// <summary>
        /// The field of the head element in the tree.
        /// </summary>
        private Node<T> _head;

        /// <summary>
        /// Delegate compare.
        /// </summary>
        private Comparison<T> comparer;

        /// <summary>
        /// Initializes new instance of <see cref="BinarySearchTree{T}"/>.Use a default compare.
        /// </summary>
        public BinarySearchTree() : this((Comparison<T>)null)
        {
        }

        /// <summary>
        /// Initializes new instance of <see cref="BinarySearchTree{T}"/>.Add list of elements and use a default compare.
        /// </summary>
        public BinarySearchTree(IEnumerable<T> list) : this()
        {
            if (ReferenceEquals(list, null))
            {
                throw new ArgumentNullException($"{nameof(list)} is null");
            }

            AddSeveralElements(list);
        }

        /// <summary>
        /// Initializes new instance of <see cref="BinarySearchTree{T}"/>.Add list of elements and use a plug-in compare.
        /// </summary>
        public BinarySearchTree(IEnumerable<T> list, IComparer<T> comparer) : this(comparer.Compare)
        {
            if (ReferenceEquals(list, null))
            {
                throw new ArgumentNullException($"{nameof(list)} is null");
            }

            AddSeveralElements(list);
        }

        /// <summary>
        /// Initializes new instance of <see cref="BinarySearchTree{T}"/>.Use a plug-in compare.
        /// </summary>
        public BinarySearchTree(IComparer<T> comparer) : this(comparer.Compare)
        {            
        }

        /// <summary>
        /// Initializes new instance of <see cref="BinarySearchTree{T}"/>.
        /// </summary>
        public BinarySearchTree(Comparison<T> comparison) 
        {
            _head = null;
            this.comparer = comparison ?? Comparer<T>.Default.Compare;
        }

        /// <summary>
        /// This method adds a new element in a tree.
        /// </summary>
        /// <param name="element">The data of type T.</param>
        /// <exception cref="ArgumentNullException"><paramref name="element"/> is null.</exception>        
        public void AddOneElement(T element)
        {
            if (ReferenceEquals(element, null))
            {
                throw new ArgumentNullException($"{nameof(element)} is null");
            }

            Node<T> temp = new Node<T>(element);
            if (Contains(temp))
            {
                throw new ArgumentException($"{nameof(element)} is already in the tree.");
            }

            if (_head == null)
            {
                _head = temp;
            }
            else
            {
                AddNode(_head, temp);
            }
        }

        /// <summary>
        /// This method adds a new several elements in a tree.
        /// </summary>
        /// <param name="listElements">The data of type T.</param>
        /// <exception cref="ArgumentNullException"><paramref name="listElements"/> is null.</exception>
        public void AddSeveralElements(IEnumerable<T> listElements)
        {
            if (ReferenceEquals(listElements, null))
            {
                throw new ArgumentNullException($"{nameof(listElements)} is null");
            }

            foreach (T x in listElements)
            {
                AddOneElement(x);
            }
        }

        /// <summary>
        /// This method checks element in the tree.
        /// </summary>
        /// <param name="checkNode">Element that needs to check in the tree.</param>
        /// <exception cref="ArgumentNullException"><paramref name="listElements"/> is null.</exception>
        /// <returns>Returns true if data exists in the tree, false if it doesn't</returns>
        public bool Contains(Node<T> checkNode)
        {
            if (ReferenceEquals(checkNode, null))
            {
                throw new ArgumentNullException($"{nameof(checkNode)} is null");
            }

            Node<T> current = _head;
            while (current != null)
            {
                if (comparer(checkNode.Data, current.Data) == 0)
                {
                    return true;
                }

                if (comparer(checkNode.Data, current.Data) < 0)
                {                    
                    current = current.Left;
                }
                else
                {                    
                    current = current.Right;                    
                }
            }

            return false;
        }

        /// <summary>
        /// Direct way of passing a tree.
        /// </summary>
        /// <returns>IEnumerable representation of the tree.</returns>
        public IEnumerable<T> Preorder() => PreorderMethod(_head);

        /// <summary>
        /// Central way to traverse a tree.
        /// </summary>
        /// <returns>IEnumerable representation of the tree.</returns>
        public IEnumerable<T> Inorder() => InorderMethod(_head);

        /// <summary>
        /// Reverse way to traverse a tree.
        /// </summary>
        /// <returns>IEnumerable representation of the tree.</returns>
        public IEnumerable<T> Postorder() => PostorderMethod(_head);

        public IEnumerator<T> GetEnumerator() => this.Inorder().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        /// <summary>
        /// This method adds a new element in a tree.
        /// </summary>
        /// <param name="node">The head element in the tree.</param> 
        /// <param name="node">The data of type T, that needs to add in the tree.</param>        
        private void AddNode(Node<T> head, Node<T> node)
        {
            if (comparer(node.Data, head.Data) < 0)
            {
                if (head.Left == null)
                {
                    head.Left = node;
                }
                else
                {
                    AddNode(head.Left, node);
                }
            }

            if (comparer(node.Data, head.Data) > 0)
            {
                if (head.Right == null)
                {
                    head.Right = node;
                }
                else
                {
                    AddNode(head.Right, node);
                }
            }
        }

        /// <summary>
        /// Direct way of passing a tree.
        /// </summary>
        /// <returns>IEnumerable representation of the tree.</returns>
        private IEnumerable<T> PreorderMethod(Node<T> node)
        {
            yield return node.Data;

            if (node.Left != null)
            {
                foreach (T element in PreorderMethod(node.Left))
                {
                    yield return element;
                }
            }

            if (node.Right != null)
            {
                foreach (T element in PreorderMethod(node.Right))
                {
                    yield return element;
                }
            }
        }

        /// <summary>
        /// Central way to traverse a tree.
        /// </summary>
        /// <returns>IEnumerable representation of the tree.</returns>
        private IEnumerable<T> InorderMethod(Node<T> node)
        {
            if (node.Left != null)
            {
                foreach (T element in InorderMethod(node.Left))
                {
                    yield return element;
                }
            }

            yield return node.Data;

            if (node.Right != null)
            {
                foreach (T element in InorderMethod(node.Right))
                {
                    yield return element;
                }
            }
        }

        /// <summary>
        /// Reverse way to traverse a tree.
        /// </summary>
        /// <returns>IEnumerable representation of the tree.</returns>
        private IEnumerable<T> PostorderMethod(Node<T> node)
        {
            if (node.Left != null)
            {
                foreach (T element in PostorderMethod(node.Left))
                {
                    yield return element;
                }
            }

            if (node.Right != null)
            {
                foreach (T element in PostorderMethod(node.Right))
                {
                    yield return element;
                }
            }

            yield return node.Data;
        }
    }
}

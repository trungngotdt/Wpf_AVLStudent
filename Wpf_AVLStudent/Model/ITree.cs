using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_AVLStudent.Model
{
    public interface ITree<T> where T : class,
         IComparable, new()
    {
        Node<T> Root { get; set; }

        /// <summary>
        /// Get height of tree
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        Task< int> HeightAsync(Node<T> node);

        /// <summary>
        /// Get height of tree
        /// </summary>
        /// <returns></returns>
        Task< int> HeightAsync();

        /// <summary>
        /// Adds the elements of the specified collection to the AVL
        /// </summary>
        /// <param name="node"></param>
        Task AddRangeAsync(Node<T>[] node);

        /// <summary>
        /// Adds the elements of the specified collection to the AVL
        /// </summary>
        /// <param name="data"></param>
        Task AddRangeAsync(T[] data);

        /// <summary>
        /// Find inorder predecessor of a node
        /// </summary>
        /// <returns></returns>
        object Predecessor(Node<T> node);

        /// <summary>
        /// Find inorder predecessor of a AVL
        /// </summary>
        /// <returns></returns>
        object Predecessor();

        /// <summary>
        /// Find inorder successor of a AVL
        /// </summary>
        /// <returns><seealso cref="Node{T}"/></returns>
        object Successor();

        /// <summary>
        /// Find inorder successor of a node 
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        object Successor(Node<T> node);

        /// <summary>
        /// Return a minimum value in Node
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        Node<T> GetMin(Node<T> node);

        /// <summary>
        ///Return a minimum value in AVL 
        /// </summary>
        /// <returns></returns>
        Node<T> GetMin();

        /// <summary>
        /// Return a maximum value in AVL
        /// </summary>
        /// <returns></returns>
        Node<T> GetMax();

        /// <summary>
        /// Return a maximum value in node
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        Node<T> GetMax(Node<T> node);

        /// <summary>
        /// Determines whether an element is in the AVL
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Contains(T data);

        /// <summary>
        /// Determines whether an element is in the AVL
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        bool Contains(Node<T> node);

        List<string> NRL();

        List<string> NLR();

        List<string> LRN();

        List<string> RLN();

        List<string> RNL();

        List<string> LNR();

        /// <summary>
        /// Searches for an parent of element that matches the conditions defined by the specified
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Tuple<Node<T>, int> FindParent(T data);

        /// <summary>
        /// Searches for an parent of element that matches the conditions defined by the specified
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        Tuple<Node<T>, int> FindParent(Node<T> node);

        /// <summary>
        /// Searches for an element that matches the conditions defined by the specified
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Node<T> FindNode(T data);

        /// <summary>
        /// Searches for an element that matches the conditions defined by the specified
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        Node<T> FindNode(Node<T> node);

        Node<T> FindNode(Node<T> nodeRoot, Node<T> node);

        /// <summary>
        /// Remove the elements in AVL - tree root
        /// Return list of element can't removed
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        Task< List<Node<T>>> RemoveRangeAsync(Node<T>[] node);

        /// <summary>
        ///  Remove a element in AVL - tree root
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task< bool> RemoveAsync(T data);

        /// <summary>
        ///  Remove a element in AVL - tree root
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        Task< bool> RemoveAsync(Node<T> node);

        /// <summary>
        /// Adds an object to the AVL
        /// </summary>
        /// <param name="item"></param>
        Task InsertAsync(Node<T> item);

        /// <summary>
        /// Adds an object to the AVL
        /// </summary>
        /// <param name="item"></param>
        Task InsertAsync(T item);

        void InsertNoRotation(Node<T> x);

        /// <summary>
        /// A List with element from minimum to maximum
        /// </summary>
        /// <returns></returns>
        List<T> ToList();
    }
}

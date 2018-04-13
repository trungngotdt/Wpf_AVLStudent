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
        /// Adds the elements of the specified collection to the BST
        /// </summary>
        /// <param name="node"></param>
        void AddRange(Node<T>[] node);

        /// <summary>
        /// Adds the elements of the specified collection to the BST
        /// </summary>
        /// <param name="data"></param>
        void AddRange(T[] data);

        /// <summary>
        /// Find inorder predecessor of a node
        /// </summary>
        /// <returns></returns>
        object Predecessor(Node<T> node);

        /// <summary>
        /// Find inorder predecessor of a BST
        /// </summary>
        /// <returns></returns>
        object Predecessor();

        /// <summary>
        /// Find inorder successor of a BST
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
        ///Return a minimum value in BST 
        /// </summary>
        /// <returns></returns>
        Node<T> GetMin();

        /// <summary>
        /// Return a maximum value in BST
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
        /// Determines whether an element is in the BST
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Contains(T data);

        /// <summary>
        /// Determines whether an element is in the BST
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        bool Contains(Node<T> node);

        void NRL();

        void NRL(Node<T> node);

        void NLR();

        void NLR(Node<T> node);

        void LRN(Node<T> node);

        void LRN();

        void RLN(Node<T> node);

        void RLN();

        void RNL(Node<T> node);

        void RNL();

        void LNR(Node<T> node);

        void LNR();

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

        /// <summary>
        /// Remove the elements in BST - tree root
        /// Return list of element can't removed
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        List<Node<T>> RemoveRange(Node<T>[] node);

        /// <summary>
        ///  Remove a element in BST - tree root
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Remove(T data);

        /// <summary>
        ///  Remove a element in BST - tree root
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        bool Remove(Node<T> node);

        /// <summary>
        /// Adds an object to the BST
        /// </summary>
        /// <param name="item"></param>
        void Insert(Node<T> item);

        /// <summary>
        /// Adds an object to the BST
        /// </summary>
        /// <param name="item"></param>
        void Insert(T item);

        /// <summary>
        /// A List with element from minimum to maximum
        /// </summary>
        /// <returns></returns>
        List<T> ToList();
    }
}

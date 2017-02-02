using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo1.Core
{
    public class MyBinaryTree<T>
    {
        public Node<T> Root { get; set; }

        public static void preOrderTraversal(Action<T> visitAction, Node<T> node)
        {
            if (node.LeftChild != null)
            {
                preOrderTraversal(visitAction, node.LeftChild);
            }


            if (node.RightChild != null)
            {
                preOrderTraversal(visitAction, node.RightChild);
            }

            visitAction(node.Value);
        }

        public static void postOrderTraversal(Action<T> visitAction, Node<T> node)
        {
            if (node != null)
            {
                postOrderTraversal(visitAction, node.LeftChild);
                postOrderTraversal(visitAction, node.RightChild);

                visitAction(node.Value);
            }
        }

        public static void InOrderTraversal(Action<T> visitAction, Node<T> node)
        {
            if (node != null)
            {
                InOrderTraversal(visitAction, node.LeftChild);


                visitAction(node.Value);
                InOrderTraversal(visitAction, node.RightChild);

            }
        }
    }

    public class Node<T>
    {
        public Node<T> LeftChild { get; set; }

        public Node<T> RightChild { get; set; }

        public T Value { get; set; }
    }

}

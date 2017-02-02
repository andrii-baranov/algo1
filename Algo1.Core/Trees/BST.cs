using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo1.Core.Trees
{
    public class BST
    {
        private Node _root;

        public BST()
        {
        }

        public string Get(int key)
        {
            var current = _root;

            while (current != null)
            {
                if (current.Key == key)
                {
                    return current.Value;
                } else if (current.Key > key)
                {
                    current = current.Left;
                } else
                {
                    current = current.Right;
                }
            }

            return null;
        }

        public void Put(int key, string value)
        {
            _root = Put(_root, key, value);
        }

        private void Remove(int key, Node startNode)
        {
            //
        }
        //todo change with recursion
        public void Remove(int key)
        {
            if (_root.Key == key)
            {
                // find smallest in right
                var minParent = FindMinChildParent(_root.Right);
                var min = minParent.Left;
                _root.Key = min.Key;
                _root.Value = min.Value;
                minParent.Left = null;
            }

            Node target = _root;
            Node targetParent = null;
            bool isLeftChild = false;
            while (target != null)
            {
                if(target.Key > key)
                {
                    isLeftChild = true;
                    targetParent = target;
                    target = target.Left;
                } else if (target.Key < key)
                {
                    isLeftChild = false;
                    targetParent = target;
                    target = target.Right;
                }
                else
                {
                    break;
                }
            }

            if (target == null)
            {
                return; // not found
            }


            // found target key
            if (target.Left == null && target.Right == null)
            {
                // no children, just remove
                if (isLeftChild)
                {
                    targetParent.Left = null;
                }
                else
                {
                    targetParent.Right = null;
                }
            }
            else if (target.Right == null) // has only right child
            {
                // has only one child
                if (isLeftChild)
                {
                    targetParent.Left = target.Left;
                }
                else
                {
                    targetParent.Right = target.Left;
                }
            }
            else if (target.Left == null)
            {
                if (isLeftChild)
                {
                    targetParent.Left = target.Right;
                }
                else
                {
                    targetParent.Right = target.Right;
                }
            } else // has two children, so we swap smallest child from right side and cleanup bottom
            {
                var minChildParent = FindMinChildParent(target.Right);
                var minChild = minChildParent.Left;

                target.Key = minChild.Key;
                target.Value = minChild.Value;

                if (minChild.Right == null)
                {
                    minChildParent.Left = minChild.Right;
                }
            }
        }


        private Node FindMinChildParent(Node node)
        {
            Node parent = node;
            while (node.Left != null)
            {
                parent = node;
                node = node.Left;
            }

            return parent;
        }

        private Node Put(Node current, int key, string value)
        {
            if (current == null)
            {
                return new Node { Key = key };
            }

            if (current.Key > key)
            {
                current.Left = Put(current, key, value);
            }
            else if (current.Key < key)
            {
                current.Right = Put(current, key, value);
            }
            else
            {
                current.Value = value;
            }

            return current;
        }

        public Node Root
        {
            get { return _root; }
        }

        public class Node
        {
            public int Key { get; set; }

            public string Value { get; set; }

            public Node Left { get; set; }

            public Node Right { get; set; }
        }
    }


}

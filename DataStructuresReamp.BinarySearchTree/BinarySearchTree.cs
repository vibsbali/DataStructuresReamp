using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;

namespace DataStructuresReamp.BinarySearchTree 
{
    public class BinarySearchTree<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        private Node<T> head;
        public int Count { get; private set; }

        public void InOrderTraversal(Action<T> action)
        {
            InOrderTraversal(action, head);
        }

        private void InOrderTraversal(Action<T> action, Node<T> node)
        {
            if (node!=null)
            {
                InOrderTraversal(action, node.Left);
                action(node.Value);
                InOrderTraversal(action, node.Right);
            }
        }

        public void PostOrderTraversal()
        {
            PostTraversal(head);
        }

        private void PostTraversal(Node<T> node)
        {
            if (node != null)
            {
                PostTraversal(node.Left);
                PostTraversal(node.Right);
                Console.WriteLine(node.Value);
            }
        }

        public void PreOrderTraversal()
        {
            PreTraversal(head);
        }

        private void PreTraversal(Node<T> node)
        {
            if (node!= null)
            {
                Console.WriteLine(node.Value);
                PreTraversal(node.Left);
                PreTraversal(node.Right);
            }
        }



        public IEnumerator<T> BreadthFirstSearch()
        {
            var queue = new Queue<Node<T>>();
            var queueToEnumerate = new Queue<T>();
            queue.Enqueue(head);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                queueToEnumerate.Enqueue(node.Value);
                if (node.Left != null)
                {
                    queue.Enqueue(node.Left);
                }
                if (node.Right != null)
                {
                    queue.Enqueue(node.Right);
                }
            }

            while (queueToEnumerate.Count != 0)
            {
                var node = queueToEnumerate.Dequeue();
                yield return node;
            }
        }

        public void Add(T value)
        {
            //Case 1. tree is empty
            if (head == null)
            {
                head = new Node<T>(value);
            } 
            //case 2. Tree is not empty, so recursively find correct location
            else
            {
                AddRecursively(head, value);
            }
            
            Count++;
        }

        public bool Remove(T item)
        {
            return RemoveRecursively(head, null, item);
        }

        public void Clear()
        {
            head = null;
            Count = 0;
        }

        private bool RemoveRecursively(Node<T> current, Node<T> parentNode, T item)
        {
            if (current == null)
            {
                return false;
            }

            int result = current.Value.CompareTo(item);
            if (result > 0)
            {
                //if the value is less than current, go left
                return RemoveRecursively(current.Left, current, item);
            }
            if (result < 0)
            {
                //if the value is more than current, go right
                return RemoveRecursively(current.Right, current, item);
            }
            if (result == 0)
            {
                if (current == head)
                {
                    Clear();
                    return true;
                }
                //otherwise check if it is a tail node
                if (current.Left == null && current.Right == null)
                {
                    //Is it left or right
                    if (IsRightNode(parentNode, current))
                    {
                        //If Right
                        parentNode.Right = null;
                    }
                    else
                    {
                        parentNode.Left = null;
                    }
                }
                else if (current.Right == null)
                {
                    //Is it left or right
                    if (IsRightNode(parentNode, current))
                    {
                        //If Right
                        parentNode.Right = current.Left;
                    }
                    else
                    {
                        parentNode.Left = current.Left;
                    }
                }
                else
                {
                    //Case 2: The node to be removed has a right child which has no left child
                    if (current.Right.Left == null)
                    {
                        //In this case, we want to move the removed node’s right child (6) into the place of the removed node.

                        //Is it left or right
                        if (IsRightNode(parentNode, current))
                        {
                            //If Right
                            parentNode.Right = current.Right;
                            parentNode.Right.Left = current.Left;
                        }
                        else
                        {
                            //Else Left
                            parentNode.Left = current.Right;
                            parentNode.Left.Left = current.Left;
                        }
                    }
                    //Case 3: The node to be removed has a right child which, in turn, has a left child.
                    if (current.Right.Left != null)
                    {
                        //In this case, the left-most child of the removed node’s right child must be placed into the
                        //removed node’s slot

                        //Is it left or right
                        if (IsRightNode(parentNode, current))
                        {
                            //If Right
                            var parent = current.Right;
                            var leftMostNode = GetLeftMostChildWithParent(ref parent);
                            parent.Left = null;
                            parentNode.Right = leftMostNode;
                            parentNode.Right.Left = current.Left;
                            parentNode.Right.Right = current.Right;
                        }
                        else
                        {
                            //Else Left
                            var parent = current.Right;
                            var leftMostNode = GetLeftMostChildWithParent(ref parent);
                            parent.Left = null;
                            parentNode.Left = leftMostNode;
                            parentNode.Left.Left = current.Left;
                            parentNode.Left.Right = current.Right;
                        }
                    }
                }

                Count--;
                return true;
            }

            return false;
        }


        private Node<T> GetLeftMostChildWithParent(ref Node<T> parent)
        {
            if (parent.Left.Left != null)
            {
                var left = parent.Left;
                return GetLeftMostChildWithParent(ref left);
            }

            return parent.Left;
        }

        private bool IsRightNode(Node<T> parentNode, Node<T> compareToNode)
        {
            return parentNode.Right == compareToNode;
        }

        private void AddRecursively(Node<T> node, T value)
        {
            //Check if node's value is greater than value
            if (node.Value.CompareTo(value) > 0)
            {
                if (node.Left == null)
                {
                    node.Left = new Node<T>(value);
                }
                else
                {
                    AddRecursively(node.Left, value);
                }
            }
            else
            {
                if (node.Right == null)
                {
                    node.Right = new Node<T>(value);
                }
                else
                {
                    AddRecursively(node.Right, value);
                }
            }
        }

        public bool Contains(T value)
        {
            var current = head;
            while(current != null)
            {
                if (current.Value.CompareTo(value) > 0)
                {
                    current = current.Left;
                }
                else if(current.Value.CompareTo(value) < 0)
                {
                    current = current.Right;
                }
                else if(current.Value.CompareTo(value) == 0)
                {
                    return true;
                }
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return BreadthFirstSearch();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

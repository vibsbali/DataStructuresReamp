using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructuresReamp.LinkedList
{
    public class LinkedList<T> : ICollection<T>
        where T : IComparable<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public int Count { get; private set; }
        public bool IsReadOnly => false;


        public void Add(T value)
        {
            if (head == null)
            {
                head = new Node<T>(value);
                tail = head;
                Count++;
            }
            else
            {
                var oldTail = tail;
                tail = new Node<T>(value);
                oldTail.Next = tail;
                Count++;
            }
        }

        public void Clear()
        {
            head = tail = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            foreach (var node in this)
            {
                if (node.CompareTo(item) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            var current = head;
            while (current != null)
            {
                array[arrayIndex] = current.Value;
                arrayIndex++;
                current = current.Next;
            }
        }

        public bool RemoveFirst()
        {
            if (head != null)
            {
                head = head.Next;
                Count--;
                if (head == null)
                {
                    tail = null;
                }
            }

            return false;
        }

        public bool RemoveLast()
        {
            if (tail == null)
            {
                return false;
            }

            var node = head;
            if (head == tail)
            {
                head = null;
                tail = null;
                Count--;
                return true;
            }

            while (node.Next.Next != null)
            {
                node = node.Next;
            }
            node.Next = null;
            tail = node;
            Count--;
            return true;
        }

        public bool Remove(T value)
        {
            if (head == null)
            {
                return false;
            }

            if (head == tail && head.Value.CompareTo(value) == 0)
            {
                head = tail = null;
                Count--;
                return true;
            }

            Node<T> previous = null;
            var current = head;

            while (current.Next != null && current.Value.CompareTo(value) != 0)
            {
                previous = current;
                current = current.Next;
            }

            if (current.Value.CompareTo(value) == 0)
            {
                //Is it head
                if (previous == null)
                {
                    head = head.Next;
                    Count--;
                    return true;
                }
                
                previous.Next = current.Next;
                Count--;

                //Is it tail
                if (current.Next == null)
                {
                    tail = previous;
                }
                return true;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> previous = null;
            var node = head;
            while (node != null)
            {
                yield return node.Value;
                previous = node;
                node = node.Next;
            }

            //Notice how you can return previous node here
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

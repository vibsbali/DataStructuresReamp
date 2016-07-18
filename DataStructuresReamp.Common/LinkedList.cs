using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructuresReamp.Common
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
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
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

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

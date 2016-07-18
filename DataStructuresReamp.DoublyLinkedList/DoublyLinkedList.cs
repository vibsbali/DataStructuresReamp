using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresReamp.DoublyLinkedList
{
    public class DoublyLinkedList<T> : ICollection<T>
        where T : IComparable<T>
    {
        private Node<T> Head { get; set; }
        private Node<T> Tail { get; set; }
        public int Count { get; private set; }
        public bool IsReadOnly => false;

        public IEnumerator<T> GetEnumerator()
        {
            var node = Head;
            while (node != null)
            {
                yield return node.Value;
                node = node.Next;
            }
        }

        public void AddFirst(T item)
        {
            //create a new node
            var node = new Node<T>(item);

            //If LinkedList is empty
            if (Head == null)
            {
                Head = node;
                Tail = node;
            }
            else
            {
                node.Next = Head;
                Head.Previous = node;
                Head = node;
            }

            Count++;
        }

        public void AddLast(T item)
        {
            var node = new Node<T>(item);

            //check if LinkedList is empty
            if (Tail == null)
            {
                Tail = node;
                Head = node;
            }
            else
            {
                Tail.Next = node;
                node.Previous = Tail;
                Tail = node;
            }
            Count++;
        }

        public bool CheckIfHeadIsTail()
        {
            return Head == Tail;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            AddFirst(item);
        }

        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            return this.Any(items => items.CompareTo(item) == 0);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            var current = Head;
            while (current != null)
            {
                if (current.Value.CompareTo(item) == 0)
                {
                    if (current == Head)
                    {
                        RemoveFirst();
                        return true;
                    }
                    if (current == Tail)
                    {
                        RemoveLast();
                        return true;
                    }
                    var previous = current.Previous;
                    previous.Next = current.Next;
                    current.Next.Previous = previous;
                    current = null;
                    Count--;
                    return true;
                }
                current = current.Next;
            }

            return false;
        }

        public bool RemoveFirst()
        {
            if (Head == null)
            {
                return false;
            }

            if (Head.Next == null)
            {
                Clear();
                return true;
            }
            
            Head = Head.Next;
            Head.Previous = null;
            Count--;
            return true;
        }

        public bool RemoveLast()
        {
            if (Tail == null)
            {
                return false;
            }

            if (Head == Tail)
            {
                Clear();
                return true;
            }

            
            Tail = Tail.Previous;
            Tail.Next = null;
            Count--;
            return true;
        }
    }
}

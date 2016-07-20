using System;
using System.Collections;
using System.Collections.Generic;

namespace ArrayList
{
    public class ArrayList<T> : IList<T>
        where T : IComparable<T>
    {
        private T[] backingArray;
        

        public int Count { get; private set; }
        public bool IsReadOnly => false;

        public ArrayList() : this(4)
        {
            
        }

        public ArrayList(uint v)
        {
            backingArray = new T[v];
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return backingArray[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            //We check if Array is full
            if (backingArray.Length == Count)
            {
                //double size
                var temp = backingArray;
                backingArray = new T[Count*2];
                Array.Copy(temp,0,backingArray,0,temp.Length);
            }
            backingArray[Count] = item;
            Count++;
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

        public bool Remove(T item)
        {
            var isFound = false;
            for (int i = 0; i < Count; i++)
            {
                if (backingArray[i].CompareTo(item) == 0)
                {
                    isFound = true;
                    for (int j = i + 1; j < Count; j++)
                    {
                        backingArray[j - 1] = backingArray[j];
                    }

                    Count--;
                    backingArray[Count] = default(T);
                    
                    break;
                }
            }

            if (Count <= 0.25 * backingArray.Length)
            {
                //new size
                //copy array
            }

            return isFound;
        }

       
        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public T this[int index]
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
    }
}

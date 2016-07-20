using System;
using System.Collections.Specialized;

namespace DataStructuresReamp.StacksAndQueues
{
    public class Stack<T>
    {
        private int head = 0;
        private T[] backingArray;

        public int Count { get; private set; }

        public Stack() : this(4)
        {
            
        }

        public Stack(int size)
        {
            backingArray = new T[size];
        }

        public void Push(T value)
        {
            backingArray[head] = value;
            Count++;

            //check if there is enough length
            if (Count == backingArray.Length)
            {
                var temp = backingArray;
                backingArray = new T[backingArray.Length * 2];
                Array.Copy(temp, 0, backingArray, 0, Count);
            }
            head++;
        }

        public T Pop()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            var value = backingArray[--head];
            backingArray[head] = default(T); // to stop loitering
            Count--;
            return value;
        }

    }
}

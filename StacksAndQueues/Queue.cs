using System;

namespace DataStructuresReamp.StacksAndQueues
{
    public class Queue<T>
    {
        private T[] backingArray;
        private int head;
        private int tail;

        public int Count { get; private set; }

        public Queue(int size)
        {
            backingArray = new T[size];
            head = 0;
            tail = -1;
        }

        public Queue() : this(4)
        {
        }

        public T Dequeue()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            var itemToReturn = backingArray[head];
            backingArray[head] = default(T); //Do not loiter
            if (head == backingArray.Length - 1)
            {
                head = 0;
            }
            else
            {
                head++;
            }

            Count--;
            return itemToReturn;
        }

        public void Enqueue(T item)
        {
            //check if we have exhausted the array
            if (Count == backingArray.Length)
            {
                //Resize the array
                ResizeUp();

                //update pointers
                head = 0;
                tail = Count;
            }
            else
            {
                //If tail is at the last index
                if (tail == backingArray.Length - 1)
                {
                    tail = 0;
                }
                else
                {
                    tail++;
                }
            }    

            backingArray[tail] = item;
            Count++;
        }

        private void ResizeUp()
        {
            var temp = backingArray;
            backingArray = new T[Count*2];

            //check if we have wrapped
            if (head > tail)
            {
                Array.Copy(temp, head, backingArray, 0, temp.Length - head);
                Array.Copy(temp, 0, backingArray, temp.Length - head, tail + 1);
            }
            else
            {
                Array.Copy(temp, 0, backingArray, 0, Count);
            }
        }
    }
}

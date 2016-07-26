using System;

namespace DataStructuresReamp.Sorts
{
    public class Sort<T> where T : IComparable<T>
    {
        public void BubbleSort(T[] array)
        {
            bool hasSortPerformed;
            var maxIndex = array.Length;
            do
            {
                hasSortPerformed = false;
                for (int i = 1; i < maxIndex; i++)
                {
                    if (array[i].CompareTo(array[i - 1]) < 0)
                    {
                        Swap(i, i - 1, array);
                        hasSortPerformed = true;
                    }
                }
                maxIndex--; // Optimization - On every run the last index will be maximum of previous values
            } while (hasSortPerformed);
        }

        private void Swap(int a1, int a2, T[] array)
        {
            var temp = array[a1];
            array[a1] = array[a2];
            array[a2] = temp;
        }
    }
}

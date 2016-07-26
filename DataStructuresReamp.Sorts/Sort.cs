using System;

namespace DataStructuresReamp.Sorts
{
    public class Sort<T> where T : IComparable<T>
    {
        //With bubble sort the maximum value gets to the end of the array hence bubble sort
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

        //With Insertion sort we move the item to correct index instead of swapping out. It has a single pass methodology
        //It always maintains a sorted sublist in the lower positions of the list. Each new item is then “inserted” back into the previous sublist such that the sorted sublist is one item larger. 
        public void InsertionSort(T[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i].CompareTo(array[i - 1]) < 0 )
                {
                    InsertArray(array, i);
                }
            }
        }

        private void InsertArray(T[] array, int maxIndex)
        {
            var itemToPlace = array[maxIndex];
            for (int i = 0; i < maxIndex; i++)
            {
                if (itemToPlace.CompareTo(array[i]) < 0)
                {
                    ShiftArray(array, i + 1, maxIndex);
                    array[i] = itemToPlace;
                    break;
                }
            }
        }

        private void ShiftArray(T[] array, int startingIndex, int maxIndex)
        {
            for (int i = maxIndex; i > startingIndex; i--)
            {
                array[i] = array[i - 1];
            }
        }


        private void Swap(int a1, int a2, T[] array)
        {
            var temp = array[a1];
            array[a1] = array[a2];
            array[a2] = temp;
        }
    }
}

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


        public void MergeSort(T[] array)
        {
            SplitRecursively(array);
        }

        private void SplitRecursively(T[] array)
        {
            if (array.Length <= 1)
            {
                return;
            }

            var mid = array.Length / 2;
            var leftArray = new T[mid];
            Array.Copy(array, 0, leftArray, 0, mid);

            var rightArray = new T[array.Length - mid];
            Array.Copy(array, mid, rightArray, 0, rightArray.Length);

            //Split recursively
            SplitRecursively(leftArray);
            SplitRecursively(rightArray);

            //Now merge Array
            MergeArray(array, leftArray, rightArray);
        }

        private void MergeArray(T[] array, T[] leftArray, T[] rightArray)
        {
            var startingIndex = 0;
            var leftIndex = 0;
            var rightIndex = 0;
            var remaining = leftArray.Length + rightArray.Length;

            while (remaining > 0)
            {
                if (leftIndex >= leftArray.Length)
                {
                    array[startingIndex] = rightArray[rightIndex];
                    startingIndex++;
                    rightIndex++;
                }
                else if (rightIndex >= rightArray.Length)
                {
                    array[startingIndex] = leftArray[leftIndex];
                    startingIndex++;
                    leftIndex++;
                }
                else
                {
                    if (leftArray[leftIndex].CompareTo(rightArray[rightIndex]) < 0)
                    {
                        array[startingIndex] = leftArray[leftIndex];
                        startingIndex++;
                        leftIndex++;
                    }
                    else
                    {
                        array[startingIndex] = rightArray[leftIndex];
                        startingIndex++;
                        rightIndex++;
                    }
                }

                remaining--;
            }
        }
    }
}

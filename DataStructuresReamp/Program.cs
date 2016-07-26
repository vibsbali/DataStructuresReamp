using System;
using System.Globalization;
using DataStructuresReamp.Sorts;
using DataStructuresReamp.StacksAndQueues;


namespace DataStructuresReamp
{
    class Program
    {
        static void Main()
        {
            var sort = new Sort<int>();
            var array = new int[] {3, 23, 1, 3, 11, 4, 23, 3, 12, 3, 123, 123,123,13,123,11, 213, 2,};
            sort.BubbleSort(array);

            foreach (var i in array)
            {
                Console.WriteLine(i);
            }
        }
    }
}

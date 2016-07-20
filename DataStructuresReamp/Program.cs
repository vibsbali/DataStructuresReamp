using ArrayList;
using System;


namespace DataStructuresReamp
{
    class Program
    {
        static void Main()
        {
            var array = new ArrayList<int>(2);
            array.Add(1);
            array.Add(2);
            array.Add(3);

            array.Remove(3);

            foreach (var i in array)
            {
                Console.WriteLine(i);
            }

            array.Add(2);

            foreach (var i in array)
            {
                Console.WriteLine(i);
            }

            array.Remove(1);

            foreach (var i in array)
            {
                Console.WriteLine(i);
            }
        }
    }
}

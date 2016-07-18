using System;
using DataStructuresReamp.LinkedList;

namespace DataStructuresReamp
{
    class Program
    {
        static void Main()
        {
            var list = new LinkedList<int> {1};

            //list.Remove(4);
            //list.RemoveLast();
            //list.Remove(2);
            Console.WriteLine(list.Contains(1));
            Console.WriteLine(list.Contains(0));
        }
    }
}

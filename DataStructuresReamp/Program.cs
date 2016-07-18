using System;
using DataStructuresReamp.DoublyLinkedList;

namespace DataStructuresReamp
{
    class Program
    {
        static void Main()
        {
            var list = new DoublyLinkedList<int>();

            for (int i = 0; i < 10; i++)
            {
                list.AddLast(i);
            }

            foreach (var i in list)
            {
                Console.WriteLine(i);
            }

            list.Remove(10);

            foreach (var i in list)
            {
                Console.WriteLine(i);
            }
        }
    }
}

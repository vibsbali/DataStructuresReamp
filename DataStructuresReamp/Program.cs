using System;
using DataStructuresReamp.BinarySearchTree;

namespace DataStructuresReamp
{
    class Program
    {
        static void Main()
        {
            var bst = new BinarySearchTree<int>();

           bst.Add(100);
            bst.Add(50);
            bst.Add(150);
            bst.Add(45);
            bst.Add(125);
            bst.Add(175);
            bst.Add(47);
            bst.Add(48);
            bst.Add(46);
            bst.Add(165);
            bst.Add(155);
            bst.Add(152);
            bst.Add(190);
            bst.Add(2000);
            bst.Add(180);
            bst.Add(176);


            Console.WriteLine(bst.Contains(2));
            Console.WriteLine(bst.Contains(190));
        }
    }
}

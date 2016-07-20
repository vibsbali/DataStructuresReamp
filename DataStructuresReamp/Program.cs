using System;
using DataStructuresReamp.StacksAndQueues;


namespace DataStructuresReamp
{
    class Program
    {
        static void Main()
        {
            var stack = new Stack<string>();

            for (int i = 0; i < 5; i++)
            {
                stack.Push(i.ToString());
            }

            var length = stack.Count;
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine(stack.Pop());
            }

            for (int i = 0; i < 5; i++)
            {
                stack.Push(i.ToString());
            }

            length = stack.Count;
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine(stack.Pop());
            }
        }
    }
}

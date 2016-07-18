using DataStructuresReamp.Common;

namespace DataStructuresReamp
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new LinkedList<int> {1, 2, 3};

            for (int i = 0; i < 3; i++)
            {
                list.Remove(1);
            }


        }
    }
}

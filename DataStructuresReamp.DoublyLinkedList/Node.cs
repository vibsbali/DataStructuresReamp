namespace DataStructuresReamp.DoublyLinkedList
{
    internal class Node<T>
    {
        public Node(T value)
        {
            Value = value;
        }

        public T Value { get; private set; }
        public Node<T> Next { get; set; }
        public Node<T> Previous { get; set; }
    }
}

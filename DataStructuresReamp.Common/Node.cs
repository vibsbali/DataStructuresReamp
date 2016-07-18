﻿namespace DataStructuresReamp.Common
{
    internal class Node<T>
    {
        public T Value { get; }
        public Node<T> Next { get; set; }
        public Node(T value)
        {
            Value = value;
        }
    }
}

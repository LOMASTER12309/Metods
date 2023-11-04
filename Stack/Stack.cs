using System;

namespace Stack
{
    public class Stack<T>
    {
        Node<T> head;
        int count;
        public void push(T obj)
        {
            Node<T> item = new Node<T>(obj);
            item.Next = head;
            head = item;
            count++;
        }
        public T pop()
        {
            if (IsEmpty) throw new InvalidOperationException("Стек пуст");
            Node<T> node = head;
            head = head.Next;
            count--;
            return node.Data;
        }
        public bool IsEmpty
        {
            get { return count == 0; }
        }
        public int size
        {
            get { return count; }
        }
        public T back()
        {
            if (IsEmpty) throw new InvalidOperationException("Стек пуст");
            return head.Data;
        }
        public void clear()
        {
            while (!IsEmpty) pop();
        }
    }
    public class Node<T>
    {
        public Node(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public Node<T> Next { get; set; }
    }
}

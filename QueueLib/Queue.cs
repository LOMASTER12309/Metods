using System;

namespace Queue
{
    public class Queue<T>
    {
        Node<T> head;
        int count;

        public void push(T obj)
        {
            Node<T> item = new Node<T>(obj);
            if (IsEmpty)
            {
                head = item;
                count++;
                return;
            }
            Node<T> slider = head;
            while (slider.Next != null) slider = slider.Next;
            slider.Next = item;
            count++;
        }
        public T pop()
        {
            if (IsEmpty) throw new InvalidOperationException("Очередь пуста");
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
        public T front()
        {
            if (IsEmpty) throw new InvalidOperationException("Очередь пуста");
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

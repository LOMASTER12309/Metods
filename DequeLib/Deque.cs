using System;

namespace DequeLib
{
    public class Deque<T>
    {
        DoublyNode<T> head; // первый
        DoublyNode<T> tail; // последний
        int count;
        public bool IsEmpty
        {
            get { return count == 0; }
        }
        public void AddLast(T obj)
        {
            DoublyNode<T> node = new DoublyNode<T>(obj);
            if (head == null)
                head = node;
            else
            {
                tail.Next = node;
                node.Previous = tail;
            }
            tail = node;
            count++;
        }
        public void AddFirst(T obj)
        {
            DoublyNode<T> node = new DoublyNode<T>(obj);
            DoublyNode<T> temp = head;
            node.Next = temp;
            head = node;
            if (count == 0)
                tail = head;
            else
                temp.Previous = node;
            count++;
        }
        public T RemoveLast()
        {
            if (IsEmpty) throw new InvalidOperationException("Пусто!");
            T data = tail.Data;
            if (count == 1)
            {
                head = tail = null;
            }
            else
            {
                tail = tail.Previous;
                tail.Next = null;
            }
            count--;
            return data;
        }

        public T RemoveFirst()
        {
            if (IsEmpty) throw new InvalidOperationException("Пусто!");
            T data = head.Data;
            if (count == 1)
            {
                head = tail = null;
            }
            else
            {
                head = head.Next;
                head.Previous = null;
            }
            count--;
            return data;
        }
        public int Search(T data)
        {
            int index = 0;
            if (IsEmpty) return -1;
            DoublyNode<T> node = head;
            while (node != null)
                if (node.Data.GetHashCode() == data.GetHashCode()) return index;
                else
                {
                    index++;
                    node = node.Next;
                }
            return -1;
        }
        public bool Remove(T data)
        {
            var dataCode = data.GetHashCode();
            if (head.Data.GetHashCode() == dataCode)
            {
                RemoveFirst();
                return true;
            }
            DoublyNode<T> node = head.Next;
            while (node != null)
                if (node.Data.GetHashCode() == dataCode)
                {
                    node.Previous.Next = node.Next;
                    if (node.Next != null) node.Next.Previous = node.Previous;
                    else tail = null;
                    count--;
                    return true;
                }
                else node = node.Next;
            return false;
        }
        public T[] UploadToArray()
        {
            T[] arr = new T[count];
            int i = 0;
            DoublyNode<T> node = head;
            while (node != null)
            {
                arr[i] = node.Data;
                i++;
            }
            return arr;
        }
    }
    public class DoublyNode<T>
    {
        public DoublyNode(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public DoublyNode<T> Previous { get; set; }
        public DoublyNode<T> Next { get; set; }
    }
}

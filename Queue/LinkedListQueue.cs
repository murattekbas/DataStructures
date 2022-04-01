using DoublyLinkedList;

namespace Queue
{
    public class LinkedListQueue<T> : IQueue<T>
    {
        private readonly DoublyLinkedList<T> list = new DoublyLinkedList<T>();
        public int Count { get; private set; }

        public T Dequeue()
        {
            if (Count == 0) throw new Exception("nothing to remove");
            var temp=list.RemoveFirst();
            Count--;
            return temp;
        }

        public void Enqueue(T value)
        {
            if (value == null) throw new ArgumentNullException("value");
            list.AddLast(value);
            Count++;
        }

        public T Peek()
        {
            if (Count == 0) throw new Exception("nothing to show");
            return list.Head.Value;
        }
    }
}
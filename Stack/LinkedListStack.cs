using SinglyLinkedList;

namespace Stack
{
    public class LinkedListStack<T> : IStack<T>
    {
        public int Count { get; private set; }
        private readonly SinglyLinkedList<T> list = new SinglyLinkedList<T>();

        public T Peek()
        {
            if (Count == 0) throw new Exception("nothing to peek");
            return list.Head.Value;
        }

        public T Pop()
        {
            if (Count == 0) throw new Exception("nothing to pop");
            var temp = list.RemoveFirst();
            Count--;
            return temp;
        }

        public void Push(T value)
        {
            if (value == null) throw new ArgumentNullException("value");
            list.AddFirst(value);
            Count++;
        }
    }
}
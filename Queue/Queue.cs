namespace Queue
{
    public class Queue<T>
    {
        private readonly IQueue<T> _queue;
        public int Count=>_queue.Count;

        public Queue(QueueType queueType=QueueType.Array)
        {
            if (queueType == QueueType.Array)
            {
                _queue = new ArrayQueue<T>();
            }
            else 
            {
                _queue = new LinkedListQueue<T>();
            }
        }

        public void EnQueue(T value)
        {
            _queue.Enqueue(value);
        }
        public T DeQueue()
        {
            return _queue.Dequeue();
        }

        public T Peek()
        {
            return _queue.Peek();
        }
    }

    public interface IQueue<T>
    {
        int Count { get; }
        public void Enqueue(T value);
        public T Dequeue();
        public T Peek();
    }

    public enum QueueType
    {
        Array=0,       //List<T>
        LinkedList=1   //DoublyLinkedList<T>
    }
}

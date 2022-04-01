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
            else if(queueType==QueueType.LinkedList) 
            {
                _queue = new LinkedListQueue<T>();
            }
        }
    }

    public interface IQueue<T>
    {
        int Count { get; }
        public void Enqueue(T value);
        public void Dequeue();
    }

    public enum QueueType
    {
        Array=0,       //List<T>
        LinkedList=1   //DoublyLinkedList<T>
    }
}

namespace Queue
{
    public class ArrayQueue<T> : IQueue<T>
    {
        private readonly List<T> list=new List<T>();   
        public int Count {get; private set;}    
        public T Dequeue()
        {
            if (Count == 0) throw new Exception("nothing to remove");
            var temp = list[0];
            list.RemoveAt(0);
            Count--;
            return temp;
        }
        public void Enqueue(T value)
        {
           if (value == null) throw new ArgumentNullException("value");
           list.Add(value);
           Count++;
        }
        public T Peek()
        {
            if (Count == 0) throw new Exception("nothing to show");
            return list[0];
        }
    }
}
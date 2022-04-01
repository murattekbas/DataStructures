namespace Stack
{
    public class ArrayStack<T> : IStack<T>
    {
        public int Count {get;private set;}
        private readonly List<T> list=new List<T> ();

        public T Peek()
        {
            if (Count == 0) throw new Exception("nothing to peek");
            return list[list.Count - 1];
        }
        public T Pop()
        {
            if (Count == 0) throw new Exception("nothing to pop");
            var temp=list[list.Count-1];
            list.RemoveAt(list.Count - 1);
            Count--;
            return temp;
        }
        public void Push(T value)
        {
            if (value == null) throw new ArgumentNullException ("value");   
            list.Add(value);
            Count++; 
        }
    }
}
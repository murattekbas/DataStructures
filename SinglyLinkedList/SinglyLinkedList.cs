using System.Collections;

namespace SinglyLinkedList
{
    public class SinglyLinkedList<T>:IEnumerable<T>
    {
        public SinglyLinkedListNode<T>? Head { get; set; }
        private bool isHeadNull => Head == null;
        public SinglyLinkedList()
        {

        }
        public SinglyLinkedList(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                this.AddFirst(item);
            }
        }
        public void AddFirst(T value)
        {
            var newNode = new SinglyLinkedListNode<T>(value);
            newNode.Next = Head;
            Head = newNode;
        }
        public void AddLast(T value)
        {
            var newNode = new SinglyLinkedListNode<T>(value);

            if (isHeadNull)
            {
                Head = newNode;
                return;
            }

            var current = Head;
            while (current?.Next != null)
            {
                current = current.Next;
            }

            if (current != null) current.Next = newNode;
        }
        public void AddAfter(SinglyLinkedListNode<T> refNode, T value)
        {
            if (refNode == null) throw new ArgumentException("Reference node can not be null.");
            if (isHeadNull)
            {
                AddFirst(value);
                return;
            }
            var newNode = new SinglyLinkedListNode<T>(value);
            var current = Head;
            while (current != null)
            {
                if (current.Equals(refNode))
                {
                    newNode.Next = current.Next;
                    current.Next = newNode;
                    return;
                }
                current = current.Next;
            }
            throw new ArgumentException("The reference node is not in this list.");
        }
        public void AddAfter(SinglyLinkedListNode<T> refNode, SinglyLinkedListNode<T> newNode)
        {
            throw new NotImplementedException();
        }
        public void AddBefore(SinglyLinkedListNode<T> refNode,T value)
        {
            throw new NotImplementedException();
        }
        public void AddBefore(SinglyLinkedListNode<T> refNode, SinglyLinkedListNode<T> newNode)
        {
            throw new NotImplementedException();
        }
        public T RemoveFirst()
        {
            if (isHeadNull)
            {
                throw new Exception("Nothing to remove");
            }
            var firstValue = Head.Value;
            Head = Head.Next;
            return firstValue;
        }
        public T RemoveLast()
        {
            if (isHeadNull)
            {
                throw new Exception("Nothing to remove");
            }
            var current = Head;
            SinglyLinkedListNode<T> prev = null;
            while (current.Next != null)
            {
                prev = current;
                current = current.Next;
            }
            var lastValue = prev.Next.Value;
            prev.Next = null;
            return lastValue;
        }
        public void Remove(T value)
        {
            if (isHeadNull) throw new Exception("Nothing to remove");
            if (value==null) throw new ArgumentNullException("value");
            var current = Head;
            SinglyLinkedListNode<T> prev = null;

            do
            {
                if (current.Value.Equals(value))
                {
                    if (current.Next == null)
                    {
                        if (prev == null)
                        {
                            Head = null;
                            return;
                        }
                        else
                        {
                            prev.Next = null;
                            return;
                        }
                    }
                    else
                    {
                        //Head
                        if (prev == null)
                        {
                            Head = Head.Next;
                            return;
                        }
                        //ara düğüm
                        else
                        {
                            prev.Next = current.Next;
                            return;
                        }
                    }
                }
                prev = current;
                current = current.Next;
            } while (current!=null);

            throw new ArgumentException("nothing to remove-could not be found in the list");
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new SinglyLinkedListEnumerator<T>(Head);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

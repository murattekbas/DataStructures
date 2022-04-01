using System.Collections;

namespace DoublyLinkedList
{
    public class DoublyLinkedList<T>:IEnumerable
    {
        public DoublyLinkedListNode<T>? Head { get; set; }
        public DoublyLinkedListNode<T>? Tail { get; set; }
        private bool isHeadNull=>Head == null;
        private bool isTailNull => Tail == null;

        public DoublyLinkedList()
        {

        }

        public DoublyLinkedList(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                AddLast(item);
            }
        }

        public void AddFirst(T value)
        {
            var newNode = new DoublyLinkedListNode<T>(value);
            if (Head != null)
            {
                Head.Prev = newNode;

            }
            newNode.Next = Head;
            newNode.Prev = null;
            Head = newNode;

            if (Tail == null)
            {
                Tail = Head;
            }
        }
        public void AddLast(T value)
        {
            if (Tail == null)
            {
                AddFirst(value);
                return;
            }
            var newNode = new DoublyLinkedListNode<T>(value);
            Tail.Next = newNode;
            newNode.Next = null;
            newNode.Prev = Tail;
            Tail = newNode;

        }
        public void AddAfter(DoublyLinkedListNode<T> refNode, DoublyLinkedListNode<T> newNode)
        {
            if (refNode == null)
            {
                throw new ArgumentNullException();
            }

            if (refNode == Head && refNode == Tail)
            {
                refNode.Next = newNode;
                refNode.Prev = null;
                newNode.Prev = refNode;
                newNode.Next = null;
                Head = refNode;
                Tail = newNode;
                return;
            }

            if (refNode != Tail)
            {
                newNode.Prev = refNode;
                newNode.Next = refNode.Next;
                refNode.Next.Prev = newNode;
                refNode.Next = newNode;
            }
            else
            {
                newNode.Prev = refNode;
                newNode.Next = null;
                refNode.Next = newNode;
                Tail = newNode;
            }
        }
        public void AddBefor(DoublyLinkedListNode<T> refNode, DoublyLinkedListNode<T> newNode)
        {
            throw new NotImplementedException();
        }
        public T RemoveFirst()
        {
            if (isHeadNull)
            {
                throw new Exception("Nothing to remove");
            }
            var temp = Head.Value;
            if (Head == Tail)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                Head = Head.Next;
                Head.Prev = null;
            }
            return temp;
        }

        public T RemoveLast()
        {
            if (isTailNull)
            {
                throw new Exception("Nothing to remove");
            }
            var temp = Tail.Value;
            if (Head == Tail)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                Tail.Prev.Next = null;
                Tail = Tail.Prev;
            }
            return temp;
        }

        public void Delete(T value)
        {
            if (isHeadNull)
                throw new Exception("Empty list");

            if (Head == Tail)
            {
                if (Head.Value.Equals(value)) 
                {
                    RemoveFirst();
                }
                return;
            }
            var current = Head;

            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    if (current.Prev == null)
                    {
                        current.Next.Prev = null;
                        Head = current.Next;
                    }
                    else if (current.Next == null)
                    {
                        current.Prev.Next = null;
                        Tail = current.Prev;
                    }
                    else
                    {
                        current.Prev.Next = current.Next;
                        current.Next.Prev = current.Prev;
                    }
                    break;
                }
                current = current.Next;
            }
        }

        private List<DoublyLinkedListNode<T>> GetAllNodes()
        {
            var list = new List<DoublyLinkedListNode<T>>();
            var current = Head;
            while (current != null)
            {
                list.Add(current);
                current = current.Next;
                
            }
            return list;
        }

        public IEnumerator GetEnumerator()
        {
            return GetAllNodes().GetEnumerator();
        }
    }
}

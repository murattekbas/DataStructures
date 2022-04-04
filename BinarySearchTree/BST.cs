using BinaryTree;
using System.Collections;

namespace BinarySearchTree
{
    public class BST<T> : IEnumerable<T> where T : IComparable
    {
        public Node<T>? Root { get;set; }
        public BST()
        {

        }
        public BST(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Add(item);
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Add(T value)
        {
            if (value == null) throw new ArgumentNullException("value");
            var newNode=new Node<T>(value);

            if(Root == null) 
            {
                Root = newNode;
            }
            else
            {
                var current=Root;
                Node<T> parent;
                while (true)
                {
                    parent = current;
                    // Sol alt ağaç
                    if (value.CompareTo(current.Value)<0)
                    {
                        current = current.Left;
                        if (current == null)
                        {
                            parent.Left = newNode;
                            break;
                        }
                    }
                    //Sağ alt ağaç
                    else
                    {
                        current=current.Right;
                        if(current == null)
                        {
                            parent.Right = newNode;
                            break;
                        }
                    }
                }
            }
        }

        public Node<T> FindMin(Node<T> root)
        {
            var current = root;
            while (!(current.Left == null))
                current = current.Left;
            return current;
        }

        public Node<T> FindMax(Node<T> root)
        {
            var current = root;
            while (!(current.Right == null))
                current = current.Right;
            return current;
        }

        public Node<T> Find(Node<T> root,T key)
        {
            if (key == null) throw new ArgumentNullException();
            var current = root;
            while (key.CompareTo(current.Value)!=0)
            {
                if (key.CompareTo(current.Value) < 0)
                {
                    current = current.Left;
                }
                else
                {
                    current = current.Right;
                }
                if (current == null)
                    throw new Exception("could not be found");
            }
            return current;
        }

        public Node<T> Remove(Node<T> root,T key)
        {
            if (root == null) throw new ArgumentNullException();

            //RECURSIVE
            if (key.CompareTo(root.Value) < 0)
            {
                root.Left = Remove(root.Left, key);

            }
            else if (key.CompareTo(root.Value) > 0)
            {
                root.Right= Remove(root.Right, key);    
            }
            else
            {
                //Silme
                //Tek çocuk ya da çocuksuz
                if (root.Left == null)
                {
                    return root.Right;
                }
                else if (root.Right == null)
                {
                    return root.Left;
                }
                root.Value = FindMax(root.Right).Value;
                root.Right = Remove(root.Right, root.Value);
            }
            return root;


        }
    }
}

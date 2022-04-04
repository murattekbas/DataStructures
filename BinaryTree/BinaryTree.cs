namespace BinaryTree
{
    public class BinaryTree<T> where T : IComparable
    {
        public List<Node<T>> list { get;private set; }
        public BinaryTree()
        {
            list = new List<Node<T>>();
        }

        //LEFT - ROOT - RIGHT
        public List<Node<T>> InOrder(Node<T> root)
        {
            if (!(root == null))
            {
                InOrder(root.Left);
                list.Add(root);
                InOrder(root.Right);    
            }
            return list;
        }  
        public List<Node<T>> InOrderNonRecursiveTraversal(Node<T> root)
        {
            var list = new List<Node<T>>();
            var S = new Stack.Stack<Node<T>>();
            Node<T> currentNode = root;
            bool done = false;
            while (!done)
            {
                if (currentNode != null)
                {
                    S.Push(currentNode);
                    currentNode = currentNode.Left;
                }
                else
                {
                    if (S.Count == 0)
                    {
                        done = true;
                    }
                    else
                    {
                        currentNode=S.Pop();
                        list.Add(currentNode);
                        currentNode=currentNode.Right;
                    }
                }
            }
            return list;
            
        }
        // ROOT - LEFT - RIGHT
        public List<Node<T>> PreOrder(Node<T> root)
        {
            if (!(root == null))
            {
                list.Add(root);
                PreOrder(root.Left);
                PreOrder(root.Right);
            }
            return list;
        }
        // ROOT - LEFT - RIGHT
        public List<Node<T>> PreOrderNonRecursiveTraversal(Node<T> root)
        {
            var list=new List<Node<T>>();   
            var S=new Stack.Stack<Node<T>>();
            if (root == null) return list;

            S.Push(root);

            while (!(S.Count==0))
            {
                var temp=S.Pop();
                list.Add(temp);
                if (temp.Right!=null)
                    S.Push(temp.Right);
                if (temp.Left!=null)
                    S.Push(temp.Left);
            }

            return list;
        }
        // LEFT - RIGHT - ROOT
        public List<Node<T>> PostOrder(Node<T> root)
        {
            if (!(root == null))
            {
                PreOrder(root.Left);
                PreOrder(root.Right);
                list.Add(root);
            }
            return list;
        }
        // LEFT - RIGHT - ROOT
        public List<Node<T>> PostOrderNonRecursiveTraversal(Node<T> root)
        {
            throw new NotImplementedException();
        }

        public void ClearList() => list.Clear();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void ClearList() => list.Clear();
    }
}

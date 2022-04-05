// See https://aka.ms/new-console-template for more information
using BinaryTree;

var bt = new BinaryTree<char>();
bt.Root = new Node<char>('F');

bt.Root.Left = new Node<char>('A');
bt.Root.Right = new Node<char>('T');

Console.WriteLine($"Deepest Node: {bt.DeepestNode(bt.Root)}");



Console.ReadKey();

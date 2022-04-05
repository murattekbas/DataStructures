// See https://aka.ms/new-console-template for more information

using BinarySearchTree;
using BinaryTree;

var bst = new BST<int>();
bst.Add(12);
bst.Add(3);
bst.Add(14);
bst.Add(2);
bst.Add(78);
bst.Add(34);
bst.Add(2);


var BST_list = new BST<int>(new int[] { 23, 16, 45, 3, 22, 37, 99 });
var bt=new BinaryTree<int>();
bt.InOrder(BST_list.Root).
    ForEach(node => Console.Write($"{node,-3} "));
bt.ClearList();
Console.WriteLine();

bt.PreOrder(BST_list.Root).
    ForEach(node => Console.Write($"{node,-3} "));
bt.ClearList();
Console.WriteLine();

bt.PostOrder(BST_list.Root).
    ForEach(node => Console.Write($"{node,-3} "));

Console.WriteLine();
bt.InOrderNonRecursiveTraversal(BST_list.Root).
    ForEach(node => Console.Write($"{node,-3} "));

Console.WriteLine();
bt.PreOrderNonRecursiveTraversal(BST_list.Root).
    ForEach(node => Console.Write($"{node,-3} "));

Console.WriteLine();
bt.LevelOrderNonRecursiveTraversal(BST_list.Root).
    ForEach(node => Console.Write($"{node,-3} "));

Console.WriteLine($"Mimimum value: {BST_list.FindMin(BST_list.Root)}");
Console.WriteLine($"Maximum value: {BST_list.FindMax(BST_list.Root)}");

//BST_list.Find(BST_list.Root, 20);
BST_list.Find(BST_list.Root,16);


Console.WriteLine("------------");
var bst1 = new BST<int>(new int[] { 23, 16, 45, 3, 22, 37, 99 });
bst1.Remove(bst1.Root, 37);

Console.WriteLine($"Number of Full Nodes               :"+$"{BinaryTree<int>.NumberOfFullNodes(bst1.Root)}");
Console.WriteLine($"Number of Half Nodes               :" + $"{BinaryTree<int>.NumberOfHalfNodes(bst1.Root)}");


var bst2 = new BST<int>(new int[] { 23, 16, 45, 3, 22, 37, 99 });
new BinaryTree<int>().PrintPaths(bst2.Root);

Console.ReadKey();

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


Console.ReadKey();

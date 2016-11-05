BinarySearchTree in C#
================

[![Build status](https://ci.appveyor.com/api/projects/status/8lgxn4qjl9pm0n9s?svg=true)](https://ci.appveyor.com/project/jeff-pang/binarysearchtree)

This project is a basic C# BST implementation. It demonstrate a few simple operations of BST:
* Find
* Insert
* Delete
* Inorder Traversal
* Preorder Traversal
* Postorder Traversal
* Levelorder Traversal
* Min
* Max

*Note: Delete operation requires a find operation as first step. So in order to simplify the example, the find operation is not implemented within the Delete(Node n) operation, just call Node n=Find(k) to get the node in question and pass it into the Delete function. Example:*

```
Node n=tree.Find(10);
tree.Delete(n);
```

Todo:
* More unit tests for demonstrations

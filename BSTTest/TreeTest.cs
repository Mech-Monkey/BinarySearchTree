using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BinarySearchTree;

namespace BSTTest
{
    [TestClass]
    public class TreeTest
    {
        [TestMethod]
        public void insert_and_inorder_traversal()
        {
            Tree t = new Tree();
            ulong[] randomnumbers = new ulong[] { 5, 3, 1, 8, 4, 2, 6, 9, 7, 0 };
            for(int x=0;x<randomnumbers.Length;x++)
            {
                t.Insert(randomnumbers[x]);
            }

            ulong[] ordered = t.Inorder();
            ulong[] expected = new ulong[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Assert.IsTrue(ordered.SequenceEqual(expected));
        }

        [TestMethod]
        public void insert_delete_and_inorder_traversal()
        {
            Tree t = new Tree();
            ulong[] randomnumbers = new ulong[] { 15, 5, 3, 1, 10, 8, 4, 2, 13, 6, 9, 7, 0, 11,12 };
            for (int x = 0; x < randomnumbers.Length; x++)
            {
                t.Insert(randomnumbers[x]);
            }

            ulong[] expected = new ulong[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 11, 12, 13, 15 };
            Node n=t.Find(10);
            t.Delete(n);
            ulong[] deletedOrder = t.Inorder();

            Assert.IsTrue(deletedOrder.SequenceEqual(expected));
        }
    }
}

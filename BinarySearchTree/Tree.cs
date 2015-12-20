using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    public class Tree
    {
        public Node Root { get; private set; }
        public Tree()
        {
        }

        public void Insert(ulong k)
        {
            //initial case
            if(Root==null)
            {
                Root = new Node() { Key = k };                
            }
            else
            {
                Node curr = Root;

                while (curr != null)
                {
                    if (curr.Key == k)
                    {
                        break;//cannot insert duplicate, we halt
                    }
                    else if (curr.Key > k)
                    {
                        if (curr.Left == null)//left leaf node
                        {
                            curr.Left = new Node() { Key = k };
                            curr.Left.Parent = curr;//optional parent reference
                            break;
                        }
                        else
                        {
                            curr = curr.Left;
                        }
                    }
                    else
                    {
                        if (curr.Right == null)//right leaf node
                        {
                            curr.Right = new Node() { Key = k };
                            curr.Right.Parent = curr;//optional parent reference
                            break;
                        }
                        else
                        {
                            curr = curr.Right;
                        }
                    }
                }
            }
        }

        public void Delete(Node n)
        {
            Node curr = n;
            Node parent = curr.Parent;

            //found, so we delete
            if (curr != null)
            {
                if (curr.Left == null && curr.Right == null)
                {
                    if(parent==null)
                    {
                        Root = new Node();
                    }
                    else if (parent.Left == curr)
                    {
                        parent.Left = null;
                    }
                    else if (parent.Right == curr)
                    {
                        parent.Right = null;
                    }

                }
                else if (curr.ChildrenCount == 1)//Have 1 child, left or right
                {
                    if (parent != null)
                    {
                        Node successor=null;
                        if (curr.Left != null)
                        {
                            successor = curr.Left;
                        }
                        else if (curr.Right != null)
                        {
                            successor = curr.Right;
                        }

                        if(parent.Left==curr)
                        {
                            parent.Left = successor;
                        }
                        else
                        {
                            parent.Right = successor;
                        }                        
                    }
                    else//root node, child to replace
                    {
                        curr.Parent = null;
                        Root = curr.Left?? curr.Right;
                    }
                }
                else if (curr.ChildrenCount == 2)
                {
                    Node successor = Min(curr.Right);//get the next higher key, which is the smallest from the current node's right branch
                    curr.Key = successor.Key;
                    Delete(successor);
                }
            }
        }

        public Node Min(Node n=null)
        {
            if(n==null)
            {
                n = Root;
            }

            Node curr = n;
            while (curr.Left != null)
            {
                curr = curr.Left;
            }
            return curr;
        }

        public Node Max(Node n = null)
        {
            if (n == null)
            {
                n = Root;
            }

            Node curr = n;
            while (curr.Left != null)
            {
                curr = curr.Left;
            }
            return curr;
        }

        public ulong[] Preorder(Node n=null)
        {
            if (n == null)
            {
                n = Root;
            }

            Node curr = null;
            Stack<Node> stack = new Stack<Node>();
            stack.Push(Root);
            List<ulong> items = new List<ulong>();
            
            while(stack.Count>0)
            {
                curr = stack.Pop();
                for(int x=0;x<curr.Children.Length;x++)
                {
                    stack.Push(curr.Children[x]);
                }
                items.Add(curr.Key);
                Console.WriteLine(curr.Key);
            }

            return items.ToArray();

        }

        public ulong[] Postorder(Node n=null)
        {
            if (n == null)
            {
                n = Root;
            }

            Node curr = n;
            Stack<Node> stack = new Stack<Node>();
            List<ulong> result = new List<ulong>();
            stack.Push(curr);

            while(stack.Count>0)
            {
                curr = stack.Pop();
                result.Add(curr.Key);

                if (curr.Left != null)
                {
                    stack.Push(curr.Left);
                }
                if (curr.Right != null)
                {
                    stack.Push(curr.Right);
                }
            }

            return result.ToArray();
        }

        public ulong[] Inorder(Node n=null)
        {
            if (n == null)
            {
                n = Root;
            }

            Node curr = n;
            Stack<Node> stack = new Stack<Node>();
            List<ulong> items = new List<ulong>();
            
            while(stack.Count>0 || curr!=null)
            {
                if(curr!=null)
                {
                    stack.Push(curr);
                    curr = curr.Left;//move to left child
                }
                else
                {
                    curr = stack.Pop();
                    items.Add(curr.Key);
                    curr = curr.Right;//move to right child
                }

            }

            return items.ToArray();
        }

        public ulong[] Levelorder(Node n=null)
        {
            if (n == null)
            {
                n = Root;
            }

            Queue<Node> q = new Queue<Node>();
            List<ulong> items = new List<ulong>();
            q.Enqueue(n);

            while(q.Count>0)
            {
                Node curr=q.Dequeue();
                items.Add(curr.Key);

                for(int x=0;x<curr.Children.Length;x++)
                {
                    if (curr.Children[x] != null)
                    {
                        q.Enqueue(curr.Children[x]);
                    }
                }

            }

            return items.ToArray();

        }

        public Node Find(ulong k)
        {
            Node curr = Root;

            while (curr != null)
            {
                if (curr.Key == k)
                {
                    return curr;
                }
                else if (curr.Key > k)
                {
                    curr = curr.Left;
                }
                else
                {
                    curr = curr.Right;
                }
            }

            return null;
        }
    }
}

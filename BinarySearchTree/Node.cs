using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    public class Node
    {
        public ulong Key;
        public Node[] Children;
        /// <summary>
        /// optional
        /// </summary>
        public Node Parent;
        public int ChildrenCount
        {
            get
            {
                int cnt = 0;

                cnt = Left != null ? cnt+1 : cnt; 
                cnt = Right != null ? cnt+1 : cnt;

                return cnt;
            }
        }
        public Node()
        {
            Children = new Node[] { null, null };
        }

        public Node Left
        {
            get 
            {
                return Children[0];
            }
            set
            {
                Children[0] = value;
            }
        }
        public Node Right
        {
            get
            {
                return Children[1];
            }
            set
            {
                Children[1] = value;
            }
        }

        public override string ToString()
        {
            return Key.ToString();
        }
    }
}

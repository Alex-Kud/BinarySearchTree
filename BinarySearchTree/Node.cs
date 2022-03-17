using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySearchTree
{
    class Node
    {
        public long Value { get; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(long val)
        {
            Value = val;
        }

    }
}

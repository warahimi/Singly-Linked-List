using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    internal class Node
    {
        public int Data { get; set; } // store the data in the Node
        public Node Next { get; set; } // store the pointer to the next node

        public Node(int data)
        {
            this.Data = data;
            this.Next = null;
        }

    }
}

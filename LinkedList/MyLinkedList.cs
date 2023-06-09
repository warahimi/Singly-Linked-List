using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    internal class MyLinkedList
    {
        private Node head; // reference to the head (first) node in the list
        private Node tail; // reference to the tail (last) node in the list
        private int len; // length of the linked list


        public MyLinkedList() 
        {
            this.head = this.tail = null; // initializing the list with null head nad tail (Emtpty list)
            this.len = 0; // initially set the linked list size to 0
        }

        public void insertAtEnd(int data)
        {
            // Created a new node with the given data.
            Node newNode = new Node(data);
            if(this.head == null) 
            {
                // if the list is empty, make the new node the head node
                this.head = this.tail = newNode;
                len++;
            }
            else
            {
                //Node nextNode= this.head;
                //while(nextNode.Next !=null)
                //{
                //    nextNode = nextNode.Next;
                //}
                //nextNode.Next = newNode;
                tail.Next= newNode;
                tail = newNode;
                len++;
            } 
        }

        public void insertAfter(int target, int data)
        {
            // Create a new node with the given data.
            Node newNode = new Node(data); 

            // Iterate through the linked list while the nextNode
            // node isn't null and doesn't match the "target" value.
            Node temp = head;
            while (temp != null && temp.Data != target)
            {
                temp = temp.Next;  // Move to the next node.
            }

            // If the "target" node was found,
            // insert the new node target it.
            if (temp != null && temp.Data == target)
            {
                newNode.Next = temp.Next;  // The next node of the new node is the nextNode next node of the "target" node.
                temp.Next = newNode;  // The next node of the "target" node is the new node.
                len++;
            }
            else
            {
                Console.WriteLine("Item not found");
            }
        }

        public void insertBefore(int target, int data)
        {
            // Create a new node with the given data.
            Node newNode = new Node(data);  

            // Check if the list is empty. If so, print a message and return.
            if (head == null)
            {
                Console.WriteLine("List is empty");
                return;
            }

            // Special case: If the head node is the "target" node, adjust the head and return.
            if (head.Data == target)
            {
                newNode.Next = head;  // The next node of the new node is the nextNode head.
                head = newNode;  // The new head is the new node.
                len++;
                return;
            }

            // Iterate through the linked list while the nextNode node isn't null and doesn't match the "target" value.
            Node cur = head;
            Node prev = null;
            while (cur != null && 
                cur.Data != target)
            {
                prev = cur;  // Save the nextNode node as the prev node.
                cur = cur.Next;  // Move to the next node.
            }

            // If the "target" node was found, insert the new node target it.
            if (cur != null)
            {
                prev.Next = newNode;  // The next node of the prev node is the new node.
                newNode.Next = cur;  // The next node of the new node is the "target" node.
                len++;
            }
            else
            {
                Console.WriteLine("Item not found");
            }
        }

        public void insertAtBeginning(int data)
        {
            // Creating a new node with the provided data.
            Node newNode = new Node(data);

            // If the list is empty, we make the new node both the head and the tail of the list.
            if (isEmpty())
            {
                // newNode is the only node in the list. Hence, it's both the head and the tail.
                this.head = this.tail = newNode;

                // Increasing the length of the list by one since we've added a node.
                len++;
            }
            else
            {
                // If the list is not empty, we insert the new node at the beginning.

                // We make the new node's 'Next' reference point to the nextNode head of the list.
                newNode.Next = head;

                // We then update the head of the list to be the new node.
                this.head = newNode;

                // Increasing the length of the list by one since we've added a node.
                len++;
            }
        }


        public void insertAtPos(int data, int pos)
        {
            // Creating a new node with the provided data.
            Node newNode = new Node(data);

            // Checking if the provided position is valid.
            // It's valid if it lies between 1 and size() + 1 (inclusive).
            // 'size() + 1' is considered valid because it means insertion at the end of the list.
            if (pos < 1 || pos > size() + 1)
            {
                // Printing an error message and terminating the function if the position is not valid.
                Console.WriteLine("Invalid Position");
                return;
            }

            // If the position is 'size() + 1', it means we need to insert at the end of the list.
            // We already have a separate function for this, so we call that function and return.
            if (pos == size() + 1)
            {
                insertAtEnd(data);
                return;
            }

            // If the position is 1, it means we need to insert at the beginning of the list.
            // We already have a separate function for this, so we call that function and return.
            if (pos == 1)
            {
                insertAtBeginning(data);
                return;
            }

            // If the position is neither the beginning nor the end, it means we need to insert somewhere in the middle.

            // We initialize a counter to keep track of the nextNode position.
            int counter = 1;

            // We initialize 'nextNode' to the head of the list and will move it forward until we reach the desired position.
            Node temp = head;

            // We move 'nextNode' forward until we reach the node right before the desired position.
            // The loop stops when 'counter' is equal to 'pos - 1'.
            while (counter < pos - 1) // O(n)
            {
                counter++;
                temp = temp.Next;
            }

            // We make the 'Next' reference of the new node point to the node after the desired position.
            newNode.Next = temp.Next;

            // We make the 'Next' reference of the node before the desired position point to the new node,
            // effectively inserting the new node at the desired position.
            temp.Next = newNode;

            // Increasing the length of the list by one since we've added a node.
            len++;
        }

        public void insertAtRandomPos(int data)
        {
            // Creating a new instance of the Random class.
            // This will be used to generate a random number.
            Random random = new Random();

            // Generating a random number between 1 and 'this.len' (inclusive).
            // This will be the position where we will insert the new node.
            int pos = random.Next(1, this.len);

            // We call the 'insertAtPos' method to insert the new node at the randomly generated position.
            // We add 1 to 'pos' because 'Random.Next(1, this.len)' generates a number that can be equal to 'this.len',
            // but 'insertAtPos' considers 'this.len + 1' as the position at the end of the list.
            insertAtPos(data, pos + 1);
        }


        public int deleteFromBeginning() // O(1)
        {
            // Checking if the list is empty.
            // We can't delete a node from an empty list.
            if (isEmpty())
            {
                // Printing an error message and returning -1 to indicate that the operation failed.
                Console.WriteLine("List is empty");
                return -1;
            }

            // Storing the data of the head node.
            // We will return this value after deleting the node.
            int data = head.Data;

            // Updating the head of the list to be the next node.
            // This effectively removes the nextNode head node from the list.
            head = head.Next;

            // Decreasing the length of the list by one since we've deleted a node.
            this.len--;

            // If the list is now empty after the deletion, we need to update the tail to null.
            if (isEmpty())
                this.tail = head;

            // Returning the data of the deleted node.
            return data;
        }


        public void deleteFromEnd()
        {
            if(isEmpty())
            {
                Console.WriteLine("List is empty");
                return;
            }
            if(head.Next == null)
            {
                this.head = null;
                this.tail = null;
                len--;
                return;
            }
            //Node prev = null;
            Node temp = head;

            //while(nextNode.Next != null)
            //{
            //    prev = nextNode;
            //    nextNode = nextNode.Next;
            //}
            //this.tail = prev;
            //prev.Next = null;
            //int counter = 1;
            //while(counter < this.len -1)
            //{
            //    nextNode = nextNode.Next;
            //    counter++;
            //}
            while(temp.Next.Next != null)
            {
                temp = temp.Next;
            }
            this.tail = temp;
            temp.Next = null;
            len--;
        }

        public void deleteAtPosition(int pos)
        {
            // Checking if the provided position is valid.
            // It's valid if it lies between 1 and 'this.len' (inclusive).
            if (pos < 1 || pos > this.len)
            {
                // Printing an error message and terminating the function if the position is not valid.
                Console.WriteLine("Invalid position");
                return;
            }

            // If the position is 1, it means we need to delete the node at the beginning of the list.
            // We already have a separate function for this, so we call that function and return.
            if (pos == 1)
            {
                deleteFromBeginning();
                return;
            }

            // If the position is 'this.len', it means we need to delete the node at the end of the list.
            // We already have a separate function for this, so we call that function and return.
            if (pos == this.len)
            {
                deleteFromEnd();
                return;
            }

            // If the position is neither the beginning nor the end, it means we need to delete a node from somewhere in the middle.

            // We initialize 'nextNode' to the head of the list and will move it forward until we reach the desired position.
            Node temp = this.head;

            // We initialize a counter to keep track of the nextNode position.
            int counter = 1;

            // We move 'nextNode' forward until we reach the node right before the desired position.
            // The loop stops when 'counter' is equal to 'pos - 1'.
            while (counter < pos - 1)
            {
                temp = temp.Next;
                counter++;
            }

            // We update 'nextNode's next pointer to skip the node at the desired position,
            // effectively removing it from the linked list.
            temp.Next = temp.Next.Next;

            // Decreasing the length of the list by one since we've deleted a node.
            len--;
        }


        public void deleteByKey(int key)
        {
            // Checking if the list is empty.
            // We can't delete a node from an empty list.
            if (isEmpty())
            {
                // Printing an error message and terminating the function if the list is empty.
                Console.WriteLine("The list is empty. Cannot delete");
                return;
            }

            // Special case: if the head node contains the key, we need to delete the head node.
            if (head.Data == key)
            {
                // Updating the head of the list to be the next node.
                // This effectively removes the nextNode head node from the list.
                head = head.Next;

                // If the list is now empty after the deletion, we need to update the tail to null.
                if (isEmpty())
                {
                    this.tail = this.head;
                }

                // Decreasing the length of the list by one since we've deleted a node.
                len--;
                return;
            }

            // If the head node doesn't contain the key, we need to traverse the list to find the node that does.

            // We initialize 'prev' to null and 'nextNode' to the head of the list.
            Node prev = null;
            Node temp = head;

            // We move 'nextNode' forward until we either reach the end of the list or find the node that contains the key.
            // We also move 'prev' forward along with 'nextNode' so that 'prev' always points to the node before 'nextNode'.
            while (temp != null && temp.Data != key)
            {
                prev = temp;
                temp = temp.Next;
            }

            // If 'nextNode' is null, it means we've reached the end of the list and haven't found the key.
            if (temp == null)
            {
                // Printing an error message and terminating the function if the key is not found.
                Console.WriteLine("Item not found");
                return;
            }

            // If 'nextNode' is not null, it means we've found the node that contains the key.

            // We update 'prev's next pointer to skip the node that contains the key,
            // effectively removing it from the linked list.
            prev.Next = temp.Next;

            // Decreasing the length of the list by one since we've deleted a node.
            len--;

            // If the node we deleted was the tail node, we need to update the tail to be 'prev'.
            if (temp == tail)
                this.tail = prev;
        }


        public void clear()
        {
            // Setting the head of the list to null.
            // This effectively removes all nodes from the list since no node is reachable from the head now.
            this.head = null;

            // Setting the tail of the list to null.
            // Since the list is now empty, there is no tail node.
            this.tail = null;

            // Setting the length of the list to 0.
            // Since the list is now empty, its length is 0.
            this.len = 0;
        }



        public void deleteDuplicates()
        {
            // Initializing a HashSet to store unique values of the linked list.
            // HashSet offers constant time complexity for add, remove and contains operations. So, it's suitable for our purpose.
            HashSet<int> set = new HashSet<int>();

            // If the list is empty or contains only a single node, there's no possibility of duplicates.
            // So, we return immediately.
            if (isEmpty() || this.len == 1)
            {
                return;
            }

            // 'prev' is a pointer to the node before the one we are currently examining.
            // Initialized to null because at the beginning there's no node before head.
            Node prev = null;

            // 'nextNode' is a pointer to the nextNode node that we are examining.
            // We start from the head of the linked list.
            Node temp = this.head;

            // We loop through each node in the linked list.
            while (temp != null)
            {
                // If the HashSet already contains the value of the nextNode node,
                // it means we've seen this value before and this is a duplicate node.
                if (set.Contains(temp.Data))
                {
                    // We update 'prev's next pointer to skip the nextNode node,
                    // effectively removing it from the linked list.
                    prev.Next = temp.Next;

                    // If the duplicate node is the last node (tail) of the list,
                    // we need to update the tail pointer of the list.
                    if (temp == tail)
                    {
                        this.tail = prev;
                    }

                    // Move to the next node.
                    temp = temp.Next;

                    // Decrease the length of the list by one as we have deleted a node.
                    len--;
                }
                else
                {
                    // If the HashSet does not contain the value of the nextNode node,
                    // it means this is the first time we've encountered this value.
                    // So, we add this value to the HashSet.
                    set.Add(temp.Data);

                    // Move the 'prev' and 'nextNode' pointers one step forward.
                    prev = temp;
                    temp = temp.Next;
                }
            }
        }

        //private bool condition(int data)
        //{
        //    return data % 2 == 0;
        //}
        public void DeleteByCondition(Func<int, bool> condition)
        {
            // Check if the list is empty.
            // If it is, there are no nodes to delete so we return immediately.
            if (head == null)
            {
                return;
            }

            // Special case: handle deletion of the head node(s).
            // If the data of the head node satisfies the condition (specified by the predicate function), delete the head node.
            while (head != null && condition(head.Data))
            {
                // Update the head to the next node, effectively removing the nextNode head node from the list.
                head = head.Next;

                // Decrease the length of the list since we've deleted a node.
                len--;

                // If the list becomes empty after the deletion (i.e., if all nodes were deleted), update the tail to null and return.
                if (len == 0)
                {
                    tail = null;
                    return;
                }
            }

            // Handle deletion of the non-head nodes.

            // Start iterating over the nodes from the (possibly new) head node.
            Node temp = head;
            while (temp.Next != null)
            {
                // If the data of the next node satisfies the condition, delete the next node.
                if (condition(temp.Next.Data))
                {
                    // Update 'nextNode's next pointer to skip the next node, effectively removing it from the list.
                    temp.Next = temp.Next.Next;

                    // Decrease the length of the list since we've deleted a node.
                    len--;

                    // If we've deleted the last node in the list (i.e., if 'nextNode's next pointer is now null), update the tail to be 'nextNode'.
                    if (temp.Next == null)
                    {
                        tail = temp;
                    }
                }
                else
                {
                    // If the next node shouldn't be deleted, just move on to the next node.
                    temp = temp.Next;
                }
            }
        }

        public bool search(int value)
        {
            // Start at the head of the list
            Node temp = head;

            // Loop through the entire list
            while (temp != null)
            {
                // Check if the nextNode node's data matches the value we're searching for
                if (temp.Data == value)
                {
                    // If a match is found, return true
                    return true;
                }

                // If the nextNode node's data doesn't match the value, move on to the next node
                temp = temp.Next;
            }

            // If we've gone through the entire list and haven't found the value, return false
            return false;
        }

        public int getIndex(int value)
        {
            // Start at the head of the list
            Node temp = head;
            int index = 0;
            // Loop through the entire list
            while (temp != null)
            {
                // Check if the nextNode node's data matches the value we're searching for
                if (temp.Data == value)
                {
                    // If a match is found, return true
                    return index;
                }

                // If the nextNode node's data doesn't match the value, move on to the next node
                temp = temp.Next;
                index++;
            }

            // If we've gone through the entire list and haven't found the value, return false
            return -1;
        }

        public void reverse()
        {
            if (isEmpty())
                return;
            Node prev = null; // To keep track of the previous node
            Node temp = head; // To keep track of the temp node
            Node nextNode; // To temporarily store the next node

            // Iterate over the list
            while (temp != null)
            {
                // Temporarily store the next node before changing temp.Next
                nextNode = temp.Next;

                // Reverse the direction of the 'Next' reference
                temp.Next = prev;

                // Move the prev and temp pointers one step forward
                prev = temp;
                temp = nextNode;
            }

            // Update the tail
            tail = head;
            // Once the loop is done, the last node we visited becomes the new head
            head = prev;
        }

        public bool isEmpty()
        { return this.head == null; }
        public void print()
        {
            Node temp= this.head;

            if(this.head ==null)
            {
                Console.WriteLine("The list is empty");
                return;
            }

            while(temp != null) 
            {
                Console.Write(temp.Data + " -> ");
                temp = temp.Next;
            }
            Console.WriteLine();
        }
        public int size() // O(n)
        {
            int size  = 0;
            Node temp = this.head;
            while(temp != null)
            {
                size++;
                temp = temp.Next;
            }
            return size;
        }

        public int length() // O(1)
        {
            return this.len;
        }
    }
}

using System;

namespace StackStuff
{
    public class StackLinkedList<T>
    {
        private Node<T> head;

        public void Push(T data)
        {
            Node<T> toAdd = new Node<T>();
            toAdd.data = data;
            toAdd.next = head;
            head = toAdd;
        }

        public void Pop()
        {
            if(head == null)
            {
                Console.WriteLine("The stack is empty nothing to pop");
            }// end if
            else
            {
                Node<T> tempNode = new Node<T>();
                tempNode = head;
                Console.WriteLine("The stack popped value is: {0}", tempNode.data);
                head = head.next;
            }// end else
        }

        public void Peek()
        {
            if(head == null)
            {
                Console.WriteLine("The stack is empty nothing to peek");
            }// end if
            else
            {
                Console.WriteLine("The stack peeked value is: {0}", head.data);
            }// end else
        }

        public bool IsEmpty()
        {
            if (head == null)
            {
                return true;
            }// end if
            return false;
        }

        public void DeleteStack()
        {
            head = null;
        }

    }
    
    public class Node<T>
    {
        public T data;
        public Node<T> next;
    }
}

using System;

namespace QueuesStuff
{
    public class LinkedListQueue<T>
    {
        private Node<T> Head;

        public void Enqueue(T data)
        {
            Node<T> toAdd = new Node<T>();
            toAdd.data = data;
            if(QueueIsEmpty())
            {   
                Head = toAdd;
            }// end if
            else
            {   
                Node<T> current = Head;
                while(current.next != null)
                {
                    current = current.next;
                }// end while
                current.next = toAdd;
            }// end else
        }

        public void Dequeue()
        {
            if(QueueIsEmpty())
            {
                Console.WriteLine("Queue is empty cannot dequeue");
            }// end if
            else
            {
                Node<T> tempNode = Head;
                Head = Head.next;
                Console.WriteLine("Dequeue: {0}", tempNode.data);
            }// end else
        }

        public void Peek()
        {
            if(QueueIsEmpty())
            {
                Console.WriteLine("Queue is empty cannot peek");
            }// end if
            else
            {
                Console.WriteLine("Peek: {0}", Head.data);
            }// end else
        }

        public bool QueueIsEmpty()
        {
            if(Head == null)
            {
                return true;
            }// end if
            return false;
        }

        public void DeleteQueue()
        {
            Head = null;
        }
    }

    public class Node<T>
    {
        public T data;
        public Node<T> next;
    }
}
using System;

namespace LinkedList
{
    public class SingleLinkedList<T>
    {
        private Node<T> head;

        public void InsertAtFront(T data)
        {
            Node<T> toAdd = new Node<T>();
            toAdd.data = data;
            toAdd.next = head;
            head = toAdd;
        }

        public void InsertAtLocation(int location, T data)
        {
            if (location < 0)
            {
                Console.WriteLine("Location can not be less than one");
                return;
            }// end if
            if(head == null)
            {
                InsertAtFront(data);
            }// end if
            else if (location == 0)
            {
                InsertAtFront(data);
            }// end else if
            else
            {
                int count = 0;
                Node<T> current = head;
                Node<T> toAdd = new Node<T>();
                toAdd.data = data;
                
                while(current.next != null && count != location -1)
                {
                    count++;
                    current = current.next;
                }// end while loop
                toAdd.next = current.next;
                current.next = toAdd;
            }// end else
        }

        public void InsertAtBack(T data)
        {
            if (head == null)
            {
                head = new Node<T>();

                head.data = data;
                head.next = null;
            }// end if
            else
            {
                Node<T> toAdd = new Node<T>();
                toAdd.data = data;

                Node<T> current = head;
                while (current.next != null)
                {
                    current = current.next;
                }// end while loop
                current.next = toAdd;
            }// end else
        }

        public void DeletionAtFront()
        {
            if(head == null)
            {
                Console.WriteLine("Nothing to delete");
                return;
            }// end if
            else if(head.next == null)
            {
                head = null;
            }// end else if
            else
            {
                head = head.next;
            }// end else
        }

        public void DeletionAtLocation(int location)
        {
            if (head == null)
            {
                Console.WriteLine("Nothing to delete");
                return;
            }// end if
            if (location < 0)
            {
                Console.WriteLine("Location can not be less than one");
                return;
            }// end if
            else if(location == 0)
            {
                DeletionAtFront();
            }// end else if
            else
            {
                int count = 0;
                Node<T> current = head;
                Node<T> prev = current;
                while (current.next != null && count != location)
                {
                    prev = current;
                    current = current.next;
                    count++;
                }// end while loop
                prev.next = current.next;
            }// end else
        }

        public void DeletionAtBack()
        {
            if(head == null)
            {
                Console.WriteLine("Nothing to delete");
                return;
            }// end if
            else if(head.next == null)
            {
                head = null;
            }// end else if
            else
            {
                Node<T> current = head;
                Node<T> prev = current;
                while(current.next != null)
                {
                    prev = current;
                    current = current.next;
                }// end while loop
                prev.next = null;
            }// end else
        }

        public void DeleteLinkedList()
        {
            head = null;
        }

        public bool Searching(T data)
        {
            Node<T> current = head;
            if(current == null)
            {
                Console.WriteLine("There is nothing to search");
                return false;
            }// end if
            while (current != null)
            {
                if(current.data.Equals(data))
                {
                    return true;
                }// end if
                current = current.next;
            }// end while loop
            return false;
        }

        public void Traversal()
        {
            Node<T> current = head;
            if(current == null)
            {
                Console.WriteLine("Nothing to print list is empty");
                return;
            }// end if
            while (current != null)
            {
                Console.WriteLine(current.data);
                current = current.next;
            }// end while loop
        }
    }

    public class Node<T>
    {
        public Node<T> next;
        public T data;
    }
}

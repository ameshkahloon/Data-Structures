using System;

namespace QueuesStuff
{
    public class LinearArrayQueue<T>
    {
        private T[] arr;
        private int topOfQueue;
        private int startOfQueue;

        public LinearArrayQueue(int size)
        {
            this.arr = new T[size];
            this.topOfQueue = -1;
            this.startOfQueue = -1;
        }

        public void EnQueue(T value)
        {
            if(IsQueueFull())
            {
                Console.WriteLine("Queue is full cannot enqueue");
            }// end if
            else
            {
                arr[topOfQueue + 1] = value;
                topOfQueue++;
            }// end else
        }

        public void DeQueue()
        {
            if(IsQueueEmpty())
            {
                Console.WriteLine("Queue is empty cannot dequeue");
            }// end if
            else
            {
                if (startOfQueue == topOfQueue)
                {
                    topOfQueue = -1;
                    startOfQueue = -1;
                    Console.WriteLine("Queue will now empty");
                    return;
                }// end if
                Console.WriteLine("Dequeue: {0}", arr[startOfQueue + 1]);
                startOfQueue++;
            }// end else
        }

        public void Peek()
        {
            if(IsQueueEmpty())
            {
                Console.WriteLine("Queue is empty cannot peek");
            }// end if
            else
            {
                Console.WriteLine("Peek: {0}", arr[startOfQueue+1]);
            }// end else
        }

        public bool IsQueueEmpty()
        {
            if (startOfQueue == -1 && topOfQueue == -1)
            {
                return true;
            }// end if
            return false;
        }

        public bool IsQueueFull()
        {
            if(topOfQueue == arr.Length - 1)
            {
                return true;
            }// end if
            return false;
        }

        public void DeleteQueue()
        {
            Console.WriteLine("Queue will now be deleted");
            arr = null;
        }
    }
}

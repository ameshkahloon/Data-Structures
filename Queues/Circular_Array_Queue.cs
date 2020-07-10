using System;

namespace QueuesStuff
{
    public class CircularArrayQueue<T>
    {
        public T[] arr;
        private int topOfQueue;
        private int startOfQueue;

        public CircularArrayQueue(int size)
        {
            this.arr = new T[size];
            this.topOfQueue = -1;
            this.startOfQueue = -1;
        }

        public void EnQueue(T value)
        {
            if (IsQueueFull())
            {
                Console.WriteLine("Queue is full cannot enqueue");
            }// end if
            else if (topOfQueue + 1 == arr.Length){
                topOfQueue = 0;
                arr[topOfQueue] = value;
            }// end else if
            else
            {
                topOfQueue++;
                arr[topOfQueue] = value;
            }// end else
        }

        public void DeQueue()
        {
            if (IsQueueEmpty())
            {
                Console.WriteLine("Queue is empty cannot dequeue");
            }// end if
            else
            {
                Console.WriteLine("Dequeue: {0}", arr[startOfQueue + 1]);
                startOfQueue++;
                if (startOfQueue == topOfQueue)
                {
                    startOfQueue = -1;
                    topOfQueue = -1;
                    Console.WriteLine("Queue is now empty");
                    return;
                }// end if
                else if (startOfQueue + 1 == arr.Length)
                {
                    startOfQueue = -1;
                }// end else if
            }// end else
        }

        public void Peek()
        {
            if (IsQueueEmpty())
            {
                Console.WriteLine("Queue is empty cannot peek");
            }// end if
            else
            {
                Console.WriteLine("Peek: {0}", arr[startOfQueue + 1]);
            }// end else
        }

        public bool IsQueueFull()
        {
            if (topOfQueue == startOfQueue && topOfQueue != -1)
            {
                return true;
            }// end if
            else if(startOfQueue == -1 && topOfQueue + 1 == arr.Length)
            {
                return true;
            }// end else if
            return false;
        }

        public bool IsQueueEmpty()
        {
            if(startOfQueue == -1 && topOfQueue == -1)
            {
                return true;
            }// end if
            return false;
        }

        public void DeleteStack()
        {
            arr = null;
        }
    }
}

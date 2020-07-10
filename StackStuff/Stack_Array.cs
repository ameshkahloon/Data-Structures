using System;

namespace StackStuff
{
    public class StackArray<T>
    {
        private int topOfStack;
        private T[] stack;

        public StackArray(int num)
        {
            topOfStack = -1;
            this.stack = new T[num];
        }

        public void DeleteStack()
        {
            stack = null;
        }

        public void Push(T data)
        {
            if (topOfStack == stack.Length - 1)
            {
                Console.WriteLine("The stack is full cannot push data");
            }// end if
            else
            {
                topOfStack++;
                stack[topOfStack] = data;
            }// end else
        }

        public void Pop()
        {
            if (topOfStack == -1)
            {
                Console.WriteLine("The stack is empty cannot pop data");
            }// end if
            else
            {
                Console.WriteLine("The stack popped value is: {0}", stack[topOfStack]);
                topOfStack--;
            }// end else
        }

        public void Peek()
        {
            if (topOfStack == -1)
            {
                Console.WriteLine("The stack is empty can not peek data");
            }// end if
            else
            {
                Console.WriteLine("The stack peeked value is: {0}", stack[topOfStack]);
            }// end else
        }

        public bool IsEmpty()
        {
            if (topOfStack == -1)
            {
                return true;
            }// end if
            return false;
        }

        public bool IsFull()
        {
            if (topOfStack == stack.Length)
            {
                return true;
            }// end if
            return false;
        }
    }
}

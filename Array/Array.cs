using System;

namespace ArrayStuff
{
    public class Array<T> where T : class
    {
        private T[] arr;
        public Array(int size)
        {
            this.arr = new T[size];
        }

        public bool Search(int find)
        {
            foreach (T element in arr) {
                if (element.Equals(find))
                {
                    return true;
                }// end if
            }// end foreach loop
            return false;
        }

        public void Traverse()
        {
            foreach(T element in arr)
            {
                Console.WriteLine(element);
            }// end foreach loop
        }

        public void Insert(int position, T element)
        {
            try
            {
                arr[position] = element;
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }// end try-catch block
        }

        public void Remove(int position)
        {
            try
            {
                arr[position] = null;
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }// end try-catch block
        }

        public T Access(int position)
        {
            try
            {
                return arr[position];
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }// end try-catch block
            return null;
        }

    }
}
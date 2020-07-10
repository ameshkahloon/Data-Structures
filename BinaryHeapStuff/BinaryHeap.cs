using System;

namespace BinaryHeapStuff
{
    public class BinaryHeap
    {
        private int[] arr;
        private int sizeOfHeap;

        public BinaryHeap(int size)
        {
            this.arr = new int[size + 1];
            this.sizeOfHeap = 0;
        }

        public int? PeekHeap()
        {
            if(arr == null || sizeOfHeap == 0)
            {
                Console.WriteLine("Heap is empty cannot peek");
                return null;
            }// end if
            else
            {
                return arr[1];
            }// end else
        }

        public void SizeOfHeap()
        {
            Console.WriteLine("Size of heap is {0}", sizeOfHeap);
        }

        public void InsertInHeap(int value)
        {
            if(arr == null)
            {
                Console.WriteLine("Heap is empty cannot insert value");
                return;
            }// end if
            else
            {
                arr[sizeOfHeap + 1] = value;
                sizeOfHeap++;
            }// end else
        }

        public void HeapifyBottomToTop(int index)
        {
            int parent = index / 2;
            if(index <= 1)
            {
                return;
            }// end if
            if(arr[index] < arr[parent])
            {
                int temp = arr[index];
                arr[index] = arr[parent];
                arr[parent] = temp;
            }// end if
            HeapifyBottomToTop(parent);
        }

        public int? Extract()
        {
            if(arr == null || sizeOfHeap == 0)
            {
                Console.WriteLine("Heap is empty cannot extract");
                return null;
            }// end if
            else
            {
                int extractedValue = arr[1];
                arr[1] = arr[sizeOfHeap];
                sizeOfHeap--;
                HeapifyTopToBottom(1);
                return extractedValue;
            }// end else
        }

        public void HeapifyTopToBottom(int index)
        {
            int left = index * 2;
            int right = (index * 2) + 1;
            int smallestChild;

            if(sizeOfHeap < left)
            {
                return;
            }// end if
            else if (sizeOfHeap == left)
            {  
                if (arr[index] > arr[left])
                {
                    int tmp = arr[index];
                    arr[index] = arr[left];
                    arr[left] = tmp;
                }// end if
                return;
            }// end else if
            else
            { 
                if (arr[left] < arr[right])
                {
                    smallestChild = left;
                }// end if
                else
                {
                    smallestChild = right;
                }// end else
                if (arr[index] > arr[smallestChild])
                {
                    int tmp = arr[index];
                    arr[index] = arr[smallestChild];
                    arr[smallestChild] = tmp;
                }// end if
            }// end else
            HeapifyTopToBottom(smallestChild);
        }
    }
}

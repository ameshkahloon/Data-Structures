using System;
using System.Collections.Generic;

namespace RecursionStuff
{
    public class ListNode
    {
       public int val;
       public ListNode next;
       public ListNode(int val = 0)
       {
           this.val = val;
       }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0)
        {
            this.val = val;
        }
    }

    public class RecursionStuff
    {
        public TreeNode SearchBST(TreeNode root, int val)
        {
            if(root == null)
            {
                return null;
            }// end if
            else if(root.val == val)
            {
                return root;
            }// end else if
            else if(root.val < val)
            {
                return SearchBST(root.right, val);
            }// end else if
            else
            {
                return SearchBST(root.left, val);
            }// end else
        }

        public int TreeMaxDepth(TreeNode root)
        {
            if(root == null)
            {
                return 0;
            }// end if
            int rightMax = TreeMaxDepth(root.right);
            int leftMax = TreeMaxDepth(root.left);
            return Math.Max(rightMax, leftMax) + 1;
        }

        public ListNode SwapPair(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }// end if
            else
            {
                ListNode second = new ListNode(head.val);
                ListNode first = new ListNode(head.next.val);
                first.next = second;
                ListNode otherPair = SwapPair(head.next.next);
                first.next.next = otherPair;
                return first;
            }// end else
        }

        public ListNode ReverseList(ListNode head)
        {
            if(head == null || head.next == null)
            {
                return head;
            }// end if
            ListNode newHead = ReverseList(head.next);
            head.next.next = head;
            head.next = null;
            return newHead;
        }

        public ListNode SortedMerge(ListNode A, ListNode B)
        {
            if(A == null)
            {
                return B;
            }// end if
            if(B == null)
            {
                return A;
            }// end if
            if(A.val < B.val)
            {
                A.next = SortedMerge(A.next, B);
                return A;
            }// end if
            else
            {
                B.next = SortedMerge(A, B.next);
                return B;
            }// end else
        }

        public void Foo(int n)
        {
            if(n < 1)
            {
                return;
            }// end if
            
            Foo(n - 1);
            Console.WriteLine("Hello World Foo: {0}", n);
        }

        public int? Factorial(int n)
        {
            if(n < 0)
            {
                return null;
            }
            else if (n == 0)
            {
                return 1;
            }// end if
            else
            {
                return (n * Factorial(n - 1));
            }// end else
        }

        public int? Fib(int n)
        {
            if(n < 1)
            {
                return null;
            }// end if
            else if(n == 1 || n == 2)
            {
                return n - 1;
            }// end else if
            else
            {
                return Fib(n - 1) + Fib(n - 2);
            }// end else
        }

        public void ReverseStringPrintout(string s)
        {
            if(s == null || s.Length <= 0)
            {
                Console.WriteLine("");
            }// end if
            else
            {
                Console.Write(s[s.Length-1]);
                ReverseStringPrintout(s.Substring(0, s.Length-1));
            }// end else
        }

        public void ReverseArray<T>(T[] arr)
        {
            if (arr == null || arr.Length <= 1)
            {
                return;
            }
            ReverseArray(0, arr.Length -1, arr);
        }

        public void ReverseArray<T>(int start, T[] arr)
        {
            if (arr == null || arr.Length <= 1)
            {
                return;
            }
            ReverseArray(start, arr.Length - 1 - start, arr);
        }

        public void ReverseArray<T>(int start, int end, T[] arr) 
        {
            if (arr == null || arr.Length <= 1)
            {
                return;
            }
            else if (start >= end)
            {
                return;
            }// end if
            else
            {
                T temp = arr[start];
                arr[start] = arr[end];
                arr[end] = temp;
                ReverseArray(start + 1, end - 1, arr);
            }// end else
        }

        public List<int> PascalTriangleRow(int rowIndex)
        {
            if(rowIndex == 0)
            {
                List<int> start = new List<int>();
                start.Add(1);
                return start;
            }// end if
            if (rowIndex == 1)
            {
                List<int> start = new List<int>();
                start.Add(1);
                start.Add(1);
                return start;
            }// end if

            List<int> preRow = PascalTriangleRow(rowIndex - 1);
            List<int> newRow = new List<int>();
            newRow.Add(1);
            for (int i = 0; i < rowIndex - 1; i++)
            {
                int sum = preRow[i] + preRow[i+1];
                newRow.Add(sum);
            }// end for loop
            newRow.Add(1);
            return newRow;
        }

        public int ClimbingStairs(int n)
        {
            if (n == 0)
            {
                return 1;
            }// end if
            if (n == 1)
            {
                return 1;
            }// end if
            int totalWay = ClimbingStairs(n - 1) + ClimbingStairs(n - 2);
            return totalWay;
        }
        
        public double MyPow(double x, int n)
        {
            if (n == 0)
            {
                return 1;
            }// end if
            else if (n > 0)
            {
                double res = x * MyPow(x, n - 1);
                return res;
            }// end else if
            else
            {
                double res = (1/x) * MyPow(x, n + 1);
                return res;
            }// end else
        }
    }
}
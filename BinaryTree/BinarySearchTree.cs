using System;
using System.Collections.Generic;

namespace BinarySearchTreeStuff
{
    public class BinarySearchTree
    {
        public Node Insert(Node root, int data)
        {
            if(root == null)
            {
                root = new Node() { data = data };
            }// end if    
            else if(root.data > data)
            {
                root.left = Insert(root.left, data);
            }// end else if
            else
            {
                root.right = Insert(root.right, data);
            }// end else
            return root;
        }

        public void PreOrderTraverse(Node root)
        {
            if(root == null)
            {
                return;
            }// end if
            else
            {
                Console.WriteLine("Value of node: {0} ", root.data);
                PreOrderTraverse(root.left);
                PreOrderTraverse(root.right);
            }// end else
        }

        public void InOrderTraversal(Node root)
        {
            if(root == null)
            {
                return;
            }// end if
            else
            {
                InOrderTraversal(root.left);
                Console.WriteLine("Value of node: {0} ", root.data);
                InOrderTraversal(root.right);
            }// end else
        }

        public void PostOrderTraversal(Node root)
        {
            if(root == null)
            {
                return;
            }// end if
            else
            {
                PostOrderTraversal(root.left);
                PostOrderTraversal(root.right);
                Console.WriteLine("Value of node: {0}", root.data);
            }// end else
        }

        public void LevelOrderTraversal(Node root)
        {
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);

            while (queue.Count != 0)
            {
                Node releasedNode = queue.Dequeue();
                Console.WriteLine("Value of node:  {0}", releasedNode.data);
                
                if(releasedNode.left != null)
                {
                    queue.Enqueue(releasedNode.left);
                }// end if

                if(releasedNode.right != null)
                {
                    queue.Enqueue(releasedNode.right);
                }// end if
            }// end while loop
        }

        public Node SearchValue(Node root, int data)
        {
            if(root == null)
            {
                return null;
            }// end if
            else if (root.data == data)
            {
                return root;
            }// end else if
            else if (data < root.data)
            {
                return SearchValue(root.left, data);
            }// end else if
            else
            {
                return SearchValue(root.right, data);
            }// end else
        }

        public Node DeleteNode(Node root, int data)
        {
            if(root == null || SearchValue(root, data) == null)
            {
                return null;
            }// end if
            else if(root.data < data)
            {
                root.right = DeleteNode(root.right, data);
            }// end else if
            else if(root.data > data)
            {
                root.left = DeleteNode(root.left, data);
            }// end else if
            else
            {
                if(root.left == null)
                {
                    return root.right;
                }// end if
                else if(root.right == null)
                {
                    return root.left;
                }// end else if

                root.data = InOrderSuccessor(root.right);

                root.right = DeleteNode(root.right, root.data);
            }// end else
            return root;
        }

        public int InOrderSuccessor(Node root)
        {
            int minv = root.data;
            while (root.left != null)
            {
                minv = root.left.data;
                root = root.left;
            }
            return minv;
        }

        public void DeleteTree(Node root)
        {
            Console.WriteLine("Tree will now be deleted");
            root.left = null;
            root.right = null;
            root.data = 0;
        }

        int MaxDepth(Node root)
        {
            if (root == null)
            {
                return 0;
            }// end if

            int leftDepth = MaxDepth(root.left);
            int rightDepth = MaxDepth(root.right);

            if (leftDepth > rightDepth)
            {
                return (leftDepth + 1);
            }// end if
            else
            {
                return (rightDepth + 1);
            }// end else
        }
    }

    public class Node
    {
        public int data;
        public Node right;
        public Node left;
    }
} 
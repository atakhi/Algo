using System;

namespace MyDS
{
    internal class MyAVLTree
    {
        NodeAvl root;
        public MyAVLTree()
        {
            
        }
        public void Insert(int key)
        {
            root = InsertNode(root, key);
        }
        public void Delete(int key)
        {
            root = DeleteKey(root, key);
        }
        private NodeAvl DeleteKey(NodeAvl root, int key)
        {
            if (root == null)
                return null;
            if (root.data < key)
            {
                root.right = DeleteKey(root.right, key);
            } else if (root.data > key)
            {
                root.left = DeleteKey(root.left, key);
            }
            else
            {
                if (root.left == null || root.right == null)
                {
                    NodeAvl temp = null;
                    if (temp == root.left)
                    {
                        temp = root.right;
                    }
                    else
                    {
                        temp = root.left;
                    }

                    if (temp == null)
                    {
                        temp = root;
                        root = null;
                    }
                    else
                    {
                        root = temp;
                    }
                }
                else
                {
                    int rightVal = GetMin(root.right);
                    root.data = rightVal;
                    root.right = DeleteKey(root.right, key);
                }
            }
                if (root == null)
                    return root;

                root.height = 1 + Math.Max(Height(root.left), Height(root.right));

                int balFactor = GetBalance(root);

                if(balFactor > 1 && GetBalance(root.left) < 0)
                {
                    root.left = RotateLeft(root.left);
                    return RotateRight(root);
                }
                else if (balFactor > 1 && GetBalance(root.left) >= 0)
                {
                    return RotateRight(root);
                }
                else if (balFactor < -1 && GetBalance(root.right) <= 0 )
                {
                    return RotateLeft(root);
                }
                else if (balFactor < -1 && GetBalance(root.right) > 0)
                {
                    root.right = RotateRight(root.right);
                    return RotateLeft(root);
                }

            return root;
        }
        public void Print()
        {
            NodeAvl temp = root;
            PrintPreOrder(temp);
            Console.WriteLine();   
        }
        private void PrintPreOrder(NodeAvl root)
        {
            if (root != null)
            {
                Console.Write(root.data + " -> ");
                PrintPreOrder(root.left);
                PrintPreOrder(root.right);
            }
        }
        private NodeAvl InsertNode(NodeAvl root, int key)
        {
            if (root == null)
            {
                root = new NodeAvl(key);
                return root;
            }
            if (root.data < key)
            {
                root.right = InsertNode(root.right, key);
            }else if (root.data > key)
            {
                root.left = InsertNode(root.left, key);
            }else
            {
                Console.WriteLine("dup not allowed");
                return null;
            }

            root.height = 1 + Math.Max(Height(root.left), Height(root.right));

            int balFactor = GetBalance(root);

            if(balFactor < -1 && root.right.data > key)
            {
                //RL
                root.right = RotateRight(root.right);
                return RotateLeft(root);
            }
            else if (balFactor < -1 && root.right.data < key)
            {
                //RR
                return RotateLeft(root);
            }
            else if (balFactor > 1 && root.left.data > key)
            {
                //LL
                return RotateRight(root);
            }
            else if (balFactor > 1 && root.left.data < key)
            {
                //LR
                root.left = RotateLeft(root.left);
                return RotateRight(root);
            }

            return root;
        }
        private int Height(NodeAvl t)
        {
            if (t == null)
                return 0;
            return t.height;
        }
        private int GetBalance(NodeAvl root)
        {
            if (root == null)
                return 0;
            return Height(root.left) - Height(root.right);
        }
        private NodeAvl RotateLeft(NodeAvl root)
        {
            NodeAvl newRoot = root.right;
            NodeAvl tempLeft = newRoot.left;

            newRoot.left = root;
            root.right = tempLeft;

            root.height = Math.Max(Height(root.left), Height(root.right)) + 1;
            newRoot.height = Math.Max(Height(newRoot.left), Height(newRoot.right)) + 1;

            return newRoot;
        } 
        private NodeAvl RotateRight(NodeAvl root)
        {
            NodeAvl newRoot = root.left;
            NodeAvl tempRight = newRoot.right;

            newRoot.right = root;
            root.left = tempRight;

            root.height = Math.Max(Height(root.left), Height(root.right)) + 1;
            newRoot.height = Math.Max(Height(newRoot.left), Height(newRoot.right)) + 1;

            return newRoot;
        }
        private int GetMin(NodeAvl root)
        {
            int val = root.data;
            while(root.left != null)
            {
                val = root.data;
                root = root.left;
            }
            return val;
        }
    }
    public class NodeAvl
    {
        public int data;
        public NodeAvl left;
        public NodeAvl right;
        public int height;
        public NodeAvl(int d)
        {
            data = d;
            height = 1;
        }
    }
}
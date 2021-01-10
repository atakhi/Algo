using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDS
{
    public class MyBSTree
    {
        public MyBNode root;
        public MyBSTree()
        {
            root = null;
        }
        public MyBNode InsertNode(MyBNode root, int data)
        {
            if (root == null)
            {
                root = new MyBNode(data);
                return root;
            }
            if(data < root.data)
            {
                root.left = InsertNode(root.left, data);
            }
            else
            {
                root.right = InsertNode(root.right, data);
            }
            return root;
        }
        public void Insert(int data)
        {
            root = InsertNode(root, data);
        }
        public void InorderTraverse()
        {
            InOrder(root);
            Console.WriteLine();
        }
        public void InOrder(MyBNode root)
        {
            if (root == null)
                return;
            if (root.left != null)
                InOrder(root.left);
            Console.Write(root.data + " ");
            if (root.right != null)
                InOrder(root.right);

        }
        public int Search(int data)
        {
             if(SearchNode(root, data) == null)
            {
                return -1;
            }

            return 1;
        }
        public MyBNode SearchNode(MyBNode root, int data)
        {
            if (root == null || root.data == data)
            {
                return root;
            }
            if (data < root.data)
            {
                return SearchNode(root.left, data);
            }else
            {
                return SearchNode(root.right, data);
            }
        }
        public void Delete(int key)
        {
            DeleteNode(root, key);
        }
        public MyBNode DeleteNode(MyBNode root, int key)
        {
            if(root == null)
            {
                return null;
            }
            if(key < root.data)
            {
                root.left = DeleteNode(root.left, key);
            }else if(key > root.data)
            {
                root.right = DeleteNode(root.right, key);
            }
            else if(root.data == key)
            {
                if(root.left == null)
                {
                    return root.right;
                }
                else if (root.right == null)
                    return root.left;
                root.data = GetMin(root.right);
                root.right = DeleteNode(root.right, root.data);

            }
            return root;
        }
        public int GetMin(MyBNode root)
        {
            int min = root.data;
            while(root.left != null)
            {
                min = root.left.data;
                root = root.left;
            }
            return min;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDS
{
    public class MyBinaryTree
    {
        public MyBNode root;
        public MyBinaryTree(MyBNode root)
        {
            this.root = root;
        }
        public void Insert(int data)
        {
            if(root == null)
            {
                root = new MyBNode(data);
                return;
            }
            Queue<MyBNode> q = new Queue<MyBNode>();
            q.Enqueue(root);
            while (q.Count != 0)
            {
                MyBNode curr = q.Dequeue();
                if(curr.left == null)
                {
                    curr.left = new MyBNode(data);
                    return;
                }else
                {
                    q.Enqueue(curr.left);
                }
                if (curr.right == null)
                {
                    curr.right = new MyBNode(data);
                    return;
                }else
                {
                    q.Enqueue(curr.right);
                }
            }
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

        public void DeleteKey(MyBNode root, int data)
        {
            MyBNode temp = null;
            MyBNode itemToDelete = null;
            Queue<MyBNode> q = new Queue<MyBNode>();
            q.Enqueue(root);
            if (root == null)
                return;
            if (root.left == null &&
       root.right == null)
            {
                if (root.data == data)
                    return;
                else
                    return;
            }
            //if (lastRight == null)
            //{
                while(q.Count != 0)
                {
                temp = q.Dequeue();
                    if (temp.data == data)
                        itemToDelete = temp;
                    if (temp.left != null)
                        q.Enqueue(temp.left);
                    if (temp.right != null)
                        q.Enqueue(temp.right);
                }
            //}
            if (itemToDelete != null)
            {
                int x = temp.data;
                DeleteDeepest(root, temp);
                itemToDelete.data = x;
            }        
        }
        public void DeleteDeepest(MyBNode root, MyBNode data)
        {
            Queue<MyBNode> q = new Queue<MyBNode>();
            MyBNode t = null;
            q.Enqueue(root);
            while (q.Count != 0)
            {
                t = q.Dequeue();
                if (t == data)
                {
                    t = null;
                    return;
                }
                if(t.left != null)
                {
                    if (t.left == data)
                    {
                        t.left = null;
                        return;
                    }else
                    q.Enqueue(t.left);
                }
                if(t.right != null)
                {
                    if(t.right == data)
                    {
                        t.right = null;
                        return;
                    }else
                    q.Enqueue(t.right);
                }
            }
        }
    }
    public class MyBNode
    {
        public int data;
        public MyBNode left;
        public MyBNode right;
        public MyBNode(int d)
        {
            data = d;
        }
    }
}

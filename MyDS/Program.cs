using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDS
{
    class Program
    {
        static void Main(string[] args)
        {
            MyArray<int> intArr = new MyArray<int>(2);
            intArr.Add(1);
            intArr.Add(2);
            //intArr.PrintElements();
            intArr.Add(3);
            //intArr.PrintElements();
            //Console.WriteLine(intArr[1]);
            //Console.WriteLine(intArr.length);

            MyLinkedList list = new MyLinkedList();
            list.AddAtEnd(3);
            list.AddAtEnd(2);
            list.AddAtEnd(1);
            //list.PrintList();
            list.AddFirst(0);
            //list.PrintList();
            list.DeleteNode(2);
            //list.PrintList();

            
            MyBNode root = new MyBNode(10);
            root.left = new MyBNode(11);
            root.left.left = new MyBNode(7);
            root.left.right = new MyBNode(12);
            root.right = new MyBNode(9);
            root.right.left = new MyBNode(15);
            root.right.right = new MyBNode(8);
            MyBinaryTree bt = new MyBinaryTree(root);
            //bt.InOrder(bt.root);
            //bt.Insert(12);
            //bt.InOrder(root);
            //Console.WriteLine();
            bt.DeleteKey(bt.root, 11);
            //bt.InOrder(root);

            MyBSTree bst = new MyBSTree();
            bst.Insert(50);
            bst.Insert(30);
            bst.Insert(20);
            bst.Insert(40);
            bst.Insert(70);
            bst.Insert(60);
            bst.Insert(80);

            // Print inorder traversal of the BST 
            //bst.InorderTraverse();
            //Console.WriteLine(bst.Search(60));
            //Console.WriteLine(bst.Search(55));
            bst.Delete(20);
            bst.Delete(30);
            bst.Delete(50);
            //bst.InorderTraverse();

            MyMaxHeap heap = new MyMaxHeap();
            //heap.Insert(10);
            //heap.Insert(5);
            //heap.Insert(3);
            //heap.Insert(2);
            //heap.Insert(4);
            //heap.Print();
            //heap.Delete();
            //heap.Print();
            int[] arr = { 4, 2, 1, 3, 7, 5, 8 ,6};
            heap.Sort(arr);
            //heap.Print();

            MergeSort ms = new MergeSort();
            //ms.Sort(arr);

            QuickSort qs = new QuickSort();
            //qs.Sort(arr);

            MyAVLTree avl = new MyAVLTree();
            avl.Insert(9);
            avl.Insert(5);
            avl.Insert(10);
            avl.Insert(0);
            avl.Insert(6);
            avl.Insert(11);
            avl.Insert(-1);
            avl.Insert(1);
            avl.Insert(2);
            //avl.Print();
            avl.Delete(10);
            //avl.Print();

            MyGraph g = new MyGraph(5 ,true);
            g.AddEdge(1, 0);
            g.AddEdge(0, 2);
            //g.AddEdge(2, 1);
            g.AddEdge(0, 3);
            g.AddEdge(3, 4);

            //g.BFS(2);
            //g.ShortestPath(1, 4);
            //g.ConnectedComponents();
            //g.isTwoColoring();

            //g.DFS(0);
            //g.IsCycle();
            //g.PrintTopologicalSort();
            //g.TopoSortKahnsBFS();
            //g.StronglyConnectedComponents();

            MyWGraph wg = new MyWGraph(9, false);
            wg.AddEdge(0, 1, 4);
            wg.AddEdge(0, 7, 8);
            wg.AddEdge(1, 2, 8);
            wg.AddEdge(1, 7, 11);
            wg.AddEdge(2, 3, 7);
            wg.AddEdge(2, 8, 2);
            wg.AddEdge(2, 5, 4);
            wg.AddEdge(3, 4, 9);
            wg.AddEdge(3, 5, 14);
            wg.AddEdge(4, 5, 10);
            wg.AddEdge(5, 6, 2);
            wg.AddEdge(6, 7, 1);
            wg.AddEdge(6, 8, 6);
            wg.AddEdge(7, 8, 7);
            //wg.PrimsMST(0);

            //wg.DijkstraMSP(0);

            //wg.PrimsMST_Heap(0);

            FloydWarshall fw = new FloydWarshall();

            int[,] gr = { {0, 5, int.MaxValue, 10},
                        {int.MaxValue, 0, 3, int.MaxValue},
                        {int.MaxValue, int.MaxValue, 0, 1},
                        {int.MaxValue, int.MaxValue, int.MaxValue, 0}
                        };
            //fw.AllPairsShortestPath(gr,4);

            Kruskals kgraph = new Kruskals(4, 5);
            kgraph.AddEdge(0, 1, 10);
            kgraph.AddEdge(0, 2, 6);
            kgraph.AddEdge(0, 3, 5);
            kgraph.AddEdge(1, 3, 15);
            kgraph.AddEdge(2, 3, 4);
            //kgraph.IsCycle();
            //kgraph.IsCycleByRank();

            //kgraph.MST();

            Backtracking bkt = new Backtracking();
            //bkt.SubsetsOfN(3);
            //bkt.PermutationsOfN(123);

            //bkt.PermutationsOfS("abc");

            PatternSearching ps = new PatternSearching();

            //ps.NaivePatternSearch("AABAACAADAABAAABAA", "AABA");

            ps.KMPSearch("ABABDABACDABABCABAB", "ABABCABAB");

            Console.WriteLine();
            Console.ReadKey();
        }
    }
}

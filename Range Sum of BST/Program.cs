using System;

namespace Range_Sum_of_BST
{
    class Program
    {
        static void Main(string[] args)
        {
            Node root = new Node(20);
            root.left = new Node(8);
            root.left.left = new Node(7);
            root.left.right = new Node(9);
            root.right = new Node(22);
            root.right.left = new Node(21);
            root.right.right = new Node(23);
            Console.WriteLine(RangeSumBST(root, 6, 9));
        }

        public class Node
        {
            public int val { get; set; }
            public Node left { get; set; }
            public Node right { get; set; }
            public Node(int val = 0)
            {
                this.val = val;
                left = right = null;
            }
        }

        static int RangeSumBST(Node root, int L, int R)
        {
            if (root == null) return 0;
            if (root.val < L) return RangeSumBST(root.right, L, R);
            if (root.val > R) return RangeSumBST(root.left, L, R);

            return root.val + RangeSumBST(root.right, L, R) + RangeSumBST(root.left, L, R);
        }
    }
}

using System;
using System.Collections.Generic;

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
            Console.WriteLine("Sum of the given range between 6, 9 is : ");
            Console.WriteLine(RangeSumBST(root, 6, 9));
            Console.WriteLine("List of the products between the given price range are");
            var result = ProductsInRange(root, 6, 9);
            Console.WriteLine(string.Join(",", result));
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

        // Complexity = O(N)
        static int RangeSumBST(Node root, int L, int R)
        {
            int sum = 0;
            Helper(root, L, R, ref sum);
            return sum;
            //if (root == null) return 0;
            //if (root.val < L) return RangeSumBST(root.right, L, R);
            //if (root.val > R) return RangeSumBST(root.left, L, R);

            //return root.val + RangeSumBST(root.right, L, R) + RangeSumBST(root.left, L, R);
        }

        static void Helper(Node root, int L, int R, ref int sum)
        {
            if (root != null)
            {
                if (root.val >= L && root.val <= R)
                    sum += root.val;
                if (root.val >= L)
                    Helper(root.left, L, R, ref sum);
                if (root.val <= R)
                    Helper(root.right, L, R, ref sum);
            }
        }

        // Complexity = O(N)
        // Space = O(N)
        static List<int> ProductsInRange(Node root, int low, int high)
        {
            List<int> products = new List<int>();
            HelperFindRange(root, low, high, products);
            return products;
        }

        static void HelperFindRange(Node root, int L, int R, List<int> products)
        {
            if (root != null)
            {
                if (root.val >= L && root.val <= R)
                    products.Add(root.val);
                if (root.val >= L)
                    HelperFindRange(root.left, L, R, products);
                if (root.val <= R)
                    HelperFindRange(root.right, L, R, products);
            }
        }
    }
}

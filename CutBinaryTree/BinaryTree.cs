using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CutBinaryTree
{
    public class Node
    {
        private int data;
        public int Data
        {
            get { return data; }
            set { data = value; }
        }
        public Node left;
        public Node right;
        public Node(int data)
        {
            this.Data = data;
            this.left = null;
            this.right = null;
        }
    }

    public class BinaryTree
    {
        Node root;
        public BinaryTree()
        {
            root = null;
        }
        public BinaryTree(Node root)
        {
            this.root = root;
        }

        public void AddNode(int data)
        {
            if (root == null)
            {
                root = new Node(data);
            }
            else
            {
                bool b = false;
                Node find = Search(data, ref b);
                if (b == false)
                {
                    if (find.Data > data)
                    {
                        find.left = new Node(data);
                    }
                    else
                    {
                        find.right = new Node(data);
                    }
                }
            }
        }
        public BinaryTree GetLeftTree()
        {
            return new BinaryTree(root.left);
        }
        public BinaryTree GetRightTree()
        {
            return new BinaryTree(root.right);
        }
        public Node DeleteNode(int data)
        {
            if (root != null)
            {
                if (root.Data > data)
                {
                    if (root.left != null)
                    {
                        root.left = GetLeftTree().DeleteNode(data);
                        return root;
                    }
                    else
                    {
                        return root;
                    }
                }
                else if (root.Data < data)
                {
                    if (root.right != null)
                    {
                        root.right = GetRightTree().DeleteNode(data);
                        return root;
                    }
                    else
                    {
                        return root;
                    }
                }
                else
                {
                    if ((root.left == null) && (root.right == null))
                    {
                        return null;
                    }
                    else if (root.left == null)
                    {
                        root = root.right;
                        return root;
                    }
                    else if (root.right == null)
                    {
                        root = root.left;
                        return root;
                    }
                    else
                    {
                        root.Data = GetLeftTree().GetMax().Data;
                        root.left = GetLeftTree().DeleteNode(root.Data);
                        return root;
                    }
                }
            }
            return root;
        }
        public Node GetMax()
        {
            Node max = root;
            while (max.right != null)
            {
                max = max.right;
            }
            return max;
        }
        public Node GetMin()
        {
            Node min = root;
            while (min.left != null)
            {
                min = min.left;
            }
            return min;
        }
        private Node Search(int data, ref bool b)
        {
            Node find = root;
            while (find.Data != data)
            {
                if (find.Data > data)
                {
                    if (find.left != null)
                    {
                        find = find.left;
                    }
                    else
                    {
                        b = false;
                        return find;
                    }
                }
                else
                {
                    if (find.right != null)
                    {
                        find = find.right;
                    }
                    else
                    {
                        b = false;
                        return find;
                    }
                }
            }
            b = true;
            return find;
        }
        
        public BinaryTree cutBinaryTree(BinaryTree B)
        {
            if ((B.root != null) && (this.root != null))
            {
                if (this.root.Data == B.root.Data)
                {
                    root.left = this.GetLeftTree().cutBinaryTree(B.GetLeftTree()).root;
                    root.right = this.GetRightTree().cutBinaryTree(B.GetRightTree()).root;
                    root = this.DeleteNode(B.root.Data);
                    return new BinaryTree(this.root);
                }
                else if (this.root.Data > B.root.Data)
                {
                    root.left = this.GetLeftTree().DeleteNode(B.root.Data);
                    root.left = this.GetLeftTree().cutBinaryTree(B.GetLeftTree()).root;
                    root = this.cutBinaryTree(B.GetRightTree()).root;
                    return new BinaryTree(this.root);
                }
                else
                {
                    root.right = this.GetRightTree().DeleteNode(B.root.Data);
                    root.right = this.GetRightTree().cutBinaryTree(B.GetRightTree()).root;
                    root = this.cutBinaryTree(B.GetLeftTree()).root;
                    return new BinaryTree(this.root);
                }
            }
            return new BinaryTree(this.root);
        }

        public void ListNodes(List<Node> listNodes, Node node = null)
        {
            if (node == null)
            {
                node = root;
            }
            if (node.left != null)
            {
                ListNodes(listNodes, node.left);
            }
            listNodes.Add(node);
            if (node.right != null)
            {
                ListNodes(listNodes, node.right);
            }
        }

        public void ListDates(List<int> listDate)
        {
            List<Node> listNodes = new List<Node>();
            ListNodes(listNodes);
            for (int i = 0; i < listNodes.Count(); i++)
            {
                listDate.Add(listNodes[i].Data);
            }
        }

        public void PrintTree(Node node = null)
        {
            List<Node> listNodes = new List<Node>();
            ListNodes(listNodes);
            for (int i = 0; i < listNodes.Count(); i++)
            {
                Console.Write(listNodes[i].Data + " ");
            }
            Console.WriteLine();

        }
    }
}

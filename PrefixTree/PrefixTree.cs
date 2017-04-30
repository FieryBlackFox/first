using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace prefixTree
{
    public class PrNode
    {
        private char text;
        public char Text
        {
            get { return text; }
            protected set { text = value; }
        }
        private string value;
        public string Value
        {
            get { return value; }
            protected set { this.value = value; }
        }
        public List<PrNode> next;
        public PrNode(char ch, string value = null)
        {
            this.value = value;
            text = ch;
            next = null;
        }
        public void NullValue()
        {
            Value = null;
        }
    }

    public class PrefixTree
    {
        private PrNode head;
        public PrefixTree()
        {
            head = new PrNode(' ');
        }
        public void AddValue(string value)
        {
            int n = 1;
            int i = AddNode(value[0], ref head);
            PrNode node = head.next[i];
            while (n < value.Length - 1)
            {
                i = AddNode(value[n], ref node);
                node = node.next[i];
                n++;
            }
            AddNode(value[n], ref node, value);

        }
        public bool ContainsValue(string value)
        {
            bool b = false;
            int n = 1;
            int i = BinarySearch(value[0], head, ref b);
            PrNode node;
            if (b == true)
            {
                node = head.next[i];
            }
            else
            {
                return false;
            }
            while (n < value.Length)
            {
                i = BinarySearch(value[n], node, ref b);
                if (b == false)
                {
                    return false;
                }
                else
                {
                    node = node.next[i];
                    n++;
                }
            }
            if (node.Value == value)
            {
                return true;
            }
            return false;
        }
        public void Remove(string value)
        {
            if (ContainsValue(value) == true)
            {
                PrNode node = head;
                int n = 0;
                int i = 0;
                List<int> ind = new List<int>();
                List<bool> bInd = new List<bool>();                
                bool b = false;
                while (n < value.Length - 1)
                {
                    i = BinarySearch(value[n], node, ref b);
                    ind.Add(i);
                    if ((node.Value != null) || (node.next.Count() > 1))
                    {
                        bInd.Add(false);
                    }
                    else
                    {
                        bInd.Add(true);
                    }
                    node = node.next[i];
                    n++;
                }
                i = BinarySearch(value[n], node, ref b);
                node = node.next[i];
                node.NullValue();
                ind.Add(i);
                if ((node.next != null) && (node.next.Count() > 0))
                {
                    bInd.Add(false);
                }
                else
                {
                    bInd.Add(true);
                }
                i = bInd.LastIndexOf(false);
                n = 0;
                node = head;
                while (n <= i)
                {
                    node = node.next[ind[n]];
                    n++;
                }
                if (i + 1 < ind.Count())
                {
                    node.next.RemoveAt(ind[i + 1]);
                }
            }
        }
        public void AllToList(ref List<string> str, PrNode node = null)
        {
            if (node == null)
            {
                node = head;
            }
            if (node.next == null)
            {
                str.Add(node.Value);
            }
            else
            {
                for (int i = 0; i < node.next.Count(); i++)
                {
                    AllToList(ref str, node.next[i]);
                }
                if (node.Value != null)
                {
                    str.Add(node.Value);
                }
            }
        }

        public void PrintAll()
        {
            List<string> str = new List<string>();
            AllToList(ref str);
            for (int i = 0; i < str.Count(); i++)
            {
                Console.WriteLine(str[i]);
            }
        }

        private int AddNode(char ch, ref PrNode node, string value = null)
        {
            if (node.next == null)
            {
                node.next = new List<PrNode>();
                node.next.Add(new PrNode(ch, value));
                return 0;
            }
            bool b = false;
            int i = BinarySearch(ch, node, ref b);
            if (b == false)
            {
                node.next.Insert(i, new PrNode(ch, value));
            }
            return i;
        }
        private int BinarySearch(char ch, PrNode node, ref bool b)
        {
            if ((node.next == null)||(node.next.Count() == 0))
            {
                b = false;
                return 0;
            }
            if (ch < node.next[0].Text)
            {
                b = false;
                return 0;
            }
            if (ch > node.next[node.next.Count() - 1].Text)
            {
                b = false;
                return node.next.Count();
            }
            int start = 0;
            int finish = node.next.Count();
            int middle;
            while (start < finish)
            {
                middle = start + (finish - start) / 2;
                if (ch <= node.next[middle].Text)
                {
                    finish = middle;
                }
                else
                {
                    start = middle + 1;
                }
            }
            if (node.next[finish].Text == ch)
            {
                b = true;
            }
            else
            {
                b = false;
            }
            return finish;
        }
    }
}

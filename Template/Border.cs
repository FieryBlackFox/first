using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace findTemplate
{
    public class Border : IComparable
    {
        private int First;
        public int first
        {
            get { return First; }
            protected set { First = value; }
        }
        private int Last;
        public int last
        {
            get { return Last; }
            protected set { Last = value; }
        }
        public Border(int first, int last)
        {
            this.first = first;
            this.last = last;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (GetType() != obj.GetType())
            {
                return false;
            }
            Border b = obj as Border;
            if ((b.first == first) && (b.last == last))
            {
                return true;
            }
            return false;
        }
        public override string ToString()
        {
            return first.ToString() + " " + last.ToString();
        }
        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }
            Border b = obj as Border;
            if (this.first < b.first)
            {
                return -1;
            }
            else if (this.first == b.first)
            {
                if (this.last < b.last)
                {
                    return -1;
                }
                else if (this.last == b.last)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                return 1;
            }
        }
    }
}

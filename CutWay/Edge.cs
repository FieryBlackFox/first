using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Graph
{
    public class Edge
    {
        private Node Start;
        private Node Finish;
        private string Name;

        public Node start
        {
            get { return Start; }
            protected set { Start = value; }
        }

        public Node finish
        {
            get { return Finish; }
            protected set { Finish = value; }
        }

        public string name
        {
            get { return Name; }
            protected set { Name = value; }
        }

        public Edge(Node start, Node finish)
        {
            this.start = start;
            this.finish = finish;
            this.name = start.name + finish.name;
        }

        public Edge(string name)
        {
            this.start = new Node(name[0].ToString());
            this.finish = new Node(name[1].ToString());
            this.name = name;
        }

        
    }
}/*public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            else if (obj.GetType() != this.GetType())
            {
                return false;
            }
            else
            {
                Edge n = obj as Edge;
                if ((n.name != this.name) || (n.finish != this.finish) || (n.start != this.start))
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            return (int)this.name[0] + (int)this.name[1];
        }

        public override string ToString()
        {
            return this.name;
        }*/

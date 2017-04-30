using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Graph
{
    public abstract class Graph
    {
        public virtual void AddNodes(Node n1) { }
        public virtual void AddNodes(Node n1, Node n2) { }
        public virtual void AddNodes(Node n1, Node n2, Node n3) { }
        public virtual void AddNodes(Node n1, Node n2, Node n3, Node n4) { }
        public virtual void AddNodes(params Node[] n) { }

        public virtual void AddEdges(Edge e1) { }
        public virtual void AddEdges(Edge e1, Edge e2) { }
        public virtual void AddEdges(Edge e1, Edge e2, Edge e3) { }
        public virtual void AddEdges(Edge e1, Edge e2, Edge e3, Edge e4) { }
        public virtual void AddEdges(params Edge[] e) { }

        public virtual void PrintNodeOfGrapf() { }
        public virtual void PrintEdgeOfGrapf() { }
        public virtual void PrintGrapf() { }
    }
}

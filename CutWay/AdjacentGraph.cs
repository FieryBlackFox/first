using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Graph
{
    
    public class AdjacentGraph : Graph
    {
        protected Dictionary<string, Dictionary<string, int>> adjacent;

        public AdjacentGraph()
        {
            this.adjacent = new Dictionary<string, Dictionary<string, int>>();
        }

        public AdjacentGraph(Dictionary<string, Dictionary<string, int>> adjacent)
        {
            this.adjacent = new Dictionary<string, Dictionary<string, int>>();
            foreach (var v in adjacent)
            {
                this.adjacent[v.Key] = new Dictionary<string, int>();
                foreach (var r in v.Value)
                {
                    this.adjacent[v.Key][r.Key] = r.Value;
                }
            }
        }

        public AdjacentGraph(AdjacentGraph G) : this(G.adjacent){}

        public AdjacentGraph(Node[] nodes = null, Edge[] edges = null)
        {
            this.adjacent = new Dictionary<string, Dictionary<string, int>>();
            if (nodes != null)
            {
                for (int i = 0; i < nodes.Length; i++)
                {
                    this.adjacent[nodes[i].name] = new Dictionary<string, int>();
                }
            }
            if (edges != null)
            {
                for (int i = 0; i < edges.Length; i++)
                {
                    if (this.adjacent.ContainsKey(edges[i].start.name) != true)
                    {
                        this.adjacent[edges[i].start.name] = new Dictionary<string, int>();
                    }
                    if (this.adjacent.ContainsKey(edges[i].finish.name) != true)
                    {
                        this.adjacent[edges[i].finish.name] = new Dictionary<string, int>();
                    }
                    this.adjacent[edges[i].start.name][edges[i].finish.name] = 1;
                }
            }
        }

        public static AdjacentGraph operator +(AdjacentGraph G, Node n)
        {
            if ((n != null) && (G.adjacent.ContainsKey(n.name) != true))
            {
                G.adjacent[n.name] = new Dictionary<string, int>();
            }
            return G;
        }

        public static AdjacentGraph operator +(Node n, AdjacentGraph G)
        {
            return (new AdjacentGraph(G) + n);
        }

        public static AdjacentGraph operator -(AdjacentGraph G, Node n)
        {
            if (G.adjacent.ContainsKey(n.name) == true)
            {
                foreach (var v in G.adjacent)
                {
                    if(v.Value.ContainsKey(n.name))
                    {
                        v.Value.Remove(n.name);
                    }
                }
                G.adjacent.Remove(n.name);
            }
            return G;
        }

        public static AdjacentGraph operator +(AdjacentGraph G, Edge ed)
        {
            if (ed != null)
            {
                if (G.adjacent.ContainsKey(ed.start.name) != true)
                {
                    G.adjacent[ed.start.name] = new Dictionary<string, int>();
                }
                if (G.adjacent.ContainsKey(ed.finish.name) != true)
                {
                    G.adjacent[ed.finish.name] = new Dictionary<string, int>();
                }
                G.adjacent[ed.start.name][ed.finish.name] = 1;
            }
            return G;
        }

        public static AdjacentGraph operator +(Edge ed, AdjacentGraph G)
        {
            return (new AdjacentGraph(G) + ed);
        }

        public static AdjacentGraph operator -(AdjacentGraph G, Edge ed)
        {
            if ((G.adjacent.ContainsKey(ed.start.name) == true) && (G.adjacent.ContainsKey(ed.finish.name) == true) && (G.adjacent[ed.start.name].ContainsKey(ed.finish.name) == true))
            {
                G.adjacent[ed.start.name].Remove(ed.finish.name);
                return G;
            }
            else
            {
                throw new TryCutNotExistEdgeExeption();
            }       
        }

        public AdjacentGraph CutEdge(Edge ed)
        {
            AdjacentGraph G = this;
            G -= ed;
            if((G.adjacent[ed.finish.name].Count != 0)&&(G.adjacent[ed.start.name].Count != 0))
            {
                return G;
            }
            bool b2 = true;
            bool b1 = true;
            if (G.adjacent[ed.finish.name].Count() != 0)
            {
                b2 = false;
            }
            else if (G.adjacent[ed.start.name].Count() != 0)
            {
                b1 = false;
            }
            foreach(var v in G.adjacent.Keys)
            {
                if (G.adjacent[v].ContainsKey(ed.finish.name) == true)
                {
                    b2 = false;
                }
                if (G.adjacent[v].ContainsKey(ed.start.name) == true)
                {
                    b1 = false;
                }
            }
            if (b2 == true)
            {
                G -= ed.finish;
            }
            if (b1 == true)
            {
                G -= ed.start;
            }
            return G;
        }

        public static AdjacentGraph operator +(AdjacentGraph G1, AdjacentGraph G2)
        {
            AdjacentGraph GF = new AdjacentGraph(G1);
            foreach (var v in G2.adjacent)
            {
                if (GF.adjacent.ContainsKey(v.Key) != true)
                {
                    GF.adjacent[v.Key] = new Dictionary<string, int>();
                }
                foreach (var r in v.Value)
                {
                    GF.adjacent[v.Key][r.Key] = G2.adjacent[v.Key][r.Key];
                }
            }
            return GF;
        }

        public static AdjacentGraph operator -(AdjacentGraph G1, AdjacentGraph G2)
        {
            foreach (var v in G2.adjacent)
            {
                G1 -= new Node(v.Key);
            }
            return G1;
        }

        public override void AddNodes(Node n1)
        {
            AdjacentGraph G = this;
            G += n1;
        }

        public override void AddNodes(Node n1, Node n2)
        {
            AdjacentGraph G = this;
            G += n1;
            G += n2;
        }

        public override void AddNodes(Node n1, Node n2, Node n3)
        {
            AdjacentGraph G = this;
            G += n1;
            G += n2;
            G += n3;
        }

        public override void AddNodes(Node n1, Node n2, Node n3, Node n4)
        {
            AdjacentGraph G = this;
            G += n1;
            G += n2;
            G += n3;
            G += n4;
        }

        public override void AddNodes(params Node[] n)
        {
            AdjacentGraph G = this;
            for (int i = 0; i < n.Length; i++)
            {
                G += n[i];
            }
        }

        public override void AddEdges(Edge e1)
        {
            AdjacentGraph G = this;
            G += e1;
        }

        public override void AddEdges(Edge e1, Edge e2)
        {
            AdjacentGraph G = this;
            G += e1;
            G += e2;
        }

        public override void AddEdges(Edge e1, Edge e2, Edge e3)
        {
            AdjacentGraph G = this;
            G += e1;
            G += e2;
            G += e3;
        }

        public override void AddEdges(Edge e1, Edge e2, Edge e3, Edge e4)
        {
            AdjacentGraph G = this;
            G += e1;
            G += e2;
            G += e3;
            G += e4;
        }

        public override void AddEdges(params Edge[] e)
        {
            AdjacentGraph G = this;
            for (int i = 0; i < e.Length; i++)
            {
                G += e[i];
            }
        }

        public override bool Equals(object obj)
        {

            if (obj == null)
            {
                return false;
            }
            if (obj.GetType() != this.GetType())
            {
                return false;
            }
            AdjacentGraph G = obj as AdjacentGraph;
            if (G.adjacent.Count != this.adjacent.Count)
            {
                return false;
            }
            foreach (var node1 in G.adjacent)
            {
                if (this.adjacent.ContainsKey(node1.Key) == false)
                {
                    return false;
                }
                if (node1.Value.Count() != this.adjacent[node1.Key].Count())
                {
                    return false;
                }
                foreach (var no in node1.Value)
                {
                    if (this.adjacent[node1.Key].ContainsKey(no.Key) == false)
                    {
                        return false;
                    }
                    if (this.adjacent[node1.Key][no.Key] != G.adjacent[node1.Key][no.Key])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            return this.adjacent.Count() * this.adjacent.GetType().GetHashCode();
        }

        public override string ToString()
        {
            string s = "";
            foreach (var v in this.adjacent)
            {
                s += v.Key + ": ";
                foreach (var r in v.Value)
                {
                    s+= v.Key + r.Key + " ";
                }
                s+=";" + Environment.NewLine;
            }
            return s;
        }

        public override void PrintNodeOfGrapf()
        {
            Console.WriteLine("Печать вершин:");
            foreach (var v in this.adjacent)
            {
                Console.Write(v.Key + " ");
            }
            Console.WriteLine('\n');
        }

        public override void PrintEdgeOfGrapf()
        {
            Console.WriteLine("Печать ребер:");
            foreach (var v in this.adjacent)
            {
                foreach (var r in v.Value)
                {
                    Console.WriteLine(v.Key + r.Key);
                }
            }
            Console.WriteLine();
        }

        public override void PrintGrapf()
        {
            Console.WriteLine("Печать графа:");
            Console.WriteLine(this.ToString());
        }

    }
}


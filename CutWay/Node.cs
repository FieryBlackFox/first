using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Graph
{
    public class Node
    {
        private string Name;
        public string name
        {
            get { return Name; }
            protected set { Name = value; }
        }

        public Node(string name)
        {
            this.name = name;
        }
    }
}

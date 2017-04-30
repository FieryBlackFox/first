using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Graph
{
    class TryCutNotExistWayExeption : TryCutNotExistEdgeExeption
    {
        public override string Message
        {
            get
            {
                return "Graph doesn't contain this way : " + base.Message;
            }
        }
    }

    class TryCutNotExistEdgeExeption : Exception
    {
        public override string Message
        {
            get
            {
                return "Graph doesn't contain this edge";
            }
        }
    }
}

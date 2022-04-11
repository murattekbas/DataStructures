using Graph.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.Concretes
{
    public class Edge<T, C> : IEdge<T> where C : IComparable
    {
        private object weight;
        public Edge(IGraphVertex<T> target,C weight)
        {
            TargetVertex = target;
            this.weight = weight;
        }
        public T TargetVertexKey =>TargetVertex.Key;

        public IGraphVertex<T> TargetVertex {get;private set;}

        public W Weight<W>() where W : IComparable
        {
            return (W)weight;  
        }
        public override string ToString()
        {
            return TargetVertexKey.ToString();
        }
    }
}

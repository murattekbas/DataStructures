using Graph.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.Concretes
{
    public class DiEdge<T, W> : IDiEdge<T>
    {
        private object weight;
        public IDiGraphVertex<T> TargetVertex { get; private set; }

        public T TargetVertexKey => TargetVertex.Key;

        public DiEdge(IDiGraphVertex<T> target,W weight)
        {
            TargetVertex = target;
            this.weight = weight;
        }

        IGraphVertex<T> IEdge<T>.TargetVertex => TargetVertex as IGraphVertex<T>;

        public W Weight<W>() where W : IComparable
        {
            return (W)weight;
        }

        public override string ToString()
        {
            return $"{TargetVertexKey}";
        }
    }
}

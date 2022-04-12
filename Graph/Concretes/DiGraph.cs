using Graph.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.Concretes
{
    public class DiGraph<T>:IDiGraph<T>
    {
        public IDiGraphVertex<T> ReferenceVertex => throw new NotImplementedException();

        public IEnumerable<IDiGraphVertex<T>> VerticesAsEnumerable => throw new NotImplementedException();

        public bool isWeightedGraf => throw new NotImplementedException();

        public int Count => throw new NotImplementedException();

        IGraphVertex<T> IGraph<T>.ReferenceVertex => throw new NotImplementedException();

        IEnumerable<IGraphVertex<T>> IGraph<T>.VerticesAsEnumerable => throw new NotImplementedException();

        public void AddVertex(T key)
        {
            throw new NotImplementedException();
        }

        public IGraph<T> Clone()
        {
            throw new NotImplementedException();
        }

        public bool ContainsVertex(T key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Edges(T key)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public IDiGraphVertex<T> GetVertex(T key)
        {
            throw new NotImplementedException();
        }

        public bool HasEdge(T source, T dest)
        {
            throw new NotImplementedException();
        }

        public void RemoveEdge(T source, T dest)
        {
            throw new NotImplementedException();
        }

        public void RemoveVertex(T key)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IGraphVertex<T> IGraph<T>.GetVertex(T key)
        {
            throw new NotImplementedException();
        }

        private class DiGraphVertex<T> : IDiGraphVertex<T>
        {
            public IEnumerable<IDiEdge<T>> OutEdges => throw new NotImplementedException();

            public IEnumerable<IDiEdge<T>> IrEdges => throw new NotImplementedException();

            public int OutEdgesCount => throw new NotImplementedException();

            public int InEdgesCount => throw new NotImplementedException();

            public T Key { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            public IEnumerable<IEdge<T>> Edges => throw new NotImplementedException();

            public IEdge<T> GetEdge(IGraphVertex<T> targetVertex)
            {
                throw new NotImplementedException();
            }

            public IEnumerator<T> GetEnumerator()
            {
                throw new NotImplementedException();
            }

            public IDiEdge<T> GetOutEdge(IDiGraphVertex<T> targetVertex)
            {
                throw new NotImplementedException();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }
    }
}

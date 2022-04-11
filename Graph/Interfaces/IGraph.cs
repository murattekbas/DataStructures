using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.Interfaces
{
    public interface IGraph<T> : IEnumerable<T>
    {
        bool isWeightedGraf { get; }
        int Count { get; }
        IGraphVertex<T> ReferenceVertex { get; }
        IEnumerable<IGraphVertex<T>> VerticesAsEnumerable { get; }
        IEnumerable<T> Edges(T key);
        IGraph<T> Clone();
        bool ContainsVertex(T key);
        IGraphVertex<T> GetVertex(T key);
        bool HasEdge(T source, T dest);
        void AddVertex(T key);
        void RemoveVertex(T key);  
        void RemoveEdge(T source, T dest);  



    }
}

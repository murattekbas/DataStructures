using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.Interfaces
{
    public interface IDiGraph<T>:IGraph<T>
    {
        new IDiGraphVertex<T> ReferenceVertex { get; }
        new IEnumerable<IDiGraphVertex<T>> VerticesAsEnumerable { get; }
        new IDiGraphVertex<T> GetVertex(T key);
    }
}

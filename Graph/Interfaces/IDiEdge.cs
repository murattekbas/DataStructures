using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.Interfaces
{
    public interface IDiEdge<T>:IEdge<T>
    {
        new IDiGraphVertex<T> TargetVertex { get; }
    }
}

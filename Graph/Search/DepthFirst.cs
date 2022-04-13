using Graph.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.Search
{
    public class DepthFirst<T>
    {
        public bool Find(IGraph<T> graph,T vertexKey)
        {
            return dfs(graph.ReferenceVertex,new HashSet<T>(),vertexKey);
        }

        private bool dfs(IGraphVertex<T> current, HashSet<T> visited,T searhVertexKey)
        {
            visited.Add(current.Key);
            Console.WriteLine(current.Key);
            if (current.Key.Equals(searhVertexKey))
                return true;

            foreach (var edge in current.Edges)
            {
                if (visited.Contains(edge.TargetVertexKey))
                    continue;
                if (dfs(edge.TargetVertex, visited, searhVertexKey))
                {
                    return true;
                }
            }
            return false;
        }
    }
}

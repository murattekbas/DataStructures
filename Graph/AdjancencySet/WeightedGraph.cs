using Graph.Concretes;
using Graph.Interfaces;
using System.Collections;

namespace Graph.AdjancencySet
{
    public class WeightedGraph<T,W>:IGraph<T> where W:IComparable
    {
        private Dictionary<T, WeightedGraphVertex<T, W>> vertices;
        public bool isWeightedGraf => true;

        public int Count => vertices.Count;

        public IGraphVertex<T> ReferenceVertex => vertices[this.First()];

        public IEnumerable<IGraphVertex<T>> VerticesAsEnumerable => vertices.Select(x=>x.Value);
        public WeightedGraph()
        {
            vertices = new Dictionary<T,WeightedGraphVertex<T, W>>();   
        }
        public WeightedGraph(IEnumerable<T> collection)
        {
            vertices=new Dictionary<T, WeightedGraphVertex<T, W>>();
            foreach (var item in collection)
            {
                AddVertex(item);
            }
        }
        public void AddVertex(T key)
        {
            if (key==null) throw new ArgumentNullException(nameof(key));

            var newVertex = new WeightedGraphVertex<T, W>(key);
            vertices.Add(key, newVertex);
        }

        IGraph<T> IGraph<T>.Clone()
        {
            return Clone();
        }

        public WeightedGraph<T,W> Clone()
        {
            var graph = new WeightedGraph<T,W>();

            foreach (var vertex in vertices)
            {
                graph.AddVertex(vertex.Key);
            }

            foreach (var vertex in vertices)
            {
                foreach (var edge in vertex.Value.Edges)
                {
                    graph.AddEdge(vertex.Value.Key, edge.Key.Key,edge.Value);
                }
            }

            return graph;
        }

        public bool ContainsVertex(T key)
        {
            return vertices.ContainsKey(key);
        }

        public IEnumerable<T> Edges(T key)
        {
            if (key == null) throw new ArgumentNullException();

            return vertices[key].Edges.Select(x => x.Key.Key);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return vertices.Select(x => x.Key).GetEnumerator();
        }

        public IGraphVertex<T> GetVertex(T key)
        {
            return vertices[key];
        }

        public bool HasEdge(T source, T dest)
        {
            if (source == null || dest == null) throw new ArgumentNullException();
            if (!vertices.ContainsKey(source) || !vertices.ContainsKey(dest)) throw new ArgumentException("source or destination vertex is not in the graph");
            return vertices[source].Edges.ContainsKey(vertices[dest]) && vertices[dest].Edges.ContainsKey(vertices[source]);
        }

        public void AddEdge(T source, T dest,W weight)
        {
            if (source == null || dest == null) throw new ArgumentNullException();
            if (!vertices.ContainsKey(source) || !vertices.ContainsKey(dest)) throw new ArgumentException("source or destination vertex is not in the graph");
            
            vertices[source].Edges.Add(vertices[dest],weight);
            vertices[dest].Edges.Add(vertices[source],weight);
        }

        public void RemoveEdge(T source, T dest)
        {
             if (source == null || dest == null) throw new ArgumentNullException();
            if (!vertices.ContainsKey(source) || !vertices.ContainsKey(dest)) throw new ArgumentException("source or destination vertex is not in the graph");
            if (!vertices[source].Edges.ContainsKey(vertices[dest]) || !vertices[dest].Edges.ContainsKey(vertices[source])) throw new Exception("nothing to remove (edge)");
            vertices[source].Edges.Remove(vertices[dest]);
            vertices[dest].Edges.Remove(vertices[source]);
        }

        public void RemoveVertex(T key)
        {
            if (key == null) throw new ArgumentNullException();

            if (!vertices.ContainsKey(key)) throw new ArgumentException("The vertex is not in this graph");

            foreach (var vertex in vertices[key].Edges)
            {
                vertex.Key.Edges.Remove(vertices[key]);
            }

            vertices.Remove(key);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
           return GetEnumerator();
        }

        private class WeightedGraphVertex<T, W> : IGraphVertex<T> where W : IComparable
        {
            public Dictionary<WeightedGraphVertex<T, W>, W> Edges;
            public T Key { get; set; }

            public WeightedGraphVertex(T key)
            {
                Key = key;
                Edges=new Dictionary<WeightedGraphVertex<T, W>,W>();
            }

            IEnumerable<IEdge<T>> IGraphVertex<T>.Edges => Edges.Select(x=> new Edge<T,W>(x.Key,x.Value));

            public IEdge<T> GetEdge(IGraphVertex<T> targetVertex)
            {
                return new Edge<T, W>(targetVertex, Edges[targetVertex as WeightedGraphVertex<T, W>]);
            }

            public IEnumerator<T> GetEnumerator()
            {
                return Edges.Select(x => x.Key.Key).GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}

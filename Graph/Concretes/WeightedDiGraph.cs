using Graph.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph.Concretes
{
    public class WeightedDiGraph<T,W>:IDiGraph<T> where W : IComparable
    {
        private Dictionary<T, WeightedDiGraphVertex<T, W>> vertices;

        public IDiGraphVertex<T> ReferenceVertex => vertices[this.First()];

        public IEnumerable<IDiGraphVertex<T>> VerticesAsEnumerable => vertices.Select(x=>x.Value);

        public bool isWeightedGraf => true;

        public int Count => vertices.Count;

        IGraphVertex<T> IGraph<T>.ReferenceVertex => vertices[this.First()] as IGraphVertex<T>;

        IEnumerable<IGraphVertex<T>> IGraph<T>.VerticesAsEnumerable => vertices.Select(x => x.Value);
        public WeightedDiGraph()
        {
            vertices = new Dictionary<T,WeightedDiGraphVertex<T, W>>();
        }
        public WeightedDiGraph(IEnumerable<T> collection)
        {
            vertices = new Dictionary<T, WeightedDiGraphVertex<T, W>>();
            foreach (var vertex in collection)
                AddVertex(vertex);
        }

        public void AddVertex(T key)
        {
            if (key == null) throw new ArgumentNullException();
            var newVertex = new WeightedDiGraphVertex<T,W>(key);
            vertices.Add(key, newVertex);
        }

        IGraph<T> IGraph<T>.Clone()
        {
            return Clone();
        }

        public WeightedDiGraph<T,W> Clone()
        {
            var graph = new WeightedDiGraph<T,W>();

            foreach (var vertex in vertices)
            {
                graph.AddVertex(vertex.Key);
            }

            foreach (var vertex in vertices)
            {
                foreach (var node in vertex.Value.OutEdges)
                {
                    graph.AddEdge(vertex.Value.Key, node.Key.Key,node.Value);
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
            return vertices[key].Edges.Select(x => x.TargetVertexKey);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return vertices.Select(x => x.Key).GetEnumerator();
        }

        public IDiGraphVertex<T> GetVertex(T key)
        {
            return vertices[key];
        }

        public bool HasEdge(T source, T dest)
        {
            if (source == null || dest == null) throw new ArgumentNullException();
            if (!vertices.ContainsKey(source) || !vertices.ContainsKey(dest)) throw new ArgumentException("source or destination vertex is not in the graph");
            return vertices[source].OutEdges.ContainsKey(vertices[dest]) && vertices[dest].InEdges.ContainsKey(vertices[source]);
        }

        public void AddEdge(T source, T dest, W weight)
        {
            if (source == null || dest == null) throw new ArgumentNullException();
            if (!vertices.ContainsKey(source) || !vertices.ContainsKey(dest)) throw new ArgumentException("source or destination vertex is not in the graph");
            if (vertices[source].OutEdges.ContainsKey(vertices[dest]) || vertices[dest].InEdges.ContainsKey(vertices[source])) throw new ArgumentException("Already defined edge");

            vertices[source].OutEdges.Add(vertices[dest],weight);
            vertices[dest].InEdges.Add(vertices[source],weight);
        }

        public void RemoveEdge(T source, T dest)
        {
            if (source == null || dest == null) throw new ArgumentNullException();
            if (!vertices.ContainsKey(source) || !vertices.ContainsKey(dest)) throw new ArgumentException("source or destination vertex is not in the graph");
            if (!vertices[source].OutEdges.ContainsKey(vertices[dest]) || !vertices[dest].InEdges.ContainsKey(vertices[source])) throw new Exception("nothing to remove (edge)");
            vertices[source].OutEdges.Remove(vertices[dest]);
            vertices[dest].InEdges.Remove(vertices[source]);
        }

        public void RemoveVertex(T key)
        {
            if (key == null) throw new ArgumentNullException();

            if (!vertices.ContainsKey(key)) throw new ArgumentException("The vertex is not in this graph");

            foreach (var vertex in vertices[key].InEdges)
            {
                vertex.Key.InEdges.Remove(vertices[key]);
            }

            foreach (var vertex in vertices[key].OutEdges)
            {
                vertex.Key.OutEdges.Remove(vertices[key]);
            }

            vertices.Remove(key);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        IGraphVertex<T> IGraph<T>.GetVertex(T key)
        {
            return vertices[key];
        }

        private class WeightedDiGraphVertex<T, W> : IDiGraphVertex<T> where W : IComparable
        {
            public Dictionary<WeightedDiGraphVertex<T,W>,W> OutEdges { get; }
            public Dictionary<WeightedDiGraphVertex<T, W>, W> InEdges { get; }
            IEnumerable<IDiEdge<T>> IDiGraphVertex<T>.OutEdges => OutEdges.Select(x => new DiEdge<T, W>(x.Key,x.Value));

            IEnumerable<IDiEdge<T>> IDiGraphVertex<T>.InEdges => InEdges.Select(x => new DiEdge<T, W>(x.Key, x.Value));

            public int OutEdgesCount =>OutEdges.Count;

            public int InEdgesCount =>InEdges.Count;

            public T Key { get ; set; }
            public WeightedDiGraphVertex(T key)
            {
                this.Key = key;
                OutEdges = new Dictionary<WeightedDiGraphVertex<T, W>, W>();
                InEdges = new Dictionary<WeightedDiGraphVertex<T, W>, W>();
            }

            public IEnumerable<IEdge<T>> Edges => OutEdges.Select(x=> new Edge<T,W>(x.Key,x.Value)); 

            public IEdge<T> GetEdge(IGraphVertex<T> targetVertex)
            {
                var node=targetVertex as WeightedDiGraphVertex<T,W>;
                return new Edge<T, W>(targetVertex,OutEdges[node]);
            }

            public IEnumerator<T> GetEnumerator()
            {
                return OutEdges.Select(x => x.Key.Key).GetEnumerator();
            }

            public IDiEdge<T> GetOutEdge(IDiGraphVertex<T> targetVertex)
            {
                var node = targetVertex as WeightedDiGraphVertex<T, W>;
                return new DiEdge<T, W>(targetVertex, OutEdges[node]);
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}

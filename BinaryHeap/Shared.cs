using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryHeap
{
    public class Shared
    {
    }

    public class CustomComparer<T> : IComparer<T> where T : IComparable
    {
        private readonly bool isMax;
        private readonly  IComparer<T> comparer;
        public CustomComparer(SortDirection sortDirection,IComparer<T> comparer)
        {
            this.isMax = sortDirection == SortDirection.Descending;
            this.comparer = comparer;
        }
        public int Compare(T? x, T? y)
        {
            return !isMax ? CompareIt(x, y) : CompareIt(y, x);
        }
        private int CompareIt(T x, T y)=>comparer.Compare(x, y);
    }

    public enum SortDirection
    {
        Ascending=0,
        Descending=1
    }
}

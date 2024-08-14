using System;

namespace Utility.DataStructures
{
    [Serializable]
    public struct NumericInterval<T> where T : IComparable<T>
    {
        public T start;
        public T end;

        public NumericInterval(T start, T end)
        {
            this.start = start;
            this.end = end;
        }
    }
}

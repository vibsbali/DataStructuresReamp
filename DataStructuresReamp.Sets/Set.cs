using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructuresReamp.Sets
{
    public class Set<T> : IEnumerable<T>
        where T : IComparer<T>
    {
        private readonly List<T> items = new List<T>();

        public Set() { }

        public Set(IEnumerable<T> items)
        {
            AddRange(items);
        }

        public void Add(T item)
        {
            if (items.Contains(item))
            {
                throw new InvalidOperationException();
            }

            items.Add(item);
        }

        public void AddRange(IEnumerable<T> items)
        {
            if (items == null)
            {
                throw new ArgumentNullException();
            }

            this.items.AddRange(items);
        }

        public bool Remove(T item)
        {
            return items.Remove(item);
        }

        public bool Contains(T item)
        {
            return items.Contains(item);
        }

        public int Count => items.Count;

        public Set<T> Union(Set<T> other)
        {
            var set = new Set<T>(items);
            foreach (var item in other)
            {
                if (!set.Contains(item))
                {
                    items.Add(item);
                }
            }

            return set;
        }

        public Set<T> Intersection(Set<T> other)
        {
            var set = new Set<T>();
            foreach (var item in other)
            {
                if (items.Contains(item))
                {
                    set.Add(item);
                }
            }

            return set;
        }

        public Set<T> Difference(Set<T> other)
        {
            var set = new Set<T>(items);
            foreach (var item in items)
            {
                set.Remove(item);
            }

            return set;
        }

        public Set<T> SymmetricDifference(Set<T> other)
        {
            var union = this.Union(other);
            var intersection = this.Intersection(other);

            return union.Difference(intersection);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

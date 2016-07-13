﻿namespace TraktApiSharp.Utils
{
    using System.Collections;
    using System.Collections.Generic;

    public abstract class TraktMultipleQueryParams<T> : IEnumerable<T>
    {
        protected readonly List<T> _items;

        public TraktMultipleQueryParams()
        {
            _items = new List<T>();
        }

        public void Add(T item)
        {
            _items.Add(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

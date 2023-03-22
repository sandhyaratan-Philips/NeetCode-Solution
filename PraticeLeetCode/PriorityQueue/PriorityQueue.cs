using System;
using System.Collections;
using System.Collections.Generic;

namespace PriorityQueue
{
    public class PriorityQueue<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        LinkedList<T> _item = new LinkedList<T>();
        public void Enqueue(T item)
        {
            if (_item.Count == 0)
            {
                var current = _item.First;

                while (current != null && current.Value.CompareTo(item) > 0)
                {
                    current = current.Next;
                }
                if (current == null)
                {
                    _item.AddLast(item);
                }
                else
                {
                    _item.AddBefore(current, item);
                }
            }
        }

        public T Dequeue()
        {
            if (_item.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty");
            }
            T value = _item.First.Value;
            _item.RemoveFirst();
            return value;
        }

        public T Peek()
        {
            if (_item.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty");
            }
            return _item.First.Value;
        }

        public int Count
        {
            get
            {
                return _item.Count;
            }
        }

        public void Clear()
        {
            _item.Clear();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _item.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _item.GetEnumerator();
        }
    }
}

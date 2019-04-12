using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests1
{
	class FakeDeque<T> : IDeque<T>
	{
		List<T> list;

		public T this[int index] { get => list[index]; set => list[index] = value; }
		public int Count => list.Count;
		public bool IsReadOnly => false;
		public void Add(T item) => AddBack(item);
		public void AddBack(T item) => list.Add(item);
		public void AddFront(T item) => list.Insert(0, item);
		public void Clear() => list.Clear();
		public bool Contains(T item) => list.Contains(item);
		public void CopyTo(T[] array, int arrayIndex) => list.CopyTo(array, arrayIndex);
		T Get(int index)
		{
			T result = list[index];
			list.RemoveAt(index);
			return result;
		}
		public T GetBack() => Get(list.Count - 1);
		public IEnumerator<T> GetEnumerator() => list.GetEnumerator();
		public T GetFront() => Get(0);
		public IDeque<T> GetReverseView()
		{
			throw new NotImplementedException();
		}
		public int IndexOf(T item) => list.IndexOf(item);
		public void Insert(int index, T item) => list.Insert(index, item);
		public bool Remove(T item) => list.Remove(item);
		public void RemoveAt(int index) => list.RemoveAt(index);
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}

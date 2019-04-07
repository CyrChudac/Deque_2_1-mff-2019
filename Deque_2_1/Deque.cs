using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deque_2_1
{
	public interface IDeque<T> : IList<T>
	{
		void AddBack(T item);
		T GetBack();

		void AddFront(T item);
		T GetFront();

		IDeque<T> GetReverseView();
	}
	public partial class Deque<T> : IDeque<T>
	{
		public static int ImplicitSize => 4;
		public Deque() : this(ImplicitSize) { }
		public Deque(int capacity) => view = new NormalView<T>(capacity);

		View<T> view;

		public int Count => view.Count;
		public bool IsReadOnly => false;
		public T this[int index] { get => view[index]; set => view[index] = value; }
		public IDeque<T> GetReverseView() => view.GetReverseView();
		public void AddBack(T item) => view.AddBack(item);
		public T GetBack() => view.GetBack();
		public void AddFront(T item) => view.AddFront(item);
		public T GetFront() => view.GetFront();
		public int IndexOf(T item) => view.IndexOf(item);
		public void Insert(int index, T item) => view.Insert(index, item);
		public void RemoveAt(int index) => view.RemoveAt(index);
		public void Add(T item) => view.Add(item);
		public void Clear() => view.Clear();
		public bool Contains(T item) => view.Contains(item);
		public void CopyTo(T[] array, int arrayIndex) => view.CopyTo(array, arrayIndex);
		public bool Remove(T item) => view.Remove(item);
		public IEnumerator<T> GetEnumerator() => view.GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		class Enumerator : IEnumerator<T>
		{
			public T Current => throw new NotImplementedException();

			object IEnumerator.Current => Current;

			public void Dispose()
			{
				throw new NotImplementedException();
			}

			public bool MoveNext()
			{
				throw new NotImplementedException();
			}

			public void Reset() => throw new Exception("Reset unsupported");

			
		}

		
	}

	sealed class Array<T>
	{
		public static readonly int Size = 32;
		public int Begin { get; private set; } = Size / 2;
		public int End { get; private set; } = Size / 2;
		public T[] list = new T[Size];
		public bool Contains(T item) => list.Contains(item);
		public T this[int i]
		{
			get => list[i];
			set => list[i] = value;
		}
	}

	public static class DequeTest
	{
		public static IList<T> GetReverseView<T>(Deque<T> d) => d.GetReverseView();
	}
}

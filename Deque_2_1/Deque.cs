using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IDeque<T> : IList<T>
{
	T PeekFront();
	T PeekBack();

	void AddBack(T item);
	T GetBack();

	void AddFront(T item);
	T GetFront();

	IDeque<T> GetReverseView();
}
public partial class Deque<T> : IDeque<T>
{
	public static int ImplicitSize => 4;
	public Deque() : this(ImplicitSize * View<T>.Array<T>.Size) { }
	public Deque(int capacity) {
		if (capacity < 0)
			throw new ArgumentOutOfRangeException();
		view = new NormalView<T>(capacity);
	}

	View<T> view;

	public T PeekBack() => view.PeekBack();
	public T PeekFront() => view.PeekFront();
	public void AddBack(T item) => view.AddBack(item);
	public T GetBack() => view.GetBack();
	public void AddFront(T item) => view.AddFront(item);
	public T GetFront() => view.GetFront();

	public int Count => view.Count;
	public bool IsReadOnly => view.IsReadOnly;
	public T this[int index] { get => view[index]; set => view[index] = value; }
	public IDeque<T> GetReverseView() => view.GetReverseView();
	public int IndexOf(T item) => view.IndexOf(item);
	public void Insert(int index, T item) => view.Insert(index, item);
	public void RemoveAt(int index) => view.RemoveAt(index);
	public void Add(T item) => view.Add(item);
	public void Clear() => view.Clear();
	public bool Contains(T item) => view.Contains(item);
	public void CopyTo(T[] array, int arrayIndex) => view.CopyTo(array, arrayIndex);
	public bool Remove(T item) => view.Remove(item);
	public IEnumerator<T> GetEnumerator() => view.GetEnumerator();
	IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)view).GetEnumerator();
}


public static class DequeTest
{
	public static IList<T> GetReverseView<T>(Deque<T> d) => d.GetReverseView();
}


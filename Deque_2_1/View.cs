using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class Deque<T> : IDeque<T>
{
	abstract class View<U> : IDeque<U>
	{
		protected Array<U>[] arrays;
		protected int begin, end;

		public abstract U this[int index] { get; set; }

		public int Count { get; protected set; } = 0;
		public bool IsReadOnly => false;

		public void Add(U item) => AddBack(item);
		public abstract void AddBack(U item);
		public abstract void AddFront(U item);
		public abstract U GetBack();
		public abstract void Clear();
		public abstract bool Contains(U item);
		public abstract U GetFront();
		public abstract IDeque<U> GetReverseView();


		public void CopyTo(U[] array, int arrayIndex)
		{
			if (arrayIndex < 0)
				throw new ArgumentOutOfRangeException(nameof(arrayIndex));
			if (array.Length - arrayIndex < Count)
				throw new ArgumentException("Not enough space between given index and destination array end.");
			for (int i = 0; i < Count; i++)
				array[arrayIndex + i] = this[i];
		}

		public void Insert(int index, U item)
		{
			if (index > Count - index)
			{
				AddBack(this[Count - 1]);
				for (int i = Count - 1; i > index; i--)
					this[i] = this[i - 1];
			}
			else
			{
				AddFront(this[0]);
				for (int i = 0; i < index; i++)
					this[i] = this[i + 1];
			}
			this[index] = item;
		}

		public bool Remove(U item)
		{
			for (int i = 0;  i < Count; i++)
					if (this[i].Equals(item))
                    {
                        RemoveAt(i);
                        return true;
                    }
			return false;
		}

		public void RemoveAt(int index)
		{
			if(index > Count - index)
			{
				for (int i = index; i < Count - 1; i++)
                    this[i] = this[i + 1];
                GetBack();
			}
			else
			{
				for (int i = index; i > 0; i--)
                    this[i]=this[i-1];
                GetFront();
			}
		}

		public IEnumerator<U> GetEnumerator() => new Enumerator<U>(this);
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();


		protected void ReallyClear()
		{
			for (int i = begin; i < end; i++)
				arrays[i] = new Array<U>();
			Count = 0;
		}

		protected bool ReallyContains(U item)
		{
			for (int i = begin; i < end; i++)
				if (arrays[i].Contains(item))
					return true;
			return false;
		}

		public int IndexOf(U item)
		{
			int result = 0;
			for (int i = begin; i <= end; i++)
			{
				int currIndex = arrays[i].IndexOf(item);
				if (currIndex >= 0)
					return result + currIndex;
				result += Array<U>.Size - 1;
			}
			return -1;
		}

		protected void ReallyAddBack(U item)
		{
			if(arrays[end].Count == Array<U>.Size)
			{
				if(end == arrays.Length - 1)
				{
					Array<U>[] newArrays = Array<U>.GetArrayOfArrays(arrays.Length * 2);
					arrays.CopyTo(newArrays, 0);
					arrays = newArrays;
				}
				end++;
			}
			Count++;
			arrays[end].AddBack(item);
		}

		protected U ReallyGetBack()
		{
			if (arrays[end].Count == 0)
				end--;
			Count--;
			return arrays[end].GetBack();
		}

		protected U ReallyGetFront()
		{
			if (arrays[begin].Count == 0)
				begin++;
			Count--;
			return arrays[begin].GetFront();
		}

		protected void ReallyAddFront(U item)
		{
			if (arrays[begin].Count == Array<U>.Size)
			{
				if (begin == 0)
				{
					Array<U>[] newArrays = Array<U>.GetArrayOfArrays(arrays.Length * 2);
					arrays.CopyTo(newArrays, arrays.Length);
					begin += arrays.Length;
					end += arrays.Length;
					arrays = newArrays;
				}
				begin--;
			}
			Count++;
			arrays[begin].AddFront(item);
		}

		class Enumerator<V> : IEnumerator<V>
		{
			int index = -1;
			readonly int count;
			View<V> view;

			public Enumerator(View<V> view)
			{
				this.view = view;
				count = view.Count;
			}

			public V Current {
				get
				{
					if (index < 0 || index > view.Count - 1)
						throw new InvalidOperationException("You did not use MoveNext yet or you are already at the collection end.");
					return view[index];
				}
			}

			object IEnumerator.Current => Current;

			public bool MoveNext()
			{
				index++;
				if (count != view.Count)
					throw new InvalidOperationException();
				return index < view.Count;
			}
			public void Reset() => index = -1;
			public void Dispose() { }
		}

		public sealed class Array<V>
		{
			public static readonly int Size = 32;
			public int MaxSize => Size;
			public int Count { get; private set; } = 0;
			public int Begin { get; private set; } = Size;
			public int End { get; private set; } = -1;
			public V[] list = new V[Size];
			public bool Contains(V item) => list.Contains(item);
			public V this[int i]
			{
				get => list[Begin + i];
				set => list[Begin + i] = value;
			}
			public int IndexOf(V item)
			{
				for (int i = Begin; i <= End; i++)
					if (list[i].Equals(item))
						return i - Begin;
				return -1;
			}
			public void AddBack(V item)
			{
				if (End == -1)
					Begin = 0;
				End++;
				list[End] = item;
				Count++;
			}
			public V GetBack()
			{
				V result = list[End];
				list[End] = default(V);
				End--;
				Count--;
				return result;
			}
			public void AddFront(V item)
			{
				if (Begin == Size)
					End = Size - 1;
				Begin--;
				list[Begin] = item;
				Count++;
			}
			public V GetFront()
			{
				V result = list[Begin];
				list[Begin] = default(V);
				Begin++;
				Count--;
				return result;
			}
			public static Array<V>[] GetArrayOfArrays(int capacity)
			{
				Array<V>[] result = new Array<V>[capacity];
				for (int i = 0; i < capacity; i++)
					result[i] = new Array<V>();
				return result;
			}
		}

	}
}


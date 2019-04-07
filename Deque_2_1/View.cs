using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deque_2_1
{
	public partial class Deque<T> : IDeque<T>
	{
		abstract class View<U> : IDeque<U>
		{
			public abstract U this[int index] { get; set; }

			public int Count { get; protected set; } = 0;
			public bool IsReadOnly => false;

			public abstract void Add(U item);
			public abstract void AddBack(U item);
			public abstract void AddFront(U item);
			public abstract U GetBack();
			public abstract void Clear();
			public abstract bool Contains(U item);
			public abstract void CopyTo(U[] array, int arrayIndex);
			public abstract U GetFront();
			public abstract IDeque<U> GetReverseView();
			public abstract int IndexOf(U item);
			public abstract void Insert(int index, U item);
			public abstract bool Remove(U item);
			public abstract void RemoveAt(int index);

			public IEnumerator<U> GetEnumerator() => new Enumerator<U>(this);
			IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();


			protected void ReallyClear(Array<U>[] arrays, int begin, int end)
			{
				for (int i = begin; i < end; i++)
					arrays[i] = new Array<U>();
				Count = 0;
			}

			protected bool ReallyContains(U item, Array<U>[] arrays, int begin, int end)
			{
				for (int i = begin; i < end; i++)
					if (arrays[i].Contains(item))
						return true;
				return false;
			}

			protected int ReallyIndexOf(U item, Array<U>[] arrays, int begin, int end)
			{
				int result = 0;
				for (int i = begin; i < end; i++)
				{
					int currIndex = arrays[i].IndexOf(item);
					if (currIndex > 0)
						return result + currIndex;
					result += Array<U>.Size - 1;
				}
				return -1;
			}

			protected void ReallyAddBack(U item, Array<U>[] arrays, ref int end)
			{
				if(arrays[end].Count == Array<U>.Size)
				{
					if(end == arrays.Count())
					{
						Array<U>[] newArrays = new Array<U>[arrays.Count() * 2];
						arrays.CopyTo(newArrays, 0);
						arrays = newArrays;
					}
					end++;
				}
				Count++;
				arrays[end].AddBack(item);
			}

			protected U ReallyGetBack(Array<U>[] arrays, ref int end)
			{
				if (arrays[end].Count == 0)
					end--;
				Count--;
				return arrays[end].GetBack();
			}

			protected U ReallyGetFront(Array<U>[] arrays, ref int begin)
			{
				if (arrays[begin].Count == 0)
					begin++;
				Count--;
				return arrays[begin].GetBack();
			}

			protected void ReallyAddFront(U item, Array<U>[] arrays, ref int begin, ref int end)
			{
				if (arrays[begin].Count == Array<U>.Size)
				{
					if (begin == 0)
					{
						Array<U>[] newArrays = new Array<U>[arrays.Count() * 2];
						arrays.CopyTo(newArrays, arrays.Count());
						begin += arrays.Count();
						end += arrays.Count();
						arrays = newArrays;
					}
					begin--;
				}
				Count++;
				arrays[begin].AddFront(item);
			}

			class Enumerator<V> : IEnumerator<V>
			{
				int index = 0;
				int count;
				View<V> view;

				public Enumerator(View<V> view)
				{
					this.view = view;
					count = view.Count;
				}

				public V Current => view[index];

				object IEnumerator.Current => Current;

				public bool MoveNext()
				{
					index++;
					if (count != view.Count)
						throw new InvalidOperationException();
					return index < view.Count;
				}
				public void Reset() => index = 0;
				public void Dispose() { }
			}

			/*					//
			//		UNDONE		//
			//					*/
		}
	}
}

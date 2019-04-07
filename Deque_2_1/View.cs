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
			public abstract IEnumerator<U> GetEnumerator();
			public abstract IDeque<U> GetReverseView();
			public abstract int IndexOf(U item);
			public abstract void Insert(int index, U item);
			public abstract bool Remove(U item);
			public abstract void RemoveAt(int index);

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

			/*					//
			//		UNDONE		//
			//					*/

			protected void ReallyAddBack(U item, Array<U>[] arrays, int end)
			{
				throw new NotImplementedException();
			}

			protected U ReallyGetBack(Array<U>[] arrays, int end)
			{
				throw new NotImplementedException();
			}

			protected void ReallyAddFront(U item, Array<U>[] arrays, int begin)
			{
				throw new NotImplementedException();
			}

			protected U ReallyGetFront(Array<U>[] arrays, int begin)
			{
				throw new NotImplementedException();
			}

			protected int ReallyIndexOf(U item, Array<U>[] arrays, int begin, int end)
			{
				throw new NotImplementedException();
			}
		}
	}
}

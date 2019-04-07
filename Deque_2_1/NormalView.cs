using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deque_2_1
{
	public partial class Deque<T> : IDeque<T>
	{
		class NormalView<U> : View<U>
		{
			Array<U>[] arrays;
			int begin, end;

			public NormalView(int capacity)
			{
				arrays = new Array<U>[capacity / Array<U>.Size];
				begin = arrays.Length/2;
				end = arrays.Length/2;
			}

			public NormalView(Array<U>[] arrays, int count, int begin, int end)
			{
				this.arrays = arrays;
				this.Count = count;
				this.begin = begin;
				this.end = end;
			}

			public override void Clear() => ReallyClear(arrays, begin, end);

			public override bool Contains(U item) => ReallyContains(item, arrays, begin, end);

			public override void Add(U item) => AddBack(item);

			public override U this[int index]
			{
				get => arrays[begin + index / Array<T>.Size][index % Array<U>.Size];
				set => arrays[begin + index / Array<T>.Size][index % Array<U>.Size] = value;
			}

			public override void AddBack(U item) => ReallyAddBack(item, arrays, end);

			public override U GetBack() => ReallyGetBack(arrays, end);

			public override void AddFront(U item) => ReallyAddFront(item, arrays, begin);

			public override U GetFront() => ReallyGetFront(arrays, begin);

			public override IDeque<U> GetReverseView() => new InvertedView<U>(arrays, Count, end, begin);

			/*					//
			//		UNDONE		//
			//					*/


			public override void CopyTo(U[] array, int arrayIndex)
			{
				throw new NotImplementedException();
			}

			public override IEnumerator<U> GetEnumerator()
			{
				throw new NotImplementedException();
			}

			public override int IndexOf(U item)
			{
				throw new NotImplementedException();
			}

			public override void Insert(int index, U item)
			{
				throw new NotImplementedException();
			}

			public override bool Remove(U item)
			{
				throw new NotImplementedException();
			}

			public override void RemoveAt(int index)
			{
				throw new NotImplementedException();
			}
		}
	}
}

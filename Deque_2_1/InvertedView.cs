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
		class InvertedView<U> : View<U>
		{
			Array<U>[] arrays;
			int begin, end;

			internal InvertedView(Array<U>[] arrays, int count, int begin, int end)
			{
				this.arrays = arrays;
				this.Count = count;
				this.begin = begin;
				this.end = end;
			}

			public override void Clear() => ReallyClear(arrays, end, begin);

			public override bool Contains(U item) => ReallyContains(item, arrays, end, begin);

			public override U this[int index]
			{
				get => arrays[begin + (Count - 1 - index) / Array<T>.Size][(Count - 1 - index) % Array<U>.Size];
				set => arrays[begin + (Count - 1 - index) / Array<T>.Size][(Count - 1 - index) % Array<U>.Size] = value;
			}

			public override U GetFront() => ReallyGetBack(arrays, ref begin);

			public override IDeque<U> GetReverseView() => new NormalView<U>(arrays, Count, end, begin);

			public override void Add(U item) => AddBack(item);

			public override void AddBack(U item) => ReallyAddFront(item, arrays, ref end, ref begin);

			public override void AddFront(U item) => ReallyAddBack(item, arrays, ref begin);

			public override U GetBack() => ReallyGetFront(arrays, ref end);

			public override int IndexOf(U item) => ReallyIndexOf(item, arrays, end, begin);

			/*					//
			//		UNDONE		//
			//					*/

			public override void CopyTo(U[] array, int arrayIndex)
			{
				throw new NotImplementedException();
			}

			public override void Insert(int index, U item)
			{
				throw new NotImplementedException();
			}		
		}
	}
}

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

			public override void AddBack(U item) => ReallyAddBack(item, arrays, ref end);

			public override U GetBack() => ReallyGetBack(arrays, ref end);

			public override void AddFront(U item) => ReallyAddFront(item, arrays, ref begin, ref end);

			public override U GetFront() => ReallyGetFront(arrays, ref begin);

			public override IDeque<U> GetReverseView() => new InvertedView<U>(arrays, Count, end, begin);

			public override int IndexOf(U item) => ReallyIndexOf(item, arrays, begin, end);

			/*					//
			//		UNDONE		//
			//					*/


			public override void CopyTo(U[] array, int arrayIndex)
			{
				throw new NotImplementedException();
			}

			public override void Insert(int index, U item)
			{
				if (index > Count - index)
                {
                    AddBack(this[Count - 1]);
                    for (int i = Count - 1; i > index; i--)
                        this[i] = this[i-1];
                }
                else
                {
                    AddFront(this[0]);
                    for (int i = 0; i < index; i++)
                        this[i] = this[i + 1];
                }
                this[index]=item;
			}

			
		}
	}
}

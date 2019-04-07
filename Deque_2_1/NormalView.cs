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
				throw new NotImplementedException();
			}

			public override bool Remove(U item)
			{
				int i1 = -1;
				int j1 = -1;
				for (int i = begin; i <= end; i++)
					for (int j = arrays[i].Begin; j < arrays[i].End; j++)
						if (arrays[i][j].Equals(item))
						{
							i1 = i;
							j1 = j;
							break;
						}
				if (i1 == -1)
					return false;
				if(end - i1 < j1 - begin)
				{
					for (int j = j1; j < arrays[i1].End; j++)
						arrays[i1][j] = arrays[i1][j + 1];
					for (int i = i1 + 1; i <= end; i++) {
						arrays[i - 1][arrays[i - 1].End] = arrays[i][arrays[i].Begin];
						for (int j = arrays[i].Begin; j < arrays[i].End; j++)
							arrays[i][j] = arrays[i][j + 1];
					}
				}
				else
				{
					for (int j = j1; j > arrays[i1].Begin; j--)
						arrays[i1][j] = arrays[i1][j - 1];
					for (int i = i1 - 1; i >= begin; i--)
					{
						arrays[i + 1][arrays[i + 1].Begin] = arrays[i][arrays[i].End];
						for (int j = arrays[i].End; j > arrays[i].Begin; j--)
							arrays[i][j] = arrays[i][j - 1];
					}
				}
				return true;
			}

			public override void RemoveAt(int index)
			{
				throw new NotImplementedException();
			}
		}
	}
}

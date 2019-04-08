using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class Deque<T> : IDeque<T>
{
	class NormalView<U> : View<U>
	{
		public NormalView(int capacity)
		{
			int count = capacity / Array<U>.Size + 1;
			arrays = Array<U>.GetArrayOfArrays(count);
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

		public override void Clear() => ReallyClear();

		public override bool Contains(U item) => ReallyContains(item);

		public override U this[int index]
		{
			get
			{
				if (index < 0)
					throw new IndexOutOfRangeException();
				int count = 0;
				for (int i = begin; i <= end; i++)
					if (index < count + arrays[i].Count)
						return arrays[i][index - count];
					else
						count += arrays[i].Count;
				throw new IndexOutOfRangeException();
			}
			set
			{
				if (index < 0)
					throw new IndexOutOfRangeException();
				int count = 0;
				for (int i = begin; i <= end; i++)
					if (index < count + arrays[i].Count)
					{
						arrays[i][index - count] = value;
						return;
					}
					else
						count += arrays[i].Count;
				throw new IndexOutOfRangeException();
			}
		}

		public override void AddBack(U item) => ReallyAddBack(item);

		public override U GetBack() => ReallyGetBack();

		public override void AddFront(U item) => ReallyAddFront(item);

		public override U GetFront() => ReallyGetFront();

		public override IDeque<U> GetReverseView() => new InvertedView<U>(arrays, Count, end, begin);
	}
}


using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class Deque<T> : IDeque<T>
{
	class InvertedView<U> : View<U>
	{
		internal InvertedView(Array<U>[] arrays, int count, int end, int begin)
		{
			this.arrays = arrays;
			this.Count = count;
			this.end = begin;
			this.begin = end;
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
				for (int i = end; i >= begin; i--)
					if (index < count + arrays[i].Count)
						return arrays[i][arrays[i].Count - (index - count)];
					else
						count += arrays[i].Count;
				throw new IndexOutOfRangeException();
			}
			set
			{
				if (index < 0)
					throw new IndexOutOfRangeException();
				int count = 0;
				for (int i = end; i >= begin; i--)
					if (index < count + arrays[i].Count)
					{
						arrays[i][arrays[i].Count - (index - count)] = value;
						return;
					}
					else
						count += arrays[i].Count;
				throw new IndexOutOfRangeException();
			}
		}

		public override U GetFront() => ReallyGetBack();

		public override IDeque<U> GetReverseView() => new NormalView<U>(arrays, Count, begin, end);

		public override void AddBack(U item) => ReallyAddFront(item);

		public override void AddFront(U item) => ReallyAddBack(item);

		public override U GetBack() => ReallyGetFront();
	}
}


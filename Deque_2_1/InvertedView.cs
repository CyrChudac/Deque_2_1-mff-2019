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
		internal InvertedView(Array<U>[] arrays, int count, int begin, int end)
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
			get => arrays[begin + (Count - 1 - index) / Array<T>.Size][(Count - 1 - index) % Array<U>.Size];
			set => arrays[begin + (Count - 1 - index) / Array<T>.Size][(Count - 1 - index) % Array<U>.Size] = value;
		}

		public override U GetFront() => ReallyGetBack();

		public override IDeque<U> GetReverseView() => new NormalView<U>(arrays, Count, end, begin);

		public override void Add(U item) => AddBack(item);

		public override void AddBack(U item) => ReallyAddFront(item);

		public override void AddFront(U item) => ReallyAddBack(item);

		public override U GetBack() => ReallyGetFront();

		public override int IndexOf(U item) => ReallyIndexOf(item);
	}
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class Deque<T> : IDeque<T>
{
	public T PeekBack() => view.PeekBack();

	public T PeekFront() => view.PeekFront();

	class NormalView<U> : View<U>
	{
		public NormalView(int capacity)
		{
			int count = capacity / Array<U>.Size + 1;
			arrays = new Map<U>(count);
			begin = arrays.Length/2;
			end = arrays.Length/2;
		}

		public NormalView(Map<U> arrays)
		{
			this.arrays = arrays;
		}

		public override int IndexOf(U item) => ReallyIndexOf(item);

        public override U this[int index]
		{
			get => ReallyIndexerGet(index);
			set => ReallyIndexerSet(index, value);
		}

		public override void AddBack(U item) => ReallyAddBack(item);

		public override U GetBack() => ReallyGetBack();

		public override void AddFront(U item) => ReallyAddFront(item);

		public override U GetFront() => ReallyGetFront();

		public override IDeque<U> GetReverseView() => new InvertedView<U>(arrays);
	}
}


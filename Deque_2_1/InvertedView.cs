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
		internal InvertedView(Map<U> arrays)
		{
			this.arrays = arrays;
		}

		public override U this[int index]
		{
			get => ReallyIndexerGet(Count - 1 - index);
			set => ReallyIndexerSet(Count - 1 - index, value);
		}

		public override int IndexOf(U item) {
			int result = ReallyIndexOf(item);
			if (result < 0)
				return result;
			return Count - 1 - result;
		}

        public override U GetFront() => ReallyGetBack();

		public override IDeque<U> GetReverseView() => new NormalView<U>(arrays);

		public override void AddBack(U item) => ReallyAddFront(item);

		public override void AddFront(U item) => ReallyAddBack(item);

		public override U GetBack() => ReallyGetFront();
	}
}


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
			arrays = new Map<U>(count);
			begin = arrays.Length/2;
			end = arrays.Length/2;
		}

		public NormalView(Map<U> arrays, int count, int begin, int end)
		{
			this.arrays = arrays;
			this.Count = count;
			this.begin = begin;
			this.end = end;
		}

        public override int IndexOf(U item)
        {
            int result = 0;
            for (int i = begin; i <= end; i++)
            {
                int currIndex = arrays[i].IndexOf(item);
                if (currIndex >= 0)
                    return result + currIndex;
                result += Array<U>.Size - 1;
            }
            return -1;
        }

        public override U this[int index]
		{
			get => ReallyIndexerGet(index);
			set => ReallyIndexerSet(index, value);
			/* Another attempt
			get
			{
				if (index < 0)
					throw new IndexOutOfRangeException();

				return arrays[((index - arrays[begin].Count) / Array<U>.Size) + 1]
					[(index - arrays[begin].Count) % Array<U>.Size];

				//int count = 0;
				//for (int i = begin; i <= end; i++)
				//	if (index < count + arrays[i].Count)
				//		return arrays[i][index - count];
				//	else
				//		count += arrays[i].Count;
			}
			set
			{
				if (index < 0)
					throw new IndexOutOfRangeException();

				arrays[((index - arrays[begin].Count) / Array<U>.Size) + 1]
					[(index - arrays[begin].Count) % Array<U>.Size] = value;
				//if (index < 0)
				//	throw new IndexOutOfRangeException();
				//int count = 0;
				//for (int i = begin; i <= end; i++)
				//	if (index < count + arrays[i].Count)
				//	{
				//		arrays[i][index - count] = value;
				//		return;
				//	}
				//	else
				//		count += arrays[i].Count;
				//throw new IndexOutOfRangeException();
			} */
		}

		public override void AddBack(U item) => ReallyAddBack(item);

		public override U GetBack() => ReallyGetBack();

		public override void AddFront(U item) => ReallyAddFront(item);

		public override U GetFront() => ReallyGetFront();

		public override IDeque<U> GetReverseView() => new InvertedView<U>(arrays, Count, end, begin);
	}
}


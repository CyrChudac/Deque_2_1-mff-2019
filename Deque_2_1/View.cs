﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class Deque<T> : IDeque<T>
{
	abstract class View<U> : IDeque<U>
	{
		protected Map<U> arrays;
		protected int begin
		{
			get => arrays.begin;
			set => arrays.begin = value;
		}
		protected int end
		{
			get => arrays.end;
			set => arrays.end = value;
		}

		public abstract U this[int index] { get; set; }

		public int Count {
			get => arrays.Count;
			protected set => arrays.Count = value;
		}
		public bool IsReadOnly => false;

		public void Add(U item) => AddBack(item);
		public abstract void AddBack(U item);
		public abstract void AddFront(U item);
		public abstract U GetBack();
		public abstract U GetFront();
		public abstract IDeque<U> GetReverseView();
        public abstract int IndexOf(U item);

		public U PeekFront() => this[0];
		public U PeekBack() => this[Count - 1];
		public void CopyTo(U[] array, int arrayIndex)
		{
			if (arrayIndex < 0)
				throw new ArgumentOutOfRangeException(nameof(arrayIndex));
			if (array == null)
				throw new ArgumentNullException();
			if (array.Length - arrayIndex < Count)
				throw new ArgumentException("Not enough space between given index and destination array end.");
			for (int i = 0; i < Count; i++)
				array[arrayIndex + i] = this[i];
		}
		public void Insert(int index, U item)
		{
			if (index > Count - index)
			{
				AddBack(default(U));
				for (int i = Count - 1; i > index; i--)
					this[i] = this[i - 1];
			}
			else
			{
				AddFront(default(U));
				for (int i = 0; i < index; i++)
					this[i] = this[i + 1];
			}
			this[index] = item;
		}
		public bool Remove(U item)
		{
			for (int i = 0;  i < Count; i++)
					if (this[i].Equals(item))
                    {
                        RemoveAt(i);
                        return true;
                    }
			return false;
		}
		public void RemoveAt(int index)
		{
			if(index > Count - index)
			{
				for (int i = index; i < Count - 1; i++)
                    this[i] = this[i + 1];
                GetBack();
			}
			else
			{
				for (int i = index; i > 0; i--)
                    this[i]=this[i-1];
                GetFront();
			}
		}
		public IEnumerator<U> GetEnumerator() => new Enumerator<U>(this);
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
		public void Clear() => arrays.Clear();
		public bool Contains(U item)
		{
			for (int i = begin; i <= end; i++)
				if (arrays[i].Contains(item))
					return true;
			return false;
		}


		protected int ReallyIndexOf(U item)
		{
			int result = 0;
			for (int i = begin; i <= end; i++)
			{
				int currIndex = arrays[i].IndexOf(item);
				if (currIndex >= 0)
				{
						return result + currIndex;
				}
				result += arrays[i].Count;
			}
			return -1;
		}
		protected U ReallyIndexerGet(int index)
		{
			if (index < arrays[begin].Count)
				return arrays[begin][index];
			index -= arrays[begin].Count;
			return arrays[begin + 1 + index / Array<U>.Size][index % Array<U>.Size];
		}
		protected void ReallyIndexerSet(int index, U item)
		{
			if (index < arrays[begin].Count)
			{
				arrays[begin][index] = item;
				return;
			}
			index -= arrays[begin].Count;
			arrays[begin + 1 + index / Array<U>.Size][index % Array<U>.Size] = item;
		}
		protected void ReallyAddBack(U item)
		{
			if (end == begin && arrays[begin].isBackFull)
				end++;
			if(arrays[end].Count == Array<U>.Size)
			{
				if(end == arrays.Length - 1)
				{
                    arrays.IncreaseBack();
				}
				end++;
			}
			Count++;
			arrays[end].AddBack(item);
		}
		protected U ReallyGetBack()
		{
			if (arrays[end].Count == 0)
				end--;
			Count--;
			return arrays[end].GetBack();
		}
		protected U ReallyGetFront()
		{
			if (arrays[begin].Count == 0)
				begin++;
			Count--;
			return arrays[begin].GetFront();
		}
		protected void ReallyAddFront(U item)
		{
			if (end == begin && arrays[begin].isFrontFull)
				begin--;
			if (arrays[begin].Count == Array<U>.Size)
			{
				if (begin == 0)
				{
                    begin += arrays.Length;
                    end += arrays.Length;
                    arrays.IncreaseFront();
				}
				begin--;
			}
			Count++;
			arrays[begin].AddFront(item);
		}



		class Enumerator<V> : IEnumerator<V>
		{
			bool disposed = false;
			int index = -1;
			readonly int count;
			View<V> view;

			public Enumerator(View<V> view)
			{
				this.view = view;
				count = view.Count;
			}

			public V Current {
				get
				{
					if (disposed)
						throw new ObjectDisposedException("Enumerator<" + nameof(V) + ">");
					if (index < 0 || index > view.Count - 1)
						throw new InvalidOperationException("You did not use MoveNext yet or you are already at the collection end.");
					return view[index];
				}
			}

			object IEnumerator.Current => Current;

			public bool MoveNext()
			{
				index++;
				if (disposed)
					throw new ObjectDisposedException("Enumerator<" + nameof(V) + ">");
				if (count != view.Count)
					throw new InvalidOperationException();
				return index < view.Count;
			}
			public void Reset() => index = -1;
			public void Dispose() { disposed = true; }
		}

		public sealed class Array<V>
		{
			public bool isFrontFull => Begin <= 0;
			public bool isBackFull => End >= Size - 1;
			public static readonly int Size = 32;
			public int MaxSize => Size;
			public int Count { get; private set; } = 0;
			public int Begin { get; private set; } = Size;
			public int End { get; private set; } = -1;

			public V[] list = new V[Size];

			public bool Contains(V item) => list.Contains(item);
			public V this[int i]
			{
				get
				{
					if (i < 0 || i > Size)
						throw new IndexOutOfRangeException();
					return list[Begin + i];
				}
				set => list[Begin + i] = value;
			}
			public int IndexOf(V item)
			{
				if (item == null)
				{
					for (int i = Begin; i <= End; i++)
						if (list[i] == null)
							return i - Begin;
				}
				else
				{
					for (int i = Begin; i <= End; i++)
						if (item.Equals(list[i]))
							return i - Begin;
				}
				return -1;
			}
			public void AddBack(V item)
			{
				if (End == -1)
					Begin = 0;
				End++;
				list[End] = item;
				Count++;
			}
			public V GetBack()
			{
				if (Count < 1)
					throw new InvalidOperationException();
				V result = list[End];
				list[End] = default(V);
				End--;
				Count--;
				return result;
			}
			public void AddFront(V item)
			{
				if (Begin == Size)
					End = Size - 1;
				Begin--;
				list[Begin] = item;
				Count++;
			}
			public V GetFront()
			{
				if (Count < 1)
					throw new InvalidOperationException();
				V result = list[Begin];
				list[Begin] = default(V);
				Begin++;
				Count--;
				return result;
			}
		}

        public class Map<V>
        {
            Array<V>[] map;

			public int begin, end;
			/// <summary>
			/// Total number of elements in the queue.
			/// </summary>
			public int Count { get; set; } = 0;
			/// <summary>
			/// Total number of arrays that queue consists of.
			/// </summary>
            public int Length => map.Length;
            public Map(int capacity)
            {
                map = GetNewMap(capacity);
            }

			static Array<V>[] GetNewMap(int capacity)
			{
				Array<V>[] result = new Array<V>[capacity];
				for (int i = 0; i < capacity; i++)
					result[i] = new Array<V>();
				return result;
			}
			public Array<V> this[int index] {
                get => map[index];
                private set => map[index] = value;
            }
			public void Clear()
			{
				for (int i = begin; i <= end; i++)
					this[i] = new Array<V>();
				Count = 0;
				begin = Length / 2;
				end = Length / 2;
			}

			public void IncreaseBack()
            {
                Array<V>[] newMap = GetNewMap(map.Length * 2);
                map.CopyTo(newMap, 0);
                map = newMap;
            }
            public void IncreaseFront()
            {
                Array<V>[] newMap = GetNewMap(map.Length * 2);
                map.CopyTo(newMap, map.Length);
                map = newMap;
            }
        }

    }
}


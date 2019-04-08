using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests1
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void EasyContructor()
		{
			IDeque<int> deq = new Deque<int>();
		}
		[TestMethod]
		public void CapacityContructor()
		{
			IDeque<int> deq = new Deque<int>(8);
		}
		[TestMethod]
		public void Add1Element()
		{
			IDeque<int> deq = new Deque<int>();
			deq.Add(5);
		}
		[TestMethod]
		public void Add40Elements()
		{
			IDeque<int> deq = new Deque<int>();
			for (int i = 0; i < 40; i++)
			{
				deq.Add(i);
			}
		}
		[TestMethod]
		public void ForeachOn40Elements()
		{
			IDeque<int> deq = new Deque<int>();
			string expected = "";
			for (int i = 0; i < 40; i++)
			{
				expected += i;
				deq.Add(i);
			}
			string actual = "";
			foreach(var item in deq)
			{
				actual += item.ToString();
			}
			Assert.AreEqual(expected, actual);
		}
		[TestMethod]
		public void Indexer()
		{
			IDeque<int> deq = new Deque<int>();
			string expected = "";
			for (int i = 0; i < 40; i++)
			{
				expected += i;
				deq.Add(i);
			}
			string actual = "";
			for (int i = 0; i < 40; i++)
				actual += deq[i];
			Assert.AreEqual(expected, actual);

		}
		[TestMethod]
		public void Count()
		{
			IDeque<int> deq = new Deque<int>();
			string expected = "";
			string actual = "";
			for (int i = 0; i < 80; i++)
			{
				expected += i;
				actual = actual + deq.Count;
				deq.Add(i);
			}
			Assert.AreEqual(expected, actual);
		}
		void Insert(int index, int number, int deqLength = 40)
		{
			IDeque<int> deq = new Deque<int>();
			for (int i = 0; i < deqLength; i++)
			{
				deq.Add(i);
			}
			deq.Insert(index, number);
			Assert.AreEqual(deq[index], number); // <--------- Also depends on indexer
			string expected = "";
			for(int i = 0; i < deqLength; i++)
			{
				if (i == index)
				{
					expected += number;
					expected += i;
					i++;
				}
				expected += i;
			}
			string actual = "";
			for (int i = 0; i < deqLength + 1; i++)
			{
				actual += deq[i];
			}
			Assert.AreEqual(expected, actual);
		}
		[TestMethod]
		public void InsertBigIndex()
		{
			Insert(80, 20, 100);
		}
		[TestMethod]
		public void InsertSmallIndex()
		{
			Insert(10, 20, 100);
		}

		/*
			UNDONE
					*/

		[TestMethod]
		public void Insert0___()
		{
			IDeque<int> deq = new Deque<int>();
			for (int i = 0; i < 40; i++)
			{
				deq.Add(i);
			}
		}
		[TestMethod]
		public void Remove()
		{
			IDeque<int> deq = new Deque<int>();
			for (int i = 0; i < 40; i++)
			{
				deq.Add(i);
			}
		}
		[TestMethod]
		public void IndexOf()
		{
			IDeque<int> deq = new Deque<int>();
			for (int i = 0; i < 40; i++)
			{
				deq.Add(i);
			}
		}
		[TestMethod]
		public void RemoveAt()
		{
			IDeque<int> deq = new Deque<int>();
			for (int i = 0; i < 40; i++)
			{
				deq.Add(i);
			}
		}
		[TestMethod]
		public void Count_VS()
		{
			IDeque<int> deq = new Deque<int>();
			for (int i = 0; i < 40; i++)
			{
				deq.Add(i);
			}
		}
		[TestMethod]
		public void Count_VS_Ch()
		{
			IDeque<int> deq = new Deque<int>();
			for (int i = 0; i < 40; i++)
			{
				deq.Add(i);
			}
		}
		[TestMethod]
		public void Count_RV()
		{
			IDeque<int> deq = new Deque<int>();
			for (int i = 0; i < 40; i++)
			{
				deq.Add(i);
			}
		}
		[TestMethod]
		public void Clear()
		{
			IDeque<int> deq = new Deque<int>();
			for (int i = 0; i < 40; i++)
			{
				deq.Add(i);
			}
		}
		[TestMethod]
		public void RemoveAt0()
		{
			IDeque<int> deq = new Deque<int>();
			for (int i = 0; i < 40; i++)
			{
				deq.Add(i);
			}
		}
	}
}

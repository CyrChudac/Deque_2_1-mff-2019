using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests1
{
	[TestClass]
	public class UnitTest1
	{
		readonly static Random Random = new Random(implicitLength);
		static int rint => Random.Next();
		readonly static int implicitLength = 40; // <-----must always be less then (4)sqrt(int.MaxValue)
		IDeque<int> deq = new Deque<int>().GetReverseView();
		IDeque<int> fake = new FakeDeque<int>();

		[TestMethod]
		public void CapacityContructor()
		{
			IDeque<int> deq = new Deque<int>(implicitLength);
		}
		[TestMethod]
		public void Add1Element()
		{
			deq.Add(rint);
		}
		[TestMethod]
		public void AddElements()
		{
			for (int i = 0; i < implicitLength; i++)
			{
				deq.Add(rint);
			}
		}
		[TestMethod]
		public void ForeachOnElements()
		{
			for (int i = 0; i < implicitLength; i++)
			{
				int a = rint;
				fake.Add(a);
				deq.Add(a);
			}
			string expected = "";
			foreach (var item in fake)
			{
				expected += item.ToString();
			}
			string actual = "";
			foreach (var item in deq)
			{
				actual += item.ToString();
			}
			Assert.AreEqual(expected, actual);
		}
		[TestMethod]
		public void Indexer()
		{
			for (int i = 0; i < implicitLength; i++)
			{
				int a = rint;
				fake.Add(a);
				deq.Add(a);
			}
			for (int i = 0; i < implicitLength; i++)
				Assert.AreEqual(fake[i], deq[i]);
		}
		[TestMethod]
		public void Count()
		{
			for (int i = 0; i < implicitLength; i++)
			{
				int a = rint;
				fake.Add(a);
				deq.Add(a);
			}
			Assert.AreEqual(fake.Count, deq.Count);
		}
		void Insert(int index, int number, int deqLength)
		{
			for (int i = 0; i < deqLength; i++)
			{
				int a = rint;
				fake.Add(a);
				deq.Add(a);
			}
			deq.Insert(index, number);
			fake.Insert(index, number);
			Assert.AreEqual(fake[index], deq[index]); // <--------- Also depends on indexer
			string expected = "";
			string actual = "";
			for (int i = 0; i < deqLength + 1; i++)
			{
				expected += fake[i];
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
		[TestMethod]
		public void Insert0___()
		{
			Insert(0, 0, implicitLength);
		}
		public void Remove(int index, int deqLenght, int item = 669)
		{
			for (int i = 0; i < deqLenght; i++)
			{
				if (i == index)
				{
					fake.Add(item);
					deq.Add(item);
				}
				else
				{
					int a = rint;
					fake.Add(a);
					deq.Add(a);
				}
			}
			string expected = "";
			fake.Remove(item);
			deq.Remove(item);
			string actual = "";
			for (int i = 0; i < deqLenght - 1; i++)
			{
				expected += fake[i];
				actual += deq[i];
			}
			Assert.AreEqual(expected, actual);
		}
		[TestMethod]
		public void RemoveSmallIndex()
		{
			Remove(3, implicitLength);
		}
		[TestMethod]
		public void RemoveBigIndex()
		{
			Remove(66, 67);
		}
		[TestMethod]
		public void IndexOf()
		{
			for (int i = 0; i < implicitLength; i++)
			{
				int a = rint;
				fake.Add(a);
				deq.Add(a);
			}
			Assert.AreEqual(fake.IndexOf(0), deq.IndexOf(0));
			Assert.AreEqual(fake.IndexOf(implicitLength - 3), deq.IndexOf(implicitLength - 3));
		}
		public void RemoveAt(int at)
		{
			for (int i = 0; i < implicitLength; i++)
			{
				int a = rint;
				fake.Add(a);
				deq.Add(a);
			}
			fake.RemoveAt(at);
			deq.RemoveAt(at);
			string actual = "";
			for (int i = 0; i < implicitLength - 1; i++)
				actual += deq[i];
			string expected = "";
			for (int i = 0; i < implicitLength - 1; i++)
				expected += fake[i];
			Assert.AreEqual(expected, actual);
		}
		[TestMethod]
		public void RemoveAtGeneral()
		{
			RemoveAt( rint % implicitLength);
		}
		[TestMethod]
		public void Count_VS()
		{
			for (int i = 0; i < implicitLength * implicitLength * implicitLength; i++)
			{
				int a = rint;
				fake.Add(a);
				deq.Add(a);
			}
			Assert.AreEqual(fake.Count, deq.Count);
			for (int i = 0; i < implicitLength * implicitLength ; i++)
			{
				fake.RemoveAt(i);
				deq.RemoveAt(i);
			}
			Assert.AreEqual(fake.Count, deq.Count);
		}
		[TestMethod]
		public void RemoveAt0()
		{
			RemoveAt(0);
		}
		[TestMethod]
		public void Clear()
		{
			for (int i = 0; i < implicitLength; i++)
			{
				int a = rint;
				fake.Add(a);
				deq.Add(a);
			}
			fake.Clear();
			deq.Clear();
			string expected = "";
			for (int i = 0; i < fake.Count; i++)
				expected += fake[i].ToString();
			string actual = "";
			for (int i = 0; i < deq.Count; i++)
				actual += deq[i].ToString();
			Assert.AreEqual(expected, actual);
		}

		/*
			UNDONE
					*/

		[TestMethod]
		public void Count_VS_Ch()
		{
			for (int i = 0; i < implicitLength; i++)
			{
				deq.Add(i);
			}
		}
	}
}

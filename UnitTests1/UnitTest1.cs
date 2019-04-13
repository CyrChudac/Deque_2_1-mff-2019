using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests1
{
	[TestClass]
	public class TestNormalView
	{
		UnitTest1 testingClass = new UnitTest1( new Deque<int>());
		[TestMethod]
		public void CapacityContructor() => testingClass.CapacityContructor();
		[TestMethod]
		public void Add1Element() => testingClass.Add1Element();
		[TestMethod]
		public void AddElements() => testingClass.AddElements();
		[TestMethod]
		public void ForeachOnElements() => testingClass.ForeachOnElements();
		[TestMethod]
		public void Indexer() => testingClass.Indexer();
		[TestMethod]
		public void Count() => testingClass.Indexer();
		[TestMethod]
		public void InsertBigIndex() => testingClass.InsertBigIndex();
		[TestMethod]
		public void InsertSmallIndex() => testingClass.InsertSmallIndex();
		[TestMethod]
		public void Insert0___() => testingClass.Insert0___();
		[TestMethod]
		public void RemoveSmallIndex() => testingClass.RemoveSmallIndex();
		[TestMethod]
		public void RemoveBigIndex() => testingClass.RemoveBigIndex();
		[TestMethod]
		public void IndexOf() => testingClass.IndexOf();
		[TestMethod]
		public void RemoveAtGeneral() => testingClass.RemoveAtGeneral();
		[TestMethod]
		public void Count_VS() => testingClass.Count_VS();
		[TestMethod]
		public void RemoveAt0() => testingClass.RemoveAt0();
		[TestMethod]
		public void Clear() => testingClass.Clear();
	}
	[TestClass]
	public class TestReverseView
	{
		UnitTest1 testingClass = new UnitTest1(new Deque<int>().GetReverseView());
		[TestMethod]
		public void CapacityContructor() => testingClass.CapacityContructor();
		[TestMethod]
		public void Add1Element() => testingClass.Add1Element();
		[TestMethod]
		public void AddElements() => testingClass.AddElements();
		[TestMethod]
		public void ForeachOnElements() => testingClass.ForeachOnElements();
		[TestMethod]
		public void Indexer() => testingClass.Indexer();
		[TestMethod]
		public void Count() => testingClass.Indexer();
		[TestMethod]
		public void InsertBigIndex() => testingClass.InsertBigIndex();
		[TestMethod]
		public void InsertSmallIndex() => testingClass.InsertSmallIndex();
		[TestMethod]
		public void Insert0___() => testingClass.Insert0___();
		[TestMethod]
		public void RemoveSmallIndex() => testingClass.RemoveSmallIndex();
		[TestMethod]
		public void RemoveBigIndex() => testingClass.RemoveBigIndex();
		[TestMethod]
		public void IndexOf() => testingClass.IndexOf();
		[TestMethod]
		public void RemoveAtGeneral() => testingClass.RemoveAtGeneral();
		[TestMethod]
		public void Count_VS() => testingClass.Count_VS();
		[TestMethod]
		public void RemoveAt0() => testingClass.RemoveAt0();
		[TestMethod]
		public void Clear() => testingClass.Clear();
	}

	public class UnitTest1
	{
		public UnitTest1(IDeque<int> deq)
		{
			this.deq = deq;
		}
		readonly static Random Random = new Random(implicitLength);
		static int rint => Random.Next();
		readonly static int implicitLength = 40; // <-----must always be less then (4)sqrt(int.MaxValue)
		IDeque<int> deq;
		IDeque<int> fake = new FakeDeque<int>();

		public void CapacityContructor()
		{
			IDeque<int> deq = new Deque<int>(implicitLength);
		}
		public void Add1Element()
		{
			deq.Add(rint);
		}
		public void AddElements()
		{
			for (int i = 0; i < implicitLength; i++)
			{
				deq.Add(rint);
			}
		}
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
		public void InsertBigIndex()
		{
			Insert(80, 20, 100);
		}
		public void InsertSmallIndex()
		{
			Insert(10, 20, 100);
		}
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
		public void RemoveSmallIndex()
		{
			Remove(3, implicitLength);
		}
		public void RemoveBigIndex()
		{
			Remove(66, 67);
		}
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
		public void RemoveAtGeneral()
		{
			RemoveAt( rint % implicitLength);
		}
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
		public void RemoveAt0()
		{
			RemoveAt(0);
		}
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
	}
}

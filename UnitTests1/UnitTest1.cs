using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DeqTests
{

	interface TestOneView
	{
		void CapacityContructor();
		void Add1Element();
		void AddElements();
		void ForeachOnElements();
		void ImprovedIndexer();
		void Indexer();
		void Count();
		void InsertBigIndex();
		void InsertSmallIndex();
		void Insert0___();
		void RemoveSmallIndex();
		void RemoveBigIndex();
		void IndexOf();
		void RemoveAtGeneral();
		void Count_VS();
		void RemoveAt0();
		void Clear();
		void ImprovedRemoveAt0();
		void AddAndRemoveEnd();
		void InsertAtEnd();
		void Add_Insert_Count();
	}

	[TestClass]
	public class TestNormalView : TestOneView
	{
		TestOneView testingClass = new TestView( new Deque<int>());
		[TestMethod]
		public void CapacityContructor() => testingClass.CapacityContructor();
		[TestMethod]
		public void Add1Element() => testingClass.Add1Element();
		[TestMethod]
		public void AddElements() => testingClass.AddElements();
		[TestMethod]
		public void ForeachOnElements() => testingClass.ForeachOnElements();
		[TestMethod]
		public void ImprovedIndexer() => testingClass.ImprovedIndexer();
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
		[TestMethod]
		public void ImprovedRemoveAt0() => testingClass.ImprovedRemoveAt0();
		[TestMethod]
		public void AddAndRemoveEnd() => testingClass.AddAndRemoveEnd();
		[TestMethod]
		public void InsertAtEnd() => testingClass.InsertAtEnd();
		[TestMethod]
		public void Add_Insert_Count() => testingClass.Add_Insert_Count();
	}
	[TestClass]
	public class TestReverseView : TestOneView
	{
		TestOneView testingClass = new TestView(new Deque<int>().GetReverseView());
		[TestMethod]
		public void CapacityContructor() => testingClass.CapacityContructor();
		[TestMethod]
		public void Add1Element() => testingClass.Add1Element();
		[TestMethod]
		public void AddElements() => testingClass.AddElements();
		[TestMethod]
		public void ForeachOnElements() => testingClass.ForeachOnElements();
		[TestMethod]
		public void ImprovedIndexer() => testingClass.ImprovedIndexer();
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
		[TestMethod]
		public void ImprovedRemoveAt0() => testingClass.ImprovedRemoveAt0();
		[TestMethod]
		public void AddAndRemoveEnd() => testingClass.AddAndRemoveEnd();
		[TestMethod]
		public void InsertAtEnd() => testingClass.InsertAtEnd();
		[TestMethod]
		public void Add_Insert_Count() => testingClass.Add_Insert_Count();
	}
	[TestClass]
	public class TestBothViewsAtOnce
	{
		IDeque<int> deq = new Deque<int>();
		[TestMethod]
		public void TestCount()
		{
			for(int i = 0; i < TestView.implicitLength; i++)
			{
				deq.Add(TestView.rint);
			}
			deq = deq.GetReverseView();
			for(int i = 0; i < TestView.implicitLength; i++)
			{
				deq.Add(TestView.rint);
			}
			IDeque<int> deq2 = deq.GetReverseView();
			Assert.AreEqual(deq.Count, deq2.Count);
		}
		[TestMethod]
		[ExpectedException(typeof(IndexOutOfRangeException))]
		public void TestIndexOnEmptyDeq()
		{
			int a = deq[0];
		}
	}

	public class TestView : TestOneView
	{
		public TestView(IDeque<int> deq)
		{
			this.deq = deq;
		}
		readonly static Random Random = new Random(implicitLength);
		public static int rint => Random.Next();
		public readonly static int implicitLength = 40; // <-----must always be less then (4)sqrt(int.MaxValue)
		IDeque<int> deq;
		IDeque<int> fake = new FakeDeque<int>();

		void AddToBoth()
		{
			for (int i = 0; i < implicitLength; i++)
			{
				int a = rint;
				deq.Add(a);
				fake.Add(a);
			}
		}
		void CompareAndAssert()
		{
			string expected = "";
			string actual = "";
			for (int i = 0; i < fake.Count; i++)
				expected += fake[i];
			for (int i = 0; i < deq.Count; i++)
				actual += deq[i];
			Assert.AreEqual(expected, actual);
		}
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
			AddToBoth();
		}
		public void ForeachOnElements()
		{
			AddToBoth();
			string expected = "";
			string actual = "";
			foreach(var item in fake)
				expected += item;
			foreach(var item in deq)
				actual += item;
			Assert.AreEqual(expected, actual);

		}
		public void ImprovedIndexer()
		{
			AddToBoth();
			CompareAndAssert();
			deq = deq.GetReverseView();
			fake = fake.GetReverseView();
			CompareAndAssert();
			AddToBoth();
			CompareAndAssert();
			deq = deq.GetReverseView();
			fake = fake.GetReverseView();
			CompareAndAssert();
		}
		public void Indexer()
		{
			AddToBoth();
			CompareAndAssert();
		}
		public void Count()
		{
			AddToBoth();
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
			CompareAndAssert();
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
			fake.Remove(item);
			deq.Remove(item);
			CompareAndAssert();
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
			AddToBoth();
			Assert.AreEqual(fake.IndexOf(0), deq.IndexOf(0));
			Assert.AreEqual(fake.IndexOf(implicitLength - 3), deq.IndexOf(implicitLength - 3));
		}
		void RemoveAt(int at)
		{
			AddToBoth();
			fake.RemoveAt(at);
			deq.RemoveAt(at);
			CompareAndAssert();
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
			AddToBoth();
			fake.Clear();
			deq.Clear();
			CompareAndAssert();
		}
		public void ImprovedRemoveAt0()
		{
			AddToBoth();
			for (int i = 0; i < implicitLength; i++)
			{
				deq.RemoveAt(0);
				fake.RemoveAt(0);
			}
			CompareAndAssert();
		}
		public void AddAndRemoveEnd()
		{
			AddToBoth();
			AddToBoth();
			for(int i = 0; i < implicitLength; i++)
			{
				deq.RemoveAt(deq.Count - 1);
				fake.RemoveAt(fake.Count - 1);
			}
			AddToBoth();
			for (int i = 0; i < implicitLength; i++)
			{
				deq.RemoveAt(deq.Count - 1);
				fake.RemoveAt(fake.Count - 1);
			}
			CompareAndAssert();
		}
		public void InsertAtEnd()
		{
			Insert(implicitLength, 3, implicitLength);
		}
		public void Add_Insert_Count()
		{
			AddToBoth();
			for (int i = 0; i < deq.Count; i += 2)
				deq.Insert(i, i);
			for (int i = 0; i < fake.Count; i += 2)
				fake.Insert(i, i);
			Assert.AreEqual(fake.Count, deq.Count);
			CompareAndAssert();
		}
	}
}

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
		void InsertInEmpty();
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
		[TestMethod]
		public void InsertInEmpty() => testingClass.InsertInEmpty();
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
		[TestMethod]
		public void InsertInEmpty() => testingClass.InsertInEmpty();
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
		public void InsertInEmpty()
		{
			deq.Insert(0, 5);
			Assert.AreEqual(5, deq.PeekBack());
		}
	}

	[TestClass]
	public class TestOnNulls
	{
		IDeque<int?> deq = new Deque<int?>().GetReverseView();
		IDeque<int?> fake = new FakeDeque<int?>().GetReverseView();
		static int ImplicitInt => 20;

		[TestMethod]
		public void Add_Null()
		{
			deq.Add(null);
			fake.Add(null);
			Assert.AreEqual(fake[0], deq[0]);
		}
		[TestMethod]
		public void Add_Nulls()
		{
			for (int i = 0; i < ImplicitInt; i++)
			{
				fake.Add(null);
				deq.Add(null);
			}
			for (int i = 0; i < ImplicitInt; i++)
				Assert.AreEqual(fake[i], deq[i]);
		}
		[TestMethod]
		public void Add_NullsAndNumbers()
		{
			for (int i = 0; i < ImplicitInt; i++)
			{
				deq.Add(5);
				deq.Add(null);
				fake.Add(5);
				fake.Add(null);
			}
			for (int i = 0; i < ImplicitInt; i++)
				Assert.AreEqual(fake[i], deq[i]);
		}
		[TestMethod]
		public void Remove_NullFromEmpty()
		{
			if (deq.Remove(null))
				throw new Exception("Attempt to remove null from epmty deque succeeded.");
		}
		[TestMethod]
		public void Remove_Nulls()
		{
			for (int i = 0; i < ImplicitInt; i++)
			{
				deq.Add(5);
				deq.Add(null);
			}
			for (int i = 0; i < ImplicitInt; i++)
				if (!deq.Remove(null))
					throw new Exception("there should be enough nulls to remove");
		}
		[TestMethod]
		public void Remove_NullsWithNoNullsInside()
		{
			for (int i = 0; i < ImplicitInt; i++)
			{
				deq.Add(5);
			}
			for (int i = 0; i < ImplicitInt; i++)
				if (deq.Remove(null))
					throw new Exception("there should be enough nulls to remove");
		}
		[TestMethod]
		public void Insert_NullsAndNumbers()
		{
			for (int i = 0; i < ImplicitInt; i++)
			{
				deq.Insert(i, 5);
				deq.Insert(i, null);
				fake.Insert(i, 5);
				fake.Insert(i, null);
			}
			for (int i = 0; i < ImplicitInt; i++)
				Assert.AreEqual(fake[i], deq[i]);
		}
		[TestMethod]
		public void Contains_WithNulls()
		{
			for (int i = 0; i < ImplicitInt; i++)
			{
				deq.Add(null);
			}
			deq.Insert(ImplicitInt / 2, 5);

			Assert.IsTrue(deq.Contains(5));
		}
		[TestMethod]
		public void IndexOf_Null()
		{
			for (int i = 0; i < ImplicitInt; i++)
			{
				deq.Add(5);
			}
			deq.Insert(8, null);

			Assert.AreEqual(8, deq.IndexOf(null));
		}
		[TestMethod]
		public void IndexOf_WithNulls()
		{
			for (int i = 0; i < ImplicitInt; i++)
			{
				deq.Add(null);
			}
			deq.Insert(8, 5);

			Assert.AreEqual(8, deq.IndexOf(5));
		}
		[TestMethod]
		public void RemoveAt_Null()
		{
			for (int i = 0; i < ImplicitInt; i++)
			{
				deq.Add(5);
			}
			deq.Insert(8, null);

			deq.RemoveAt(8);
		}
		[TestMethod]
		public void RemoveAt_WithNulls()
		{
			for (int i = 0; i < ImplicitInt; i++)
			{
				deq.Add(null);
			}
			deq.Insert(8, 8);

			deq.RemoveAt(8);
		}
		[TestMethod]
		public void Clear_NullsAndNumbers()
		{
			Add_NullsAndNumbers();
			deq.Clear();
			Assert.AreEqual(0, deq.Count);
		}
		[TestMethod]
		public void CopyTo_NullsAndNumbers()
		{
			Add_NullsAndNumbers();
			int count = deq.Count;
			int?[] testingArray = new int?[ImplicitInt * 2];
			deq.CopyTo(testingArray, 0);
			Assert.AreEqual(count, testingArray.Length);
		}
		[TestMethod]
		public void IndexerGet_NullsAndNumbers()
		{
			Add_NullsAndNumbers();
			for (int i = 0; i < deq.Count; i++)
				Assert.AreEqual(fake[i], deq[i]);
		}
		[TestMethod]
		public void IndexerSet_NullsAndNumbers()
		{
			Add_NullsAndNumbers();
			int count = deq.Count;
			for (int i = 0; i < deq.Count; i++)
				deq[i] = null;
			Assert.AreEqual(count, deq.Count);
			deq.Clear(); // <------ nedovoli prekladaci optimalizaci ve for cyklu
		}
		[TestMethod]
		public void Foreach_WithNulls()
		{
			Add_NullsAndNumbers();
			foreach (var item in deq)
			{
				if (item.Equals(-1))
					throw new Exception("there should be no -1 in the Deque");
			}
		}
		[TestMethod]
		public void AddBack_AddFront_Null()
		{
			for (int i = 0; i < ImplicitInt; i++)
			{
				deq.AddFront(5);
				deq.AddFront(null);
				deq.AddBack(6);
				deq.AddBack(null);
				fake.AddFront(5);
				fake.AddFront(null);
				fake.AddBack(6);
				fake.AddBack(null);
			}
			for (int i = 0; i < ImplicitInt * 4; i++)
				Assert.AreEqual(fake[i], deq[i]);
		}
	}
}

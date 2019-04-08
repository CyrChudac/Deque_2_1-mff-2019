using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests1
{
	[TestClass]
	public class UnitTest1
	{
		static int implicitLength = 40; // <-----must always be less then (4)sqrt(int.MaxValue)
		IDeque<int> deq = new Deque<int>().GetReverseView();
		[TestMethod]
		public void CapacityContructor()
		{
			IDeque<int> deq = new Deque<int>(implicitLength);
		}
		[TestMethod]
		public void Add1Element()
		{
			deq.Add(5);
		}
		[TestMethod]
		public void AddElements()
		{
			for (int i = 0; i < implicitLength; i++)
			{
				deq.Add(i);
			}
		}
		[TestMethod]
		public void ForeachOnElements()
		{
			string expected = "";
			for (int i = 0; i < implicitLength; i++)
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
			string expected = "";
			for (int i = 0; i < implicitLength; i++)
			{
				expected += i;
				deq.Add(i);
			}
			string actual = "";
			for (int i = 0; i < implicitLength; i++)
				actual += deq[i];
			Assert.AreEqual(expected, actual);

		}
		[TestMethod]
		public void Count()
		{
			string expected = "";
			string actual = "";
			for (int i = 0; i < implicitLength; i++)
			{
				expected += i;
				actual = actual + deq.Count;
				deq.Add(i);
			}
			Assert.AreEqual(expected, actual);
		}
		void Insert(int index, int number, int deqLength)
		{
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
		[TestMethod]
		public void Insert0___()
		{
			Insert(0, 0, implicitLength);

		}
		public void Remove(int item, int deqLenght)
		{
			for (int i = 0; i < deqLenght; i++)
			{
				deq.Add(i);
			}
			string expected = "";
			for (int i = 0; i < deqLenght; i++)
				if (item != deq[i])
					expected += i;
			deq.Remove(item);
			string actual = "";
			for (int i = 0; i < deqLenght - 1; i++)
				actual += deq[i];
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
				deq.Add(i);
			}
			Assert.AreEqual(0, deq.IndexOf(0));
			Assert.AreEqual(implicitLength - 4, deq.IndexOf(implicitLength - 3));
		}
		public void RemoveAt(int at)
		{
			for (int i = 0; i < implicitLength; i++)
			{
				deq.Add(i);
			}
			string expected = "";
			for (int i = 0; i < implicitLength; i++)
				if (at != i)
					expected += i;
			deq.RemoveAt(at);
			string actual = "";
			for (int i = 0; i < implicitLength - 1; i++)
				actual += deq[i];
			Assert.AreEqual(expected, actual);
		}
		[TestMethod]
		public void RemoveAtGeneral()
		{
			RemoveAt(new Random().Next(implicitLength));
		}
		[TestMethod]
		public void Count_VS()
		{
			for (int i = 0; i < implicitLength * implicitLength * implicitLength; i++)
			{
				deq.Add(i);
			}
			Assert.AreEqual(implicitLength * implicitLength * implicitLength, deq.Count);
			for (int i = 0; i < implicitLength * implicitLength; i++)
				deq.RemoveAt(i);
			Assert.AreEqual(implicitLength * implicitLength * implicitLength 
				- implicitLength * implicitLength, deq.Count);
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
				deq.Add(i);
			}
			deq.Clear();
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

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DequeLib;
using System.Linq;
using System.Collections.Generic;

namespace Task4_Tests
{
    [TestClass]
    public class Task4_Tests
    {
        [TestMethod]
        public void TestPushFirstAndLast() 
        {
            Deque<object> dec = new Deque<object>();
            dec.AddFirst("Hi");
            dec.AddLast(3);
            dec.AddFirst(4);
            dec.AddLast("Bye");
            object[] arr = new object[] { 4, "Hi", 3, "Bye" };
            for (int i = 0; i < arr.Length; i++)
                if (arr[i].GetHashCode() != dec.RemoveFirst().GetHashCode())
                    Assert.Fail();
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestSearch()
        {
            Deque<object> dec = new Deque<object>();
            dec.AddFirst(5.33);
            dec.AddLast(1);
            dec.AddFirst("lol");
            dec.AddLast('<');
            object[] arr = new object[] { "lol", 5.33, 1, '<' };
            for (int i = 0; i < arr.Length; i++) 
                if (dec.Search(arr[i]) != i)
                    Assert.Fail();
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestRemove()
        {
            Deque<object> dec = new Deque<object>();
            dec.AddFirst("Hi");
            dec.AddFirst(4);
            dec.AddFirst(5.33);
            dec.AddFirst("lol");
            dec.AddLast(3);
            dec.AddLast("Bye");
            dec.AddLast(1);
            dec.AddLast('<');
            List<object> arr = new List<object> { "lol", 5.33, 4, "Hi", 3, "Bye", 1, '<'};

            dec.Remove(5.33);
            arr.RemoveAt(1);
            for (int i = 0; i < arr.Count; i++)
                if (i != dec.Search(arr[i]))
                    Assert.Fail();

            dec.Remove('<');
            arr.RemoveAt(6);
            for (int i = 0; i < arr.Count; i++)
                if (i != dec.Search(arr[i]))
                    Assert.Fail();

            dec.Remove("lol");
            arr.RemoveAt(0);
            for (int i = 0; i < arr.Count; i++)
                if (i != dec.Search(arr[i]))
                    Assert.Fail();
            Assert.IsTrue(true);
        }
    }
}

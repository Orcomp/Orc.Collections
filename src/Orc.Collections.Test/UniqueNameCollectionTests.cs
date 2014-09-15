namespace DefaultNamespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using NUnit.Framework;

    using Orc.Collections;
    using Orc.Collections.Tests;

    [TestFixture]
    public class UniqueNameCollectionTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void UniqueNameCollection_Instantiate_WithDuplicateName_WillThrow()
        {
            var orders = new List<Order>() { new Order("hello"), new Order("hello") };

            var uniqueNameCollection = new UniqueNameCollection<Order>(orders);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void UniqueNameCollection_Add_WithDuplicateName_WillThrow()
        {
            var orders = new List<Order>() { new Order("hello"), new Order("hello") };

            var uniqueNameCollection = new UniqueNameCollection<Order>();

            foreach (var order in orders)
            {
                uniqueNameCollection.Add(order);
            }
        }

        [Test]
        public void UniqueNameCollection_Get_ReturnMatch()
        {
            var hello = new Order("hello");
            var world = new Order("world");

            var orders = new List<Order>() { hello , world};

            var uniqueNameCollection = new UniqueNameCollection<Order>(orders);

            var result = uniqueNameCollection.Get(world.Name);

			Assert.True(ReferenceEquals(result, world));
        }

        [Test]
        public void UniqueNameCollection_Get_ReturnNull()
        {
            var hello = new Order("hello");
            var world = new Order("world");

            var orders = new List<Order>() { hello, world };

            var uniqueNameCollection = new UniqueNameCollection<Order>(orders);

            var result = uniqueNameCollection.Get("test");

            Assert.True(result == null);
        }

        [Test]
        public void UniqueNameCollection_ContainsName_ReturnTrue()
        {
            var hello = new Order("hello");
            var world = new Order("world");

            var orders = new List<Order>() { hello, world };

            var uniqueNameCollection = new UniqueNameCollection<Order>(orders);

            var result = uniqueNameCollection.Contains(world.Name);

            Assert.True(result);
        }

        [Test]
        public void UniqueNameCollection_ContainsName_ReturnFalse()
        {
            var hello = new Order("hello");
            var world = new Order("world");

            var orders = new List<Order>() { hello, world };

            var uniqueNameCollection = new UniqueNameCollection<Order>(orders);

            var result = uniqueNameCollection.Contains("test");

            Assert.False(result);
        }

        [Test]
        public void UniqueNameCollection_ContainsObject_ReturnTrue()
        {
            var hello = new Order("hello");
            var world = new Order("world");

            var orders = new List<Order>() { hello, world };

            var uniqueNameCollection = new UniqueNameCollection<Order>(orders);

            var result = uniqueNameCollection.Contains(world);

            Assert.True(result);
        }

        [Test]
        public void UniqueNameCollection_ContainsObject_ReturnFalse()
        {
            var hello = new Order("hello");
            var world = new Order("world");
            var test = new Order("test");

            var orders = new List<Order>() { hello, world };

            var uniqueNameCollection = new UniqueNameCollection<Order>(orders);

            var result = uniqueNameCollection.Contains(test);

            Assert.False(result);
        }

        [Test]
        public void UniqueNameCollection_RemoveName_ReturnTrue()
        {
            var hello = new Order("hello");
            var world = new Order("world");

            var orders = new List<Order>() { hello, world };

            var uniqueNameCollection = new UniqueNameCollection<Order>(orders);

            var result = uniqueNameCollection.Remove(world.Name);

            Assert.True(result);
        }

        [Test]
        public void UniqueNameCollection_RemoveName_ReturnFalse()
        {
            var hello = new Order("hello");
            var world = new Order("world");

            var orders = new List<Order>() { hello, world };

            var uniqueNameCollection = new UniqueNameCollection<Order>(orders);

            var result = uniqueNameCollection.Remove("test");

            Assert.False(result);
        }

        [Test]
        public void UniqueNameCollection_RemoveObject_ReturnTrue()
        {
            var hello = new Order("hello");
            var world = new Order("world");

            var orders = new List<Order>() { hello, world };

            var uniqueNameCollection = new UniqueNameCollection<Order>(orders);

            var result = uniqueNameCollection.Remove(world);

            Assert.True(result);
        }

        [Test]
        public void UniqueNameCollection_RemoveObject_ReturnFalse()
        {
            var hello = new Order("hello");
            var world = new Order("world");
            var test = new Order("test");

            var orders = new List<Order>() { hello, world };

            var uniqueNameCollection = new UniqueNameCollection<Order>(orders);

            var result = uniqueNameCollection.Remove(test);

            Assert.False(result);
        }

        [Test]
        public void UniqueNameCollection_EnumerateCollection()
        {
            var hello = new Order("hello");
            var world = new Order("world");
            var test = new Order("test");

            var orders = new List<Order>() { hello, world, test };

            var uniqueNameCollection = new UniqueNameCollection<Order>(orders);

            var collection = uniqueNameCollection.ToArray();

            var expected = new[] { hello, world, test};

            Assert.AreEqual(expected, collection);
        }
    }
}
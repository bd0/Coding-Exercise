using CodingExercise.Enums;
using CodingExercise.EventStore;
using CodingExercise.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingExercise.Tests.EventStore
{
    [TestClass]
    public class InMemoryEventStore_AddEvent
    {


        public IEventStore NewEventStore() => new InMemoryEventStore();


        [TestMethod]
        public void ShouldBeEmptyWhenInitialized()
        {
            var eventStore = NewEventStore();

            var result = eventStore.Events;

            Assert.AreEqual(0, result.Count());
        }


        [TestMethod]
        public void ShouldStoreAllEventsAdded()
        {
            var eventStore = NewEventStore();

            var events = new List<IEvent>()
            {
                new TestEvent(),
                new TestEvent(),
                new TestEvent(),
                new TestEvent(),
            };

            foreach(var ev in events)
            {
                eventStore.AddEvent(ev);
            }

            var result = eventStore.Events;

            CollectionAssert.AreEqual(events, result.ToArray(), new EventComparer());
        }

    }
}

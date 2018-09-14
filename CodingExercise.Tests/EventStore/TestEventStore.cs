using CodingExercise.EventStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingExercise.Tests.EventStore
{
    public class TestEventStore : IEventStore
    {

        private List<IEvent> events = new List<IEvent>();


        public IEnumerable<IEvent> Events
        {
            get => events;
            set => events = value.ToList();
        }


        public void AddEvent(IEvent @event)
        {
            events.Add(@event);
        }

    }
}

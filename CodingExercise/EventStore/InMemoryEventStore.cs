using System;
using System.Collections.Generic;
using System.Text;

namespace CodingExercise.EventStore
{
    /// <summary>
    /// A simple repository maintaining a list of all events
    /// recorded by the system. Normally this would be in 
    /// some sort of persistent storage.
    /// </summary>
    public class InMemoryEventStore : IEventStore
    {
        readonly List<IEvent> events;


        public InMemoryEventStore()
        {
            events = new List<IEvent>();
        }


        /// <summary>
        /// Returns a list of all events that have occurred in the system.
        /// </summary>
        public IEnumerable<IEvent> Events => events.AsReadOnly();


        /// <summary>
        /// Adds the event to the event store history.
        /// </summary>
        /// <param name="event"></param>
        public void AddEvent(IEvent @event)
        {
            events.Add(@event);
        }

    }
}

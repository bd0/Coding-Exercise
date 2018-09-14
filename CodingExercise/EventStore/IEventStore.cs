using System;
using System.Collections.Generic;
using System.Text;

namespace CodingExercise.EventStore
{
    /// <summary>
    /// Stores events that are received by the system.
    /// </summary>
    public interface IEventStore
    {
        /// <summary>
        /// Returns a list of all events that have occurred in the system.
        /// </summary>
        IEnumerable<IEvent> Events { get; }

        /// <summary>
        /// Adds the event to the event store history.
        /// </summary>
        void AddEvent(IEvent @event);
    }
}

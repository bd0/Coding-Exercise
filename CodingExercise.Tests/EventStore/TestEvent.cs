using CodingExercise.EventStore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingExercise.Tests.EventStore
{
    /// <summary>
    /// A minimal event for testing purposes.
    /// </summary>
    public class TestEvent : IEvent
    {
        public Guid Id { get; } = Guid.NewGuid();
    }
}

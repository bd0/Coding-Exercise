using System;
using System.Collections.Generic;
using System.Text;

namespace CodingExercise.EventStore.Events
{
    /// <summary>
    /// Event representing that the calculator state was cleared
    /// so a new calculation can begin.
    /// </summary>
    public class ClearStateEvent : IEvent
    {

        public Guid Id { get; } = Guid.NewGuid();

    }
}

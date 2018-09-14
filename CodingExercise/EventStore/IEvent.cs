using System;
using System.Collections.Generic;
using System.Text;

namespace CodingExercise.EventStore
{
    /// <summary>
    /// Defines an event that happened in the system.
    /// </summary>
    public interface IEvent
    {
        Guid Id { get; }
    }
}

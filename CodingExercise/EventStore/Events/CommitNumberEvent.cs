using CodingExercise.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingExercise.EventStore.Events
{
    /// <summary>
    /// Event representing a number to be used for the calculation.
    /// </summary>
    public class CommitNumberEvent : IEvent
    {

        public Guid Id { get; } = Guid.NewGuid();


        public int Number { get; }


        public CommitNumberEvent(int number) => Number = number;

    }
}

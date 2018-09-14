using CodingExercise.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingExercise.EventStore.Events
{
    /// <summary>
    /// Event representing which operation has been set for
    /// the calculator to use.
    /// </summary>
    public class SetOperationEvent : IEvent
    {

        public Guid Id { get; } = Guid.NewGuid();


        public CalculatorOperation Operation { get; }


        public SetOperationEvent(CalculatorOperation operation) => Operation = operation;

    }
}

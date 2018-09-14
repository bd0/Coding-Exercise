using CodingExercise.EventStore;
using CodingExercise.EventStore.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingExercise.Commands.Calculation
{
    /// <summary>
    /// Command handler to process the ClearCalculationCommand.
    /// Writes a ClearCalculationEvent.
    /// </summary>
    public class ClearCalculationCommandHandler : ICommandHandler<ClearCalculationCommand>
    {

        readonly IEventStore eventStore;


        public ClearCalculationCommandHandler(IEventStore eventStore) => this.eventStore = eventStore;


        public void Execute(ClearCalculationCommand command)
        {
            var clearEvent = new ClearCalculationEvent();

            eventStore.AddEvent(clearEvent);
        }

    }
}

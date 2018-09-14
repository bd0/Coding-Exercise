using CodingExercise.EventStore;
using CodingExercise.EventStore.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingExercise.Commands.Calculation
{
    /// <summary>
    /// Command handler to process the CommitNumberCommand.
    /// Writes a SetOperationEvent followed by a CommitNumberEvent.
    /// </summary>
    public class CommitNumberCommandHandler : ICommandHandler<CommitNumberCommand>
    {

        readonly IEventStore eventStore;


        public CommitNumberCommandHandler(IEventStore eventStore) => this.eventStore = eventStore;


        public void Execute(CommitNumberCommand command)
        {
            var operationEvent = new SetOperationEvent(command.Operation);

            var numberEvent = new CommitNumberEvent(command.Number);

            eventStore.AddEvent(operationEvent);
            eventStore.AddEvent(numberEvent);
        }

    }
}

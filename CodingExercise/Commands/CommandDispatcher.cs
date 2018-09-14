using CodingExercise.Commands.Calculation;
using CodingExercise.EventStore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingExercise.Commands
{
    /// <summary>
    /// Identifies the appropriate command handler for a given command
    /// and dispatches the command to the handler.
    /// </summary>
    public class CommandDispatcher
    {

        readonly ICommandHandler<ClearCalculationCommand> clearCommandHandler;


        readonly ICommandHandler<CommitNumberCommand> numberCommandHandler;


        public CommandDispatcher(
            ICommandHandler<ClearCalculationCommand> clearCommandHandler,
            ICommandHandler<CommitNumberCommand> numberCommandHandler)
        {
            this.clearCommandHandler = clearCommandHandler; // new ClearCalculationCommandHandler(eventStore);
            this.numberCommandHandler = numberCommandHandler; // new CommitNumberCommandHandler(eventStore);
        }


        /// <summary>
        /// Dispatches the given command to the appropriate command handler.
        /// </summary>
        /// <typeparam name="TCommand"></typeparam>
        /// <param name="command"></param>
        public void Dispatch<TCommand>(TCommand command) where TCommand : ICommand
        {
            switch (command)
            {
                case ClearCalculationCommand clearCommand:
                    clearCommandHandler.Execute(clearCommand);
                    break;

                case CommitNumberCommand numberCommand:
                    numberCommandHandler.Execute(numberCommand);
                    break;

                default:
                    throw new ArgumentException($@"Unrecognized command type ""{command.GetType().FullName}"".");
            }
        }

    }
}

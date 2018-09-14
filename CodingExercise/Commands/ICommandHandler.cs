using System;
using System.Collections.Generic;
using System.Text;

namespace CodingExercise.Commands
{
    /// <summary>
    /// Handles a specific type of command and applies any 
    /// necessary state changes that result.
    /// </summary>
    /// <typeparam name="TCommand"></typeparam>
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        /// <summary>
        /// Executes the command by applying any resultant state changes.
        /// </summary>
        /// <param name="command"></param>
        void Execute(TCommand command);
    }
}

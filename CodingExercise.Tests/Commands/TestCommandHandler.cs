using CodingExercise.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingExercise.Tests.Commands
{
    /// <summary>
    /// A command handler for testing purposes.
    /// </summary>
    /// <typeparam name="TCommand"></typeparam>
    public class TestCommandHandler<TCommand> : ICommandHandler<TCommand> where TCommand : ICommand
    {

        public bool IsHandled { get; private set; }


        public ICommand Command { get; private set; }


        public void Execute(TCommand command)
        {
            IsHandled = true;
            Command = command;
        }

    }
}

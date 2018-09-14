using CodingExercise.Commands;
using CodingExercise.Commands.Calculation;
using CodingExercise.EventStore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingExercise.Tests.Commands
{
    [TestClass]
    public class CommandDispatcher_Dispatch
    {

        private TestCommandHandler<ClearCalculationCommand> clearCommandHandler;

        private TestCommandHandler<CommitNumberCommand> numberCommandHandler;

        private CommandDispatcher commandDispatcher;


        [TestInitialize]
        public void Initialize()
        {
            clearCommandHandler = new TestCommandHandler<ClearCalculationCommand>();
            numberCommandHandler = new TestCommandHandler<CommitNumberCommand>();
            commandDispatcher = new CommandDispatcher(clearCommandHandler, numberCommandHandler);
        }


        [TestMethod]
        public void ShouldDispatchClearCalculationCommand()
        {
            var command = new ClearCalculationCommand();

            commandDispatcher.Dispatch(command);

            // The test command handler will indicate if it received a command.
            Assert.IsTrue(clearCommandHandler.IsHandled);
            Assert.AreSame(command, clearCommandHandler.Command);
        }


        [TestMethod]
        public void ShouldDispatchCommitNumberCommand()
        {
            var command = new CommitNumberCommand(Enums.CalculatorOperation.Addition, 17);

            commandDispatcher.Dispatch(command);

            // The test command handler will indicate if it received a command.
            Assert.IsTrue(numberCommandHandler.IsHandled);
            Assert.AreSame(command, numberCommandHandler.Command);
        }


        [TestMethod]
        public void ShouldThrowExceptionForUnrecognizedCommandType()
        {
            var command = new TestCommand();

            var exception = Assert.ThrowsException<ArgumentException>(() =>
            {
                commandDispatcher.Dispatch(command);
            });

            var expectedMessage = $@"Unrecognized command type ""{command.GetType().FullName}"".";

            Assert.AreEqual(expectedMessage, exception.Message);
        }

    }
}

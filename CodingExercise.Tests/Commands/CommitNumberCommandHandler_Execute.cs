using CodingExercise.Commands;
using CodingExercise.Commands.Calculation;
using CodingExercise.Enums;
using CodingExercise.EventStore;
using CodingExercise.EventStore.Events;
using CodingExercise.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingExercise.Tests.Commands
{
    [TestClass]
    public class CommitNumberCommandHandler_Execute
    {

        private IEventStore eventStore;

        private ICommandHandler<CommitNumberCommand> commandHandler;


        [TestInitialize]
        public void Initialize()
        {
            eventStore = new InMemoryEventStore();
            commandHandler = new CommitNumberCommandHandler(eventStore);
        }


        [TestMethod]
        public void ShouldCreateASetOperationEvent()
        {
            var command = new CommitNumberCommand(CalculatorOperation.Addition, 7);

            commandHandler.Execute(command);

            // Find the event in the event store.
            var result = eventStore.Events.FirstOrDefault();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(SetOperationEvent));
        }


        [TestMethod]
        public void ShouldCreateACommitNumberEventAfterSetOperation()
        {
            var command = new CommitNumberCommand(CalculatorOperation.Addition, 7);

            commandHandler.Execute(command);

            // Find the event in the event store.
            var operationResult = eventStore.Events.ElementAt(0);
            var numberResult = eventStore.Events.ElementAt(1);

            Assert.IsInstanceOfType(operationResult, typeof(SetOperationEvent));
            Assert.IsInstanceOfType(numberResult, typeof(CommitNumberEvent));
        }


        [TestMethod]
        public void ShouldHaveOperationEventMatchingCommandOperation()
        {
            var command = new CommitNumberCommand(CalculatorOperation.Subtraction, 17);

            commandHandler.Execute(command);

            // Find the event in the event store.
            var result = eventStore.Events.FirstOrDefault();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(SetOperationEvent));
            Assert.AreEqual(CalculatorOperation.Subtraction, (result as SetOperationEvent).Operation);
        }


        [TestMethod]
        public void ShouldHaveCommitNumberEventMatchingCommandNumber()
        {
            var command = new CommitNumberCommand(CalculatorOperation.Multiplication, 23);

            commandHandler.Execute(command);

            // Find the event in the event store.
            var numberResult = eventStore.Events.ElementAt(1);

            Assert.IsInstanceOfType(numberResult, typeof(CommitNumberEvent));
            Assert.AreEqual(23, (numberResult as CommitNumberEvent).Number);
        }

    }
}

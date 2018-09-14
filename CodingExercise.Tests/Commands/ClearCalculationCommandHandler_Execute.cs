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
    public class ClearCalculationCommandHandler_Execute
    {

        private IEventStore eventStore;

        private ICommandHandler<ClearCalculationCommand> commandHandler;


        [TestInitialize]
        public void Initialize()
        {
            eventStore = new InMemoryEventStore();
            commandHandler = new ClearCalculationCommandHandler(eventStore);
        }


        [TestMethod]
        public void ShouldCreateAClearCalculationEvent()
        {
            var command = new ClearCalculationCommand();

            commandHandler.Execute(command);

            // Find the event in the event store.
            var result = eventStore.Events.FirstOrDefault();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ClearCalculationEvent));
        }

    }
}

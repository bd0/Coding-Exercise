using CodingExercise.Commands;
using CodingExercise.Commands.Calculation;
using CodingExercise.Enums;
using CodingExercise.EventStore;
using CodingExercise.EventStore.Events;
using CodingExercise.Queries;
using CodingExercise.Queries.Calculation;
using CodingExercise.Services;
using CodingExercise.Tests.EventStore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingExercise.Tests.Queries
{
    [TestClass]
    public class CalculationResultQueryHandler_Execute
    {

        private TestEventStore eventStore;

        private IQueryHandler<CalculationResultQuery, int> queryHandler;


        [TestInitialize]
        public void Initialize()
        {
            eventStore = new TestEventStore();
            queryHandler = new CalculationResultQueryHandler(eventStore);
        }


        [TestMethod]
        public void ShouldReturnZeroWhenEventStoreIsEmpty()
        {
            // Clear the event list.
            eventStore.Events = Enumerable.Empty<IEvent>();

            var query = new CalculationResultQuery();

            var result = queryHandler.ExecuteQuery(query);

            Assert.AreEqual(0, result);
        }


        [DataTestMethod]
        [DataRow(CalculatorOperation.Addition, 10, 2, 12)]
        [DataRow(CalculatorOperation.Subtraction, 10, 2, 8)]
        [DataRow(CalculatorOperation.Multiplication, 10, 2, 20)]
        [DataRow(CalculatorOperation.Division, 10, 2, 5)]
        public void ShouldReturnZeroWhenInitialized(CalculatorOperation operation, int firstNumber, int secondNumber, int expectedResult)
        {
            // Configure some initial state.
            eventStore.Events = new List<IEvent>()
            {
                new ClearCalculationEvent(),
                new SetOperationEvent(operation),
                new CommitNumberEvent(firstNumber),
                new CommitNumberEvent(secondNumber)
            };

            var query = new CalculationResultQuery();

            var result = queryHandler.ExecuteQuery(query);

            Assert.AreEqual(expectedResult, result);
        }

    }
}

using CodingExercise.Commands;
using CodingExercise.Commands.Calculation;
using CodingExercise.Enums;
using CodingExercise.EventStore;
using CodingExercise.Queries;
using CodingExercise.Queries.Calculation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingExercise.Services.Calculators
{
    /// <summary>
    /// An ICalculator implementation demonstrating the 
    /// CQRS and Event Source patterns.
    /// </summary>
    public class CQRSCalculator : ICalculator
    {

        readonly IEventStore eventStore;

        readonly CommandDispatcher commandDispatcher;

        readonly CalculationResultQueryHandler queryHandler;


        public CQRSCalculator()
        {
            // Normally these should be provided via dependency injection, but we'll
            // ignore that for the purposes of this exercise.

            // Create an event store.
            eventStore = new InMemoryEventStore();

            // Set up the command dispatcher.
            var clearCommandHandler = new ClearCalculationCommandHandler(eventStore);
            var numberCommandHandler = new CommitNumberCommandHandler(eventStore);

            commandDispatcher = new CommandDispatcher(clearCommandHandler, numberCommandHandler);

            // Set up the query handler we need.
            queryHandler = new CalculationResultQueryHandler(eventStore);
        }


        /// <summary>
        /// Clears the current state of the calculator store, 
        /// effectively beginning a new calculation.
        /// </summary>
        public void Clear()
        {
            commandDispatcher.Dispatch(new ClearCalculationCommand());
        }


        /// <summary>
        /// Commits a number to the store.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="operation"></param>
        public void CommitNumber(int number, CalculatorOperation operation)
        {
            commandDispatcher.Dispatch(new CommitNumberCommand(operation, number));
        }


        /// <summary>
        /// Gets the result of the calculation in the store.
        /// </summary>
        /// <returns></returns>
        public int GetResult()
        {
            return queryHandler.ExecuteQuery(new CalculationResultQuery());
        }

    }
}

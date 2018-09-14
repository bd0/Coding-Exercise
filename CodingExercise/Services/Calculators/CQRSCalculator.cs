using System;
using System.Collections.Generic;
using System.Text;
using CodingExercise.Commands;
using CodingExercise.Commands.Calculation;
using CodingExercise.Enums;
using CodingExercise.EventStore;

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


        public CQRSCalculator()
        {
            eventStore = new InMemoryEventStore();

            var clearCommandHandler = new ClearCalculationCommandHandler(eventStore);
            var numberCommandHandler = new CommitNumberCommandHandler(eventStore);

            commandDispatcher = new CommandDispatcher(clearCommandHandler, numberCommandHandler);
        }


        public void Clear()
        {
            commandDispatcher.Dispatch(new ClearCalculationCommand());
        }


        public void CommitNumber(int number, CalculatorOperation operation)
        {
            commandDispatcher.Dispatch(new CommitNumberCommand(operation, number));
        }


        public int GetResult()
        {
            throw new NotImplementedException();
        }

    }
}

using CodingExercise.Enums;
using CodingExercise.EventStore;
using CodingExercise.EventStore.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingExercise.Queries.Calculation
{
    /// <summary>
    /// A QueryHandler for CalculationResultQuery. It queries
    /// the IEventStore to determine the current calculation result.
    /// </summary>
    public class CalculationResultQueryHandler : IQueryHandler<CalculationResultQuery, int>
    {

        readonly IEventStore eventStore;


        public CalculationResultQueryHandler(IEventStore eventStore)
        {
            this.eventStore = eventStore;
        }


        public int ExecuteQuery(CalculationResultQuery query) => GetCurrentCalculationValue();


        private int GetCurrentCalculationValue()
        {
            var events = eventStore?.Events ?? Enumerable.Empty<IEvent>();

            // Read all the events to get the current calculation value.
            var currentValue = 0;
            var operation = CalculatorOperation.Addition;
            var isFirstNumber = true;

            foreach (var ev in events)
            {
                switch (ev)
                {
                    case ClearCalculationEvent clearEvent:
                        currentValue = 0;
                        operation = CalculatorOperation.Addition;
                        isFirstNumber = true;
                        break;

                    case SetOperationEvent operationEvent:
                        operation = operationEvent.Operation;
                        break;

                    case CommitNumberEvent numberEvent:

                        var number = numberEvent.Number;

                        if (isFirstNumber)
                        {
                            isFirstNumber = false;
                            currentValue = number;
                            break;
                        }

                        currentValue = GetNextValue(currentValue, operation, number);
                        break;

                    default:
                        throw new InvalidOperationException($"Event type {ev.GetType().FullName} not recognized.");
                }
            }

            return currentValue;
        }


        private int GetNextValue(int currentValue, CalculatorOperation operation, int number)
        {

            // Adjust the calculation for the current operation.
            switch (operation)
            {
                case CalculatorOperation.Addition:
                    currentValue += number;
                    break;
                case CalculatorOperation.Subtraction:
                    currentValue -= number;
                    break;
                case CalculatorOperation.Multiplication:
                    currentValue *= number;
                    break;
                case CalculatorOperation.Division:
                    // We'll ignore that integer division is error-prone for the purposes of this exercise.
                    currentValue /= number;
                    break;
                default:
                    throw new ArgumentException($@"Unrecognized operation ""{operation}"".", nameof(operation));
            }

            return currentValue;
        }

    }
}

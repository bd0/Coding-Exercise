using CodingExercise.Enums;
using CodingExercise.EventStore;
using CodingExercise.EventStore.Events;
using CodingExercise.Services.Calculators;
using CodingExercise.Tests.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingExercise.Tests.Calculators
{
    public static class CQRSCalculatorTestUtils
    {

        public static int? GetCurrentCQRSCalculatorValue(ICalculator calculator)
        {
            // Must access the private state of the SimpleCalculatorStore to validate.
            var eventStore = calculator.GetPrivateFieldValue("eventStore") as IEventStore;

            var events = eventStore?.Events ?? Enumerable.Empty<IEvent>();

            // Simulate reading all the events to get the current calculation value.
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


        public static int GetNextValue(int currentValue, CalculatorOperation operation, int number)
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

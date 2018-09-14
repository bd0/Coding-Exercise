using CodingExercise.Enums;
using CodingExercise.Services.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingExercise.Services
{
    /// <summary>
    /// Takes a string representation of a list of numbers
    /// and calculates the sum of those values.
    /// </summary>
    public class CalculatorService : ICalculatorService
    {

        readonly INumberInputParser numberInputParser;

        readonly ICalculatorStore calculatorStore;

        readonly IEnumerable<INumberValidator> numberValidators;


        public CalculatorService()
        {
            // Normally these should be provided via dependency injection, but we'll
            // ignore that for the purposes of this exercise.
            numberInputParser = new NumberInputParser();
            calculatorStore = new SimpleCalculatorStore();
            numberValidators = new List<INumberValidator>()
            {
                new NoNegativesNumberValidator(),
                new OnlySmallNumbersNumberValidator()
            };
        }


        /// <summary>
        /// Parses the text representation of a series of numbers and 
        /// returns the result of the specified calculation.
        /// </summary>
        /// <param name="numbers">A list of numbers to use for the calculation.</param>
        /// <param name="operation">The operation to perform. Defaults to Addition.</param>
        /// <returns></returns>
        public int Calculate(string numbers, CalculatorOperation operation = CalculatorOperation.Addition)
        {
            // Parse the input string to get the list of integers.
            var numbersToCalculate = numberInputParser.ParseNumberInput(numbers);

            // Prior to performing the calculation, validate that these numbers are acceptable.
            foreach(var validator in numberValidators)
            {
                // The validator will either filter the list to only acceptable numbers,
                // or throw an exception for truly egregious ones.
                numbersToCalculate = validator.GetValidNumbers(numbersToCalculate);
            }

            // Add each integer to the calculator store.
            foreach(var number in numbersToCalculate)
            {
                calculatorStore.CommitNumber(number, operation);
            }

            // Get the final result of the operation.
            var sum = calculatorStore.GetResult();

            return sum;
        }

    }
}

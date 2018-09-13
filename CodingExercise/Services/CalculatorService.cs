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


        public CalculatorService()
        {
            // Normally these should be provided via dependency injection, but we'll
            // ignore that for the purposes of this exercise.
            numberInputParser = new NumberInputParser();
            calculatorStore = new SimpleCalculatorStore();
        }


        /// <summary>
        /// Parses the text representation of a series of numbers and returns the sum.
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public int Add(string numbers)
        {
            // Parse the input string to get the list of integers.
            var numbersToAdd = numberInputParser.ParseNumberInput(numbers);

            // Add each integer to the calculator store.
            foreach(var number in numbersToAdd)
            {
                calculatorStore.CommitNumber(number);
            }

            // Get the final result of the operation.
            var sum = calculatorStore.GetResult();

            return sum;
        }

    }
}

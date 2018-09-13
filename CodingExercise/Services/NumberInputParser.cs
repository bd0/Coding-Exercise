using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingExercise.Services
{
    /// <summary>
    /// Input parser to take a string representation of a list of numbers
    /// and return a list of integer values.
    /// </summary>
    public class NumberInputParser : INumberInputParser
    {
        /// <summary>
        /// Takes a string representation of a list of numbers and returns
        /// a parsed list of integers.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public IEnumerable<int> ParseNumberInput(string input)
        {
            // If no input provided, return an empty enumerable.
            if (input == null) { return Enumerable.Empty<int>(); }

            int temp = 0;

            // Split the input string by the delimiter and parse into individual integers.
            var numbers = (from number in input.Split(',', StringSplitOptions.RemoveEmptyEntries)
                           where int.TryParse(number, out temp)
                           select temp).ToList();

            return numbers;
        }

    }
}

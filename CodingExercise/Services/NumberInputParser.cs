﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CodingExercise.Services
{
    /// <summary>
    /// Input parser to take a string representation of a list of numbers
    /// and return a list of integer values.
    /// </summary>
    public class NumberInputParser : INumberInputParser
    {
        readonly Regex delimiterCheck = new Regex(@"^//(?<delimiter>.)\n(?<numbers>.*)", RegexOptions.Singleline);


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

            char[] delimiters;

            // STEP-4 Add support for custom delimiters.
            var delimiterResult = delimiterCheck.Match(input);

            if (delimiterResult.Success)
            {
                // If we found a delimiter character specified, use that instead of the default delimiters.
                var delimiterChar = delimiterResult.Groups["delimiter"].Value[0];

                delimiters = new char[] { delimiterChar };

                // Only consider the input after the delimiter specification when parsing numbers.
                input = delimiterResult.Groups["numbers"].Value ?? string.Empty;
            }
            else
            {
                // STEP-3 Add support for new line delimiters.
                // Default to ',' and '\n'.
                delimiters = new char[] { ',', '\n' };
            }


            var temp = 0;

            // Split the input string by the delimiter and parse into individual integers.
            var numbers = (from number in input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
                           where int.TryParse(number, out temp)
                           select temp).ToList();

            return numbers;
        }

    }
}

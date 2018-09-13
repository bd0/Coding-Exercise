using System;
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
        /// <summary>
        /// A Regex for checking for custom delimiters.
        /// Per STEP-4 STEP-7: Should support custom delimiters of any length.
        /// Per STEP-8: Should support multiple delimiters.
        /// Delimiter format should be one of:
        /// "//*\n..." (single char delimiter)
        /// "//[**]\n..." (multi char delimiter)
        /// "//[*][@@][...]\n..." (more than one delimiter)
        /// </summary>
        readonly Regex delimiterCheck = new Regex(@"
            ^//
            (
            # Support multiple delimiters defined by [ ].
            (\[(?<delimiter>.+?)\])+
            # Or a single, 1-char delimiter without brackets.
            |(?<delimiter>.)
            )
            \n(?<numbers>.*)",
            RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace | RegexOptions.ExplicitCapture);


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

            string[] delimiters;

            // STEP-4 Add support for custom delimiters.
            var delimiterResult = delimiterCheck.Match(input);

            if (delimiterResult.Success)
            {
                // If we found a delimiter character specified, use that instead of the default delimiters.
                var delimiterGroup = delimiterResult.Groups["delimiter"];

                // Each specified delimiter will be captured in this group.
                delimiters = delimiterGroup.Captures.Select(capture => capture.Value).ToArray();

                // Only consider the input after the delimiter specification when parsing numbers.
                input = delimiterResult.Groups["numbers"].Value ?? string.Empty;
            }
            else
            {
                // STEP-3 Add support for new line delimiters.
                // Default to ',' and '\n'.
                delimiters = new string[] { ",", "\n" };
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

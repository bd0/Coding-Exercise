using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingExercise.Services.Validation
{
    /// <summary>
    /// Checks a series of integers and returns the ones that
    /// are considered valid. This validates that none of the
    /// numbers are negative and throws an exception if there
    /// are any.
    /// </summary>
    public class NoNegativesNumberValidator : INumberValidator
    {

        /// <summary>
        /// Returns the numbers that are considered valid.
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public IEnumerable<int> GetValidNumbers(IEnumerable<int> numbers)
        {
            // Identify any negative numbers in the list.
            var negatives = numbers.Where(x => x < 0);

            if (negatives.Any())
            {
                var message = $"Negatives not allowed: {string.Join(", ", negatives)}";

                throw new ArgumentException(message, nameof(numbers));
            }

            // Return the number list as-is.
            return numbers;
        }

    }
}

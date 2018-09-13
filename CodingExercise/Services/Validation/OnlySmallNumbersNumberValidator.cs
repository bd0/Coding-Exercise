using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingExercise.Services.Validation
{
    /// <summary>
    /// Checks a series of integers and returns the ones that
    /// are considered valid. This validates that none of the
    /// numbers are greater than the small number limit.
    /// Numbers that exceed the limit are excluded from the 
    /// returned list.
    /// </summary>
    public class OnlySmallNumbersNumberValidator : INumberValidator
    {

        /// <summary>
        /// A small number is considered anything less than or equal to 1000.
        /// </summary>
        const int SmallNumberLimit = 1000;


        /// <summary>
        /// Returns the numbers that are considered valid.
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public IEnumerable<int> GetValidNumbers(IEnumerable<int> numbers) =>
            // Return all numbers that are less than the limit.
            numbers.Where(x => x <= SmallNumberLimit);

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CodingExercise.Services.Validation
{
    /// <summary>
    /// Checks a series of integers and returns the ones that
    /// are considered valid by the implementation.
    /// </summary>
    public interface INumberValidator
    {
        /// <summary>
        /// Returns the numbers that are considered valid.
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        IEnumerable<int> GetValidNumbers(IEnumerable<int> numbers);
    }
}

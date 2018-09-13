using System;
using System.Collections.Generic;
using System.Text;

namespace CodingExercise.Services
{
    /// <summary>
    /// Interface used by ICalculatorService to store the current state of the calculation.
    /// </summary>
    public interface ICalculatorStore
    {
        /// <summary>
        /// Commits a number to the store.
        /// </summary>
        /// <param name="number"></param>
        void CommitNumber(int number);

        /// <summary>
        /// Gets the result of the calculation in the store.
        /// </summary>
        /// <returns></returns>
        int GetResult();
    }
}

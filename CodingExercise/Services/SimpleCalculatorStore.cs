using System;
using System.Collections.Generic;
using System.Text;

namespace CodingExercise.Services
{
    /// <summary>
    /// Maintains the current state of the calculation by 
    /// keeping a running total of the numbers provided so far.
    /// </summary>
    public class SimpleCalculatorStore : ICalculatorStore
    {
        private int total = 0;


        /// <summary>
        /// Commits a number to the store.
        /// </summary>
        /// <param name="number"></param>
        public void CommitNumber(int number)
        {
            total += number;
        }


        /// <summary>
        /// Gets the result of the calculation in the store.
        /// </summary>
        /// <returns></returns>
        public int GetResult() => total;

    }
}

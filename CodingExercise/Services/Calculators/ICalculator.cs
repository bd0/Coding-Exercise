using CodingExercise.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingExercise.Services.Calculators
{
    /// <summary>
    /// Interface used by ICalculatorService to manage the calculator state 
    /// and process calculations.
    /// </summary>
    public interface ICalculator
    {
        /// <summary>
        /// Clears the current state of the calculator store, 
        /// effectively beginning a new calculation.
        /// </summary>
        void Clear();

        /// <summary>
        /// Commits a number to the store.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="operation"></param>
        void CommitNumber(int number, CalculatorOperation operation);

        /// <summary>
        /// Gets the result of the calculation in the store.
        /// </summary>
        /// <returns></returns>
        int GetResult();
    }
}

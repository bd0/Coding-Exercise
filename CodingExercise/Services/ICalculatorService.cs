using CodingExercise.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingExercise.Services
{
    /// <summary>
    /// A Calculation service that performs an operation on a list of numbers.
    /// </summary>
    public interface ICalculatorService
    {
        /// <summary>
        /// Parses the text representation of a series of numbers and 
        /// returns the result of the specified calculation.
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="operation"></param>
        /// <returns></returns>
        int Calculate(string numbers, CalculatorOperation operation);
    }
}

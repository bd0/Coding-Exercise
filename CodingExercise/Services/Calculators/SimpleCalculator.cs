using CodingExercise.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingExercise.Services.Calculators
{
    /// <summary>
    /// Maintains the current state of the calculation as a 
    /// single value, and applies number operations as they
    /// are given.
    /// </summary>
    public class SimpleCalculator : ICalculator
    {
        /// <summary>
        /// The current value of the calculation.
        /// </summary>
        private int currentValue = 0;

        
        /// <summary>
        /// Flag for tracking if this is the first number 
        /// provided for the calculation.
        /// </summary>
        private bool isFirstNumber = true;


        /// <summary>
        /// Clears the current state of the calculator store, 
        /// effectively beginning a new calculation.
        /// </summary>
        public void Clear()
        {
            currentValue = 0;
            isFirstNumber = true;
        }


        /// <summary>
        /// Commits a number to the store.
        /// </summary>
        /// <param name="number"></param>
        public void CommitNumber(int number, CalculatorOperation operation)
        {
            if (isFirstNumber)
            {
                // If this is the first number provided, use that as the starting 
                // value for future calculations. The operation will be ignored
                // for this method call.
                currentValue = number;

                isFirstNumber = false;
                return;
            }

            // Apply this number to the store using the specified operation.
            switch (operation)
            {
                case CalculatorOperation.Addition:
                    currentValue += number;
                    break;
                case CalculatorOperation.Subtraction:
                    currentValue -= number;
                    break;
                case CalculatorOperation.Multiplication:
                    currentValue *= number;
                    break;
                case CalculatorOperation.Division:
                    // We'll ignore that integer division is error-prone for the purposes of this exercise.
                    currentValue /= number;
                    break;
                default:
                    throw new ArgumentException($@"Unrecognized operation ""{operation}"".", nameof(operation));
            }
        }


        /// <summary>
        /// Gets the result of the calculation in the store.
        /// </summary>
        /// <returns></returns>
        public int GetResult() => currentValue;

    }
}

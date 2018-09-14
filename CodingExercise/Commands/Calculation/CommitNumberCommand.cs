using CodingExercise.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingExercise.Commands.Calculation
{
    /// <summary>
    /// Represents a command to commit a new operation and number
    /// to the calculator. These will be used to compute the final result.
    /// </summary>
    public class CommitNumberCommand : ICommand
    {

        public Guid Id { get; } = Guid.NewGuid();


        public CalculatorOperation Operation { get; }


        public int Number { get; }


        public CommitNumberCommand(CalculatorOperation operation, int number)
        {
            Operation = operation;
            Number = number;
        }

    }
}

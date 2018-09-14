using System;
using System.Collections.Generic;
using System.Text;

namespace CodingExercise.Commands.Calculation
{
    /// <summary>
    /// Represents a command to clear the current calculation state
    /// so it is ready for a new calculation.
    /// </summary>
    public class ClearCalculationCommand : ICommand
    {
        public Guid Id { get; } = Guid.NewGuid();
    }
}

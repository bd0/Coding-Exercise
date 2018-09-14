using System;
using System.Collections.Generic;
using System.Text;

namespace CodingExercise.Commands.Calculation
{
    public class ClearCalculationCommand : ICommand
    {
        public Guid Id { get; } = Guid.NewGuid();
    }
}

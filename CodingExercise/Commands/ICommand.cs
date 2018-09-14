using System;
using System.Collections.Generic;
using System.Text;

namespace CodingExercise.Commands
{
    /// <summary>
    /// Represents a command to do something in the system.
    /// </summary>
    public interface ICommand
    {
        Guid Id { get; }
    }
}

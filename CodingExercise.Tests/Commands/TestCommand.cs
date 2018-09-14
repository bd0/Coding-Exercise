using CodingExercise.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingExercise.Tests.Commands
{
    /// <summary>
    /// A minimal command used for testing.
    /// </summary>
    public class TestCommand : ICommand
    {

        public Guid Id { get; } = Guid.NewGuid();

    }
}

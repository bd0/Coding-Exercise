using System;
using System.Collections.Generic;
using System.Text;

namespace CodingExercise.Services
{
    /// <summary>
    /// Input parser to take a string representation of a list of numbers
    /// and return a list of integer values.
    /// </summary>
    public interface INumberInputParser
    {
        IEnumerable<int> ParseNumberInput(string input);
    }
}

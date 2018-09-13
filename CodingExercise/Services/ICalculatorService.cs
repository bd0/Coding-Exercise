using System;
using System.Collections.Generic;
using System.Text;

namespace CodingExercise.Services
{
    /// <summary>
    /// A Calculation service that can add a list of numbers together.
    /// </summary>
    public interface ICalculatorService
    {
        int Add(string numbers);
    }
}

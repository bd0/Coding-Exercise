using CodingExercise.Enums;
using CodingExercise.Services;
using CodingExercise.Services.Calculators;
using CodingExercise.Tests.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingExercise.Tests.Calculators
{
    /// <summary>
    /// Tests the SimpleCalculator implementation of ICalculator.GetResult.
    /// </summary>
    [TestClass]
    public class SimpleCalculator_GetResult : ICalculator_GetResult
    {


        protected override ICalculator NewCalculator() => new SimpleCalculator();


        protected override int? GetCurrentCalculatorValue(ICalculator calculator)
        {
            // Must access the private state of the SimpleCalculatorStore to validate.
            var storeCurrentValue = calculator.GetPrivateFieldValueInteger("currentValue");

            return storeCurrentValue;
        }

    }
}

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
    /// Tests the CQRSCalculator implementation of ICalculator.GetResult.
    /// </summary>
    [TestClass]
    public class CQRSCalculator_GetResult : ICalculator_GetResult
    {

        protected override ICalculator NewCalculator() => new CQRSCalculator();


        protected override int? GetCurrentCalculatorValue(ICalculator calculator)
        {
            return CQRSCalculatorTestUtils.GetCurrentCQRSCalculatorValue(calculator);
        }

    }
}

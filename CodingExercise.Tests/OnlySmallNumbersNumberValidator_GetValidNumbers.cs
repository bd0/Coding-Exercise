using CodingExercise.Services.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingExercise.Tests
{
    [TestClass]
    public class OnlySmallNumbersNumberValidator_GetValidNumbers
    {
        readonly OnlySmallNumbersNumberValidator validator;


        public OnlySmallNumbersNumberValidator_GetValidNumbers()
        {
            validator = new OnlySmallNumbersNumberValidator();
        }


        // STEP-6 Silently ignore numbers bigger than 1000.
        [DataTestMethod]
        [DataRow(new[] { 1, 2, 3, 4, 5 })]
        [DataRow(new[] { 0, 1, 1, 2, 3, 5, 8 })]
        [DataRow(new int[] { })]
        public void ShouldReturnTheSameNumbersIfNoBigNumbers(int[] numbers)
        {
            var result = validator.GetValidNumbers(numbers);

            CollectionAssert.AreEqual(numbers, result.ToArray());
        }


        // STEP-6 Silently ignore numbers bigger than 1000.
        [DataTestMethod]
        [DataRow(new[] { 1, 2, 3, 4, 5000 }, new[] { 1, 2, 3, 4 })]
        [DataRow(new[] { -1, 0, 1, 1000, 1001 }, new[] { -1, 0, 1, 1000 })]
        [DataRow(new[] { 1001, 10001, 100001 }, new int[] { })]
        public void ShouldExcludeNumbersBiggerThan1000(int[] numbers, int[] expectedNumbers)
        {
            var result = validator.GetValidNumbers(numbers);

            CollectionAssert.AreEqual(expectedNumbers, result.ToArray());
        }
    }
}

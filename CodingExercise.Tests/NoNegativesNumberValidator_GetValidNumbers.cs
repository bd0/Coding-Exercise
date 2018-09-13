using CodingExercise.Services.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingExercise.Tests
{
    [TestClass]
    public class NoNegativesNumberValidator_GetValidNumbers
    {
        readonly NoNegativesNumberValidator validator;


        public NoNegativesNumberValidator_GetValidNumbers()
        {
            validator = new NoNegativesNumberValidator();
        }


        // STEP-5 Validate numbers and throw an exception if negative numbers are provided.
        [DataTestMethod]
        [DataRow(new[] { 1, 2, 3, 4, 5 })]
        [DataRow(new[] { 0, 1, 1, 2, 3, 5, 8 })]
        [DataRow(new int[] { })]
        public void ShouldReturnTheSameNumbersIfNoNegatives(int[] numbers)
        {
            var result = validator.GetValidNumbers(numbers);

            CollectionAssert.AreEqual(numbers, result.ToArray());
        }


        // STEP-5 Validate numbers and throw an exception if negative numbers are provided.
        [DataTestMethod]
        [DataRow(new[] { -1, 2, 3, 4, 5 }, "Negatives not allowed: -1\r\nParameter name: numbers")]
        [DataRow(new[] { 0, 1, -1, -2, -3, 5, 8 }, "Negatives not allowed: -1, -2, -3\r\nParameter name: numbers")]
        [DataRow(new int[] { -8, -10, -12 }, "Negatives not allowed: -8, -10, -12\r\nParameter name: numbers")]
        public void ShouldThrowExceptionForNegativeNumbers(int[] numbers, string expectedMessage)
        {
            var exception = Assert.ThrowsException<ArgumentException>(() =>
            {
                validator.GetValidNumbers(numbers);
            });

            Assert.AreEqual(expectedMessage, exception.Message);
        }
    }
}

using CodingExercise.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingExercise.Tests
{
    [TestClass]
    public class NumberInputService_ParseNumberInput
    {
        readonly NumberInputParser numberInputParser;


        public NumberInputService_ParseNumberInput()
        {
            numberInputParser = new NumberInputParser();
        }


        [TestMethod]
        public void ShouldReturnAnEmptyEnumerableForEmptyInput()
        {
            var result = numberInputParser.ParseNumberInput(string.Empty);

            Assert.IsFalse(result.Any());
        }


        [TestMethod]
        public void ShouldReturnAnEmumerableOfASingleDigitProvided()
        {
            var result = numberInputParser.ParseNumberInput("1");

            CollectionAssert.AreEqual(new[] { 1 }, result.ToArray());
        }


        [TestMethod]
        public void ShouldReturnAnEnumerableOfTwoProvidedDigits()
        {
            var result = numberInputParser.ParseNumberInput("2,3");

            CollectionAssert.AreEqual(new[] { 2, 3 }, result.ToArray());
        }

    }
}

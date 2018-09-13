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


        // STEP-2 Support any amount of numbers in input.
        [DataTestMethod]
        [DataRow("1,2,3", new[] { 1, 2, 3 })]
        [DataRow("10,20,30,40,50,60", new[] { 10, 20, 30, 40, 50, 60 })]
        [DataRow("0,1,1,2,3,5,8,13,21,34,55,89,144", new[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144 })]
        public void ShouldReturnAnEnumerableOfForAnySetOfProvidedDigits(string input, int[] expectedCollection)
        {
            var result = numberInputParser.ParseNumberInput(input);

            CollectionAssert.AreEqual(expectedCollection, result.ToArray());
        }

    }
}

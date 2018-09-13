using CodingExercise.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CodingExercise.Tests
{
    [TestClass]
    public class CalculatorService_Add
    {

        readonly CalculatorService calculatorService;


        public CalculatorService_Add()
        {
            calculatorService = new CalculatorService();
        }


        [TestMethod]
        public void ShouldReturn0ForEmptyInput()
        {
            var result = calculatorService.Add(string.Empty);

            Assert.AreEqual(0, result);
        }


        [TestMethod]
        public void ShouldReturnTheSameNumberWhenASingleDigitProvided()
        {
            var result = calculatorService.Add("3");

            Assert.AreEqual(3, result);
        }


        [TestMethod]
        public void ShouldReturnTheSumOfTwoNumbers()
        {
            var result = calculatorService.Add("2,5");

            Assert.AreEqual(7, result);
        }


        // STEP-2 Support any amount of numbers in input.
        [DataTestMethod]
        [DataRow("1,2,3", 6)]
        [DataRow("10,20,30,40,50,60", 210)]
        [DataRow("0,1,1,2,3,5,8,13,21,34,55,89,144", 376)]
        public void ShouldReturnTheSumOfAnyAmountOfNumbers(string numbers, int expectedSum)
        {
            var result = calculatorService.Add(numbers);

            Assert.AreEqual(expectedSum, result);
        }


        // STEP-3 Add support for new line delimiters.
        [DataTestMethod]
        [DataRow("1\n2,3", 6)]
        [DataRow("10\n20\n30\n40\n50\n60", 210)]
        [DataRow("1,\n", 1)]
        public void ShouldHandleNewLinesBetweenNumbers(string numbers, int expectedSum)
        {
            var result = calculatorService.Add(numbers);

            Assert.AreEqual(expectedSum, result);
        }


        // STEP-4 Add support for custom delimiter character.
        [DataTestMethod]
        [DataRow("//;\n1;2;3", 6)]
        [DataRow("//*\n10*20*30*40*50*60", 210)]
        [DataRow("//#\n1#5#9#\n", 15)]
        public void ShouldSupportCustomDelimiterBetweenNumbers(string numbers, int expectedSum)
        {
            var result = calculatorService.Add(numbers);

            Assert.AreEqual(expectedSum, result);
        }


        // STEP-4 Add support for custom delimiter character.
        [DataTestMethod]
        [DataRow("//;\n1,200;2,400;200;300;500", 1000)]
        [DataRow("//;\n10;20\n30;40\n50;60", 70)]
        [DataRow("//;\n1\n5\n9\n", 0)]
        public void ShouldNotSplitOnCommaOrNewLineWhenCustomDelimiterSpecified(string numbers, int expectedSum)
        {
            var result = calculatorService.Add(numbers);

            Assert.AreEqual(expectedSum, result);
        }


        // STEP-5 Validate numbers and throw an exception if negative numbers are provided.
        [DataTestMethod]
        [DataRow("-1,2,3,4,5", "Negatives not allowed: -1\r\nParameter name: numbers")]
        [DataRow("0,1,-1,-2,-3,5,8", "Negatives not allowed: -1, -2, -3\r\nParameter name: numbers")]
        [DataRow("-8,-10,-12", "Negatives not allowed: -8, -10, -12\r\nParameter name: numbers")]
        public void ShouldThrowExceptionForNegativeNumbers(string numbers, string expectedMessage)
        {
            var exception = Assert.ThrowsException<ArgumentException>(() =>
            {
                calculatorService.Add(numbers);
            });

            Assert.AreEqual(expectedMessage, exception.Message);
        }

    }
}

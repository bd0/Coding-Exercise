using CodingExercise.Enums;
using CodingExercise.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CodingExercise.Tests
{
    [TestClass]
    public class CalculatorService_Calculate
    {

        readonly CalculatorService calculatorService;


        public CalculatorService_Calculate()
        {
            calculatorService = new CalculatorService();
        }


        [TestMethod]
        public void ShouldReturn0ForEmptyInput()
        {
            var result = calculatorService.Calculate(string.Empty);

            Assert.AreEqual(0, result);
        }


        [TestMethod]
        public void ShouldReturnTheSameNumberWhenASingleDigitProvided()
        {
            var result = calculatorService.Calculate("3");

            Assert.AreEqual(3, result);
        }


        [TestMethod]
        public void ShouldReturnTheSumOfTwoNumbers()
        {
            var result = calculatorService.Calculate("2,5");

            Assert.AreEqual(7, result);
        }


        // STEP-2 Support any amount of numbers in input.
        [DataTestMethod]
        [DataRow("1,2,3", 6)]
        [DataRow("10,20,30,40,50,60", 210)]
        [DataRow("0,1,1,2,3,5,8,13,21,34,55,89,144", 376)]
        public void ShouldReturnTheSumOfAnyAmountOfNumbers(string numbers, int expectedSum)
        {
            var result = calculatorService.Calculate(numbers);

            Assert.AreEqual(expectedSum, result);
        }


        // STEP-3 Add support for new line delimiters.
        [DataTestMethod]
        [DataRow("1\n2,3", 6)]
        [DataRow("10\n20\n30\n40\n50\n60", 210)]
        [DataRow("1,\n", 1)]
        public void ShouldHandleNewLinesBetweenNumbers(string numbers, int expectedSum)
        {
            var result = calculatorService.Calculate(numbers);

            Assert.AreEqual(expectedSum, result);
        }


        // STEP-4 Add support for custom delimiter character.
        [DataTestMethod]
        [DataRow("//;\n1;2;3", 6)]
        [DataRow("//*\n10*20*30*40*50*60", 210)]
        [DataRow("//#\n1#5#9#\n", 15)]
        public void ShouldSupportCustomDelimiterBetweenNumbers(string numbers, int expectedSum)
        {
            var result = calculatorService.Calculate(numbers);

            Assert.AreEqual(expectedSum, result);
        }


        // STEP-4 Add support for custom delimiter character.
        [DataTestMethod]
        [DataRow("//;\n1,200;2,400;200;300;500", 1000)]
        [DataRow("//;\n10;20\n30;40\n50;60", 70)]
        [DataRow("//;\n1\n5\n9\n", 0)]
        public void ShouldNotSplitOnCommaOrNewLineWhenCustomDelimiterSpecified(string numbers, int expectedSum)
        {
            var result = calculatorService.Calculate(numbers);

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
                calculatorService.Calculate(numbers);
            });

            Assert.AreEqual(expectedMessage, exception.Message);
        }


        // STEP-6 Silently ignore numbers bigger than 1000.
        [DataTestMethod]
        [DataRow("1,2,3,4,5000", 10)]
        [DataRow("0,1,2,1000,1001", 1003)]
        [DataRow("1001,10001,100001", 0)]
        public void ShouldExcludeNumbersBiggerThan1000(string numbers, int expectedSum)
        {
            var result = calculatorService.Calculate(numbers);

            Assert.AreEqual(expectedSum, result);
        }


        // STEP-7 Add support for delimiters to optionally be longer than 1 character.
        [DataTestMethod]
        [DataRow("//[;]\n1;2;3", 6)]
        [DataRow("//[**]\n10**20**30**40**50**60", 210)]
        [DataRow("//[###]\n1###5###9###\n", 15)]
        public void ShouldSupportCustomDelimiterLongerThan1Character(string numbers, int expectedSum)
        {
            var result = calculatorService.Calculate(numbers);

            Assert.AreEqual(expectedSum, result);
        }


        // STEP-8 Add support for multiple delimiters.
        [DataTestMethod]
        [DataRow("//[;][@]\n1;2;3@4@5", 15)]
        [DataRow("//[*][%]\n10*20*30*40*50*60", 210)]
        [DataRow("//[+][-][*][/]\n1+5-9*5/3+4", 27)]
        public void ShouldSupportMultiple1CharDelimitersWithBrackets(string numbers, int expectedSum)
        {
            var result = calculatorService.Calculate(numbers);

            Assert.AreEqual(expectedSum, result);
        }


        // STEP-9 Add support for multiple delimiters longer than 1 character.
        [DataTestMethod]
        [DataRow("//[;;][@@]\n1;;2;;3@@4@@5", 15)]
        [DataRow("//[**][%%]\n10**20**30**40**50**60", 210)]
        [DataRow("//[+][--][***][////]\n1+5--9***5////3+4", 27)]
        public void ShouldSupportMultipleDelimitersOfAnyLength(string numbers, int expectedSum)
        {
            var result = calculatorService.Calculate(numbers);

            Assert.AreEqual(expectedSum, result);
        }



        [TestMethod]
        public void ShouldDefaultToAddition()
        {
            var result = calculatorService.Calculate("2,1");

            // Confirm that addition is being performed as it is 
            // the only operation that will result in an answer of 3.
            Assert.AreEqual(3, result);
        }


        [DataTestMethod]
        [DataRow(CalculatorOperation.Addition, "10,2", 12)]
        [DataRow(CalculatorOperation.Subtraction, "10,2", 8)]
        [DataRow(CalculatorOperation.Multiplication, "10,2", 20)]
        [DataRow(CalculatorOperation.Division, "10,2", 5)]
        [DataRow(CalculatorOperation.Addition, "100,10,2", 112)]
        [DataRow(CalculatorOperation.Subtraction, "100,10,2", 88)]
        [DataRow(CalculatorOperation.Multiplication, "100,10,2", 2000)]
        [DataRow(CalculatorOperation.Division, "100,10,2", 5)]
        public void ShouldAffectTheResultOfTheCalculateMethod(CalculatorOperation operation, string input, int expectedResult)
        {
            var result = calculatorService.Calculate(input, operation);

            Assert.AreEqual(expectedResult, result);
        }

    }
}

using CodingExercise.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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

    }
}

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

    }
}

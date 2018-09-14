using CodingExercise.Enums;
using CodingExercise.Services;
using CodingExercise.Services.Calculators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingExercise.Tests
{
    [TestClass]
    public class SimpleCalculatorStore_GetResult
    {


        private ICalculator NewCalculatorStore() => new SimpleCalculator();


        [TestMethod]
        public void ShouldReturn0ForInitialState()
        {
            var store = NewCalculatorStore();

            var result = store.GetResult();

            Assert.AreEqual(0, result);
        }


        [DataTestMethod]
        [DataRow(1)]
        [DataRow(9)]
        [DataRow(17)]
        public void ShouldReturnNumberAfterASingleDigitAdded(int value)
        {
            var store = NewCalculatorStore();

            store.CommitNumber(value, CalculatorOperation.Addition);

            var result = store.GetResult();

            Assert.AreEqual(value, result);
        }


        [DataTestMethod]
        [DataRow(1, 2)]
        [DataRow(9, 13)]
        [DataRow(17, 23)]
        public void ShouldReturnSumAfterTwoDigitsAdded(int value1, int value2)
        {
            var store = NewCalculatorStore();

            store.CommitNumber(value1, CalculatorOperation.Addition);
            store.CommitNumber(value2, CalculatorOperation.Addition);

            var result = store.GetResult();

            Assert.AreEqual(value1 + value2, result);
        }


        // STEP-10 Support specifying an operation for the calculation.
        [DataTestMethod]
        [DataRow(CalculatorOperation.Addition, new[] { 10, 2 }, 12)]
        [DataRow(CalculatorOperation.Subtraction, new[] { 10, 2 }, 8)]
        [DataRow(CalculatorOperation.Multiplication, new[] { 10, 2 }, 20)]
        [DataRow(CalculatorOperation.Division, new[] { 10, 2 }, 5)]
        [DataRow(CalculatorOperation.Addition, new[] { 100, 10, 2 }, 112)]
        [DataRow(CalculatorOperation.Subtraction, new[] { 100, 10, 2 }, 88)]
        [DataRow(CalculatorOperation.Multiplication, new[] { 100, 10, 2 }, 2000)]
        [DataRow(CalculatorOperation.Division, new[] { 100, 10, 2 }, 5)]
        public void ShouldReturnSumAfterTwoDigitsAdded(CalculatorOperation operation, int[] numbers, int expectedValue)
        {
            var store = NewCalculatorStore();

            foreach (var number in numbers)
            {
                store.CommitNumber(number, operation);
            }

            var result = store.GetResult();

            Assert.AreEqual(expectedValue, result);
        }

    }
}

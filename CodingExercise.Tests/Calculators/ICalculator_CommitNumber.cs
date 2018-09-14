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
    /// Abstract class for testing implementations of the ICalculator interface.
    /// </summary>
    public abstract class ICalculator_CommitNumber
    {

        protected abstract ICalculator NewCalculator();


        protected abstract int? GetCurrentCalculatorValue(ICalculator calculator);


        [DataTestMethod]
        [DataRow(1)]
        [DataRow(9)]
        [DataRow(17)]
        public void ShouldAddNumberToStoreState(int value)
        {
            var store = NewCalculator();

            store.CommitNumber(value, Enums.CalculatorOperation.Addition);

            var storeCurrentValue = GetCurrentCalculatorValue(store);

            Assert.IsTrue(storeCurrentValue.HasValue);
            Assert.AreEqual(value, storeCurrentValue);
        }


        // STEP-10 Support specifying an operation for the calculation.
        [DataTestMethod]
        [DataRow(7, CalculatorOperation.Addition)]
        [DataRow(7, CalculatorOperation.Subtraction)]
        [DataRow(7, CalculatorOperation.Multiplication)]
        [DataRow(7, CalculatorOperation.Division)]
        public void ShouldInitializeStoreStateWithFirstValue(int value, CalculatorOperation operation)
        {
            var store = NewCalculator();

            store.CommitNumber(value, operation);

            var storeCurrentValue = GetCurrentCalculatorValue(store);

            Assert.IsTrue(storeCurrentValue.HasValue);
            Assert.AreEqual(value, storeCurrentValue);
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
        public void ShouldUpdateTheStoreStateWithTheAppropriateValues(CalculatorOperation operation, int[] numbers, int expectedResult)
        {
            var store = NewCalculator();

            foreach(var number in numbers)
            {
                store.CommitNumber(number, operation);
            }

            var storeCurrentValue = GetCurrentCalculatorValue(store);

            Assert.IsTrue(storeCurrentValue.HasValue);
            Assert.AreEqual(expectedResult, storeCurrentValue.Value);
        }

    }
}

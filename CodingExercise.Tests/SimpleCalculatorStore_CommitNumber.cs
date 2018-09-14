using CodingExercise.Enums;
using CodingExercise.Services;
using CodingExercise.Tests.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingExercise.Tests
{
    [TestClass]
    public class SimpleCalculatorStore_CommitNumber
    {


        private ICalculatorStore NewCalculatorStore() => new SimpleCalculatorStore();


        [DataTestMethod]
        [DataRow(1)]
        [DataRow(9)]
        [DataRow(17)]
        public void ShouldAddNumberToStoreState(int value)
        {
            var store = NewCalculatorStore();

            store.CommitNumber(value, Enums.CalculatorOperation.Addition);

            // Must access the private state of the SimpleCalculatorStore to validate.
            var storeCurrentValue = store.GetPrivateFieldValueInteger("currentValue");

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
            var store = NewCalculatorStore();

            store.CommitNumber(value, operation);

            // Must access the private state of the SimpleCalculatorStore to validate.
            var storeCurrentValue = store.GetPrivateFieldValueInteger("currentValue");

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
            var store = NewCalculatorStore();

            foreach(var number in numbers)
            {
                store.CommitNumber(number, operation);
            }

            // Must access the private state of the SimpleCalculatorStore to validate.
            var storeCurrentValue = store.GetPrivateFieldValueInteger("currentValue");

            Assert.IsTrue(storeCurrentValue.HasValue);
            Assert.AreEqual(expectedResult, storeCurrentValue.Value);
        }
    }
}

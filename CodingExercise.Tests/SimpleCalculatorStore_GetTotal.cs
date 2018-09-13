using CodingExercise.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingExercise.Tests
{
    [TestClass]
    public class SimpleCalculatorStore_GetTotal
    {


        private ICalculatorStore NewCalculatorStore() => new SimpleCalculatorStore();


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

            store.CommitNumber(value);

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

            store.CommitNumber(value1);
            store.CommitNumber(value2);

            var result = store.GetResult();

            Assert.AreEqual(value1 + value2, result);
        }

    }
}

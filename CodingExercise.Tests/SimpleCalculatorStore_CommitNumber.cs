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

            store.CommitNumber(value);

            // Must access the private state of the SimpleCalculatorStore to validate.
            var storeTotalState = store.GetPrivateFieldValueInteger("total");

            Assert.IsTrue(storeTotalState.HasValue);
            Assert.AreEqual(value, storeTotalState);
        }

    }
}

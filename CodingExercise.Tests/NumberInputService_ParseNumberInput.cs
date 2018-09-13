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


        // STEP-3 Add support for new line delimiters.
        [DataTestMethod]
        [DataRow("1\n2,3", new[] { 1, 2, 3 })]
        [DataRow("10\n20\n30\n40\n50\n60", new[] { 10, 20, 30, 40, 50, 60 })]
        [DataRow("1,\n", new[] { 1 })]
        public void ShouldHandleNewLinesBetweenNumbers(string input, int[] expectedCollection)
        {
            var result = numberInputParser.ParseNumberInput(input);

            CollectionAssert.AreEqual(expectedCollection, result.ToArray());
        }


        // STEP-4 Add support for custom delimiter character.
        [DataTestMethod]
        [DataRow("//;\n1;2;3", new[] { 1, 2, 3 })]
        [DataRow("//*\n10*20*30*40*50*60", new[] { 10, 20, 30, 40, 50, 60 })]
        [DataRow("//#\n1#5#9#\n", new[] { 1, 5, 9 })]
        public void ShouldSupportCustomDelimiterBetweenNumbers(string input, int[] expectedCollection)
        {
            var result = numberInputParser.ParseNumberInput(input);

            CollectionAssert.AreEqual(expectedCollection, result.ToArray());
        }


        // STEP-4 Add support for custom delimiter character.
        [DataTestMethod]
        [DataRow("//;\n1,200;2,400;200;300;500", new[] { 200, 300, 500 })]
        [DataRow("//;\n10;20\n30;40\n50;60", new[] { 10, 60 })]
        [DataRow("//;\n1\n5\n9\n", new int[] { })]
        [DataRow("///\n1/5/9", new int[] { 1, 5, 9 })]
        public void ShouldNotSplitOnCommaOrNewLineWhenCustomDelimiterSpecified(string input, int[] expectedCollection)
        {
            var result = numberInputParser.ParseNumberInput(input);

            CollectionAssert.AreEqual(expectedCollection, result.ToArray());
        }


        // STEP-4 Add support for custom delimiter character.
        [DataTestMethod]
        [DataRow("/;\n1,2,3", new[] { 1, 2, 3 })]
        [DataRow("//\n10,20,30,40,50,60", new[] { 10, 20, 30, 40, 50, 60 })]
        [DataRow("//;1,5,9,\n", new[] { 5, 9 })] // 1 is lost in this case because it becomes "//;1".
        public void ShouldStillWorkWithInvalidDelimiterSpecification(string input, int[] expectedCollection)
        {
            var result = numberInputParser.ParseNumberInput(input);

            CollectionAssert.AreEqual(expectedCollection, result.ToArray());
        }


        // STEP-7 Add support for delimiters to optionally be longer than 1 character.
        [DataTestMethod]
        [DataRow("//[;]\n1;2;3", new[] { 1, 2, 3 })]
        [DataRow("//[***]\n10***20***30***40***50***60", new[] { 10, 20, 30, 40, 50, 60 })]
        [DataRow("//[DELIMITER]\n1DELIMITER5DELIMITER9DELIMITER", new[] { 1, 5, 9 })]
        public void ShouldSupportCustomDelimiterOfAnyLengthWithBrackets(string input, int[] expectedCollection)
        {
            var result = numberInputParser.ParseNumberInput(input);

            CollectionAssert.AreEqual(expectedCollection, result.ToArray());
        }


        // STEP-7 Add support for delimiters to optionally be longer than 1 character.
        [DataTestMethod]
        [DataRow("//;;\n1;;2;;3", new int[] { })] // No numbers found because the delimiter is invalid.
        [DataRow("//***\n10***20,30,40,50***60", new[] { 30, 40 })] // Only 30, 40 found due to using default delimiter.
        [DataRow("//DELIMITER\n1DELIMITER5DELIMITER9DELIMITER", new int[] { })] // No numbers found because the delimiter is invalid.
        public void ShouldRequireBracketsAroundDelimiterGreaterThan1Character(string input, int[] expectedCollection)
        {
            var result = numberInputParser.ParseNumberInput(input);

            CollectionAssert.AreEqual(expectedCollection, result.ToArray());
        }


        // STEP-8 Add support for multiple delimiters.
        [DataTestMethod]
        [DataRow("//[;][@]\n1;2;3@4@5", new[] { 1, 2, 3, 4, 5 })]
        [DataRow("//[*][%]\n10*20*30*40*50*60", new[] { 10, 20, 30, 40, 50, 60 })]
        [DataRow("//[+][-][*][/]\n1+5-9*5/3+4", new[] { 1, 5, 9, 5, 3, 4 })]
        public void ShouldSupportMultiple1CharDelimitersWithBrackets(string input, int[] expectedCollection)
        {
            var result = numberInputParser.ParseNumberInput(input);

            CollectionAssert.AreEqual(expectedCollection, result.ToArray());
        }


        // STEP-9 Add support for multiple delimiters longer than 1 character.
        [DataTestMethod]
        [DataRow("//[;;][@@]\n1;;2;;3@@4@@5", new[] { 1, 2, 3, 4, 5 })]
        [DataRow("//[**][%%]\n10**20**30**40**50**60", new[] { 10, 20, 30, 40, 50, 60 })]
        [DataRow("//[+][--][***][////]\n1+5--9***5////3+4", new[] { 1, 5, 9, 5, 3, 4 })]
        public void ShouldSupportMultipleDelimitersOfAnyLength(string input, int[] expectedCollection)
        {
            var result = numberInputParser.ParseNumberInput(input);

            CollectionAssert.AreEqual(expectedCollection, result.ToArray());
        }

    }
}

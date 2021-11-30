using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProcessLibrary;

namespace FileProcessorTests
{
    [TestClass]
    public class FileProcessingTest
    {
        [TestMethod]
        public void GetPriceMultiplier_ReturnsCorrectMultiplier()
        {
            string inputValue = "InstIdentCode:DE000ABCDEFG|;InstFullName:DAX|;InstClassification:FFICSX|;NotionalCurr:EUR|;PriceMultiplier:20.0|;UnderlInstCode:DE0001234567|;UnderlIndexName:DAX PERFORMANCE-INDEX|;OptionType:OTHR|;StrikePrice:0.0|;OptionExerciseStyle:|;ExpiryDate:2021-01-01|;DeliveryType:PHYS|";

            string expectedValue = "20.0";

            string actualValue = CustomExtractor.GetPriceMultiplier(inputValue);

            Assert.AreEqual(expectedValue, actualValue);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetPriceMultiplier_ThrowException_WhenInput_Is_Empty()
        {
            string inputValue = string.Empty;

            CustomExtractor.GetPriceMultiplier(inputValue);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetPriceMultiplier_ThrowException_WhenInput_Is_Null()
        {
            string inputValue = null;

            CustomExtractor.GetPriceMultiplier(inputValue);
        }
    }
}

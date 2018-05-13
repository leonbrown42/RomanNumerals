using NUnit.Framework;
using System;

namespace RomanNumeralConverter.Tests
{
    [TestFixture]
    public class ConvertBySubtractionTests
    {
        [Test]
        [TestCase(1, ExpectedResult = "I", TestName = "{m}_{0}")]
        [TestCase(2, ExpectedResult = "II", TestName = "{m}_{0}")]
        [TestCase(3, ExpectedResult = "III", TestName = "{m}_{0}")]

        [TestCase(4, ExpectedResult = "IV", TestName = "{m}_{0}")]
        [TestCase(5, ExpectedResult = "V", TestName = "{m}_{0}")]
        [TestCase(6, ExpectedResult = "VI", TestName = "{m}_{0}")]
        [TestCase(7, ExpectedResult = "VII", TestName = "{m}_{0}")]
        [TestCase(8, ExpectedResult = "VIII", TestName = "{m}_{0}")]

        [TestCase(9, ExpectedResult = "IX", TestName = "{m}_{0}")]
        [TestCase(10, ExpectedResult = "X", TestName = "{m}_{0}")]
        [TestCase(11, ExpectedResult = "XI", TestName = "{m}_{0}")]
        [TestCase(12, ExpectedResult = "XII", TestName = "{m}_{0}")]
        [TestCase(13, ExpectedResult = "XIII", TestName = "{m}_{0}")]
        [TestCase(14, ExpectedResult = "XIV", TestName = "{m}_{0}")]
        [TestCase(20, ExpectedResult = "XX", TestName = "{m}_{0}")]
        [TestCase(30, ExpectedResult = "XXX", TestName = "{m}_{0}")]

        [TestCase(40, ExpectedResult = "XL", TestName = "{m}_{0}")]
        [TestCase(50, ExpectedResult = "L", TestName = "{m}_{0}")]
        [TestCase(60, ExpectedResult = "LX", TestName = "{m}_{0}")]
        [TestCase(70, ExpectedResult = "LXX", TestName = "{m}_{0}")]
        [TestCase(80, ExpectedResult = "LXXX", TestName = "{m}_{0}")]

        [TestCase(90, ExpectedResult = "XC", TestName = "{m}_{0}")]
        [TestCase(100, ExpectedResult = "C", TestName = "{m}_{0}")]
        [TestCase(200, ExpectedResult = "CC", TestName = "{m}_{0}")]
        [TestCase(300, ExpectedResult = "CCC", TestName = "{m}_{0}")]

        [TestCase(400, ExpectedResult = "CD", TestName = "{m}_{0}")]
        [TestCase(500, ExpectedResult = "D", TestName = "{m}_{0}")]
        [TestCase(600, ExpectedResult = "DC", TestName = "{m}_{0}")]
        [TestCase(700, ExpectedResult = "DCC", TestName = "{m}_{0}")]
        [TestCase(800, ExpectedResult = "DCCC", TestName = "{m}_{0}")]

        [TestCase(900, ExpectedResult = "CM", TestName = "{m}_{0}")]
        [TestCase(990, ExpectedResult = "CMXC", TestName = "{m}_{0}")]
        [TestCase(1000, ExpectedResult = "M", TestName = "{m}_{0}")]
        [TestCase(1014, ExpectedResult = "MXIV", TestName = "{m}_{0}")]
        [TestCase(2000, ExpectedResult = "MM", TestName = "{m}_{0}")]
        [TestCase(3000, ExpectedResult = "MMM", TestName = "{m}_{0}")]
        [TestCase(3999, ExpectedResult = "MMMCMXCIX", TestName = "{m}_{0}")]

        [TestCase(1776, ExpectedResult = "MDCCLXXVI", TestName = "{m}_{0}")]
        [TestCase(1954, ExpectedResult = "MCMLIV", TestName = "{m}_{0}")]
        [TestCase(1984, ExpectedResult = "MCMLXXXIV", TestName = "{m}_{0}")]
        [TestCase(1990, ExpectedResult = "MCMXC", TestName = "{m}_{0}")]
        [TestCase(2018, ExpectedResult = "MMXVIII", TestName = "{m}_{0}")]
        public string ConvertBySubtraction_ValidNumber_ReceiveRomanNumeral(int number)
        {
            var romanNumeral = ConvertBySubtraction.Convert(number);
            return romanNumeral;
        }

        [Test]
        [TestCase(4000)]
        public void ConvertBySubtraction_NumberExceedsMaxValue_ArgumentExceptionThrown(int number)
        {
            Assert.That(() => ConvertBySubtraction.Convert(number), Throws.TypeOf<ArgumentException>()
                .With.Message.EqualTo("Roman numerals have a maximum calculation value of 3999"));
        }
    }
}

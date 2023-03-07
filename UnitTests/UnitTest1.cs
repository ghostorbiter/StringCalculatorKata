using NUnit.Framework;
using StringCalculatorKata;
using System;

namespace TestProject1
{
    public class Tests
    {
        Calculator calculator;

        [SetUp]
        public void Setup()
        {
            calculator = new Calculator();
        }

        [Test]
        public void Return0WhenEmpty()
        {
            var result = calculator.add("");
            Assert.AreEqual(0, result);
        }

        [Test]
        public void CaseWhen1Num()
        {
            var result = calculator.add("1");
            Assert.AreEqual(1, result);
        }

        [Test]
        public void Comma2Nums()
        {
            var result = calculator.add("1, 2");
            Assert.AreEqual(3, result);
        }

        [Test]
        public void Newline2Nums()
        {
            var result = calculator.add("1\n2");
            Assert.AreEqual(3, result);
        }

        [Test]
        public void Comma3Nums()
        {
            var result = calculator.add("1, 2, 3");
            Assert.AreEqual(6, result);
        }

        [Test]
        public void Newline3Nums()
        {
            var result = calculator.add("1\n2\n3");
            Assert.AreEqual(6, result);
        }

        [Test]
        public void NegativeNum()
        {
            try
            {
                var result = calculator.add("1, -2");
                Assert.Fail();
            }
            catch (Exception)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void Greater1000num()
        {
            var result = calculator.add("10001, 1");
            Assert.AreEqual(1, result);
        }

        [Test]
        public void SingleDelimiter()
        {
            var result = calculator.add("#1#2#3");
            Assert.AreEqual(6, result);
        }

        [Test]
        public void MultiCharDelimiter()
        {
            var result = calculator.add("[###]1###2###3");
            Assert.AreEqual(6, result);
        }

        [Test]
        public void ManyDelimiters()
        {
            var result = calculator.add("[###][$][!]1$2!3###4");
            Assert.AreEqual(10, result);
        }
    }
}
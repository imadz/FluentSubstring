using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using FluentSubstring;
namespace FluentSubstringTests
{
    [TestFixture]
    public class NumericExtensionTest
    {
        [Test]
        public void Test_1st()
        {
            NumericStringSelector context = 1.st("A");
            Assert.That(context.Direction, Is.EqualTo(NumericStringSelector.ContextDirection.Forward));
            Assert.That(context.Number, Is.EqualTo(1));
        }
        [Test]
        public void Test_2nd()
        {
            NumericStringSelector context = 2.nd("A");
            Assert.That(context.Direction, Is.EqualTo(NumericStringSelector.ContextDirection.Forward));
            Assert.That(context.Number, Is.EqualTo(2));
        }
        [Test]
        public void Test_3rd()
        {
            NumericStringSelector context = 3.rd("A");
            Assert.That(context.Direction, Is.EqualTo(NumericStringSelector.ContextDirection.Forward));
            Assert.That(context.Number, Is.EqualTo(3));
        }
    }
}

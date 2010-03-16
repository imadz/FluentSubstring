using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using FluentSubstring;

namespace FluentSubstringTests
{
    [TestFixture]
    public class StringHelperTest
    {
        [Test]
        public void TestIndexOfNoArgs()
        {
            string test = "abcdefghijk lmnopqrstuvwxyz";
            Assert.That(StringHelper.IndexOf(test, "a"), Is.EqualTo(0));
            Assert.That(StringHelper.IndexOf(test, "b"), Is.EqualTo(1));
            Assert.That(StringHelper.IndexOf(test, "z"), Is.EqualTo(test.Length - 1));
            Assert.That(StringHelper.IndexOf(test, "*"), Is.EqualTo(-1));
        }
        [Test]
        public void TestIndexOf()
        {
            string test = "ababa  ababa";
            Assert.That(StringHelper.IndexOf(test, "a", 0, 1), Is.EqualTo(0));
            Assert.That(StringHelper.IndexOf(test, "a", 0, 2), Is.EqualTo(2));
            Assert.That(StringHelper.IndexOf(test, "a", 0, 3), Is.EqualTo(4));


            Assert.That(StringHelper.IndexOf(test, " ", 0, 1), Is.EqualTo(5));
            Assert.That(StringHelper.IndexOf(test, " ", 0, 2), Is.EqualTo(6));
        }
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestIndexOfInvalidArgs()
        {
            string test = "ababa  ababa";
            StringHelper.IndexOf(test, "a", 0, 0);
        }
        [Test]
        public void TestReverseIndexOf()
        {
            string test = "ababa  ababa";
            Assert.That(StringHelper.ReverseIndexOf(test, "a", 0, 1), Is.EqualTo(0));
            Assert.That(StringHelper.ReverseIndexOf(test, "a", 1, 1), Is.EqualTo(0));
            Assert.That(StringHelper.ReverseIndexOf(test, "a", 2, 1), Is.EqualTo(2));
            Assert.That(StringHelper.ReverseIndexOf(test, "a", 4, 1), Is.EqualTo(4));
            Assert.That(StringHelper.ReverseIndexOf(test, "a", 4, 2), Is.EqualTo(2));
            Assert.That(StringHelper.ReverseIndexOf(test, "a", 4, 3), Is.EqualTo(0));
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestReverseIndexOfInvalidOccurences()
        {
            string test = "ababa  ababa";
            Assert.That(StringHelper.ReverseIndexOf(test, "a", 2, 0), Is.EqualTo(2));
        }

        [Test]
        public void Test_First_And_Last()
        {
            string test = "atoz";
            FluentString searcher = new FluentString(test);
        }
    }
}

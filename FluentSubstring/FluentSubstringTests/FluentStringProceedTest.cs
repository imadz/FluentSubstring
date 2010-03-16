using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using FluentSubstring;
namespace FluentSubstringTests
{
    [TestFixture]
    public class FluentStringProceedTest
    {
        [Test]
        public void Test_From_Invalid_False()
        {
            bool proceed = false;
            string testString = "abcdefg";

            Assert.That(testString.AsFluent().ProceedIf.StringValid((str) => proceed)
                .From(1.st("z")).ToString(), Is.EqualTo(String.Empty));
        }
        [Test]
        public void Test_From_Invalid_False_2()
        {
            bool proceed = false;
            string testString = "abcdefg";

            Assert.That(testString.AsFluent().ProceedIf.True(() => proceed)
                .From(1.st("z")).ToString(), Is.EqualTo(String.Empty));
        }
        [Test]
        public void Test_To_Invalid_False()
        {
            bool proceed = false;
            string testString = "abcdefg";

            Assert.That(testString.AsFluent().ProceedIf.StringValid((str) => proceed)
                .To(1.st("z")).ToString(), Is.EqualTo(String.Empty));
        }
        [Test]
        public void Test_To_Invalid_False_2()
        {
            bool proceed = false;
            string testString = "abcdefg";

            Assert.That(testString.AsFluent().ProceedIf.True(() => proceed)
                .To(1.st("z")).ToString(), Is.EqualTo(String.Empty));
        }

        [Test]
        public void Test_From_Valid_True()
        {
            Assert.That("abcdefg".AsFluent().ProceedIf.True(() => true).From(1.st("a")).ToString(), Is.EqualTo("abcdefg"));
        }
        [Test]
        public void Test_From_Valid_False()
        {
            Assert.That("abcdefg".AsFluent().ProceedIf.True(() => false).From(1.st("a")).ToString(), Is.EqualTo(String.Empty));
        }


        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Test_Invalid_True()
        {
            bool proceed = true;
            string testString = "abcdefg";

            Assert.That(testString.AsFluent().ProceedIf.StringValid((x) => proceed).
                From(1.st("z")).ToString(), Is.EqualTo(String.Empty));
        }
    }
}

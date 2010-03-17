using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using FluentSubstring;

namespace FluentStringSearchTests
{
    [TestFixture]
    public class FluentSubstringTest
    {
        [Test]
        public void Test_Beginning()
        {
            String test = "1.2.3.4.5.6.7.8";
            Assert.That(test.AsFluent().From(5.th(".")).ToString(), Is.EqualTo(".6.7.8"));
        }
        [Test]
        public void Test_Beginning_To_End()
        {
            string testString = "atoz";
            FluentString searcher = new FluentString(testString);
            Assert.That("atoz".AsFluent().From(1.st("a")).To(1.st("z")).ToString(), Is.EqualTo("atoz"));
            Assert.That("atoz".AsFluent().From(1.st("a")).To(1.st("o")).ToString(), Is.EqualTo("ato"));
        }
        [Test]
        public void Test_Repeat_Occurrences()
        {
            string testString = "aa";
            FluentString searcher = new FluentString(testString);
            Assert.That("aa".AsFluent().
                From(1.st("a")).
                To(1.st("a")).ToString(), Is.EqualTo("a"));
            Assert.That(searcher.From(1.st("a")).To(2.nd("a")).ToString(), Is.EqualTo("aa"));
        }

        [Test]
        public void Test_Last()
        {
            string testString = "aaaaa";
            string result = testString.AsFluent().From(1.st("a")).To(1.st("a").Last());
            Assert.That(result, Is.EqualTo("aaaaa"));

            string result2 = testString.AsFluent().From(1.st("a")).To(5.th("a").Last());
            Assert.That(result2, Is.EqualTo("a"));
        }
        [Test]
        public void Test_From_Last()
        {
            string delimited = "1.2.3.4.5.6.7.8.9.10";
            string from = delimited.AsFluent().From(3.rd(".").Last());
            Assert.That(from, Is.EqualTo(".8.9.10"));
        }
        [Test]
        public void Test_To()
        {
            string delimited = "1.2.3";
            Assert.That(delimited.AsFluent().To(1.st(".")).ToString(), Is.EqualTo("1."));
        }
        [Test]
        public void Test_Add()
        {
            string s1 = "1";
            string s2 = "2";
            Assert.That((s1.AsFluent() + s2.AsFluent()).ToString(), Is.EqualTo("12"));
        }
        [Test]
        public void Test_Complex_Add()
        {
            string s1 = "1.2.3.4.5";
            string s2 = "6.7.8.9";
            Assert.That((s1.AsFluent().From(3.rd(".")) + s2.AsFluent().From(3.rd("."))).ToString(), Is.EqualTo(".4.5.9"));
        }
        [Test]
        public void Test_Length()
        {
            Assert.That("".AsFluent().Length, Is.EqualTo(0));
            Assert.That("1".AsFluent().Length, Is.EqualTo(1));

        }
        [Test]
        public void Test_Concat()
        {
            Assert.That(("a".AsFluent() + "b".AsFluent()).ToString(), Is.EqualTo("ab"));
            Assert.That(("a".AsFluent().Concat("b".AsFluent())).ToString(), Is.EqualTo("ab"));
        }
        [Test]
        public void Test_Before()
        {
            Assert.That("ab".AsFluent().To(Before.The(1.st("b"))).ToString(), Is.EqualTo("a"));
        }
        [Test]
        public void Test_After()
        {
            Assert.That("ab".AsFluent().From(After.The(1.st("a"))).ToString(), Is.EqualTo("b"));
        }
        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Test_Before_Invalid()
        {
            Assert.That("a".AsFluent().From(Before.The(1.st("a"))).ToString(), Is.EqualTo(""));
        }
        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Test_After_Invalid()
        {
            Assert.That("a".AsFluent().From(After.The(1.st("a"))).ToString(), Is.EqualTo(""));
        }

        [Test]
        public void Test_Chained_From()
        {
            Assert.That("ababc".AsFluent().From(1.st("b")).From(1.st("a")).ToString(), Is.EqualTo("abc"));
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Test_Chained_To()
        {
            "ababc".AsFluent().To(2.nd("a")).To(1.st("c"));
        }
    }
}

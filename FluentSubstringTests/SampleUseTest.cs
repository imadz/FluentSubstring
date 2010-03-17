using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using FluentSubstring;
namespace FluentSubstringTests
{
    [TestFixture]
    public class SampleUseTest
    {
        [Test]
        public void ExampleTest()
        {
            string html =
            @"<html>
                <head><title>HTML example</title></head>
                <body>I only want what's in the title and I don't want to use a full-blown parser/tidier. 
                      Which way is cleaner? should I do the following?
                </body>
              </html>";

            int titleIndex = html.IndexOf("<title>") + 7;
            int endTitleIndex = html.IndexOf("</title>") - 1;
            string titleContents = html.Substring(titleIndex, endTitleIndex - titleIndex + 1); //am I sure I want to add 1?

            //or I can do this.

            string cleanerTitle = html.AsFluent().
                From(After.The(1.st("<title>"))).
                To(1.st("</title>") - 1);

            Assert.That(cleanerTitle, Is.EqualTo(titleContents));
            Assert.That(html.AsFluent().
                From(After.The(1.st("<title>"))).
                To(Before.The(1.st("</title>"))).ToString(), Is.EqualTo(titleContents));
        }
    }
}

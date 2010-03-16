using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentSubstring.Dummy
{
    internal class DummyFluentSubstring : FluentString
    {
        private static readonly DummyFluentSubstring DummyFluent = new DummyFluentSubstring();
        private DummyFluentSubstring()
        {
        }
        public override FluentString From(NumericStringSelector selector)
        {
            return DummyFluent;
        }
        public override FluentString To(NumericStringSelector selector)
        {
            return DummyFluent;
        }
        public override string ToString()
        {
            return String.Empty;
        }
        public static DummyFluentSubstring Create()
        {
            return DummyFluent;
        }
    }

}

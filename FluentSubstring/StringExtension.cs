using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentSubstring
{
    public static class StringExtension
    {
        public static FluentString AsFluent(this string str)
        {
            return new FluentString(str);
        }
    }
}

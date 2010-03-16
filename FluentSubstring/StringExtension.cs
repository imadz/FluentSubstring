using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentSubstring
{
    /// <summary>
    /// Contains extension string methods
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// Bootstraps the entire fluent string process
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static FluentString AsFluent(this string str)
        {
            return new FluentString(str);
        }
    }
}

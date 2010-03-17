using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentSubstring
{
    public class After
    {
        public static NumericStringSelector The(NumericStringSelector selection)
        {
            int cSkipped = selection.SearchString.Length;
            return new NumericStringSelector(selection.Number, selection.SearchString, selection.Direction, cSkipped);
        }
    }
    public class Before
    {
        public static NumericStringSelector The(NumericStringSelector selection)
        {
            int cSkipped = selection.SearchString.Length;
            return new NumericStringSelector(selection.Number, selection.SearchString, selection.Direction, -1);

        }
    }
}

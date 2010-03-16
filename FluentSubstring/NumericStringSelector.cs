using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentSubstring
{
    public static class NumericExtension
    {
        public static NumericStringSelector st(this int number, string search)
        {
            return th(number, search);
        }
        public static NumericStringSelector nd(this int number, string search)
        {
            return th(number, search);
        }
        public static NumericStringSelector rd(this int number, string search)
        {
            return th(number, search);
        }
        public static NumericStringSelector th(this int number, string search)
        {
            return new NumericStringSelector(number, search, NumericStringSelector.ContextDirection.Forward);
        }
    }

    public class NumericStringSelector : INumericStringSelector
    {
        public enum ContextDirection
        {
            Forward = 0,
            Backward = 1
        }
        protected internal int Number { get; set; }
        protected internal ContextDirection Direction { get; set; }
        protected internal string SearchString { get; set; }
        internal NumericStringSelector()
        {
            Number = 0;
            this.Direction = ContextDirection.Forward;
            this.SearchString = String.Empty;
        }
        internal NumericStringSelector(int number, string searchString, ContextDirection direction)
        {
            Number = number;
            this.Direction = direction;
            this.SearchString = searchString;
        }

        public NumericStringSelector Last()
        {
            NumericStringSelector clone = new NumericStringSelector(Number, SearchString, ContextDirection.Backward);
            return clone;            
        }

    }

}

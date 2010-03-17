using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentSubstring
{
    public static class NumericExtension
    {
        /// <summary>
        /// Interchangible with nd, rd, and th
        /// </summary>
        /// <param name="number"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        public static NumericStringSelector st(this int number, string search)
        {
            return th(number, search);
        }
        /// <summary>
        /// Interchangible with nd, rd, and th
        /// </summary>
        /// <param name="number"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        public static NumericStringSelector nd(this int number, string search)
        {
            return th(number, search);
        }
        /// <summary>
        /// Interchangible with nd, rd, and th
        /// </summary>
        /// <param name="number"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        public static NumericStringSelector rd(this int number, string search)
        {
            return th(number, search);
        }
        /// <summary>
        /// Interchangible with nd, rd, and th
        /// </summary>
        /// <param name="number"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        public static NumericStringSelector th(this int number, string search)
        {
            return new NumericStringSelector(number, search, NumericStringSelector.ContextDirection.Forward);
        }
    }
    /// <summary>
    /// Used to select the instance of a string within another string
    /// </summary>
    public class NumericStringSelector : INumericStringSelector
    {
        /// <summary>
        /// Since 2.nd("foo").Last() is very different from 2.nd("foo"), we need to keep track of direction state
        /// </summary>
        public enum ContextDirection
        {
            Forward = 0,
            Backward = 1
        }
        /// <summary>
        /// the x in x.th
        /// </summary>
        protected internal int Number { get; set; }
        protected internal ContextDirection Direction { get; set; }
        protected internal int Skipped { get; set; }
        /// <summary>
        /// The needle used to search the haystack
        /// </summary>
        protected internal string SearchString { get; set; }
        internal NumericStringSelector()
            : this(0, String.Empty, ContextDirection.Forward)
        {
        }
        internal NumericStringSelector(int number, string searchString, ContextDirection direction)
            : this(number, searchString, direction, 0)
        {
        }
        internal NumericStringSelector(int number, string searchString, ContextDirection direction, int skipped)
        {
            Number = number;
            Direction = direction;
            SearchString = searchString;
            Skipped = skipped;
        }
        /// <summary>
        /// Reverses the previous NumberStringSelector.
        /// For a string = "aaaa", 2.nd("a") refers to index 1 where as 2.nd("a").Last() refers to index 2
        /// </summary>
        /// <returns>
        ///     new instance
        /// </returns>
        public NumericStringSelector Last()
        {
            NumericStringSelector clone = new NumericStringSelector(Number, SearchString, ContextDirection.Backward);
            return clone;
        }

        public static NumericStringSelector operator +(NumericStringSelector selector, int n)
        {
            NumericStringSelector clone = new NumericStringSelector(selector.Number, selector.SearchString, selector.Direction, selector.Skipped + n);
            return clone;
        }
        public static NumericStringSelector operator +(int n, NumericStringSelector selector)
        {
            NumericStringSelector clone = new NumericStringSelector(selector.Number, selector.SearchString, selector.Direction, selector.Skipped + n);
            return clone;
        }
        public static NumericStringSelector operator -(NumericStringSelector selector, int n)
        {
            return selector + (-n);
        }
        public static NumericStringSelector operator -(int n, NumericStringSelector selector)
        {
            return selector + (-n);
        }

    }

}

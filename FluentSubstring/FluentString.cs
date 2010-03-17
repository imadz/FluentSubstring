using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentSubstring.Dummy;
using FluentSubstring.Misc;

namespace FluentSubstring
{
    public class FluentString : AbstractFluentSubstringBase, IObjectHider
    {
        private ProceedIfCondition ifCondition;
        public ProceedIfCondition ProceedIf
        {
            get { return ifCondition ?? (ifCondition = new ProceedIfCondition(OriginalString, PreviousOperation, BeginIndex, EndIndex)); }
            set { ifCondition = value; }
        }


        public FluentString(string originalString)
            : this(originalString, SelectOperation.From, 0, originalString.Length - 1)
        {

        }
        /// <summary>
        /// Internal empty ctor
        /// </summary>
        internal FluentString()
            : this(String.Empty, SelectOperation.From, 0, 0)
        {
        }
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="originalString">original string from which the substring should come</param>
        /// <param name="previous">Indicates if the last operation was a From or a To</param>
        /// <param name="beginIndex">The beginning index of our substring</param>
        /// <param name="endIndex">The ending index of our substring</param>
        internal FluentString(string originalString, SelectOperation previous, int beginIndex, int endIndex)
        {
            this.OriginalString = originalString;
            this.PreviousOperation = previous;
            this.BeginIndex = beginIndex;
            this.EndIndex = endIndex;
        }
        /// <summary>
        /// Creates a new instance of FluentString that represents a substring beginning from some instance of a string as represented by context
        /// 
        /// </summary>
        /// <param name="context">
        ///     Indicates the n-th occurence of a string from which the substring should start.
        ///     i.e. 2.nd("foo")
        /// </param>
        /// <returns>
        ///     A new instance of FluentString.
        /// </returns>
        /// <example>
        ///     "foofoo".From(2.nd("foo")) represents "foo"
        /// </example>
        public virtual FluentString From(NumericStringSelector context)
        {
            return PerformSubstring(context, true, false);
        }
        /// <summary>
        /// Creates a new instance of FluentString that represents a substring that ends with some instance of a string as represented by context
        /// 
        /// </summary>
        /// <param name="context">
        ///     Indicates the n-th occurence of a string from which the substring should end.
        ///     i.e. 2.nd("foo")
        /// </param>
        /// <returns>
        ///     A new instance of FluentString.
        /// </returns>
        /// <example>
        ///    "abab".To(2.nd("a")) represents "aba"
        /// </example>
        public virtual FluentString To(NumericStringSelector context)
        {
            return PerformSubstring(context, false, false);
        }
        private FluentString PerformSubstring(NumericStringSelector context, bool isFrom, bool fromBeginning)
        {
            int nIndex = -1;
            FluentString result = null;
            switch (context.Direction)
            {
                case NumericStringSelector.ContextDirection.Forward:
                    nIndex = StringHelper.IndexOf(OriginalString, context.SearchString, BeginIndex, context.Number, EndIndex);
                    break;
                case NumericStringSelector.ContextDirection.Backward:
                    nIndex = StringHelper.ReverseIndexOf(OriginalString, context.SearchString, EndIndex, context.Number);
                    break;
            }
            //if we can't find something we want an exception always
            if (nIndex == -1)
            {
                throw new ArgumentOutOfRangeException("Could not find " + context.SearchString);
            }
            else
            {
                nIndex += context.Skipped;
                if (isFrom)
                {
                    //if last operation was from, we want to change start
                    result = new FluentString(OriginalString, PreviousOperation, nIndex, EndIndex);
                }
                else
                {
                    //if last operation was to, we want to change the end
                    result = new FluentString(OriginalString, PreviousOperation, BeginIndex, nIndex);
                }
            }
            return result;
        }
        public FluentString Concat(FluentString s2)
        {
            return this + s2;
        }
        /// <summary>
        /// Concatenates two FluentString together. This creates 3 new strings.
        /// It collapses the first substring, collapses the second substring, and concatenates together
        /// </summary>
        /// <param name="s1">First FluentString</param>
        /// <param name="s2">Second FluentString</param>
        /// <returns>
        ///     A new FluentString instance.
        /// </returns>
        public static FluentString operator +(FluentString s1, FluentString s2)
        {
            string s1Portion = s1.ToString();
            string s2Portion = s2.ToString();
            return new FluentString(s1Portion + s2Portion, SelectOperation.From, 0, s1.Length + s2.Length - 1);
        }
        /// <summary>
        /// Implicit conversion to string.
        /// 
        /// </summary>
        /// <param name="substr"></param>
        /// <returns></returns>
        public static implicit operator string(FluentString substr)
        {
            return substr.ToString();
        }
        public static implicit operator StringBuilder(FluentString substr)
        {
            return new StringBuilder(substr);
        }

    }
}

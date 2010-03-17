using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentSubstring;
using FluentSubstring.Dummy;
using System.ComponentModel;

namespace FluentSubstring
{
    /// <summary>
    /// Used to define a condition "proceed if(x)". If x evaluates to be true, then proceed normally.
    /// Otherwise, any following operations do nothing, and thrown exceptions are ignored and an empty string is returned in the end.
    /// </summary>
    public class ProceedIfCondition : FluentString, IConditionMatcher
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new IConditionMatcher ProceedIf { get; set; }
        #region IConditionMatcher Members
        public ProceedIfCondition(string originalString, SelectOperation op, int beginIndex, int endIndex)
            : base(originalString, op, beginIndex, endIndex)
        {
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override FluentString From(NumericStringSelector context)
        {
            return base.From(context);
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override FluentString To(NumericStringSelector context)
        {
            return base.To(context);
        }
        public FluentString True(Func<bool> condition)
        {
            return (condition()) ? (FluentString)this : DummyFluentSubstring.Create();
        }

        public FluentString False(Func<bool> condition)
        {
            if (!condition())
            {
                return this;
            }
            else
            {
                return DummyFluentSubstring.Create();
            }
        }

        public FluentString IsEmpty()
        {
            return (BeginIndex == EndIndex) ? (FluentString)this : DummyFluentSubstring.Create();

        }

        public FluentString NotEmpty()
        {
            return (EndIndex > BeginIndex) ? (FluentString)this : DummyFluentSubstring.Create();

        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString()
        {
            return base.ToString();
        }

        public FluentString StringValid(Func<string, bool> predicate)
        {
            return (predicate(ToString())) ? (FluentString)this : DummyFluentSubstring.Create();
        }

        #endregion
    }
    public interface IConditionMatcher
    {
        /// <summary>
        /// Continues if and only if the condition delegate evaluates to true
        /// </summary>
        /// <param name="condition">
        ///     A delegate that returns a bool
        /// </param>
        /// <returns></returns>
        FluentString True(Func<bool> condition);
        /// <summary>
        /// Continues if and only if the condition delegate evaluates to false
        /// </summary>
        /// <param name="condition">
        ///     A delegate that returns a bool
        /// </param>
        /// <returns></returns>
        FluentString False(Func<bool> condition);

        /// <summary>
        /// Continues if and only if the substring thus far evaluates to String.Empty
        /// </summary>
        /// <returns></returns>
        FluentString IsEmpty();
        /// <summary>
        /// Continues if and only if the substring thus far does not evaluate to String.Empty
        /// </summary>
        /// <returns></returns>
        FluentString NotEmpty();
        /// <summary>
        /// Continus if and only if the substring thus, when passed into predicate, evaluates to be true
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        FluentString StringValid(Func<string, bool> predicate);
    }
}

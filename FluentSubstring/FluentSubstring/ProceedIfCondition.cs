using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentSubstring;
using FluentSubstring.Dummy;
using System.ComponentModel;

namespace FluentSubstring
{
    public class ProceedIfCondition : FluentString, IConditionMatcher
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new ProceedIfCondition ProceedIf { get; set; }
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
            if (condition())
            {
                return this;
            }
            else
            {
                return DummyFluentSubstring.Create();
            }


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
            if (BeginIndex == EndIndex)
            {
                return this;
            }
            else
            {
                return DummyFluentSubstring.Create();
            }
        }

        public FluentString NotEmpty()
        {
            if (EndIndex > BeginIndex)
            {
                return this;
            }
            else
            {
                return DummyFluentSubstring.Create();
            }

        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString()
        {
            return base.ToString();
        }


        #endregion

        #region IConditionMatcher Members


        public FluentString StringValid(Func<string, bool> predicate)
        {
            if (predicate(ToString()))
            {
                return this;
            }
            else
            {
                return DummyFluentSubstring.Create();
            }
        }

        #endregion
    }
    public interface IConditionMatcher
    {
        FluentString True(Func<bool> condition);
        FluentString False(Func<bool> condition);
        FluentString IsEmpty();
        FluentString NotEmpty();
        FluentString StringValid(Func<string, bool> predicate);
    }
}

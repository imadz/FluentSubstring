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
        internal FluentString()
            : this(String.Empty, SelectOperation.From, 0, 0)
        {
        }
        internal FluentString(string originalString, SelectOperation previous, int beginIndex, int endIndex)
        {
            this.OriginalString = originalString;
            this.PreviousOperation = previous;
            this.BeginIndex = beginIndex;
            this.EndIndex = endIndex;
        }

        public virtual FluentString From(NumericStringSelector context)
        {
            return PerformSubstring(context, true, false);
        }
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
                    nIndex = StringHelper.IndexOf(OriginalString, context.SearchString, 0, context.Number);
                    break;
                case NumericStringSelector.ContextDirection.Backward:
                    nIndex = StringHelper.ReverseIndexOf(OriginalString, context.SearchString, OriginalString.Length - 1, context.Number);
                    break;
            }
            if (nIndex == -1)
            {
                throw new ArgumentOutOfRangeException("Could not find " + context.SearchString);
            }
            else if (isFrom)
            {
                result = new FluentString(OriginalString, PreviousOperation, nIndex, EndIndex);
            }
            else
            {
                result = new FluentString(OriginalString, PreviousOperation, BeginIndex, nIndex);
            }
            return result;
        }
        public FluentString Concat(FluentString s2)
        {
            return this + s2;
        }
        public static FluentString operator +(FluentString s1, FluentString s2)
        {
            string s1Portion = s1.ToString();
            string s2Portion = s2.ToString();
            return new FluentString(s1Portion + s2Portion, SelectOperation.From, 0, s1.Length + s2.Length - 1);
        }
        public static implicit operator string(FluentString substr)
        {
            return substr.ToString();
        }

    }
}

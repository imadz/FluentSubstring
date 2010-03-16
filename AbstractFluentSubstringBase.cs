using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using FluentSubstring.Misc;

namespace FluentSubstring
{
    public abstract class AbstractFluentSubstringBase : IObjectHider
    {
        #region IBeginEnd Members
        private int beginIndex;
        private int endIndex;
        private SelectOperation previous;
        private string originalString;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public string OriginalString
        {
            get { return originalString; }
            set { originalString = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public int BeginIndex
        {
            get { return beginIndex; }
            set { beginIndex = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public int EndIndex
        {
            get { return endIndex; }
            set { endIndex = value; }
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SelectOperation PreviousOperation
        {
            get { return previous; }
            set { previous = value; }
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int Length
        {
            get
            {
                int length = -1;
                if (EndIndex < BeginIndex)
                {
                    length = 0;
                }
                else
                {
                    length = EndIndex - BeginIndex + 1;
                }
                return length;
            }
        }
        public override string ToString()
        {
            string stringRepresentation = null;
            if (BeginIndex == 0 && EndIndex == OriginalString.Length - 1)
            {
                stringRepresentation = OriginalString;
            }
            else
            {
                stringRepresentation = OriginalString.Substring(BeginIndex, EndIndex - BeginIndex + 1);
            }
            return stringRepresentation;
        }
        #endregion



        #region IObjectHider Members
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object other)
        {
            return base.Equals(other);
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Type GetType()
        {
            return base.GetType();
        }
        #endregion
    }
}

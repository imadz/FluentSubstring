using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace FluentSubstring.Misc
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IObjectHider
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        bool Equals(object other);
        [EditorBrowsable(EditorBrowsableState.Never)]
        int GetHashCode();
        [EditorBrowsable(EditorBrowsableState.Never)]
        Type GetType();

    }
}

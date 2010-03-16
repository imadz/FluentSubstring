using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace FluentSubstring
{
    public interface IBoundedString
    {
        string OriginalString { get; set; }
        int BeginIndex { get; set; }
        int EndIndex { get; set; }
        int Length {get;}
    }
}

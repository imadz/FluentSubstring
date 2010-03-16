using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentSubstring
{
    internal interface IStateAware
    {
        SelectOperation PreviousOperation { get; set; }
    }
}

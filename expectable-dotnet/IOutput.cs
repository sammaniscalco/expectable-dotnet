using System;
using System.Collections.Generic;
using System.Text;

namespace Expectable
{
    public interface IOutput
    {
        string ToString();
        List<string> ToList();
    }
}

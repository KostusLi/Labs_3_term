using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class OutRangeException : ArgumentException
{
    public OutRangeException(string message) : base(message)
    {

    }
}

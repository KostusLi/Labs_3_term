using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class CheckListException : ArgumentOutOfRangeException
{
    public CheckListException(string message) : base(message) { }
}

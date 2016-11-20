using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRMKJK
{
    public class UnexpectedCRMKJKEncodeException : Exception
    {
        public UnexpectedCRMKJKEncodeException() { }
        public UnexpectedCRMKJKEncodeException(string message) : base(message) { }
        public UnexpectedCRMKJKEncodeException(string message, Exception inner) : base(message, inner) { }
    }
}

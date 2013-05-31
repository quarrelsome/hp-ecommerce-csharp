using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HpEcommerce.messages;

namespace HpEcommerce.exceptions
{
    public class HpServerError : Exception
    {
        public ErrorMessage ErrorMsg { get; set; }

        public HpServerError(string message, ErrorMessage errorMsg)
            : base(message)
        {
            ErrorMsg = errorMsg;
        }
        public HpServerError(string message, System.Exception inner, ErrorMessage errorMsg)
            : base(message, inner)
        {
            ErrorMsg = errorMsg;
        }
    }

    class HpECommerceException : Exception
    {
        public HpECommerceException() : base() { }
        public HpECommerceException(string message) : base(message) { }
        public HpECommerceException(string message, System.Exception inner) : base(message, inner) { }
    }
}

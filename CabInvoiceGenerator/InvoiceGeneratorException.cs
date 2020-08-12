using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    public class InvoiceGeneratorException : Exception
    {
        public enum ExceptionType
        {
            NULL_USER_EXCEPTION
        }
        public ExceptionType type;
        public InvoiceGeneratorException(string message, ExceptionType type)
            : base(message)
        {
            this.type = type;
        }
    }
}

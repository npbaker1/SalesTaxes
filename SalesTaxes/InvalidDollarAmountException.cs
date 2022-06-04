using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTaxes
{
    //Custom Exception for an incorrect price.
    //Exception gets thrown based on the response from Validations.IsValidMoney
    internal class InvalidDollarAmountException : Exception
    {
        public InvalidDollarAmountException()
        {

        }

        public InvalidDollarAmountException(string message)
            : base(message)
        {

        }

        public InvalidDollarAmountException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}

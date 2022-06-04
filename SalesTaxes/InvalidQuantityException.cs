using System;


namespace SalesTaxes
{
    //Custom Exception for an incorrect quantity.
    //Exception gets thrown based on the response from Validations.IsPositiveInteger
    internal class InvalidQuantityException: Exception
    {
        public InvalidQuantityException()
        {

        }

        public InvalidQuantityException(string message)
            : base(message)
        {

        }

        public InvalidQuantityException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}

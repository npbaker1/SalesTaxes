using System;


namespace SalesTaxes
{
    //Custom Exception for missing the word "at" which is used to split
    //the description from the price in user input.
    //Exception gets thrown from Program.LoopThroughLines if the specific line
    //does not contain the word "at"
    internal class MissingAtException: Exception
    {
        public MissingAtException()
        {

        }

        public MissingAtException(string message)
            : base(message)
        {

        }

        public MissingAtException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}

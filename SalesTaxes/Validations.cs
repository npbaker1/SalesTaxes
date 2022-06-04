using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SalesTaxes
{
    //Class contains validations on user input
    public class Validations
    {
        //This validation is used when evaluating what should be
        //the quantity component of the user entry.  Used to throw the 
        //InvalidQuantityException if the value returns false
        public static bool IsPositiveInteger(string s)
        {
            bool ReturnValue = false;
            
            if (Regex.IsMatch(s,@"^\d+$"))
            {
                ReturnValue = true;
            }

            return ReturnValue;
        }
        //This validation is used when evaluating what should be
        //the price component of the user entry.  Used to throw the
        //InvalidDollarAmountException if the value returns false
        public static bool IsValidMoney(string s)
        {
            bool ReturnValue = false;

            if ((Regex.IsMatch(s, @"^\$?([0-9]{1,3},([0-9]{3},)*[0-9]{3}|[0-9]+)(.[0-9][0-9])?$")))
            {
                ReturnValue = true;
            }

            return ReturnValue;
        }
    }
}

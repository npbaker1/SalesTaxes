using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTaxes
{
    //Custom class for individual items in the shopping basket
    //Quantity was included to allow for the user to enter various quantities besides 1
    //as listed in the example
    //Total Price is also used to handle multiple quantities and so the value is easily available
    //when summing for the receipt output
    //IsBook, IsFood, IsMedical, and IsImport are used to determine what taxes need to be used on
    //the item and are currently calculated values based on the description
    //CalculateSalesTax and CalculateImportTax calculate the tax amounts per unit based on
    //the IsBook, IsFood, IsMedical, and IsImport properties along with the unit price
    public class Item
    {
        private string _description =String.Empty;
        private decimal _unitPrice = 0;
        private decimal _totalPrice = 0;
        private bool _isBook =false;
        private bool _isFood=false;
        private bool _isMedical = false;
        private bool _isImport = false;
        private int _quantity = 0;
        private decimal _salestax = 0;
        private decimal _importtax = 0;

        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }

        public decimal UnitPrice
        {
            get 
            { 
                return _unitPrice; 
            }
            set
            {
                _unitPrice = value;
            }
        }
        public decimal TotalPrice
        {
            get
            {
                return (UnitPrice + SalesTax + ImportTax)*Quantity;
            }
        }

        public  bool IsBook
        {
            get
            {
                return CalculateIsBook(Description);
            }
        
        }

        public bool IsFood
        {
            get
            {
                return CalculateIsFood(Description);
            }
          
        }

        public bool IsMedical
        {
            get
            {
                return CalculateIsMedical(Description);
            }
           
        }

        public bool IsImport
        {
            get
            {
                return CalculateIsImport(Description);
            }
          
        }

        public int Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value;
            }
        }

        public decimal SalesTax
        {
            get
            {
                if (!IsBook && !IsMedical && !IsFood)
                {
                    return CalculateSalesTax(UnitPrice);
                }
                else
                {
                    return Convert.ToDecimal(0.00);
                }
            }
        }
        public decimal ImportTax
        {
            get
            {
                if (IsImport)
                {
                    return CalculateImportTax(UnitPrice);
                }
                else
                {
                    return Convert.ToDecimal(0.00);
                }
            }
        }

        public static bool CalculateIsBook(string description)
        {
            bool ReturnValue = false;

            if (description.ToUpper().Contains("BOOK"))
            {
                ReturnValue = true;
            }

            return ReturnValue;

        }

        public static bool CalculateIsFood(string description)
        {
            bool ReturnValue = false;

            if (description.ToUpper().Contains("CHOCOLATE"))
            {
                ReturnValue = true;
            }
            

            return ReturnValue;

        }

        public static bool CalculateIsMedical(string description)
        {
            bool ReturnValue = false;

            if (description.ToUpper().Contains("PILLS"))
            {
                ReturnValue = true;
            }


            return ReturnValue;

        }

        public static bool CalculateIsImport(string description)
        {
            bool ReturnValue = false;

            if (description.ToUpper().Contains("IMPORTED"))
            {
                ReturnValue = true;
            }


            return ReturnValue;

        }

        public static decimal CalculateSalesTax(decimal price)
        {
            decimal ReturnValue = 0;



            ReturnValue = (price * Convert.ToDecimal(.1));

            var mod = ReturnValue % Convert.ToDecimal(.05);

            if (mod > 0)
            {
                ReturnValue = ReturnValue + (Convert.ToDecimal(.05) - mod);
            }



            return ReturnValue;



        }

        public static decimal CalculateImportTax(decimal price)
        {
            decimal ReturnValue = 0;

            ReturnValue = (price * Convert.ToDecimal(.05));

            var mod = ReturnValue % Convert.ToDecimal(.05);

            if (mod>0)
            {
                ReturnValue = ReturnValue + (Convert.ToDecimal(.05) - mod);
            }
           




            return ReturnValue;



        }
    }
}

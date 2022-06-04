
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Given the simple text based input and output for this problem I decided to create a console app
 * as it seemed to meet the requirments without needing to develop a user interface component.  I
 * made the assumption that in any scenario we would know all of the potential products we could
 * sell and therefore only coded taxing calculations based on the products I was aware of from 
 * the inputs listed in the problem.  While you could enter any product and the basic sale price
 * would function correctly the ability to identify books, food, medical products, and imported 
 * items are driven by the descriptions used from the sample inputs.  I created the Item class in
 * order to have easy access to the values needed to generate the receipt and for ease of creating
 * a list I could use for summing the values.  I split off the Validations class just to create a
 * central file where all validation functions could be found that could be expanded if needed.
 */


namespace SalesTaxes
{
    class Program
    {
        private static List<Item> ItemList = new List<Item>();
        private static Item item = new Item();
        private static int counter = 1;
        private static bool descriptiondone = false;
      
        //The loop is broken out from the main program 
        //so it can be recalled in case of exception and allow
        //the user to correct or skip a single item without
        //having to re-enter the entire shopping cart
        private static void LoopThroughItems(string[] s)
        {
            foreach (var line in s)
            {
                try
                {
                    if (!line.ToUpper().Contains(" AT "))
                    {
                        throw new MissingAtException();

                    }
                    string[] words = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    counter = 1;
                    descriptiondone = false;
                    item = new Item();
                    StringBuilder sb = new StringBuilder();
                    foreach (string word in words)
                    {
                        //based on the formatting in the example the first word 
                        //of the entry should be the quantity and it will
                        //be validated to be a positive integer or throw
                        //the InvalidQuantityException
                        if (counter == 1)
                        {
                            if (!Validations.IsPositiveInteger(word))
                            {
                                throw new InvalidQuantityException();
                            }

                            item.Quantity = Convert.ToInt32(word);
                        }
                        else
                        {
                            //Based on formatting in the example the word at
                            //splits the description from the price of the item
                            //At this point we are done building the description string
                            //and can store it
                            if (word.ToUpper() == "AT")
                            {
                                item.Description = sb.ToString().Trim();
                                descriptiondone = true;
                            }
                            //if we are done with the description we should then have the price
                            //based on example formatting.
                            //Validate the formatting and if not valid throw
                            //the InvalidDollarAmountException and allow user to re-enter the
                            //item
                            else if (descriptiondone==true)
                            {
                                if (Validations.IsValidMoney(word))
                                {
                                    //Strip out the dollar sign if the user included it
                                    if (word.StartsWith('$'))
                                    {
                                       
                                        item.UnitPrice = Convert.ToDecimal(word.Substring(1));
                                    }
                                    else
                                    {
                                        item.UnitPrice = Convert.ToDecimal(word);
                                    }
                                    

                                }
                                else
                                {
                                    throw new InvalidDollarAmountException();
                                }
                              
                            }
                            //Build the item description
                            else
                            {
                                sb.Append(word + " ");
                            }
                        }
                        counter++;

                    }
                    //Add all of the items to the ItemList for later use
                    //in generating the receipt output
                    ItemList.Add(item);


                }
                //Custom Exception Catching
                //These allow the user to re-enter the individual item causing
                //the error without re-entering the entire shopping cart
                catch (InvalidDollarAmountException ex)
                {
                    Console.WriteLine("Price is invalid at line: " + line + ".  Please re-enter the item or press enter to skip.");
                    Console.WriteLine("Please enter item in the following format: [Quantity] [Description] at [Price]");
                    string[] errorinput = { "" };
                    var x = Console.ReadLine();
                    errorinput[0] = x;
                    LoopThroughItems(errorinput);
                    item = new Item();
                    counter = 1;
                }
                catch (MissingAtException ex)
                {
                    Console.WriteLine("Missing the word \"at\" at line: " + line + ".  Please re-enter the item or press enter to skip.");
                    Console.WriteLine("Please enter item in the following format: [Quantity] [Description] at [Price]");
                    string[] errorinput = { "" };
                    var x = Console.ReadLine();
                    errorinput[0] = x;
                    LoopThroughItems(errorinput);
                    item = new Item();
                    counter = 1;
                }
                catch (InvalidQuantityException ex)
                {
                    Console.WriteLine("Quantity value is invalid at line: "+line+".  Please re-enter the item or press enter to skip.");
                    Console.WriteLine("Please enter item in the following format: [Quantity] [Description] at [Price]");
                    string[] errorinput = {""};
                     var x=   Console.ReadLine();
                    errorinput[0] = x;
                    LoopThroughItems(errorinput);
                    item = new Item();
                    counter = 1;

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unhandled Error");
                }
            }
        }
        static void Main(string[] args)
        {

            //Allow user to enter all items in their shopping cart
            //use CTRL+Z followed by Enter to indicate user is finished

            try
            {

                Console.WriteLine("Enter Item (When finished enter CTRL+Z and hit enter for receipt):");
                var input = Console.In.ReadToEnd();


                string[] items = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
                LoopThroughItems(items);

                //Generate summed data for the receipt printout
                //Grouping is based on item description
                //Note this will cause issues if you have items with the same description
                //and different prices but in a real world scenario I would be inclined
                //to base products off of a database table using identity fields to eliminate
                //that issue
                var LineItems = ItemList.GroupBy(i => i.Description).Select(i => new { Description = i.Key, TotalQuantity = i.Sum(item => item.Quantity), TotalPrice = i.Sum(item => item.TotalPrice), TotalTaxes = i.Sum(item => (item.SalesTax + item.ImportTax)) });

                var SalesTaxes = LineItems.Sum(item => item.TotalTaxes);
                var Total = LineItems.Sum(item => item.TotalPrice);
               //Prints out the individual item line items
                foreach (var lineitem in LineItems)
                {
                    if (lineitem.TotalQuantity > 1)
                    {
                        Console.WriteLine(lineitem.Description + ": " + lineitem.TotalPrice.ToString("N2") + " (" + lineitem.TotalQuantity + " @ " + (lineitem.TotalPrice / lineitem.TotalQuantity).ToString("N2") + ")");

                    }
                    else
                    {
                        Console.WriteLine(lineitem.Description + ": " + lineitem.TotalPrice.ToString("N2"));
                    }
                }
                //Prints out Sales Taxes and Total
                Console.WriteLine("Sales Taxes: " + SalesTaxes.ToString("N2"));
                Console.WriteLine("Total: " + Total.ToString("N2"));

                ItemList.Clear();

                //Allow use to enter another shopping basket after printing receipt or exit program
                Console.WriteLine("Type X and then hit Enter to exit program or type anything else and hit Enter to create a new shopping basket.");
                var closeprogram = Console.ReadLine();

                if(closeprogram.ToUpper()=="X")
                {
                    return;
                }
                else
                {
                    Main(args);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Unhandled Error");
            }

             
            


        }
    }
}
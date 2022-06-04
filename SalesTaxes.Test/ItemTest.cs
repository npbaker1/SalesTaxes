

namespace SalesTaxes.Test
{
    [TestClass]
    public class ItemTest
    {
        [TestMethod]
        public void CalculateIsBook_ValidValue()
        {
            string testvalue = "book";
            var result = SalesTaxes.Item.CalculateIsBook(testvalue);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CalculateIsBook_InvalidValue()
        {
            string testvalue = "apple";
            var result = SalesTaxes.Item.CalculateIsBook(testvalue);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CalculateIsMedical_ValidValue()
        {
            string testvalue = "pills";
            var result = SalesTaxes.Item.CalculateIsMedical(testvalue);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CalculateIsMedical_InvalidValue()
        {
            string testvalue = "chocolate";
            var result = SalesTaxes.Item.CalculateIsMedical(testvalue);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CalculateIsFood_ValidValue()
        {
            string testvalue = "chocolate";
            var result = SalesTaxes.Item.CalculateIsFood(testvalue);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CalculateIsFood_InvalidValue()
        {
            string testvalue = "cd";
            var result = SalesTaxes.Item.CalculateIsFood(testvalue);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CalculateIsImport_ValidValue()
        {
            string testvalue = "IMPORTED";
            var result = SalesTaxes.Item.CalculateIsImport(testvalue);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CalculateIsImport_InvalidValue()
        {
            string testvalue = "cd";
            var result = SalesTaxes.Item.CalculateIsImport(testvalue);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CalculateSalesTax_CorrectAmount()
        {
            decimal testvalue = Convert.ToDecimal(14.99);
            decimal expected = Convert.ToDecimal(1.5);
            var result = SalesTaxes.Item.CalculateSalesTax(testvalue);
            Assert.AreEqual(expected,result);
        }

        [TestMethod]
        public void CalculateImportTax_CorrectAmount()
        {
            decimal testvalue = Convert.ToDecimal(11.25);
            decimal expected = Convert.ToDecimal(.6);
            var result = SalesTaxes.Item.CalculateImportTax(testvalue);
            Assert.AreEqual(expected, result);
        }

    }
}

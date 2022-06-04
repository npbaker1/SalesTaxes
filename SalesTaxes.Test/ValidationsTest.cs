
namespace SalesTaxes.Test
{
    //Unit Testing for the Validations Class
    [TestClass]
    public class ValidationsTest
    {
        [TestMethod]
        public void IsPositiveInteger_ValidValue()
        {
            string testvalue = "5";
            var result = SalesTaxes.Validations.IsPositiveInteger(testvalue);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsPositiveInteger_InvalidValue()
        {
            string testvalue = "-5";
            var result = SalesTaxes.Validations.IsPositiveInteger(testvalue);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidMoney_ValidValue()
        {
            string testvalue = "12.49";
            var result = SalesTaxes.Validations.IsValidMoney(testvalue);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValidMoney_InvalidValue()
        {
            string testvalue = "-12.49";
            var result = SalesTaxes.Validations.IsValidMoney(testvalue);
            Assert.IsFalse(result);
        }
    }
}
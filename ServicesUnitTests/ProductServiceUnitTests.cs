using Services;
using Xunit;

namespace ServicesUnitTests
{
    public class ProductServiceUnitTests
    {
        [Fact]
        public void GetProducts_FirstItemName_IsIsabelle()
        {
            // Arrange
            string expected = "Isabelle's Homemade Marmelade";
            ProductService prodServ = new();

            // Act
            IEnumerable<DataObjects.Product> products = prodServ.GetProducts();

            // Assert
            Assert.Equal(expected, products.First().Name);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1.5)]
        public void GetProducts_FirstItemPrice_IsAbove(decimal lesserValue)
        {
            // Arrange
            decimal expected = lesserValue;
            ProductService prodServ = new();

            // Act
            IEnumerable<DataObjects.Product> products = prodServ.GetProducts();

            // Assert
            Assert.True(lesserValue < products.First().Price);
        }
    }
}

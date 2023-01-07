namespace OrderNow.Tests.Services
{
    public class ProductsServicesTest
    {
        private readonly ProductsServices _sut;
        private readonly Mock<IProductsRepository> _productsRepository = new Mock<IProductsRepository>();

        public ProductsServicesTest()
        {
            _sut = new ProductsServices(_productsRepository.Object);
        }

        [Theory]
        [InlineData(300.0, 4, 4, 2, 600D)]
        [InlineData(300.0, 9, 4, 2, 1500D)]
        [InlineData(300.0, 10, 10, 7, 2100D)]
        [InlineData(300.0, 20, 10, 7, 4200D)]
        [InlineData(100.0, 34, 10, 7, 2500D)]
        [InlineData(250.0, 4, 3, 2, 750D)]
        [InlineData(320.0, 2, 2, 1, 320D)]
        [InlineData(100.0, 13, 2, 1, 700D)]
        [InlineData(100.0, 1, 2, 1, 100D)]
        public void CalculateDiscountsShouldReturnTrue(double precio, int cantidad, int lleva, int paga, double expected)
        {
           
            var result = _sut.CalculateDiscounts(precio, cantidad, lleva, paga);

            result.Should().Be(expected);
        }
    }
}
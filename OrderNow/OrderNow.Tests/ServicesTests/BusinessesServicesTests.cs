namespace OrderNow.Tests.ServicesTests
{
    public class BusinessesServicesTests
    {

        private readonly BusinessesServices _sut;
        private readonly Mock<DataContext> _dataContextMock;
        private readonly Mock<IBusinessesRepository> _businessRepoMock =
            new Mock<IBusinessesRepository>();

        public BusinessesServicesTests()
        {
            _sut = new BusinessesServices(_businessRepoMock.Object, _dataContextMock.Object);
        }

        [Theory]
        [InlineData("pizzeria-popular-rc", true)]
        public void BusinessExists_ShouldReturnTrue_WhenBusinessExists(string URL, bool expected)
        {

            var business = new Businesses()
            {
                ContractURL = "pizzeria-popular-rc"
            };

            _businessRepoMock.Setup(x => x.Exists(business.ContractURL))
                .Returns(true);


            var result = _sut.Exists(URL);

            result.Should().Be(expected);

        }


        [Fact]
        public void ValidateBusiness() { }
        [Fact]
        public void PaymentForm() { }



    }
}

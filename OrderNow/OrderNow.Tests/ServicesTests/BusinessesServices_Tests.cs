using AutoFixture;
using Moq;
using OrderNow.Blazor.Data;

namespace OrderNow.Tests.Services
{
    public class BusinessesServices_Tests
    {
        private readonly BusinessesServices _sut;
        private readonly Mock<IBusinessesRepository> _businessRepoMock = new();
        private readonly Mock<IUsersRepository> _userRepository = new();
        private Fixture fixture = new Fixture();

        public BusinessesServices_Tests()
        {
            _sut = new BusinessesServices(_businessRepoMock.Object, _userRepository.Object);
        }

        [Theory]
        [InlineData("pizzeria-popular-rc", true)]
        [InlineData("pizzeria-popular-ric", false)]
        public async Task BusinessExists_ShouldReturnTrue_WhenBusinessExists(string URL, bool expected)
        {
            var business = new Business()
            {
                CUIT = "20307821959",
                IsFrachise = true,
                IsValidated = false,
                LegalName = "Pizzerias Populares S.R.L",
                Name = "Pizzeria Popular Río Ceballos",
                ContractURL = "pizzeria-popular-rc"
            };
            _businessRepoMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(business);

            var result = _sut.Exists(URL);

            result.Should().Be(expected);
        }

        [Fact]
        public void PaymentForm()
        { }

        [Fact]
        public void GetTopCustomersByBusiness_ShouldReturn10Customers()
        { }

        [Fact]
        public void GetTopProductsByBusiness_ShouldReturn10Products()
        { }

        //[Fact]
        //public void ReturnDatosPortada_BeTrue()
        //{
        //}

        [Fact]
        public void ShouldApproveComerce_WhenDocumentationIsComplete()
        {
            //AprobarComercio
            //Vencimiento de Aprobacion
            //Job para finalizar estados activos
            //Alta de usuario
            //Alta Cuenta Comercial
            //Alta Producto
        }

        [Fact]
        public void ValidateBusiness()
        { }
    }
}
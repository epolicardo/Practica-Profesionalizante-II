using OrderNow.Common.Services;

namespace OrderNow.Tests.Services
{
    public class OrdersServices_Tests
    {
        private readonly OrdersServices _sut;

        private readonly Mock<IOrdersRepository> _ordersRepositoryMock = new Mock<IOrdersRepository>();
        private readonly Mock<IUsersServices> _usersServiceMock = new Mock<IUsersServices>();
        private readonly Mock<IProductsRepository> _productRepositoryMock = new();
        private readonly Mock<IBusinessesRepository> _businessRepositoryMock = new();
        private readonly Mock<IUsersRepository> _usersRepositoryMock = new();

        private readonly Mock<IDateTimeProvider> _mockDateTimeProvider = new Mock<IDateTimeProvider>();

        public OrdersServices_Tests()
        {
            _sut = new OrdersServices(_ordersRepositoryMock.Object, _usersRepositoryMock.Object, _businessRepositoryMock.Object, _productRepositoryMock.Object)
            {
            };
            _mockDateTimeProvider.Setup(x => x.UtcNow).Returns(new DateTime(2021, 07, 20));
        }

        [Fact]
        public void CreateOrder_ShouldReturnANewOrder_WhenOrderIsCreatedAsync()
        {
            Business business = new Business
            {
                Id = Guid.NewGuid(),
                Address = It.IsAny<Address>(),
                ContractURL = It.IsAny<string>(),
            };

            Users users = new Users
            {
                Email = It.IsAny<string>(),
                Id = It.IsAny<string>(),
            };
            _ordersRepositoryMock.Setup(x => x.CreateOrderAsync(users.Id, business.Id)).ReturnsAsync(new Order());
            var res = _sut.CreateOrderAsync(business.Id, users.Email);

            res.Should().BeOfType<Order>();
        }

        [Fact]
        public void GetPendingOrdersByBusiness_ShouldReturnData_WhenBusinessAndOrderExists()
        { }

        [Fact]
        public void AddProductToOrderAsync_ShouldReturnOrderId_WhenOrderWasCreated()
        {
        }

        [Fact]
        public void GetTopCustomersByBusiness_ShouldReturnData_WhenBusinessExists()
        { }

        [Fact]
        public void GetTopProductsByBusiness_ShouldReturnData_WhenBusinessExists()
        { }

        [Fact]
        public void GetLoggedUser_ShouldReturnUserData_WhenUserExistsANdIsLogged()
        { }

        [Fact]
        public void SwitchProfile_ShouldShowAButtonToSwitchProfiles_Always()
        { }

        [Fact]
        public void GetOrderById_ShouldReturnAnOrder_WhenOrderExists()
        { }
    }
}
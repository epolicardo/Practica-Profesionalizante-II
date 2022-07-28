using OrderNow.API.Data;

namespace OrderNow.Tests.Services
{
    public class OrdersServices_Tests
    {
        private readonly OrdersServices _sut;

        private readonly Mock<DataContext> _dataContextMock = new Mock<DataContext>();
        private readonly Mock<IOrdersRepository> _ordersRepositoryMock = new Mock<IOrdersRepository>();

        


        public OrdersServices_Tests(
          )
        {
            _sut = new OrdersServices(_ordersRepositoryMock.Object, _dataContextMock.Object);
        }

        //public OrdersServicesTests(Mock<BusinessesServices> _businessServicesMock, Mock<UsersServices> _userServicesMock)
        //{
        //    _sut = new OrdersServices(_dataContextMock.Object);
        //    _businessServicesMock = _businessServicesMock;
        //    _userServicesMock = userServicesMock;

        //}

        [Fact]
        public void CreateOrder_ShouldCreateANewOrder()
        {
            var mock = new Mock<DateTimeProvider>();
            mock.Setup(x => x.UtcNow).Returns(new DateTime(2021, 07, 20));

            Businesses business = new Businesses()
            {
                ContractURL = "La-pizzeria",
                IsValidated = true,
                ValidationTime = mock.Object.UtcNow
            };

            Users users = new Users()
            {
                Email = "emilianopolicardo@gmail.com"
            };

            var res = _sut.CreateOrder(business, users);

            res.Should().BeOfType<Orders>();
        }

        [Fact]
        public void GetPendingOrdersByBusiness_ShouldReturnData_WhenBusinessAndOrderExists()
        { }

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
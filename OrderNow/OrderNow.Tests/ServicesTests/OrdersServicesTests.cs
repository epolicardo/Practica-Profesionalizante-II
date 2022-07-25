namespace OrderNow.Tests.ServicesTests
{
    public class OrdersServicesTests
    {
        private readonly Mock<DataContext> _dataContextMock = new Mock<DataContext>();
        private readonly Mock<BusinessesServices> _businessServicesMock = new Mock<BusinessesServices>();
        private readonly Mock<UsersServices> _userServicesMock = new Mock<UsersServices>();
        private readonly Mock<OrdersRepository> _ordersRepositoryMock = new Mock<OrdersRepository>();

        private readonly OrdersServices _sut;

        public OrdersServicesTests(Mock<DataContext> dataContextMock, Mock<BusinessesServices> businessServicesMock, Mock<UsersServices> userServicesMock)
        {
            _sut = new OrdersServices(_ordersRepositoryMock.Object, _dataContextMock.Object);
            _dataContextMock = dataContextMock;
            _businessServicesMock = businessServicesMock;
            _userServicesMock = userServicesMock;
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
            Businesses business = new Businesses()
            {
                ContractURL = "La-pizzeria",
                IsValidated = true
            };

            Users users = new Users()
            {
                Email = "emilianopolicardo@gmail.com"
            };

            var res = _sut.CreateOrder(business, users);

            res.Should().BeOfType<Orders>();
        }

        [Fact]
        public void GetPendingOrdersByBusiness_ShouldReturnData_WhenBusinessAndOrderExists() { }

        [Fact]
        public void GetTopCustomersByBusiness_ShouldReturnData_WhenBusinessExists() { }

        [Fact]
        public void GetTopProductsByBusiness_ShouldReturnData_WhenBusinessExists() { }

        [Fact]
        public void GetLoggedUser_ShouldReturnUserData_WhenUserExistsANdIsLogged() { }

        [Fact]
        public void SwitchProfile_ShouldShowAButtonToSwitchProfiles_Always() { }

        [Fact]
        public void GetOrderById_ShouldReturnAnOrder_WhenOrderExists() { }
    }
}
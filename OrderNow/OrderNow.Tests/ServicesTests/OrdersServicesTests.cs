


namespace OrderNow.Tests.ServicesTests
{
    public class OrdersServicesTests
    {
        private readonly DataContext _dataContext = new DataContext();
        private readonly OrdersServices _sut;
        private readonly Mock<IGenericRepository<Businesses>> _businessRepositoryMock = new Mock<IGenericRepository<Businesses>>();
        private readonly Mock<IGenericRepository<Users>> _userRepositoryMock = new Mock<IGenericRepository<Users>>();
        private readonly Mock<IGenericRepository<Orders>> _orderRepositoryMock = new Mock<IGenericRepository<Orders>>();


        public OrdersServicesTests()
        {
            _sut = new OrdersServices(_dataContext, _orderRepositoryMock.Object);
        }

        [Fact]
        public void CreateOrder_ShouldCreateANewOrder()
        {


            //var business = _dataContext.Businesses.
            //var user = _userRepositoryMock.Object;
            //var result = _sut.CreateOrder(business, user);
            //result.Should().BeTrue();
        }

    }
}

using Data.Entities;
using FluentAssertions;
using Moq;
using OrderNow.API.Controllers.Generic;
using OrderNow.API.Services;
using OrderNow.Data;
using Xunit;

namespace OrderNow.Tests.ServicesTests
{
    public class OrdersServicesTests
    {
        private readonly DataContext _dataContext = new DataContext();
        private readonly OrdersServices _sut; 
        private readonly Mock<IGenericRepository<Businesses>> _businessRepositoryMock = new Mock<IGenericRepository<Businesses>>();
        private readonly Mock<IGenericRepository<User>> _userRepositoryMock = new Mock<IGenericRepository<User>>();
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

using Data.Entities;
using FluentAssertions;
using Moq;
using OrderNow.API.Services;
using OrderNow.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OrderNow.Tests.ServicesTests
{
    public class BusinessesServicesTests
    {
        private readonly Mock<DataContext> _dataContext = new Mock<DataContext>();
        public BusinessesServicesTests()
        {

        }

        [Theory]
        [InlineData("/pizzeria-popular-rc", true)]
        public void BusinessExists_ShouldReturnTrue_WhenBusinessExists(string URL, bool expected)
        {

            BusinessesServices _sut = new BusinessesServices(_dataContext.Object);
            var result = _sut.BusinessesExists(URL);

            result.Should().Be(expected);

        }


        [Fact]
        public void ValidateBusiness() { }
        [Fact]
        public void PaymentForm() { }
  


    }
}

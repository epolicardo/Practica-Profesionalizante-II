using Data.Entities;
using Services;
using Xunit;

namespace OrderNow.Tests.ServicesTests
{
    public class UsersServicesTest
    {

        private readonly UsersServices _sut;

        public UsersServicesTest()
        {
        }

        [Fact]
        public void AssingAFavoriteBusinessToAUser()
        {

            UsersServices _sut = new UsersServices();
            var user = new User();
            var business = new Businesses();
            //Act
            var result = _sut.AssignFavoriteBusinessToUser(user, business);

            //Assert
            Assert.True(result);

        }

        [Fact]
        public void AssingAFavoriteProductToAUser()
        {

            UsersServices _sut = new UsersServices();
            var user = new User();
            var product = new Products();
            //Act
            var result = _sut.AssignFavoriteProductsToUsers(user, product);

            //Assert
            Assert.True(result);

        }


    }
}

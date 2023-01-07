
using Microsoft.EntityFrameworkCore;
using OrderNow.Blazor.Data;

namespace OrderNow.Tests.RepositoriesTest
{
    public class UsersShould
    {

        private readonly UsersRepository _sut;
        private readonly DataContext _dataContext;

   
        //[Fact]
        //public async Task AddRelationWithBusiness()
        //{
        //    Businesses business = new Businesses()
        //    {
        //        Id = It.IsAny<Guid>(),
        //        Name = It.IsAny<string>(),
        //        Created = It.IsAny<DateTime>(),
        //    };

        //    Users user = new Users()
        //    {
        //        Id = It.IsAny<string>(),
        //        UserName = It.IsAny<string>(),
        //    };
        //    await _sut.AddRelationUserBusiness(user, business);
        //}

        [Fact]
        public void GetByIdAsync_Returns_Product()
        {
            //Setup DbContext and DbSet mock  
            var dbContextMock = new Mock<DataContext>();
            var dbSetMock = new Mock<DbSet<Users>>();
            dbSetMock.Setup(s => s.FindAsync(It.IsAny<string>())).ReturnsAsync((new Users()));
            dbContextMock.Setup(s => s.Set<Users>()).Returns(dbSetMock.Object);

            //Execute method of SUT (ProductsRepository)  
            var usersRepository = new UsersRepository(dbContextMock.Object);
            var user = usersRepository.GetByIdAsync(Guid.NewGuid()).Result;

            //Assert  
            Assert.NotNull(user);
            Assert.IsAssignableFrom<Users>(user);
        }
    }
}

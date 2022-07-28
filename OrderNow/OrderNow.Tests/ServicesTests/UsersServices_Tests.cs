namespace OrderNow.Tests.Services
{
    public class UsersServices_Tests
    {
        private readonly UsersServices _sut;
        private readonly Mock<IUsersRepository> _userRepositoryMock = new Mock<IUsersRepository>();
        private readonly Mock<UserManager<Users>> _userManagerMock = new();

        public UsersServices_Tests()
        {
            _sut = new UsersServices(_userRepositoryMock.Object,_userManagerMock.Object);
        }

        [Fact]
        public void AssingAFavoriteBusinessToAUser()
        {
            var user = new Users();
            var business = new Businesses();
            //Act
            var result = _sut.AssignFavoriteBusinessToUser(user, business);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void AssingAFavoriteProductToAUser()
        {
            // UsersServices _sut = new UsersServices();
            var user = new Users();
            var product = new Products();
            //Act
            var result = _sut.AssignFavoriteProductsToUsers(user, product);

            //Assert
            Assert.True(result);
        }

        //Agregar producto a orden

        /// <summary>
        /// CU -
        /// </summary>

        [Fact]
        public void AddProductToOrder_ShouldAddAProductToAnOrder_WhenProductAndOrderExists()
        {
            //UsersServices _sut = new UsersServices();

            var user = new Users();
            var product = new Products();
            var order = new Orders();
            //Act
            var result = _sut.AddProductToOrder(user, order, product);

            //Assert
            Assert.True(result);
        }

        //Editar producto en orden
        //Finalizar pedido (Se completa la orden, se envia al comercio y se guardan en mis compras)

        [Fact]
        public void ValidateUser()
        {
            //https://docs.microsoft.com/en-us/aspnet/mvc/overview/security/create-an-aspnet-mvc-5-web-app-with-email-confirmation-and-password-reset
        }

        //[Fact]
        //public void ValidateBusiness() { }
        //[Fact]
        //public void ValidateBusiness() { }
    }
}
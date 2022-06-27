using Controllers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderNow.Tests
{
    public class AddressesControllerTests
    {

        private readonly AddressesController _sut;
        private readonly Mock<IGenericRepository<Addresses>> _addressesRepositoryMock = new Mock<IGenericRepository<Addresses>>();
        private readonly Mock<IConfigurationHelper> _configMock = new Mock<IConfigurationHelper>();

        public AddressesControllerTests()
        {
            _sut = new AddressesController(_addressesRepositoryMock.Object, _configMock.Object);
        }


        [Fact]
        public async Task GetByIdAsync_ShouldReturnAnAddress_WhenTheAddressExists()
        {

            //a

            var addressId = Guid.NewGuid();
            var addressStreet = "Colon";
            var addressDto = new Addresses
            {
                Id = addressId,
                Street = addressStreet
            };



            _addressesRepositoryMock.Setup(x => x.GetByIdAsync(addressId.ToString()))
                .ReturnsAsync(addressDto);
            //a

            var result = await _sut.GetByIdAsync(addressId);

            //a

            Assert.Equal(addressId.ToString(), result.Id.ToString());
            Assert.Equal(addressStreet, result.Street);

        }
        [Fact]
        public async Task GetByIdAsync_ShouldReturnNotFound_WhenAddressDoesNotExists()
        {


            //Arrange


            _addressesRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<string>()))
                .ReturnsAsync(() => null);

            //Act
            var result = await _sut.GetByIdAsync(Guid.NewGuid());


            //Assert
            Assert.Null(result);

        }


        [Fact]
        public void GetListAsync_ShouldReturnAllAddresses_WhenTheAddressesExists()
        {

            //Arrange
            List<Addresses> addressList = new List<Addresses>();
            addressList.Add(new Addresses
            {
                City = new Cities
                {
                    Name = "Rio Ceballos"
                },
                Street = "Diaguitas"
            });

            _addressesRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(addressList);

            //Act
            var result = _sut.GetListAsync();

            //Assert
            Assert.Equal(addressList, result.Result);

        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderNow.IntegrationTests
{
    public class PostControllerTest : IntegrationTest
    {
        [Fact]
        public async Task GettAll_WithoutAnyCustomers_ReturnEmpryResponse()
        {
            var business = await sut.GetBusinessIfActive("pizzeria-popular-rc");
        }
    }
}
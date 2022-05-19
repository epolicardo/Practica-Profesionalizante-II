
namespace Controllers
{
    [Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly IConfigurationHelper configHelper;
        private readonly IGenericRepository<Customers> customerRepository;

        public CustomersController(IConfigurationHelper configHelper, IGenericRepository<Customers> customerRepository)
        {
            this.configHelper = configHelper;
            this.customerRepository = customerRepository;
        }

        /// <summary>
        /// This method returns all the customers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetList")]
        public IActionResult GetList()
        {
            var customers = this.customerRepository.GetAll();
            return this.Ok(customers);
        }

        //Metodo encargado de retornar un customer
        [HttpGet]
        [Route("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {

            var customer = await this.customerRepository.GetByIdAsync(id);
            if (customer == null)
            {
                return this.NotFound();
            }
            return this.Ok(customer);
        }


    }



}


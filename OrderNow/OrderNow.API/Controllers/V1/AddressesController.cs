namespace Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AddressesController : ControllerBase
    {
        private readonly IConfigurationHelper configHelper;

        public AddressesController(IConfigurationHelper configHelper)
        {
            this.configHelper = configHelper;
        }

    }
}

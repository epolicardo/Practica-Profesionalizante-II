namespace Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class GenericController : ControllerBase
    {
        private readonly IConfiguration configuration;

        [HttpGet]
        [Route("UseMockup")]
        public bool UseMockup(string Servicio)
        {
            if (configuration[Servicio] == configuration["AmbienteMockup"] && configuration["AmbienteMockup"] == "true")
                return true;

            return false;
        }
    }
}
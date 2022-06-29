namespace Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize]
    public class MessagesController : ControllerBase
    {
        //TODO: Controlador encargado de mostrar mensajes guardados en base de datos, parametrizables y genericos.
    }
}
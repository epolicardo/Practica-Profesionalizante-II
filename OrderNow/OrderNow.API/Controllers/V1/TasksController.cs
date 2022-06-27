using Controllers;

namespace OrderNow.API.Controllers.V1
{
    public class TasksController : Controller
    {

        [HttpGet]
        [Route("CreateJob")]
        public void CreateJob()
        {
            BackgroundJob.Enqueue(() => Console.WriteLine("Ejecutar algo luego de la creacion de un usuario"));

            Log.Information("Se ha creado el job");

            BackgroundJob.Enqueue<IEmailSender>(x =>
            x.SendEmail(
               "emilianopolicardo@gmail.com",
               "hangfire@example.com",
               "Hola Mundo Loco",
               "Hola mundo"));

        }
    }
}

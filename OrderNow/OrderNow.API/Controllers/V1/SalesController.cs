namespace Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize]
    [Route("api/v{version:apiVersion}/[controller]")]

    public class SalesController : ControllerBase
    {
        private readonly DataContext dataContext;
        private readonly IGenericRepository<Sales> genericRepository;
        private readonly IConfigurationHelper configHelper;
        public SalesController(IConfigurationHelper configurationHelper, DataContext dataContext, IGenericRepository<Sales> genericRepository)
        {
            this.configHelper = configurationHelper;
            this.dataContext = dataContext;
            this.genericRepository = genericRepository;
        }

        public IConfigurationHelper ConfigurationHelper { get; }


        [HttpPost]
        [Route("CreateAsync")]
        public int CreateAsync()
        {
            //if (configHelper.UseMockup("Ventas"))
            //{
            //    return 1;
            //}
            //else
            //{
            //    Transaccion transaccion = new Transaccion
            //    {
            //        Tipo = TipoTransaccion.Venta,
            //        FechaAlta = DateTime.Today,
            //        FechaRealizado = DateTime.Today,
            //        //Obtener la cuenta mediante metodo get
            //        Cuenta = new Cuenta() { },
            //        Descripcion = "Realizamos una venta"

            //    };
            //}
                return 0;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using OrderNow.API.Services;

namespace Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize]

    public class OrdersController : ControllerBase
    {
        private readonly IGenericRepository<Orders> _genericRepository;
        private readonly DataContext _context;

        public OrdersController(IGenericRepository<Orders> genericRepository, DataContext dataContext)
        {
            this._genericRepository = genericRepository;
            _context = dataContext;
        }

        [HttpGet]
        public void AddProductToOrder()
        {

        }
    }
}
using Controllers;
using OrderNow.API.Data;

namespace Services
{
    public class BusinessesServices : GenericServices<Businesses>, IBusinessesServices
    {
        private readonly IBusinessesRepository _businessesRepository;
        private readonly DataContext _dataContext;

        public BusinessesServices(IBusinessesRepository businessesRepository, DataContext dataContext) : base(businessesRepository)
        {
            _businessesRepository = businessesRepository;
            _dataContext = dataContext;
        }

        public Task<Businesses> GetBusinessIfActive(string url)
        {
            return _businessesRepository.FindByConditionAsync(x => x.ContractURL == url);
        }

        public IEnumerable<Products> ProductsByBusiness(string url)
        {
            throw new NotImplementedException();
        }

        public bool SetAsFavorite(string url, Guid userId)
        {
            var business = _businessesRepository.FindByConditionAsync(x => x.ContractURL.Equals(url));

            if (business.Result != null)
            {
                var user = _dataContext.Users.FirstOrDefault(x => x.Id == userId.ToString());

                if (user != null)
                {
                    FavoriteBusiness favoriteBusiness = new FavoriteBusiness();
                    favoriteBusiness.Business = business.Result;
                    favoriteBusiness.Users = (Users)user;

                    var res = _dataContext.FavoriteBusinessesByUser.Add(favoriteBusiness);

                    _dataContext.SaveChangesAsync();
                }
                return true;
            }
            return false;
        }

        public IEnumerable<Products> SugestedProductsByBusiness(string url)
        {
            //var products = _businessesRepository.Products.Where(x => x.Business.ContractURL == url).Where(p => p.IsSuggested == true).ToList();

            //return products;
            return null;
        }

        public bool Exists(string url)
        {
            return _businessesRepository.Exists(url);
        }

        //public async Task<string> GetDashboard(string url)
        //{
        //    /* Debo obtener la siguiente info:
        //     * Listado de Ordenes en curso
        //     * Bloque de estadisticas
        //     * Top Clientes
        //    // * Top Productos*/
        //    //var b = await _businessesRepository.FindByConditionAsync(x => x.ContractURL == url);
          

        //    //return bd;
        //}
    }
}
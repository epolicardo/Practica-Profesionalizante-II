using OrderNow.Blazor.Data;
using System.Security.Policy;

namespace Services
{
    public class BusinessesServices : GenericServices<Businesses>, IBusinessesServices
    {
        private readonly IBusinessesRepository _businessesRepository;
        private readonly IUsersRepository _usersRepository;

        public BusinessesServices(IBusinessesRepository businessesRepository, IUsersRepository usersRepository) : base(businessesRepository)
        {
            _businessesRepository = businessesRepository;
            _usersRepository = usersRepository;
        }

        public async Task<Businesses> GetBusinessIfActive(string url)
        {
            return await _businessesRepository.GetByURL(url);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="url"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<bool> SetAsFavorite(string url, Guid userId)
        {
            var business = await _businessesRepository.FindByConditionAsync(x => x.ContractURL.Equals(url));

            if (business != null)
            {
                var user = await _usersRepository.GetByIdAsync(userId);

                if (user != null)
                {
                    UsersBusinesses favoriteBusiness = new UsersBusinesses();
                    favoriteBusiness.Business = business;
                    favoriteBusiness.Users = user;
                    //var res = await _dataContext.UsersBusinesses.AddAsync(favoriteBusiness);
                    //await _dataContext.SaveChangesAsync();
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Este metodo valida si un comercio existe.
        /// </summary>
        /// <param name="url">La URL del comercio a validar</param>
        /// <returns>True si el comercio existe</returns>
        public async Task<bool> Exists(string url)
        {
            var t = await _businessesRepository.ExistsAsync(url);
            return t;
        }

        public async Task<List<Businesses>> GetSuggestedBusinessesAsync()
        {
            return await _businessesRepository.GetSuggestedBusinessesAsync();
        }
    }
}
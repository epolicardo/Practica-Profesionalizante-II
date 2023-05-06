using OrderNow.Blazor.Data;
using System.Security.Policy;

namespace Services
{
    public class BusinessesServices : GenericServices<Business>, IBusinessesServices
    {
        private readonly IBusinessesRepository _businessesRepository;
        private readonly IUsersRepository _usersRepository;

        public BusinessesServices(IBusinessesRepository businessesRepository, IUsersRepository usersRepository) : base(businessesRepository)
        {
            _businessesRepository = businessesRepository;
            _usersRepository = usersRepository;
        }

        public async Task<Business> GetBusinessIfActive(string url)
        {
            return await _businessesRepository.GetByURL(url);
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

        public async Task<List<Business>> GetSuggestedBusinessesAsync()
        {
            return await _businessesRepository.GetSuggestedBusinessesAsync();
        }
    }
}
using Controllers;

namespace OrderNow.API.Services
{
    public class BusinessesServices
    {

        private readonly DataContext _context;

        public BusinessesServices(DataContext context)
        {
            _context = context;
        }

        public bool BusinessesExists(string URL)
        {
            Businesses business = _context.Businesses.FirstOrDefault(x => x.ContractURL == URL);
            if (business == null)
                return false;
            return true;

        }


        public void ValidateBusiness() { }
    }
}

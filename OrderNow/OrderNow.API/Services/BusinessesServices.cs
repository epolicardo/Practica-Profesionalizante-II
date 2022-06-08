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
            Businesses? business = _context.Businesses.FirstOrDefault(x => x.ContractURL == URL);
            if (business == null)
                return false;
            return true;

        }


        public Businesses BusinessPortal(string URL)
        {
            Businesses? business = _context.Businesses.FirstOrDefault(x => x.ContractURL == URL);

            if (business.IsValidated && business.ValidationExpires > DateTime.Today)
            {
            return business;

            }
            return null;

        }

        /// <summary>
        /// Returns a list of products, grouped by Family, related to a particular Business
        /// </summary>
        /// <param name="URL"></param>
        /// <returns></returns>
        public List<Products> SugestedProductsByBusiness(string URL)
        {

            var products = _context.Products.Where(x => x.Business.ContractURL == URL).Where(p=>p.IsSuggested==true).ToList();
         
            return products;

        }


        public List<Products> ProductsByBusinessByCategory(string URL, Categories Category)
        {

            var products = _context.Products.Where(x => x.Business.ContractURL == URL).Where(p => p.Category.Name == Category.Name).ToList();

            return products;

        }





        public void ValidateBusiness() { }
    }
}

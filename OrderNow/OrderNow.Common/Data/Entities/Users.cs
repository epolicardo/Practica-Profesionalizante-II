

using Microsoft.AspNetCore.Identity;

namespace OrderNow.Common.Data.Entities
{
    public class Users : IdentityUser
    {
        public UserType? UserType { get; set; }
        public Person? Person { get; set; }
        public IList<Business>? FavoriteBusiness { get; set; }
        public IList<Product>? FavoriteProducts { get; set; }
        public Business? AssosiatedBusiness{ get; set; }
        [NotMapped]
        public string Password { get; set; }
    }

    public enum UserType
    {
        Administrator,
        Manager,
        Colaborator,
        User

    }
}
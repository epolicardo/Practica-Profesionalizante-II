using Microsoft.AspNetCore.Identity;

namespace OrderNow.API.Data.Entities
{
    public class Users : IdentityUser
    {
        public UserType UserType { get; set; }
        public List<Businesses> Business { get; set; }


    }

    public enum UserType
    {
        Administrator,
        Manager,
        Colaborator,
        User
    }
}

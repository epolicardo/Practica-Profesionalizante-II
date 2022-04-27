using Microsoft.AspNetCore.Identity;

namespace OrderNow.API.Data.Entities
{
    public class Users : IdentityUser
    {
        [Display(Name = "Correo Electrónico")]
        public string Email { get; set; }
    }
}

namespace Data.Entities
{
    public class Users : IdentityUser
    {
        public UserType? UserType { get; set; }
        public People? person { get; set; }
        public List<Businesses>? FavoriteBusiness { get; set; }
        public List<Products>? FavoriteProducts { get; set; }
        public string Password { get; set; }




    }

    public enum UserType
    {
        Administrator,
        Manager,
        Colaborator
    }
}

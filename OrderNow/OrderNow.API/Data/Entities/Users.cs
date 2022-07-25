namespace Data.Entities
{
    public class Users : IdentityUser
    {
        public UserType? UserType { get; set; }
        public People? person { get; set; }
        public IList<Businesses>? FavoriteBusiness { get; set; }
        public IList<Products>? FavoriteProducts { get; set; }
        public string Password { get; set; }
    }

    public enum UserType
    {
        Administrator,
        Manager,
        Colaborator
    }
}
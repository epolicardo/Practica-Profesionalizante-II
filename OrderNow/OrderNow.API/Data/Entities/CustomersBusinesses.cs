namespace Data.Entities
{
    public class UsersBusinesses : EntityBase
    {
        public Users Users { get; set; }
        public Businesses Business { get; set; }
    }

    public class FavoriteProducts : EntityBase
    {
        public Products Product { get; set; }
        public Users Users { get; set; }
    }

    public class FavoriteBusiness : EntityBase
    {
        public Businesses Business { get; set; }
        public Users Users { get; set; }
    }
}
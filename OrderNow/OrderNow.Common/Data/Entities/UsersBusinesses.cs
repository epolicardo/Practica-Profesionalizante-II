namespace OrderNow.Common.Data.Entities
{
    public class UsersBusinesses : EntityBase
    {
        public Users Users { get; set; }
        public Businesses Business { get; set; }
        public DateTime LastVisit { get; set; }
        public bool IsFavorite { get; set; }
    }

    public class FavoriteProducts : EntityBase
    {
        public Products Product { get; set; }
        public Users Users { get; set; }
        public DateTime Added { get; set; } = DateTime.Now;
    }
}
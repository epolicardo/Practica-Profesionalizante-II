namespace OrderNow.Common.Data.Entities
{
    public class UserBusiness : EntityBase
    {
        public Users Users { get; set; }
        public Business Business { get; set; }
        public DateTime LastVisit { get; set; }
        public bool IsFavorite { get; set; }
    }

    public class FavoriteProducts : EntityBase
    {
        public Product Product { get; set; }
        public Users Users { get; set; }
        public DateTime Added { get; set; } = DateTime.Now;
    }
}
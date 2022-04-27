namespace OrderNow.API.Data.Entities
{
    public class EntityBase
    {
        public int Id { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastModified { get; set; } = DateTime.Now;
    }
}
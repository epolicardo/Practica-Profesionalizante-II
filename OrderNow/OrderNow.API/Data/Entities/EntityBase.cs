namespace OrderNow.Data.Entities
{
    public class EntityBase
    {
        public string Id { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastModified { get; set; } = DateTime.Now;
    }
}
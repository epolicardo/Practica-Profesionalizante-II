namespace OrderNow.Common.Data.Entities
{
    public class EntityBase
    {


        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime Created { get; set; } 
        public DateTime LastModified { get; set; } = DateTime.UtcNow;

    }
}
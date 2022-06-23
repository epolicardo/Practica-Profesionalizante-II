using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class EntityBase
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastModified { get; set; } = DateTime.Now;
    }
}
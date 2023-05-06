namespace OrderNow.Common.Data.Entities
{
    public class Category : EntityBase
    {
        [Display(Name = "Nombre")]
        public string? Name { get; set; }
    }
}
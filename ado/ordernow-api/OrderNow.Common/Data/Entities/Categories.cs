namespace OrderNow.Common.Data.Entities
{
    public class Categories : EntityBase
    {
        [Display(Name = "Nombre")]
        public string? Name { get; set; }
    }
}
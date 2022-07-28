namespace OrderNow.Common.Data.Entities
{
    public class ProductOptions : EntityBase
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public ProductOption? Options { get; set; }
    }

    public class ProductOption
    {
        public int Id { get; set; }
        public string Option { get; set; }
        public bool Aplicable { get; set; }
    }
}
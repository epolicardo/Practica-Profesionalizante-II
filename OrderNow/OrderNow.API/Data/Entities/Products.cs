namespace OrderNow.API.Data
{
    public class Products : EntityBase
    {
     
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ProductOptions> OptionsList { get; set; }

    }
}

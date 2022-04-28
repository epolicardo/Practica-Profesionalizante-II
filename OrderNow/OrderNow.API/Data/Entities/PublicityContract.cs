namespace OrderNow.API.Data.Entities
{
    public class PublicityContract : EntityBase
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime Aquired { get; set; }
        public DateTime Expire { get; set; }
        public int Credits { get; set; }

    }
}

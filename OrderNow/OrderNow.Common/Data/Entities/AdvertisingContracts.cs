namespace OrderNow.Common.Data.Entities
{
    public class AdvertisingContracts : EntityBase
    {
        public string Name { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public DateTime Aquired { get; set; }
        public DateTime Expire { get; set; }
        public int Credits { get; set; }
        public Businesses Business { get; set; }
    }
}
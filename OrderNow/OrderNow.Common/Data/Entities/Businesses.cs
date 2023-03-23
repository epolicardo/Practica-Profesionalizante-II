namespace OrderNow.Common.Data.Entities
{
    public class Businesses : EntityBase
    {
        public string Name { get; set; }
        public Addresses? Address { get; set; }
        public string? URLIconImage { get; set; }
        public string? URLRegularImage { get; set; }
        public string ContractURL { get; set; } // /pizzeria-popular
        public string? PromoMessage { get; set; }
        public string? Email { get; set; }
        public bool IsFrachise { get; set; } = false;
        public string CUIT { get; set; }
        public string LegalName { get; set; }
        public string Phone { get; set; }

        [NotMapped]
        public List<PaymentType>? PaymentsType { get; set; }

        public bool IsValidated { get; set; } = false;
        public DateTime ValidationTime { get; set; }
        public DateTime ValidationExpires { get; set; }
        public float Score { get; set; }
        public UInt64 Qualification { get; set; }
        public bool IsPromoted { get; set; }
        public DateTime PromotionStart { get; set; }
        public DateTime PromotionEnd { get; set; }
        public int PromotionCredits { get; set; }
    }
}
namespace Data.Entities
{
    public class Businesses : EntityBase
    {

        public string Name { get; set; }
        public Addresses? Address { get; set; }
        public string? URLIconImage { get; set; }
        public string? URLRegularImage { get; set; }
        public string ContractURL { get; set; } // /pizzeria-popular
        public string? PromoMessage { get; set; }
        public bool IsFrachise { get; set; } = false;
        public string CUIT { get; set; }
        public string LegalName { get; set; }
        public string Phone { get; set; }
        [NotMapped]
        public PaymentType[]? PaymentsType { get; set; }
        public bool IsValidated { get; set; } = false;
        public DateTime ValidationTime { get; set; }
        public DateTime ValidationExpires { get; set; }
        public float Score { get; set; }
        public UInt64 Qualification { get; set; }
        //public List<User> CustomersList { get; set; }



        public class Image : EntityBase
        {

            public string Name { get; set; }
            public string URL { get; set; }
            public ImageType Type { get; set; }
        }

        public enum ImageType
        {
            Icon,
            Regular
        }
    }
}

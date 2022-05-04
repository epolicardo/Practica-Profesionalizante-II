﻿namespace OrderNow.Data.Entities
{
    public class PaymentMethods : EntityBase
    {

        public string Name { get; set; }
        public PaymentType Type { get; set; }
        public string? CardNumber { get; set; }
        public DateTime? Expiration { get; set; }



    }

   
    public enum PaymentType
    {
        CreditCard,
        DebitCard,
        GiftCard,
        Check,
        Cash,
        Transfer

    }
}
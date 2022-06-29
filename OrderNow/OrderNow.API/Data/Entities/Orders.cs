namespace Data.Entities
{
    public class Orders : EntityBase
    {
        public DateTime OrderDate { get; set; }
        public DateTime? PartialCompletionOrderDate { get; set; }
        public DateTime? CompletionOrderDate { get; set; }
        public OrderStatus OrderStatus { get; set; } = OrderStatus.Waiting;
        public int TableNro { get; set; } = 0;
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal DiscountsAmount { get; set; }
        public PaymentMethods? PaymentMethod { get; set; }
        public Businesses Business { get; set; }
        public Users? User { get; set; }
        public OrdersDetail? Details { get; set; }


    }

    public enum OrderStatus
    {
        Waiting = 1,
        Processing = 2,
        Partial = 3,
        Completed = 4,
        Canceled = 5
    }
}
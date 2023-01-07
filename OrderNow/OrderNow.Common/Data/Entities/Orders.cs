namespace OrderNow.Common.Data.Entities
{
    public class Orders : EntityBase
    {
        public DateTime OrderDate { get; set; }
        public DateTime? PartialCompletionOrderDate { get; set; }
        public DateTime? CompletionOrderDate { get; set; }
        [Display(Name = "Estado")]
        public OrderStatus OrderStatus { get; set; } = OrderStatus.Waiting;
        public int TableNro { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal DiscountsAmount { get; set; }

        public PaymentMethods? PaymentMethod { get; set; }
        public PaymentStatus? PaymentStatus { get; set; }
        public Businesses Business { get; set; }
        public Users? User { get; set; }
        public List<OrderItem>? Items { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9\s*]*$", ErrorMessage = "Only Alphabets and Numbers are allowed.")]
        public string? Comments { get; set; }
        public Users? ModifiedBy { get; set; }

      

   
    }


    public enum PaymentStatus
    {
        Pending =0,
        FullyPayed =1,
        Partial=2,

    }

    public enum OrderStatus
    {
        [Display(Name = "Sin asignar")]
        NotAssigned = 0,
        [Display(Name = "En espera")]
        Waiting = 1,
        [Display(Name = "En proceso")]
        Processing = 2,
        [Display(Name = "Entrega parcial")]
        PartiallyDelivered = 3,
        [Display(Name = "Completado")]
        Completed = 4,
        [Display(Name = "Cancelado")]
        Canceled = 5
    }

    


}
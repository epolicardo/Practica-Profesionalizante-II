namespace OrderNow.Common.Data.Entities
{
    public class Person : EntityBase
    {
        [Display(Name = "Nombre")]
        [MaxLength(50)]
        public string? FirstName { get; set; }

        [Display(Name = "Apellido")]
        [MaxLength(50)]
        public string? LastName { get; set; }

        [Display(Name = "Domicilio")]
        [MaxLength(150)]
        public Address? Address { get; set; }

       
        [Display(Name = "Fecha Nacimiento")]
        public DateTime? BirthDate { get; set; }
    }
}
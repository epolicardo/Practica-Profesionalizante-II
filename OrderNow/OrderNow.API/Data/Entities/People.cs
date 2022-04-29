﻿
using Microsoft.AspNetCore.Identity;

namespace OrderNow.API.Data.Entities
{
    public abstract class People : IdentityUser
    {
        [Display(Name = "Nombre")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Display(Name = "Apellido")]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Display(Name = "Celular")]
        [MaxLength(14)]
        public string CellPhone { get; set; }

        [Display(Name = "Domicilio")]
        [MaxLength(150)]
        public Addresses Address { get; set; }
        [Required]

        [Display(Name = "Fecha Nacimiento")]
        public DateTime BirthDate { get; set; }

       

    }
}
using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    /// <summary>
    /// Entidad Categoria. Representa una categoria de los gastos
    /// </summary>
    public class Categories : EntityBase
    {
        [Display(Name = "Nombre")]
        public string? Name { get; set; }

    }
}

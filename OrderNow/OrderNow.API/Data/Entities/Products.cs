using Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public class Products : EntityBase
    {

        public string? Code { get; set; }
        public string? EAN { get; set; }
        public string? Name { get; set; }
        [MaxLength(40)]
        public string? LegalName { get; set; }//RAID MPyG 390cm3
        public string? Description { get; set; }
        public string? URLImage { get; set; } //Imagen grande
        public string? URLIcon { get; set; } //Imagen Chica
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; } = 0;
        
        public float Stock { get; set; }
        public bool Status { get; set; } //Activo-Inactivo
        //public Businesses Business { get; set; }
        public List<ProductOptions>? OptionsList { get; set; }
        public float Score { get; set; }
        public UInt64 Qualification { get; set; }

        public string? Brand { get; set; } //Raid
        //public bool? IsItExpires { get; set; } //True 
        //public UnidadMedida UnidadMedida { get; set; }
        //public Familia Familia { get; set; }
        //public double StockActual { get; set; }
        //public double StockMinimo { get; set; }
        //public double StockOptimo { get; set; }
        //public decimal PrecioVenta { get; set; }
        //public decimal UltimoPrecioCompra { get; set; }
        //public int ListaPrecio { get; set; }
        //public Color Color { get; set; }
        //public Size Size { get; set; }
       

    }


}

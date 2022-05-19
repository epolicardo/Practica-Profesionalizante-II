using System.ComponentModel;

namespace Data.Entities
{
    public class Cuenta : EntityBase
    {
        [DisplayName("Nombre Cuenta")]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double SaldoInicial { get; set; }
        public double SaldoActual { get; set; }
        public bool Activa { get; set; }
#nullable enable
        public TipoMoneda? Moneda { get; set; }
        public TipoCuenta? TipoCuenta { get; set; }
        public Cuenta? Padre { get; set; }
        public Businesses? Institucion { get; set; }
    }


    public class TipoCuenta : EntityBase
    {
#nullable disable
        public string Nombre { get; set; }
        public string Icono { get; set; }
    }

    public class TipoMoneda : EntityBase
    {
        public string Nombre { get; set; }
        public string Simbolo { get; set; }
        public double Equivalencia { get; set; }

    };
}

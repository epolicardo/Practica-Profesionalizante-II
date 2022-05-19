
namespace Data.Entities
{
    public class Contacto : EntityBase
    {
        public TipoContacto Tipo { get; set; } // Telefono - Correo - Celular - Linkedin
        public string Dato { get; set; } //3513416192 - emilianopolicardo@gmail.com - 353464981435 - linkedin.com/epolicardo
    }


    public enum TipoContacto
    {
        Telefono = 1,
        Correo = 2,
        Celular = 3,
        RedSocial = 4

    }
}
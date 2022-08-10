namespace Configuration
{
    public interface IConfigurationHelper
    {
        /// <summary>
        /// Permite la utilizacion de Datos Ficticios para pruebas de desarrollo
        /// </summary>
        /// <param name="Servicio">El servicio a validar en MockUp</param>
        /// <returns>Verdadero si tanto el servicio como el Ambiente estan iguales</returns>
        bool UseMockup(string Servicio);

        string UrlServicio();
    }
}
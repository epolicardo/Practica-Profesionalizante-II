namespace Configuration
{
    public class ConfigurationHelper : IConfigurationHelper
    {
        private readonly ILogger _log;

        public string UrlServicio()
        {
            return System.Configuration.ConfigurationManager.AppSettings.Get("OrderNow.API");
        }

        public bool UseMockup(string Servicio)
        {
            try
            {
                if (System.Configuration.ConfigurationManager.AppSettings.Get(Servicio) == System.Configuration.ConfigurationManager.AppSettings.Get("AmbienteMockup")
                    && System.Configuration.ConfigurationManager.AppSettings.Get("AmbienteMockup") == "true")
                    return true;
            }
            catch (Exception ex)
            {
                _log.LogError(ex, "No se encontró clave de Debug");
            }
            return false;
        }

        //public void mockupXML(string FileName)
        //{
        //    XmlSalida = new XmlDocument();
        //    XmlSalida.Load(Path.Combine(ObtenerPath() + "/DEBUG", FileName));
        //}
        //public void mockupJson(string FileName)
        //{
        //    XmlSalida = new XmlDocument();
        //    XmlSalida.Load(Path.Combine(ObtenerPath() + "/DEBUG", FileName));
        //}
    }
}
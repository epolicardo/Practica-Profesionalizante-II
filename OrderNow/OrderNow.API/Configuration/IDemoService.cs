namespace Configuration
{
    public interface IDemoService
    {
        void RunDemoTask();
    }

    public class DemoService : IDemoService
    {
        public void RunDemoTask()
        {
            Console.WriteLine(value: "Este es un task en Configuracion/IDemoService");
        }
    }
}
namespace Controllers
{
    public interface IEmailSender
    {

        void SendEmail(string emailto, string emailfrom, string subject, string body);
    }
}
namespace Configuration
{
    public class JwtBearerTokenSettings
    {
        public const string SectionName = "JwtBearerTokenSettings";
        public string SecretKey { get; set; }
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int ExpiryTimeInMinutes { get; set; }
    }
}
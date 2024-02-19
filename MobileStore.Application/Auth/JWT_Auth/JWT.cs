

namespace MobileStore.Application.Auth.JWT_Auth
{
    public class JWT
    {
        public string secretKey { get; set; }
        public string issuer { get; set; }
        public string audience { get; set; }
        public bool Enable { get; set; }
        public double expiryMinutes { get; set; }


    }
}

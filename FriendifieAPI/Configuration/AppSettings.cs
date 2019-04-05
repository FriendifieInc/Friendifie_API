namespace FriendifieAPI.Configuration
{
    public class AppSettings
    {
        public string DbCon { get; set; }
        public string AuthSigningKey { get; set; }
        public string UserClaim { get; set; }
        public string UserClaimValue { get; set; }
        public string AuthAudience { get; set; }
        public string JwtExpiry { get; set; }
    }
}
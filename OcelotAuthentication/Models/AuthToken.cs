namespace OcelotAuthentication.Models
{
    public class AuthToken(string Token, int Expiry)
    {
        public  string Token { get; set; } = Token;
        public int Expiry { get; set; } = Expiry;
    }
}

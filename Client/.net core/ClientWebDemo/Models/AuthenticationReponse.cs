namespace Demo.Models
{
    public class AuthenticationReponse
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string JwtToken { get; set; }
        public int ExpiresIn { get; set; }
    }
}

using CaseEntity;

namespace CaseAPI.Models
{
    public class AuthResponse : RequestReponse
    {
       
        public User User { get; set; }
        public string Token { get; set; }
    }
}

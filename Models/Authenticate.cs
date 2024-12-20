using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models
{
    public class AuthenticateRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
    public class AuthenticateResponse
    {
        public int IdUser { get; set; }
        public string EmailUser { get; set; } = null!;
        public string PasswordUser { get; set; } = null!;
        public string NicknameUser { get; set; } = null!;
        public int IdRole { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public bool IsVerified { get; set; }
        public string JwtToken { get; set; }

        [JsonIgnore] // для того, чтобы вернуть токен в качестве куки
        public string RefreshToken { get; set; }
    }
}
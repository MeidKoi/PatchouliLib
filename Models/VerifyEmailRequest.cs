using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class VerifyEmailRequest
    {
        [Required]
        public string Token { get; set; }
    }
}
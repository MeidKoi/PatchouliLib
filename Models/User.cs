namespace Models{
    public class User
    {
        public int IdUser { get; set; }
        public string EmailUser { get; set; } = null!;
        public string PasswordUser { get; set; } = null!;
        public string NicknameUser { get; set; } = null!;
        public int IdRole { get; set; }
        public DateTime CreatedTime { get; set; }
        public int LastUpdateBy { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedTime { get; set; }


        //Поля для JWT

        public bool AcceptTerms { get; set; }
        public string? VerificationToken { get; set; }
        public DateTime? Verified { get; set; }
        public bool IsVerified => Verified.HasValue || PasswordReset.HasValue;
        public string? ResetToken { get; set; }
        public DateTime? ResetTokenExpires { get; set; }
        public DateTime? PasswordReset { get; set; }
        //public DateTime Created {get; set;}
        public DateTime? Updated { get; set; }
    }
}
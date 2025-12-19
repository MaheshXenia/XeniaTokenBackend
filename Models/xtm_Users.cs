using System.ComponentModel.DataAnnotations;

namespace XeniaTokenBackend.Models
{
    public class xtm_Users
    {
        [Key]
        public int UserID { get; set; }

        public int CompanyID { get; set; }

        public required string Username { get; set; }

        public required string Password { get; set; }

        public bool TokenResetAllowed { get; set; }

        public string? UserType { get; set; }

        public bool Status { get; set; }
    }
}

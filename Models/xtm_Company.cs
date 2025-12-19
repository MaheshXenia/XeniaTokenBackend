using System.ComponentModel.DataAnnotations;

namespace XeniaTokenBackend.Models
{
    public class xtm_Company
    {
        [Key]
        public int CompanyID { get; set; }

        [Required]
        [MaxLength(200)]
        public string CompanyName { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? LicenseKey { get; set; }

        public bool Status { get; set; }

        [MaxLength(100)]
        public string? Country { get; set; }

        [MaxLength(500)]
        public string? Address { get; set; }

        [MaxLength(200)]
        public string? Email { get; set; }

        public DateTime? Validity { get; set; }

        public bool IsExpired { get; set; }
    }
}

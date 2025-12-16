using System.ComponentModel.DataAnnotations;

namespace XeniaTokenApi.Models
{
    public class xtm_TokenRegister
    {
        [Key]
        public int TokenID { get; set; } 
        public int CompanyID { get; set; }
        public int DepID { get; set; }
        public string? DepPrefix { get; set; }
        public int? ServiceID { get; set; }
        public int? CounterID { get; set; }
        public int? CustomerID { get; set; }
        public int CreatedUserID { get; set; }
        public required string CreatedSource { get; set; }
        public DateTime CreatedDate { get; set; }
        public int TokenValue { get; set; }
        public required string TokenStatus { get; set; }
        public DateTime StatusModifiedDate { get; set; }
        public int StatusModifiedUser { get; set; }
        public bool IsAnnounced { get; set; }
        public bool TokenActive { get; set; }

    }
}

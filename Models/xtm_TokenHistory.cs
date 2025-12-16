using System.ComponentModel.DataAnnotations;

namespace XeniaTokenApi.Models
{
    public class xtm_TokenHistory
    {
        [Key]
        public int TokenHistoryID { get; set; }
        public int TokenID { get; set; }
        public int TokenValue { get; set; }
        public int CompanyID { get; set; }
        public required string DepPrefix { get; set; }
        public int DepFrom { get; set; }
        public int DepTo { get; set; }
        public int? ServiceID { get; set; }
        public int? CustomerID { get; set; }  
        public int? CounterID { get; set; }  
        public required string CreatedSource { get; set; }
        public required string TokenStatus { get; set; }
        public DateTime StatusCreatedDate { get; set; }
        public int StatusCreatedUser { get; set; }
    }
}

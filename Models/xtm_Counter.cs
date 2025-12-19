using System.ComponentModel.DataAnnotations;

namespace XeniaTokenBackend.Models
{
    public class xtm_Counter
    {
        [Key]
        public int CounterID { get; set; }
        public int CompanyID { get; set; }
        public int DepID { get; set; }
        public required string CounterName { get; set; }
        public bool Status { get; set; }
    }
}

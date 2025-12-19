using System.ComponentModel.DataAnnotations;

namespace XeniaTokenBackend.Models
{
    public class xtm_Service
    {
        [Key]
        public int SerID { get; set; }
        public int SerCompanyID { get; set; }
        public int SerDepID { get; set; }
        public required string SerName { get; set; }
        public bool SerStatus { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace XeniaTokenBackend.Models
{
    public class xtm_UserMap
    {
        [Key]
        public int UserMapID { get; set; }
        public int DepID { get; set; }
        public int UserID { get; set; }
        public bool Status { get; set; }
    }
}

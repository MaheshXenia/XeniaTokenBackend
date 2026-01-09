using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XeniaTokenBackend.Models
{
    [Table("xtm_Advertisement", Schema = "dbo")]
    public class xtm_Advertisement
    {
        [Key]
        public int AdvID { get; set; }

        public int CompanyID { get; set; }

        public int DepID { get; set; }

        [Required]
        public string AdvName { get; set; }

        public int AdvOrder { get; set; }

        public string AdvFileUrl { get; set; }

        public DateTime AdvModifiedDate { get; set; }

        public int AdvModifiedUserID { get; set; }

        [Required]
        [MaxLength(50)] 
        public bool Status { get; set; }
    }
}

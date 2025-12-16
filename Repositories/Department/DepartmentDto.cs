using XeniaTokenApi.Models;

namespace XeniaTokenApi.Repositories.Department
{
    public class DepartmentDto
    {
        public int DepID { get; set; }
        public string DepName { get; set; }
        public int CompanyID { get; set; }
        public string DepPrefix { get; set; }
        public DateTime? DepExpire { get; set; }
        public bool Status { get; set; }

        public int MaxToken { get; set; }
        public int PrintTokenValue { get; set; }
        public List<xtm_Counter> Counters { get; set; } = new();
    }
}

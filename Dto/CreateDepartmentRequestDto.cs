namespace XeniaTokenBackend.Dto
{
    public class CreateDepartmentRequestDto
    {
        public int CompanyID { get; set; }
        public string DepName { get; set; }
        public string? DepPrefix { get; set; }
        public int MaximumToken { get; set; }
        public bool Status { get; set; }
    }

}

namespace XeniaTokenBackend.Dto
{
    public class UserWithDepartmentsDto
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string UserType { get; set; }
        public bool TokenResetAllowed { get; set; }
        public bool Status { get; set; }
        public List<UserDepartmentDto> Departments { get; set; } = new();
    }
    public class UserDepartmentDto
    {
        public int DepID { get; set; }
        public string DepName { get; set; }
        public bool Status { get; set; }
    }

}

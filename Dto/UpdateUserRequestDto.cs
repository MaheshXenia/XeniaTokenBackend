namespace XeniaTokenBackend.Dto
{
    public class UpdateUserRequestDto
    {
        public int CompanyID { get; set; }
        public string Username { get; set; }
        public bool TokenResetAllowed { get; set; }
        public string UserType { get; set; }
        public bool Status { get; set; }
        public string? Password { get; set; }
    }

}

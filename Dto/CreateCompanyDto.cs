namespace XeniaTokenBackend.Dto
{
    public class CreateCompanyDto
    {
        public string CompanyName { get; set; }
        public string LicenseKey { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string DepPrefix { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

}

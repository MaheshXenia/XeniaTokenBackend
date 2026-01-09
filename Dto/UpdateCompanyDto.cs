namespace XeniaTokenBackend.Dto
{
    public class UpdateCompanyDto
    {
        public string CompanyName { get; set; }
        public string LicenseKey { get; set; }
        public bool Status { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public bool IsExpired { get; set; }
    }

}

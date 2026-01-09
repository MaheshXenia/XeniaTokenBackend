namespace XeniaTokenBackend.Dto
{
    public class LoginRequestDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class LoginResponseDto
    {
        public string Status { get; set; }
        public string? Message { get; set; }
        public string? Token { get; set; }
    }
}

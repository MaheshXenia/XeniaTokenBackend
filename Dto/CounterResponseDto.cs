namespace XeniaTokenBackend.Dto
{
    public class CounterResponseDto
    {
        public int CounterID { get; set; }
        public int CompanyID { get; set; }
        public int DepID { get; set; }
        public string CounterName { get; set; }
        public bool Status { get; set; }
        public string DepName { get; set; }
    }

}

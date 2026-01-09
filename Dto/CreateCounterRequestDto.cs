namespace XeniaTokenBackend.Dto
{
    public class CreateCounterRequestDto
    {
        public int CompanyID { get; set; }
        public int DepID { get; set; }
        public string CounterName { get; set; }
        public bool Status { get; set; } 
    }

}

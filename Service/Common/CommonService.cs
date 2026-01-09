namespace XeniaTokenBackend.Service.Common
{
    public class CommonService
    {
        public DateTime CalculateValidityDate()
        {
            return DateTime.UtcNow.AddDays(14);
        }

        public static DateTime FormatDateToLocalTime(DateTime? date = null)
        {
            return (date ?? DateTime.UtcNow).Date;
        }


        public static string ConvertTo12HourFormat(string dateTimeString)
        {
            var utcTime = DateTime.Parse(dateTimeString).ToUniversalTime();
            return utcTime.ToString("h:mm tt");
        }


    }
}

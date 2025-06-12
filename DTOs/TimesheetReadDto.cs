namespace EffortTracker.DTOs
{
    public class TimesheetReadDto
    {
        public int timesheet_id { get; set; }
        public DateOnly date { get; set; }
        public int associate_id { get; set; }
        public int application_id { get; set; }
        public int task_id { get; set; }
        public decimal hours { get; set; }
        public string comments { get; set; }
        public string status { get; set; }
    }
}

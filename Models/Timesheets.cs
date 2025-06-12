using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EffortTracker.Models
{
    public class Timesheets
    {
        [Key]
        public int timesheet_id { get; set; }
        [Required]
        public DateOnly date { get; set; }
        [Required]
        [ForeignKey("associate_id")]
        public int associate_id { get; set; }
        [Required]
        [ForeignKey("application_id")]
        public int application_id { get; set; }
        [Required]
        [ForeignKey("task_id")]
        public int task_id { get; set; }
        [Required]
        [Range(0, 9)]
        public decimal hours { get; set; }
        [Required]
        public string comments { get; set; }
        public string status { get; set; } // Pending, Approved, Rejected

    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EffortTracker.Models
{
    public class Tasks
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int task_id { get; set; }

        [Required]
        public string task_name { get; set; }

        [StringLength(500)]
        public string description { get; set; }
    }
}

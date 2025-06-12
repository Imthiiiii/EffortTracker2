using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EffortTracker.Models
{
    public class Applications
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int application_id { get; set; }


        [Required]
        [StringLength(100)]

        public string name { get; set; }

        [StringLength(500)]
        public string description { get; set; }

        [Required]
        [StringLength(100)]

        public string client_name { get; set; }
    }
}

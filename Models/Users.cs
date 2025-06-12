using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EffortTracker.Models
{
    public class Users
    {
        [Key]
        [ForeignKey("associate_id")]
        public int associate_id { get; set; } // Foreign key to Associates table

        [Required]
        public string password { get; set; }

       
        [Required]
        public string role { get; set; } // Admin, Associate, Manager





    }
}

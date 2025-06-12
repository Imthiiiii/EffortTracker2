using System.ComponentModel.DataAnnotations;

namespace EffortTracker.Models
{
    public class Associates
    {

        [Key]
        public int associate_id { get; set; }

        [Required]
        public string name { get; set; }

        [EmailAddress]
        public string email { get; set; }

        [Required]
        public string department { get; set; }




    }
}

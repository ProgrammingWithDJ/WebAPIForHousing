using System.ComponentModel.DataAnnotations;

namespace WebAPIForHousing.Models
{
    public class USer
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace WebAPIForHousing.Dtos
{
    public class CityDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Name is mandatory field")]
        [StringLength(10, MinimumLength =2)]
        public string Name { get; set; }

        [Required]
        public string Country{ get; set; }
    }
}

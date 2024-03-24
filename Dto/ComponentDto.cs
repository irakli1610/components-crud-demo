using System.ComponentModel.DataAnnotations;

namespace JunkWebApi.Dto
{
    public class ComponentDto
    {
        [Required]
        public string Name { get; set; } 

        [Required]
        public string Status { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }
    }
}

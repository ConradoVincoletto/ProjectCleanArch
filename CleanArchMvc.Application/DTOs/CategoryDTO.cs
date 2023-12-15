using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CleanArchMcv.Application.DTOs
{
    public record CategoryDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="The name is required")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string? Name { get; set; }
    }
}
